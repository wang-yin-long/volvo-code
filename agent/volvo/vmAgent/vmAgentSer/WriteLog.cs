using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace vmAgentSer
{
    class WriteLog
    {
        public static string vmAgentSerLog_path = "c:\\ucp\\ucpAgentSer.log";
        public static void write(string log)
        {
            FileStream fs = new FileStream(vmAgentSerLog_path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("<upcAgentSer>:  " + DateTime.Now.ToString() + "  >  " + log + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();

            //TODO:优先级低:检查log文件大小,太大则删除一些
        }
    }
}
