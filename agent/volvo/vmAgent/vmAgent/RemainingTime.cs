using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vmAgent
{ // 剩余时间不足提示 add by wyl
    public partial class RemainingTime : Form
    {
        private string remiantime = "";

        public RemainingTime(string timeInfo)
        {
            InitializeComponent();
            remiantime = timeInfo;
            this.TopMost = true;
        }

        private void vmAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void RemainingTime_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Remaining Time:" + remiantime);
            this.remain_title.Text = "Remaining Time :";
            this.remain_time.Text = remiantime;
            this.remain_warn.Text = "Please extent time ! \t\n Otherwise it will be forced to logout !";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("...Remaining Time Form Close...");
            this.Close();
        }

        private void remain_time_Click(object sender, EventArgs e)
        {

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
                    System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses(System.Environment.MachineName);
                    foreach (System.Diagnostics.Process p in ps)
                    {
                        if (p.ProcessName == "ucpAgent-Warning")
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

