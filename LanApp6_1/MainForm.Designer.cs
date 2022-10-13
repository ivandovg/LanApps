
namespace LanApp6_1
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
            this.grSendMessage = new System.Windows.Forms.GroupBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.edMessage = new System.Windows.Forms.TextBox();
            this.lsbMessages = new System.Windows.Forms.ListBox();
            this.grUserinfo = new System.Windows.Forms.GroupBox();
            this.edUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edRemoteIp = new System.Windows.Forms.TextBox();
            this.edLocalPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grSendMessage.SuspendLayout();
            this.grUserinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLocalPort)).BeginInit();
            this.SuspendLayout();
            // 
            // grSendMessage
            // 
            this.grSendMessage.Controls.Add(this.btnSendText);
            this.grSendMessage.Controls.Add(this.edMessage);
            this.grSendMessage.Enabled = false;
            this.grSendMessage.Location = new System.Drawing.Point(12, 350);
            this.grSendMessage.Name = "grSendMessage";
            this.grSendMessage.Size = new System.Drawing.Size(444, 56);
            this.grSendMessage.TabIndex = 5;
            this.grSendMessage.TabStop = false;
            this.grSendMessage.Text = "Message";
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(363, 19);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Send";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // edMessage
            // 
            this.edMessage.Location = new System.Drawing.Point(6, 21);
            this.edMessage.Name = "edMessage";
            this.edMessage.Size = new System.Drawing.Size(351, 20);
            this.edMessage.TabIndex = 0;
            // 
            // lsbMessages
            // 
            this.lsbMessages.FormattingEnabled = true;
            this.lsbMessages.Location = new System.Drawing.Point(12, 106);
            this.lsbMessages.Name = "lsbMessages";
            this.lsbMessages.Size = new System.Drawing.Size(444, 238);
            this.lsbMessages.TabIndex = 4;
            this.lsbMessages.TabStop = false;
            // 
            // grUserinfo
            // 
            this.grUserinfo.Controls.Add(this.edUsername);
            this.grUserinfo.Controls.Add(this.label3);
            this.grUserinfo.Controls.Add(this.label4);
            this.grUserinfo.Controls.Add(this.edRemoteIp);
            this.grUserinfo.Controls.Add(this.edLocalPort);
            this.grUserinfo.Controls.Add(this.label1);
            this.grUserinfo.Location = new System.Drawing.Point(12, 12);
            this.grUserinfo.Name = "grUserinfo";
            this.grUserinfo.Size = new System.Drawing.Size(338, 90);
            this.grUserinfo.TabIndex = 4;
            this.grUserinfo.TabStop = false;
            this.grUserinfo.Text = "Userinfo";
            // 
            // edUsername
            // 
            this.edUsername.Location = new System.Drawing.Point(76, 20);
            this.edUsername.Name = "edUsername";
            this.edUsername.Size = new System.Drawing.Size(115, 20);
            this.edUsername.TabIndex = 0;
            this.edUsername.Text = "user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remote IP";
            // 
            // edRemoteIp
            // 
            this.edRemoteIp.Location = new System.Drawing.Point(213, 56);
            this.edRemoteIp.Name = "edRemoteIp";
            this.edRemoteIp.Size = new System.Drawing.Size(115, 20);
            this.edRemoteIp.TabIndex = 2;
            this.edRemoteIp.Text = "235.10.10.10";
            // 
            // edLocalPort
            // 
            this.edLocalPort.Location = new System.Drawing.Point(77, 54);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(356, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(356, 66);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(93, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 415);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.grSendMessage);
            this.Controls.Add(this.lsbMessages);
            this.Controls.Add(this.grUserinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lan - Test Multicast";
            this.grSendMessage.ResumeLayout(false);
            this.grSendMessage.PerformLayout();
            this.grUserinfo.ResumeLayout(false);
            this.grUserinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLocalPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grSendMessage;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.TextBox edMessage;
        private System.Windows.Forms.ListBox lsbMessages;
        private System.Windows.Forms.GroupBox grUserinfo;
        private System.Windows.Forms.TextBox edUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edRemoteIp;
        private System.Windows.Forms.NumericUpDown edLocalPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

