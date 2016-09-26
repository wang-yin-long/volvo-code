namespace vmAgent
{
    partial class PortalAgent
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortalAgent));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistPortalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_current_book = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_remaining_time = new System.Windows.Forms.Label();
            this.button_cancel_booking = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_booking = new System.Windows.Forms.TabPage();
            this.button_goto_portal = new System.Windows.Forms.Button();
            this.button_exten_time = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_user_name = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage_status = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label_portal_connect = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_booking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "vmAgent Deamon";
            this.notifyIcon1.BalloonTipTitle = "vmAgent";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "vmAgent";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.vistPortalToolStripMenuItem,
            this.logOffToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showToolStripMenuItem.Text = "Show Window";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // vistPortalToolStripMenuItem
            // 
            this.vistPortalToolStripMenuItem.Name = "vistPortalToolStripMenuItem";
            this.vistPortalToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.vistPortalToolStripMenuItem.Text = "Go To Portal";
            this.vistPortalToolStripMenuItem.Click += new System.EventHandler(this.vistPortalToolStripMenuItem_Click);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.logOffToolStripMenuItem.Text = "Log Off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // label_current_book
            // 
            this.label_current_book.AutoSize = true;
            this.label_current_book.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_current_book.Location = new System.Drawing.Point(110, 126);
            this.label_current_book.Name = "label_current_book";
            this.label_current_book.Size = new System.Drawing.Size(112, 21);
            this.label_current_book.TabIndex = 1;
            this.label_current_book.Text = "00:00 ~ 00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Booking ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(106, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remaining Time";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_remaining_time
            // 
            this.label_remaining_time.AutoSize = true;
            this.label_remaining_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_remaining_time.ForeColor = System.Drawing.Color.Brown;
            this.label_remaining_time.Location = new System.Drawing.Point(119, 198);
            this.label_remaining_time.Name = "label_remaining_time";
            this.label_remaining_time.Size = new System.Drawing.Size(106, 21);
            this.label_remaining_time.TabIndex = 6;
            this.label_remaining_time.Text = "00h 00m 00s";
            // 
            // button_cancel_booking
            // 
            this.button_cancel_booking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel_booking.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel_booking.ForeColor = System.Drawing.Color.DarkRed;
            this.button_cancel_booking.Location = new System.Drawing.Point(262, 102);
            this.button_cancel_booking.Name = "button_cancel_booking";
            this.button_cancel_booking.Size = new System.Drawing.Size(147, 44);
            this.button_cancel_booking.TabIndex = 7;
            this.button_cancel_booking.Text = "Cancel  Booking";
            this.button_cancel_booking.UseVisualStyleBackColor = true;
            this.button_cancel_booking.Click += new System.EventHandler(this.button_cancel_booking_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_booking);
            this.tabControl1.Controls.Add(this.tabPage_status);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 260);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_booking
            // 
            this.tabPage_booking.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_booking.Controls.Add(this.button_goto_portal);
            this.tabPage_booking.Controls.Add(this.button_exten_time);
            this.tabPage_booking.Controls.Add(this.pictureBox3);
            this.tabPage_booking.Controls.Add(this.pictureBox2);
            this.tabPage_booking.Controls.Add(this.pictureBox1);
            this.tabPage_booking.Controls.Add(this.label_user_name);
            this.tabPage_booking.Controls.Add(this.button_cancel_booking);
            this.tabPage_booking.Controls.Add(this.label_current_book);
            this.tabPage_booking.Controls.Add(this.label_remaining_time);
            this.tabPage_booking.Controls.Add(this.label3);
            this.tabPage_booking.Controls.Add(this.label1);
            this.tabPage_booking.Controls.Add(this.groupBox1);
            this.tabPage_booking.Controls.Add(this.groupBox2);
            this.tabPage_booking.Location = new System.Drawing.Point(4, 22);
            this.tabPage_booking.Name = "tabPage_booking";
            this.tabPage_booking.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_booking.Size = new System.Drawing.Size(437, 234);
            this.tabPage_booking.TabIndex = 0;
            this.tabPage_booking.Text = "Booking";
            // 
            // button_goto_portal
            // 
            this.button_goto_portal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_goto_portal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_goto_portal.Location = new System.Drawing.Point(262, 24);
            this.button_goto_portal.Name = "button_goto_portal";
            this.button_goto_portal.Size = new System.Drawing.Size(147, 44);
            this.button_goto_portal.TabIndex = 15;
            this.button_goto_portal.Text = "Go to Portal";
            this.button_goto_portal.UseVisualStyleBackColor = true;
            this.button_goto_portal.Click += new System.EventHandler(this.button_goto_portal_Click);
            // 
            // button_exten_time
            // 
            this.button_exten_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exten_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_exten_time.Location = new System.Drawing.Point(262, 173);
            this.button_exten_time.Name = "button_exten_time";
            this.button_exten_time.Size = new System.Drawing.Size(147, 44);
            this.button_exten_time.TabIndex = 14;
            this.button_exten_time.Text = "Extend Time";
            this.button_exten_time.UseVisualStyleBackColor = true;
            this.button_exten_time.Click += new System.EventHandler(this.button_exten_time_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::vmAgent.Properties.Resources.volvo_time22;
            this.pictureBox3.Location = new System.Drawing.Point(24, 166);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 59);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(24, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label_user_name
            // 
            this.label_user_name.AutoSize = true;
            this.label_user_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_user_name.ForeColor = System.Drawing.Color.Black;
            this.label_user_name.Location = new System.Drawing.Point(110, 37);
            this.label_user_name.Name = "label_user_name";
            this.label_user_name.Size = new System.Drawing.Size(49, 22);
            this.label_user_name.TabIndex = 10;
            this.label_user_name.Text = "John";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 78);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 154);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // tabPage_status
            // 
            this.tabPage_status.Controls.Add(this.pictureBox4);
            this.tabPage_status.Controls.Add(this.label_portal_connect);
            this.tabPage_status.Controls.Add(this.label5);
            this.tabPage_status.Controls.Add(this.groupBox3);
            this.tabPage_status.Location = new System.Drawing.Point(4, 22);
            this.tabPage_status.Name = "tabPage_status";
            this.tabPage_status.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_status.Size = new System.Drawing.Size(437, 234);
            this.tabPage_status.TabIndex = 1;
            this.tabPage_status.Text = "Status";
            this.tabPage_status.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::vmAgent.Properties.Resources.volvo_portal;
            this.pictureBox4.Location = new System.Drawing.Point(22, 25);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 59);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // label_portal_connect
            // 
            this.label_portal_connect.AutoSize = true;
            this.label_portal_connect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_portal_connect.ForeColor = System.Drawing.Color.DarkRed;
            this.label_portal_connect.Location = new System.Drawing.Point(106, 56);
            this.label_portal_connect.Name = "label_portal_connect";
            this.label_portal_connect.Size = new System.Drawing.Size(105, 21);
            this.label_portal_connect.TabIndex = 1;
            this.label_portal_connect.Text = "Disonnected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Portal Server";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(11, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 78);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 30000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PortalAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 261);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortalAgent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal Agent";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vmAgent_FormClosing);
            this.Load += new System.EventHandler(this.vmAgent_Load);
            this.Shown += new System.EventHandler(this.vmAgent_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_booking.ResumeLayout(false);
            this.tabPage_booking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage_status.ResumeLayout(false);
            this.tabPage_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vistPortalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.Label label_current_book;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_remaining_time;
        private System.Windows.Forms.Button button_cancel_booking;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_booking;
        private System.Windows.Forms.TabPage tabPage_status;
        private System.Windows.Forms.Label label_portal_connect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_user_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_exten_time;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_goto_portal;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

