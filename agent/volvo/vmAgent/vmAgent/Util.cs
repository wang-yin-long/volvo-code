using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace vmAgent
{
    class Util//一些工具类/功能类的函数放在这里
    {
        public static string vmAgentSerLog_path = "c:\\ucp\\ucpAgent.log";

        // public static string SERVER_IP = "192.168.1.103:3000";
        public static string SERVER_IP = AppConfig.GetAppConfig("ServerIP");

        public static void write_log(string log)
        {
            FileStream fs = new FileStream(vmAgentSerLog_path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("<upcAgent>:  " + DateTime.Now.ToString() + "  >  " + log + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();

            //TODO:优先级低:检查log文件大小,太大则删除一些
        }

       

        public static void logoff()
        {
            System.Diagnostics.Process.Start("logoff");
        }


        public static string getUserName()
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

        public static void goToPortal()
        {
            string url = "http://" + AppConfig.GetAppConfig("ServerIP");
            System.Diagnostics.Process.Start("explorer.exe",url);
        }

        public static string utilPost(string postURl, string jsonParas)
        {
            string strURL = "http://" + postURl;

            //创建一个HTTP请求  
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/x-www-form-urlencoded";

            //设置参数，并进行URL编码  
            //虽然我们需要传递给服务器端的实际参数是JsonParas(格式：[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}])，
            //但是需要将该字符串参数构造成键值对的形式（注："paramaters=[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}]"），
            //其中键paramaters为WebService接口函数的参数名，值为经过序列化的Json数据字符串
            //最后将字符串参数进行Url编码
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode("paramaters");
            paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode(jsonParas);

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;
            //发送请求，获得请求流  

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("----------------- Connect Server Error -----------------");
            }
            //将请求参数写入流
            if (writer == null) {
                return null;
            }
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
                response = ex.Response as System.Net.HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader reader = new StreamReader(s, Encoding.UTF8);
            strValue = reader.ReadToEnd();
          
            return strValue;//返回Json数据
        }


    }
}
