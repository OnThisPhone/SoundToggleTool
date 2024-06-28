namespace SoundToggleTool
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnClose = new System.Windows.Forms.Button();
            this.ntf = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmbDevices1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDevices2 = new System.Windows.Forms.ComboBox();
            this.lblCurrentDevice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chkDynamicIcon = new System.Windows.Forms.CheckBox();
            this.chkAutoStartWithWindows = new System.Windows.Forms.CheckBox();
            this.btnToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(228, 123);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ntf
            // 
            this.ntf.Icon = ((System.Drawing.Icon)(resources.GetObject("ntf.Icon")));
            this.ntf.Text = "Speakers";
            this.ntf.Visible = true;
            // 
            // cmbDevices1
            // 
            this.cmbDevices1.FormattingEnabled = true;
            this.cmbDevices1.Location = new System.Drawing.Point(10, 25);
            this.cmbDevices1.Name = "cmbDevices1";
            this.cmbDevices1.Size = new System.Drawing.Size(232, 21);
            this.cmbDevices1.TabIndex = 2;
            this.cmbDevices1.SelectedIndexChanged += new System.EventHandler(this.cmbDevices1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // cmbDevices2
            // 
            this.cmbDevices2.FormattingEnabled = true;
            this.cmbDevices2.Location = new System.Drawing.Point(10, 69);
            this.cmbDevices2.Name = "cmbDevices2";
            this.cmbDevices2.Size = new System.Drawing.Size(232, 21);
            this.cmbDevices2.TabIndex = 4;
            this.cmbDevices2.SelectedIndexChanged += new System.EventHandler(this.cmbDevices2_SelectedIndexChanged);
            // 
            // lblCurrentDevice
            // 
            this.lblCurrentDevice.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentDevice.ForeColor = System.Drawing.Color.DimGray;
            this.lblCurrentDevice.Location = new System.Drawing.Point(7, 164);
            this.lblCurrentDevice.Name = "lblCurrentDevice";
            this.lblCurrentDevice.Size = new System.Drawing.Size(244, 20);
            this.lblCurrentDevice.TabIndex = 6;
            this.lblCurrentDevice.Text = "Current Device";
            this.lblCurrentDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(0, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(176, 123);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(46, 32);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SoundToggleTool.Properties.Resources.headset_mic_b;
            this.pictureBox2.Location = new System.Drawing.Point(248, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::SoundToggleTool.Properties.Resources.speaker_b;
            this.pictureBox3.Location = new System.Drawing.Point(248, 67);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // chkDynamicIcon
            // 
            this.chkDynamicIcon.AutoSize = true;
            this.chkDynamicIcon.Checked = global::SoundToggleTool.Properties.Settings.Default.DynamicIcon;
            this.chkDynamicIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDynamicIcon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SoundToggleTool.Properties.Settings.Default, "DynamicIcon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkDynamicIcon.Location = new System.Drawing.Point(10, 116);
            this.chkDynamicIcon.Name = "chkDynamicIcon";
            this.chkDynamicIcon.Size = new System.Drawing.Size(91, 17);
            this.chkDynamicIcon.TabIndex = 11;
            this.chkDynamicIcon.Text = "Dynamic Icon";
            this.chkDynamicIcon.UseVisualStyleBackColor = true;
            this.chkDynamicIcon.CheckedChanged += new System.EventHandler(this.chkDynamicIcon_CheckedChanged);
            // 
            // chkAutoStartWithWindows
            // 
            this.chkAutoStartWithWindows.AutoSize = true;
            this.chkAutoStartWithWindows.Checked = global::SoundToggleTool.Properties.Settings.Default.AutoStartWithWindows;
            this.chkAutoStartWithWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStartWithWindows.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SoundToggleTool.Properties.Settings.Default, "AutoStartWithWindows", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAutoStartWithWindows.Location = new System.Drawing.Point(10, 139);
            this.chkAutoStartWithWindows.Name = "chkAutoStartWithWindows";
            this.chkAutoStartWithWindows.Size = new System.Drawing.Size(138, 17);
            this.chkAutoStartWithWindows.TabIndex = 0;
            this.chkAutoStartWithWindows.Text = "Start app with Windows";
            this.chkAutoStartWithWindows.UseVisualStyleBackColor = true;
            this.chkAutoStartWithWindows.CheckedChanged += new System.EventHandler(this.chkAutoStartWithWindows_CheckedChanged);
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Gainsboro;
            this.btnToggle.BackgroundImage = global::SoundToggleTool.Properties.Resources.change_circle_b;
            this.btnToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Location = new System.Drawing.Point(257, 166);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(26, 18);
            this.btnToggle.TabIndex = 12;
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 184);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.chkDynamicIcon);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblCurrentDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDevices2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDevices1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkAutoStartWithWindows);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoStartWithWindows;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbDevices1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDevices2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox chkDynamicIcon;
        private System.Windows.Forms.Button btnToggle;
        public System.Windows.Forms.NotifyIcon ntf;
        public System.Windows.Forms.Label lblCurrentDevice;
    }
}

