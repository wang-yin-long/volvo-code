using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace vmAgentSer
{

    class RunAsUser
    {
        #region 获取/复制用户令牌，启动进程
        internal const int GENERIC_ALL_ACCESS = 0x10000000; //访问权限

        [StructLayout(LayoutKind.Sequential)]
        public struct StartUpInfo
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Process_Information
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 dwProcessID;
            public Int32 dwThreadID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SecurityAttributes
        {
            public Int32 Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        public enum SecurityImpersonationLevel
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        public enum TokenType
        {
            TokenPrimary = 1,
            TokenImpersonation
        }

        [DllImport("advapi32", SetLastError = true)]
        public static extern bool OpenProcessToken(IntPtr processHandle, TokenAccessLevels desiredAccess, ref IntPtr htok);

        [DllImport("advapi32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CreateProcessAsUser(
            IntPtr hToken,
            string lpApplicationName,
            string lpCommandLine,
            ref SecurityAttributes lpProcessAttributes,
            ref SecurityAttributes lpThreadAttributes,
            bool bInheritHandle,
            Int32 dwCreationFlags,
            IntPtr lpEnvrionment,
            string lpCurrentDirectory,
            ref StartUpInfo lpStartupInfo,
            ref Process_Information lpProcessInformation);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool DuplicateTokenEx(
            IntPtr hExistingToken,
            Int32 dwDesiredAccess,
            ref SecurityAttributes lpThreadAttributes,
            Int32 ImpersonationLevel,
            Int32 dwTokenType,
            ref IntPtr phNewToken);

        [DllImport("userenv.dll", SetLastError = true)]
        public static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

        [DllImport("kernel32.dll")]
        public static extern int WTSGetActiveConsoleSessionId();

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion        

        #region 模拟用户进程
        /// <summary>
        /// 调用方必须具备System权限
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="appFullName"></param>
        /// <param name="args"></param>
        public static void CreateProcess(int sessionId, string appFullName, string args)
        {
            //mcj;多用户登陆时，以当前活动用户启动可以用WTSGetActiveConsoleSessionId();取得作为第一个参数
            if (0 == sessionId)
            {
                sessionId =  WTSGetActiveConsoleSessionId();
            }
                

            if (!System.IO.File.Exists(appFullName))
            {
                throw new System.IO.FileNotFoundException(appFullName);
            }
            bool sucess = false;
            IntPtr hToken = IntPtr.Zero, hDupedToken = IntPtr.Zero;
            Process_Information pi = new Process_Information();
            SecurityAttributes sa;
            try
            {
                //服务程序中，通过桌面进程的SessionId来获得
                Process explorer = null;
                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    if (process.SessionId == sessionId)
                    {
                        explorer = process;
                        break;
                    }
                }
                if (explorer == null)
                {
                    TraceWin32Error("There has no Explorer process running yet!");
                    return;
                }
                Process.EnterDebugMode();
                sucess = OpenProcessToken(explorer.Handle, TokenAccessLevels.Duplicate | TokenAccessLevels.Read | TokenAccessLevels.Impersonate, ref hToken);
                if (!sucess)
                {
                    TraceWin32Error("OpenProcessToken");
                    return;
                }
                sa = new SecurityAttributes();
                sa.Length = Marshal.SizeOf(sa);
                var si = new StartUpInfo();
                si.cb = Marshal.SizeOf(si);
                sucess = DuplicateTokenEx(
                        hToken,
                        GENERIC_ALL_ACCESS,
                        ref sa,
                        (int)SecurityImpersonationLevel.SecurityIdentification,
                        (int)TokenType.TokenPrimary,
                        ref hDupedToken
                );
                if (!sucess)
                {
                    TraceWin32Error("DuplicateTokenEx");
                    return;
                }
                IntPtr lpEnvironment = IntPtr.Zero;
                sucess = CreateEnvironmentBlock(out lpEnvironment, hDupedToken, false);
                if (!sucess)
                {
                    TraceWin32Error("CreateEnvironmentBlock");
                    return;
                }
                sucess = CreateProcessAsUser(
                    hDupedToken,
                    appFullName,
                    args,
                    ref sa, ref sa,
                    false, 0, IntPtr.Zero,
                    null,
                    ref si,
                    ref pi
                );
                if (!sucess)
                {
                    TraceWin32Error("CreateProcessAsUser");
                }
            }
            finally
            {
                if (hDupedToken != IntPtr.Zero) CloseHandle(hDupedToken);
                if (pi.hProcess != IntPtr.Zero) CloseHandle(pi.hProcess);
                if (pi.hThread != IntPtr.Zero) CloseHandle(pi.hThread);
                Process.LeaveDebugMode();
            }
        }

        static void TraceWin32Error(string error)
        {
            WriteLog.write("RunAsUser:TraceWin32Error,Last Error Code:" + error + Marshal.GetLastWin32Error().ToString());
        }
        #endregion
    }

}


