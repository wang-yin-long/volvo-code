using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Threading;

namespace vmAgentSer
{
    public partial class vmAgentService : ServiceBase
    {

        string vmAgent_path = "c:\\ucp\\ucpAgent.exe";
        

        public vmAgentService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            WriteLog.write(" service start!");

            //获取系统注销,关机,登录
            //Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(this.OnSessionEnding);


            System.Timers.Timer t = new System.Timers.Timer();//定时器  
            t.Interval = 5000;//设置定时器时间间隔为5000毫秒  
            t.Elapsed += new System.Timers.ElapsedEventHandler(check_service);//到达时间的时候执行事件（每隔5秒）      
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；      
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        protected override void OnStop()
        {
            WriteLog.write(" service stop!");
        }

        protected override void OnPause()
        {
            //服务暂停执行代码
            base.OnPause();
            WriteLog.write(" service Pause!");
        }
        protected override void OnContinue()
        {
            //服务恢复执行代码
            base.OnContinue();
            WriteLog.write(" service Continue!");
        }


        public void check_service(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(this.vmAgent_path);// fileName.Replace(ext, "");
                if (!this.IsExistProcess(fileName))
                {
                    //this.StartProgram(this.vmAgent_path);
                    RunAsUser.CreateProcess(0, this.vmAgent_path, "");
                }
            }
            catch (Exception err)
            {
                WriteLog.write("check_service err:"+err.Message);
            }
        }

        public string GetUserName()
        {
            try
            {
                return System.Environment.UserName;
            }
            catch (Exception e)
            {
                return "";
            }
        }
/*
        成员名称 说明
 ConsoleConnect 控制台会话已连接。 
 ConsoleDisconnect 控制台会话已断开连接。 
 RemoteConnect 远程会话已连接。 
 RemoteDisconnect 远程会话已断开连接。 
 SessionLogon 用户已登录到会话。 
 SessionLogoff 用户已从会话注销。 
 SessionLock 会话已被锁定。 
 SessionUnlock 会话已被解除锁定。 
 SessionRemoteControl 会话的远程控制状态已更改。 
 */
        /// <summary>
        /// 不再触发些函数，因为：base.CanHandleSessionChangeEvent = false;
        /// </summary>
        /// <param name="changeDescription"></param>
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            try
            {

                switch (changeDescription.Reason)
                {
                    case SessionChangeReason.SessionLogon://用户登录
                        WriteLog.write("OnSessionChange <SessionLogon> <UserName>:" + this.GetUserName());
                        //this.check_service(null, null);
                        break;
                    case SessionChangeReason.SessionLogoff://用户登出
                        WriteLog.write("OnSessionChange <SessionLogoff> <UserName>:" + this.GetUserName());
                        //
                        break;
                    case SessionChangeReason.RemoteConnect:
                    case SessionChangeReason.RemoteDisconnect:
                    case SessionChangeReason.SessionLock:
                    case SessionChangeReason.SessionUnlock:
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                WriteLog.write("OnSessionChange Error:" + ex.Message + "/r/n" + ex.StackTrace);
            }
        }


        /// <summary>
        /// 检查该进程是否已启动
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        private bool IsExistProcess(string processName)
        {

            Process[] MyProcesses = Process.GetProcesses();
            foreach (Process MyProcess in MyProcesses)
            {
                if (MyProcess.ProcessName.CompareTo(processName) == 0)
                {
                    return true;

                }
            }
            return false;
        }

    }
}
