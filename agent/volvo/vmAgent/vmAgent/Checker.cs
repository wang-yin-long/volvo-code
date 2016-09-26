using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace vmAgent
{
    class Checker//agent的定时检查,预定校验逻辑等,在这里实现
    {
        private static Booking bookLogin = null;

        private static Boolean daojishi = false;
        private static Boolean tishi = false;
        private static Boolean tishi2 = false;

        private static TimeSpan timeRemain = new TimeSpan();

        public PortalAgent agentForm { get; set; }

        //检查用户当前时间是否有预定
        public static Booking user_current_booking_check()
        {
            try
            {
                string infos = PortalServer.get_user_booking();
                daojishi = false; // 倒计时窗口弹出一次
                tishi = false; // 10分钟提示弹出一次
                tishi2 = false;// 5分钟提示弹出一次
                if (infos == null || infos == "")
                {
                    return null;
                }
                else
                {
                    Booking book = JsonConvert.DeserializeObject<Booking>(infos);
                    bookLogin = book;
                    // Console.WriteLine(book);
                    // 与server通信取得用户预定数据之后,与现有数据做对比,返回 null 或 booking
                    return book;
                }
            }
            catch (Exception e)
            {
                Util.write_log(e + "");
                return null;
                throw;
            }

        }

        //每个30秒 更新  检查用户当前时间是否有预定
        public static Booking user_update_booking_check()
        {
            try
            {
                string infos = PortalServer.get_user_booking();
                if (infos == null || infos == "")
                {
                    return null;
                }
                else
                {
                    Booking book = JsonConvert.DeserializeObject<Booking>(infos);
                    bookLogin = book;
                    // Console.WriteLine(book);
                    // 与server通信取得用户预定数据之后,与现有数据做对比,返回 null 或 booking
                    return book;
                }
            }
            catch (Exception e)
            {
                Util.write_log(e + "");
                return null;
                throw;
            }

        }


        //启动agent的例行检查程序
        public static void start_checker()
        {
            int checkInterval = 30000;
            int serverHeartBeat = 60000;
            //agent默认会有两个时钟现成一致在跑
            //一个是检查用户剩余时间
            //另一个是与服务器的心跳通信
            try
            {
                checkInterval = int.Parse(AppConfig.GetAppConfig("CheckInterval"));
                serverHeartBeat = int.Parse(AppConfig.GetAppConfig("AgentHeartBeat"));
            }
            catch (Exception e)
            {
                Util.write_log(e + "");
                throw;
            }
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = checkInterval; //  剩余10分钟  和剩余5分钟 弹窗提示 用户检查时间间隔:AppConfig.GetAppConfig("CheckInterval");
            t.Elapsed += new System.Timers.ElapsedEventHandler(user_check_service);      
            t.AutoReset = true;    
            t.Enabled = true;

            System.Timers.Timer t1 = new System.Timers.Timer();
            t1.Interval = 5000; //  剩余时间少于1分钟，弹出不可关闭的倒计时窗口
            t1.Elapsed += new System.Timers.ElapsedEventHandler(user_check_remain_service);
            t1.AutoReset = true;
            t1.Enabled = true;

            System.Timers.Timer t2 = new System.Timers.Timer();
            t2.Interval = serverHeartBeat; //心跳通信间隔: AppConfig.GetAppConfig("ServerHeartBeat"); 默认1分钟
            t2.Elapsed += new System.Timers.ElapsedEventHandler(server_heart_beat);
            t2.AutoReset = true;
            t2.Enabled = true; 

        }

        // 剩余时间少于1分钟，弹出不可关闭的倒计时窗口
        public static void user_check_remain_service(object source, System.Timers.ElapsedEventArgs e)
        {//每隔一段时间
            try
            {
                // 当前时间有预定,检查剩余预定时间,时间不足则通知用户
                DateTime start = bookLogin.BookStart;
                DateTime end = bookLogin.BookEnd;
                TimeSpan span = end - DateTime.Now;
                timeRemain = span;
                if (span.TotalSeconds > 0)
                {
                    // Console.WriteLine("span.TotalSeconds : " + span.TotalSeconds);
                    if (span.TotalSeconds >= 60 && span.TotalSeconds < 70 && !daojishi) // 剩余时间小于1分钟 提示
                    {
                        daojishi = true; // 倒计时窗口弹出一次
                        TimeCountDown frmShowWarning = new TimeCountDown(end);//Form1为要弹出的窗体（提示框），
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height - frmShowWarning.Height);
                        frmShowWarning.PointToScreen(p);
                        frmShowWarning.Location = p;
                        frmShowWarning.ShowDialog();
                    }
                }
                else
                {
                    // 通知服务器取消、agent下线,强制关闭  add by wyl
                    string back = PortalServer.user_force_logoff(bookLogin);
                    Util.logoff();
                }
            }
            catch (Exception ex)
            {
                Util.write_log(ex + "");
                throw;
            }
        }

        //用户检查时间间隔 剩余10分钟  和剩余5分钟 弹窗提示
        public static void user_check_service(object source, System.Timers.ElapsedEventArgs e)
        {//每隔一段时间
            // Util.write_log("******************************  SRART");
            try
            {
                double showRemainWarn = double.Parse(AppConfig.GetAppConfig("ShowRemainWarning"));
                // 当前时间有预定,检查剩余预定时间,时间不足则通知用户
                DateTime start = bookLogin.BookStart;
                DateTime end = bookLogin.BookEnd;
                TimeSpan span = end - DateTime.Now;
                timeRemain = span;
                if (span.TotalSeconds > 0)
                {
                    if ((span.TotalMinutes >= 10 && span.TotalMinutes < 12) && !tishi) // 剩余时间10分钟 提示
                    {
                        tishi = true; // 10分钟提示弹出一次
                        string remain = span + "";
                        string str = remain.Substring(0, remain.LastIndexOf("."));
                        string[] strs = str.Split(new char[] { ':' });
                        int mm = System.Int32.Parse(strs[1]);
                        string timeInfo = mm + " Minutes ";  // 剩余时间 时 分 秒                                                                                            // Console.WriteLine(timeInfo);
                        RemainingTime frmShowWarning = new RemainingTime(timeInfo);//Form1为要弹出的窗体（提示框），
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height - frmShowWarning.Height);
                        Util.write_log("**********" + p.ToString());
                        frmShowWarning.PointToScreen(p);
                        frmShowWarning.Location = p;
                        Util.write_log("**********" + frmShowWarning.Location.ToString());
                        frmShowWarning.ShowDialog();
                        Util.write_log("*********  END ***");
                    }

                    if ((span.TotalMinutes >= 5 && span.TotalMinutes < 7) && !tishi2) // 剩余时间5分钟 提示
                    {
                        tishi2 = true; // 5分钟提示弹出一次
                        string remain = span + "";
                        string str = remain.Substring(0, remain.LastIndexOf("."));
                        string[] strs = str.Split(new char[] { ':' });
                        int mm = System.Int32.Parse(strs[1]);
                        string timeInfo = mm + " Minutes ";  // 剩余时间 时 分 秒                                                                                            // Console.WriteLine(timeInfo);
                        RemainingTime frmShowWarning = new RemainingTime(timeInfo);//Form1为要弹出的窗体（提示框），
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height - frmShowWarning.Height);
                        Util.write_log("**********" + p.ToString());
                        frmShowWarning.PointToScreen(p);
                        frmShowWarning.Location = p;
                        Util.write_log("**********" + frmShowWarning.Location.ToString());
                        frmShowWarning.ShowDialog();
                        Util.write_log("*********  END ***");
                    }
                }
                else
                {
                    // 通知服务器取消、agent下线,强制关闭  add by wyl
                    string back = PortalServer.user_force_logoff(bookLogin);
                    Util.logoff();
                }  
            }
            catch (Exception ex)
            {
                Util.write_log(ex + "");
                throw;
            }
        }

        public static Boolean user_check_remian()
        {
            Boolean flg = true;
            if (bookLogin == null)
            {
                flg = false;
            }
            else
            {
                // 当前时间有预定,检查剩余预定时间,时间不足则通知用户
                DateTime start = bookLogin.BookStart;
                DateTime end = bookLogin.BookEnd;
                TimeSpan span = end - DateTime.Now;
                if (span.TotalSeconds > 0)
                {
                    flg = true;
                }
                else
                {
                    flg = false;
                }
            }
            return flg;      
        }

        // 与服务器的心跳通信,累加用户使用时间
        public static void server_heart_beat(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // 与服务器的心跳通信 统计用户使用时间
                string back = PortalServer.heart_beat_service(bookLogin);

            }
            catch (Exception ex)
            {
                Util.write_log(ex + "");
                throw;
            }
        }
    }
}
