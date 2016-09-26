using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace vmAgent
{
    public partial class PortalAgent : Form
    {
        private Booking userbook = null;

        public static PortalAgent agent = null;

        public PortalAgent()
        {
            InitializeComponent();
            agent = this;
            Control.CheckForIllegalCrossThreadCalls = false;
            //  检查预订时间在后台是否被修改的间隔时间
            this.timer2.Interval =Convert.ToInt32(AppConfig.GetAppConfig("CheckBookUpdated"));
        }

        private void vmAgent_Shown(object sender, EventArgs e)
        {//窗体初始化显示之后,agent的运行从这里开始  add by wyl

            this.label_user_name.Text = Util.getUserName();//获取当前用户名
            this.Visible = false;//程序启动时隐藏在托盘
            this.WindowState = FormWindowState.Minimized;
            Util.write_log("----------------- Portal Agent Start ----------------------");

            Booking book = Checker.user_current_booking_check();
            if (book != null)
            {
                // 登录用户的预定信息
                userbook = book;
                this.Set_Form_Info(book);
                //启动agent的例行检查程序、agent默认会有两个时钟现成一致在跑、一个是检查用户剩余时间、另一个是与服务器的心跳通信
                Checker.start_checker();
            }
            else//当前没预定
            {
                // 当前没预定的情况下,直接弹出quick booking窗口  add by wyl
                Form_QuickBooking form_quick_booking = new Form_QuickBooking();
                form_quick_booking.ShowDialog();
                if (form_quick_booking.DialogResult == DialogResult.OK)
                {
                    this.label_user_name.Text = Util.getUserName();//获取当前用户名
                    Booking one = Checker.user_current_booking_check();
                    if (one != null)
                    {                 
                        userbook = one;
                        this.Set_Form_Info(one);
                        Checker.start_checker();
                    }
                }
                // form_quick_booking.Show();
            }

        }

        // 绑定信息到窗体上  add by wyl
        public void Set_Form_Info(Booking book)
        {
            if (book != null)
            {
                userbook = book;
                // 当前时间有预定,
                DateTime start = book.BookStart;
                DateTime end = book.BookEnd;
                // 更新Form1主窗体上的当前预定时间信息 /剩余时间信息/服务器连接状态
                string sHour = start.Hour < 10 ? "0" + start.Hour : start.Hour + "";
                string sMinite = start.Minute < 10 ? "0" + start.Minute : start.Minute + "";
                string eHour = end.Hour < 10 ? "0" + end.Hour : end.Hour + "";
                string eMinite = end.Minute < 10 ? "0" + end.Minute : end.Minute + "";
                label_current_book.Text = sHour + ":" + sMinite + " ~ " + eHour + ":" + eMinite; //预定时间段

                TimeSpan remainSpan = end - DateTime.Now;
                if (remainSpan.TotalSeconds <= 0)
                {
                    // 倒计时结束 强制注销
                    Console.WriteLine("倒计时结束 强制注销");
                    string books = "";
                    try
                    {
                        books = PortalServer.user_logoff_event(userbook);
                    }
                    catch (Exception ex)
                    {
                        Util.write_log(ex + "");
                        throw;
                    }
                    if (books == "true")
                    {
                        Console.WriteLine("Agent Login Off");
                        Util.logoff();
                    }

                }
                else
                {
                    string remain = remainSpan + "";
                    string str = remain.Substring(0, remain.LastIndexOf("."));
                    string[] strs = str.Split(new char[] { ':' });
                    label_remaining_time.Text = strs[0] + "h " + strs[1] + "m " + strs[2] + "s";  // 剩余时间 时 分 秒
                }

                label_portal_connect.Text = "Connected"; // 服务器连接状态
                label_portal_connect.ForeColor = Color.Green;
            }
        }

        private void vmAgent_FormClosing(object sender, FormClosingEventArgs e)
        {//点击关闭窗口按钮的时候，不要真的关闭，而是隐藏到托盘
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击显示、隐藏窗口
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //单击同样显示、隐藏窗口
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.logoff();
        }

        private void vmAgent_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //切换table
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.label_user_name.Text = Util.getUserName();
            }
            else
            {

            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }


        private void vistPortalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.goToPortal();
        }

        // 取消当前 用户预订信息
        private void button_cancel_booking_Click(object sender, EventArgs e)
        {
            // 设置该 booking信息 在服务器中的状态 下线 add by wyl
            DialogResult confirm = MessageBox.Show("Do you want to Cancel Current Booking? \t\n" +
                   " If yes, will Log Off immediately.\t\n Please be sure that your work has been Saved.",
                   "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string books = "";
                try
                {
                    // 预订信息 状态修改为 login off 状态  add by wyl
                    // 通知服务器取消、agent下线,并注明是用户手动取消  add by wyl
                    books = PortalServer.user_logoff_event(userbook);
                }
                catch (Exception ex)
                {
                    Util.write_log(ex + "");
                    throw;
                }
                if (books == "true")
                {
                    Console.WriteLine("Agent Login Off");
                    Util.logoff(); 
                }

            }          
        }

        private void button_goto_portal_Click(object sender, EventArgs e)
        {
            Util.goToPortal();
        }

        // 点击Extent Time按钮 打开quickbooking 窗体
        private void button_exten_time_Click(object sender, EventArgs e)
        {
            Form_QuickBooking form_quickbooking = new Form_QuickBooking();
            form_quickbooking.ShowDialog();
            if (form_quickbooking.DialogResult == DialogResult.OK)
            {
                this.label_user_name.Text = Util.getUserName();//获取当前用户名
                Booking book = Checker.user_current_booking_check();
                if (book != null)
                {
                    userbook = book;
                    this.Set_Form_Info(book);
                    Checker.start_checker();
                }
            }
            // form_quickbooking.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Console.WriteLine("...vmAgent Info Refresh...");
            this.Set_Form_Info(userbook);      
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("*******************" + this.timer2.Interval);
            this.label_user_name.Text = Util.getUserName();//获取当前用户名
            Util.write_log("----------------- Portal Agent Refresh  ----------------------");
            this.Visible = false;//隐藏在托盘
            this.WindowState = FormWindowState.Minimized;

            Booking book = Checker.user_update_booking_check();
            if (book != null)
            {
                // 登录用户的预定信息
                userbook = book;
                Console.WriteLine(book);
                this.Set_Form_Info(book);
             }
            else//当前没预定
            {
                // 当前没预定的情况下,直接弹出quick booking窗口  add by wyl
                Form_QuickBooking form_quick_booking = new Form_QuickBooking();
                form_quick_booking.ShowDialog();
                if (form_quick_booking.DialogResult == DialogResult.OK)
                {
                    this.label_user_name.Text = Util.getUserName();//获取当前用户名
                    Booking one = Checker.user_current_booking_check();
                    if (one != null)
                    {
                        userbook = one;
                        this.Set_Form_Info(one);
                        Checker.start_checker();
                    }
                }
                // form_quick_booking.Show();
            }
        }
    }
}
