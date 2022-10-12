
namespace LanApp5_1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grUserinfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edLocalPort = new System.Windows.Forms.NumericUpDown();
            this.edRemotePort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edRemoteIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edUsername = new System.Windows.Forms.TextBox();
            this.lsbMessages = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edMessage = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grUserinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLocalPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRemotePort)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grUserinfo
            // 
            this.grUserinfo.Controls.Add(this.btnStart);
            this.grUserinfo.Controls.Add(this.edUsername);
            this.grUserinfo.Controls.Add(this.label3);
            this.grUserinfo.Controls.Add(this.label4);
            this.grUserinfo.Controls.Add(this.edRemoteIp);
            this.grUserinfo.Controls.Add(this.edRemotePort);
            this.grUserinfo.Controls.Add(this.label2);
            this.grUserinfo.Controls.Add(this.edLocalPort);
            this.grUserinfo.Controls.Add(this.label1);
            this.grUserinfo.Location = new System.Drawing.Point(12, 12);
            this.grUserinfo.Name = "grUserinfo";
            this.grUserinfo.Size = new System.Drawing.Size(444, 99);
            this.grUserinfo.TabIndex = 0;
            this.grUserinfo.TabStop = false;
            this.grUserinfo.Text = "Userinfo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local port";
            // 
            // edLocalPort
            // 
            this.edLocalPort.Location = new System.Drawing.Point(86, 24);
            this.edLocalPort.Maximum = new decimal(new int[] {
            655535,
            0,
            0,
            0});
            this.edLocalPort.Name = "edLocalPort";
            this.edLocalPort.Size = new System.Drawing.Size(62, 20);
            this.edLocalPort.TabIndex = 1;
            this.edLocalPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // edRemotePort
            // 
            this.edRemotePort.Location = new System.Drawing.Point(86, 62);
            this.edRemotePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.edRemotePort.Name = "edRemotePort";
            this.edRemotePort.Size = new System.Drawing.Size(62, 20);
            this.edRemotePort.TabIndex = 3;
            this.edRemotePort.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Remote port";
            // 
            // edRemoteIp
            // 
            this.edRemoteIp.Location = new System.Drawing.Point(222, 26);
            this.edRemoteIp.Name = "edRemoteIp";
            this.edRemoteIp.Size = new System.Drawing.Size(115, 20);
            this.edRemoteIp.TabIndex = 4;
            this.edRemoteIp.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remote IP";
            // 
            // edUsername
            // 
            this.edUsername.Location = new System.Drawing.Point(222, 61);
            this.edUsername.Name = "edUsername";
            this.edUsername.Size = new System.Drawing.Size(115, 20);
            this.edUsername.TabIndex = 7;
            this.edUsername.Text = "user";
            // 
            // lsbMessages
            // 
            this.lsbMessages.FormattingEnabled = true;
            this.lsbMessages.Location = new System.Drawing.Point(12, 119);
            this.lsbMessages.Name = "lsbMessages";
            this.lsbMessages.Size = new System.Drawing.Size(444, 225);
            this.lsbMessages.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendFile);
            this.groupBox1.Controls.Add(this.btnSendText);
            this.groupBox1.Controls.Add(this.edMessage);
            this.groupBox1.Location = new System.Drawing.Point(12, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message";
            // 
            // edMessage
            // 
            this.edMessage.Location = new System.Drawing.Point(6, 21);
            this.edMessage.Name = "edMessage";
            this.edMessage.Size = new System.Drawing.Size(250, 20);
            this.edMessage.TabIndex = 0;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(262, 19);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Text";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(343, 19);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 2;
            this.btnSendFile.Text = "File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.InitialDirectory = "c:";
            // 
            // dlgSave
            // 
            this.dlgSave.InitialDirectory = "c:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(352, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 188);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 417);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbMessages);
            this.Controls.Add(this.grUserinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP Client";
            this.grUserinfo.ResumeLayout(false);
            this.grUserinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLocalPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edRemotePort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grUserinfo;
        private System.Windows.Forms.TextBox edUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edRemoteIp;
        private System.Windows.Forms.NumericUpDown edRemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edLocalPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbMessages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.TextBox edMessage;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

