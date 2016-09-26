using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vmAgent
{// 剩余时间不足1分钟 add by wyl
    public partial class TimeCountDown : Form
    {
        private DateTime endTime = new DateTime();

        public TimeCountDown(DateTime timeInfo)
        {
            InitializeComponent();
            endTime = timeInfo;
            this.TopMost = true;
        }

        private void TimeCountDown_Load(object sender, EventArgs e)
        {
            this.set_info();
        }

        private void set_info()
        {
            TimeSpan remainSpan = endTime - DateTime.Now;
            if (remainSpan.TotalSeconds > 0)
            {
                // 剩余时间不足1分钟  ，倒计时
                string remain = remainSpan + "";
                string str = remain.Substring(0, remain.LastIndexOf("."));
                string[] strs = str.Split(new char[] { ':' });
                string timeInfo = strs[0] + "h " + strs[1] + "m " + strs[2] + "s";  // 剩余时间 时 分 秒                                                                    // Console.WriteLine(timeInfo);
                                                                                    // Console.WriteLine("倒计时 :" + timeInfo);
                this.label1.Text = "Remaining Time :";
                this.label2.Text = timeInfo;
                this.label3.Text = "Please extent time ! \t\n Otherwise it will be forced to logout !";
            }          
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Console.WriteLine("timer1_Tick : 倒计时");
            this.set_info();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_QuickBooking form_quickbooking = new Form_QuickBooking();
            form_quickbooking.ShowDialog();
            if (form_quickbooking.DialogResult == DialogResult.OK)
            {
                Booking book = Checker.user_current_booking_check();
                if (book != null)
                {
                    System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
                    foreach (System.Diagnostics.Process p in ps)
                    {
                        if (p.ProcessName == "ucpAgent-TimeCountDown")
                        {
                            p.Kill();
                        }
                    }
                    this.Close();
                    PortalAgent.agent.Set_Form_Info(book);
                }
            }
        }
    }
}
