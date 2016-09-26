using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace vmAgent
{
    class PortalServer//与poratl server的通信在这个类
    {
        public static void json_call_to_server(string json)//json通信
        {
            string server_ip = AppConfig.GetAppConfig("ServerIP");
            // 与portal server的json通信
        }


        public static string get_user_booking()//获取当前用户预定时间、存在则发送agent启动通知
        {
            string user_name = Util.getUserName();

            Booking condi = new Booking();

            // 2016-08-03 用户名相关的操作全部改为大写形式
            condi.UserName = user_name.ToUpper();

            string agname = System.Environment.MachineName;
            condi.AgentName = agname;
            // condi.AgentName = "AVC123456789"; // TODO  机器代号字符串

            Console.WriteLine("****************" + agname);

            // 根据用户查询服务器转 booking 返回当前时间的一个booking对象，当前时间没有预定则为null 
            string books = Util.utilPost(Util.SERVER_IP +"/getuserbooks", JsonConvert.SerializeObject(condi));
            return books;
        }

        public static string user_quick_booking(Booking book)//quick booking接口
        {
            // 2016-08-03 用户名相关的操作全部改为大写形式
            book.UserName = book.UserName.ToUpper();

            string user_name = Util.getUserName();
            // 新增一个quick booking与当前预订时间连接
            return Util.utilPost(Util.SERVER_IP + "/addQuickBook", JsonConvert.SerializeObject(book));
             
        }

        public static string user_extent_booking(Booking book)//Extent booking接口
        {
            // 2016-08-03 用户名相关的操作全部改为大写形式
            book.UserName = book.UserName.ToUpper();

            string user_name = Util.getUserName();
            // 新增一个quick booking与当前预订时间连接
            return Util.utilPost(Util.SERVER_IP + "/addExtentTime", JsonConvert.SerializeObject(book));

        }

        public static void user_login_event()
        {
            string user_name = Util.getUserName();
           
        }

        public static string user_logoff_event(Booking userbook)//agent关闭通知
        {
            // 2016-08-03 用户名相关的操作全部改为大写形式
            userbook.UserName = userbook.UserName.ToUpper();

            string user_name = Util.getUserName();
            return Util.utilPost(Util.SERVER_IP + "/agentLoginOff", JsonConvert.SerializeObject(userbook));

        }

        public static string user_force_logoff(Booking userbook)//agent关闭通知
        {
            // 2016-08-03 用户名相关的操作全部改为大写形式
            userbook.UserName = userbook.UserName.ToUpper();

            string user_name = Util.getUserName();
            return Util.utilPost(Util.SERVER_IP + "/forceLoginOff", JsonConvert.SerializeObject(userbook));

        }

        // 心跳通信，统计用户使用时间
        public static string heart_beat_service(Booking book)//agent关闭通知
        {
            string user_name = Util.getUserName();

            Booking back = new Booking();
            back.Id = book.Id;
            back.BookType = book.BookType;
            back.UserId = book.UserId;
            back.UserName = book.UserName.ToUpper();
            back.BookStart = book.BookStart.AddHours(-2);
            back.BookEnd = book.BookEnd.AddHours(-2);
            back.BookRegion = book.BookRegion;
            back.BookPool = book.BookPool;
            back.BookGroup = book.BookGroup;
            back.AgentName = book.AgentName;
            back.Status = book.Status;
            back.Description = book.Description;
            back.Remarks = book.Remarks;
           
            return Util.utilPost(Util.SERVER_IP + "/userHeartBeat", JsonConvert.SerializeObject(back));

        }

        public static void user_heart_beat_event()
        {
            string user_name = Util.getUserName();

        }


        //TODO:更多具体的通信接口
    }
}
