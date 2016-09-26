namespace vmAgent
{
    partial class Form_QuickBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QuickBooking));
            this.button_quickbooking_confirm = new System.Windows.Forms.Button();
            this.button_quickbooking_cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_quickbooking_confirm
            // 
            this.button_quickbooking_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_quickbooking_confirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_quickbooking_confirm.ForeColor = System.Drawing.Color.DarkRed;
            this.button_quickbooking_confirm.Location = new System.Drawing.Point(35, 141);
            this.button_quickbooking_confirm.Name = "button_quickbooking_confirm";
            this.button_quickbooking_confirm.Size = new System.Drawing.Size(111, 44);
            this.button_quickbooking_confirm.TabIndex = 16;
            this.button_quickbooking_confirm.Text = "Confirm";
            this.button_quickbooking_confirm.UseVisualStyleBackColor = true;
            this.button_quickbooking_confirm.Click += new System.EventHandler(this.button_quickbooking_confirm_Click);
            // 
            // button_quickbooking_cancel
            // 
            this.button_quickbooking_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_quickbooking_cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_quickbooking_cancel.Location = new System.Drawing.Point(156, 141);
            this.button_quickbooking_cancel.Name = "button_quickbooking_cancel";
            this.button_quickbooking_cancel.Size = new System.Drawing.Size(111, 44);
            this.button_quickbooking_cancel.TabIndex = 17;
            this.button_quickbooking_cancel.Text = "Cancel";
            this.button_quickbooking_cancel.UseVisualStyleBackColor = true;
            this.button_quickbooking_cancel.Click += new System.EventHandler(this.button_quickbooking_cancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::vmAgent.Properties.Resources.volvo_booking2;
            this.pictureBox1.Location = new System.Drawing.Point(46, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "End Time";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 28);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form_QuickBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(296, 249);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_quickbooking_cancel);
            this.Controls.Add(this.button_quickbooking_confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_QuickBooking";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extend Time";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_QuickBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_quickbooking_confirm;
        private System.Windows.Forms.Button button_quickbooking_cancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}