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
    public partial class Form_QuickBooking : Form
    {
        DateTime nowDateTime = new DateTime();

        Booking exist = null;

        public Form_QuickBooking()
        {
            InitializeComponent();
        }

        private void Form_QuickBooking_Load(object sender, EventArgs e)
        {
            exist = Checker.user_current_booking_check();
            if (exist == null)
            { // 小于30分钟 从前一个整点开始，大于30分钟从上一个整半点开始 计算时间
                nowDateTime = DateTime.Now;
                int nowHour = nowDateTime.Hour;
                int nowMinute = nowDateTime.Minute;
                if (nowMinute < 30)
                {
                    this.comboBox1.Items.Add((nowHour + 1) + ":" + "00");
                    this.comboBox1.Items.Add((nowHour + 1) + ":" + "30");
                    this.comboBox1.Items.Add((nowHour + 2) + ":" + "00");
                    this.comboBox1.Items.Add((nowHour + 2) + ":" + "30");
                    // 默认选择
                    this.comboBox1.Text = (nowHour + 1) + ":" + "00";
                }
                else
                {
                    this.comboBox1.Items.Add((nowHour + 1) + ":" + "30");
                    this.comboBox1.Items.Add((nowHour + 2) + ":" + "00");
                    this.comboBox1.Items.Add((nowHour + 2) + ":" + "30");
                    this.comboBox1.Items.Add((nowHour + 3) + ":" + "00");
                    // 默认选择
                    this.comboBox1.Text = (nowHour + 1) + ":" + "30";
                }
            }
            else
            {
                // 存在普通预订信息，追加时间向后延迟，30分钟为基数
                nowDateTime = exist.BookEnd.AddHours(0);
                DateTime obj = nowDateTime.AddMinutes(30);
                string defaultObj = obj.Hour + ":" + ( obj.Minute == 0 ? "0" + obj.Minute : obj.Minute + "");
                this.comboBox1.Items.Add(defaultObj);
                obj = obj.AddMinutes(30);
                this.comboBox1.Items.Add(obj.Hour + ":" + (obj.Minute == 0 ? "0" + obj.Minute : obj.Minute + ""));
                obj = obj.AddMinutes(30);
                this.comboBox1.Items.Add(obj.Hour + ":" + (obj.Minute == 0 ? "0" + obj.Minute : obj.Minute + ""));
                obj = obj.AddMinutes(30);
                this.comboBox1.Items.Add(obj.Hour + ":" + (obj.Minute == 0 ? "0" + obj.Minute : obj.Minute + ""));
                // 默认选择
                this.comboBox1.Text = defaultObj;
            }

        }

        private void button_quickbooking_cancel_Click(object sender, EventArgs e)
        {//取消quick booking
            // 重新检查用户时间有没有到,时间到了或者没有预定则弹警告框之后强制Log off
            if (!Checker.user_check_remian())
            {
                Util.logoff();
            }
            this.Close();
        }

        private void button_quickbooking_confirm_Click(object sender, EventArgs e)
        {
            // 重新检查用户时间有没有到,时间到了或者没有预定则弹警告框之后强制Log of
            // 通过接口向服务器发送quick booking请求,若成功,弹框提示用户成功
            string endTimeStr = this.comboBox1.Text;
            string[] strs = endTimeStr.Split(new char[] { ':' });
            int endTimeHour = int.Parse(strs[0]);
            int endTimeMit = int.Parse(strs[1]);
            Booking book;
            DateTime now; // 追加预订信息的开始时间
            if (exist == null)
            {
                book = new Booking();
                book.UserName = Util.getUserName();
                // 没有普通预定信息时，默认为快速预定book
                book.BookType = 1;
                if (nowDateTime.Minute < 30 )
                { // 小于30分钟 从前一个整点开始  计算时间
                    now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, nowDateTime.Hour,0,0);
                }
                else
                {// 大于30分钟从上一个整半点开始
                    now = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, nowDateTime.Hour, 30, 0);
                }
                book.Description = "NewQuickBooking";
                book.Remarks = DateTime.Now.ToString();
            }
            else
            {
                book = exist;
                book.BookType = exist.Id;
                // 时间环境  虚拟机时间和服务器时间相差2小时-------------------
                now = exist.BookEnd.AddHours(-2);
                book.Description = "ExtentTime";
                book.Remarks = "";
            }            
            book.BookStart = now;

            string agname = System.Environment.MachineName;

            // book.AgentName = "AVC123456789"; // TODO  机器代号字符串
            book.AgentName = agname;

            // 下拉选中的结束时间
            book.BookEnd = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, endTimeHour, endTimeMit, 0) ;
            try
            {
                string books = "";
                if (book.Description == "NewQuickBooking")
                {
                    books = PortalServer.user_quick_booking(book);
                }
                else
                {
                    books = PortalServer.user_extent_booking(book);
                }
                if (books == "true")
                {
                    this.Close();
                    MessageBox.Show("Success", "Info");
                    // 快速预定成功后 刷新对应的book信息
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Util.write_log(ex + "");
                throw;
            }
                       
        }

        private void quick_book_hour10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
