
namespace LanApp8_2
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
            this.grConnection = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbUseSSL = new System.Windows.Forms.CheckBox();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grMessage = new System.Windows.Forms.GroupBox();
            this.edMessageText = new System.Windows.Forms.RichTextBox();
            this.edSubject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.grConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPort)).BeginInit();
            this.grMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grConnection
            // 
            this.grConnection.Controls.Add(this.btnSend);
            this.grConnection.Controls.Add(this.cbUseSSL);
            this.grConnection.Controls.Add(this.edPassword);
            this.grConnection.Controls.Add(this.label4);
            this.grConnection.Controls.Add(this.edUser);
            this.grConnection.Controls.Add(this.label3);
            this.grConnection.Controls.Add(this.edPort);
            this.grConnection.Controls.Add(this.label2);
            this.grConnection.Controls.Add(this.edHost);
            this.grConnection.Controls.Add(this.label1);
            this.grConnection.Location = new System.Drawing.Point(12, 12);
            this.grConnection.Name = "grConnection";
            this.grConnection.Size = new System.Drawing.Size(529, 95);
            this.grConnection.TabIndex = 10;
            this.grConnection.TabStop = false;
            this.grConnection.Text = "Connection";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(437, 54);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbUseSSL
            // 
            this.cbUseSSL.AutoSize = true;
            this.cbUseSSL.Checked = true;
            this.cbUseSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseSSL.Location = new System.Drawing.Point(437, 32);
            this.cbUseSSL.Name = "cbUseSSL";
            this.cbUseSSL.Size = new System.Drawing.Size(68, 17);
            this.cbUseSSL.TabIndex = 18;
            this.cbUseSSL.Text = "Use SSL";
            this.cbUseSSL.UseVisualStyleBackColor = true;
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(287, 56);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(134, 20);
            this.edPassword.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password";
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(287, 30);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(134, 20);
            this.edUser.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Username";
            // 
            // edPort
            // 
            this.edPort.Location = new System.Drawing.Point(50, 57);
            this.edPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.edPort.Name = "edPort";
            this.edPort.Size = new System.Drawing.Size(112, 20);
            this.edPort.TabIndex = 13;
            this.edPort.Value = new decimal(new int[] {
            465,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // edHost
            // 
            this.edHost.Location = new System.Drawing.Point(50, 30);
            this.edHost.Name = "edHost";
            this.edHost.Size = new System.Drawing.Size(163, 20);
            this.edHost.TabIndex = 11;
            this.edHost.Text = "smtp.gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Host";
            // 
            // grMessage
            // 
            this.grMessage.Controls.Add(this.button2);
            this.grMessage.Controls.Add(this.button1);
            this.grMessage.Controls.Add(this.edFile);
            this.grMessage.Controls.Add(this.label8);
            this.grMessage.Controls.Add(this.edMessageText);
            this.grMessage.Controls.Add(this.edSubject);
            this.grMessage.Controls.Add(this.label7);
            this.grMessage.Controls.Add(this.edTo);
            this.grMessage.Controls.Add(this.label6);
            this.grMessage.Controls.Add(this.edFrom);
            this.grMessage.Controls.Add(this.label5);
            this.grMessage.Location = new System.Drawing.Point(12, 113);
            this.grMessage.Name = "grMessage";
            this.grMessage.Size = new System.Drawing.Size(529, 303);
            this.grMessage.TabIndex = 11;
            this.grMessage.TabStop = false;
            this.grMessage.Text = "Message";
            // 
            // edMessageText
            // 
            this.edMessageText.Location = new System.Drawing.Point(18, 75);
            this.edMessageText.Name = "edMessageText";
            this.edMessageText.Size = new System.Drawing.Size(494, 192);
            this.edMessageText.TabIndex = 18;
            this.edMessageText.Text = "";
            // 
            // edSubject
            // 
            this.edSubject.Location = new System.Drawing.Point(66, 49);
            this.edSubject.Name = "edSubject";
            this.edSubject.Size = new System.Drawing.Size(446, 20);
            this.edSubject.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Subject";
            // 
            // edTo
            // 
            this.edTo.Location = new System.Drawing.Point(325, 23);
            this.edTo.Name = "edTo";
            this.edTo.Size = new System.Drawing.Size(187, 20);
            this.edTo.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "To";
            // 
            // edFrom
            // 
            this.edFrom.Location = new System.Drawing.Point(66, 23);
            this.edFrom.Name = "edFrom";
            this.edFrom.Size = new System.Drawing.Size(202, 20);
            this.edFrom.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "File";
            // 
            // edFile
            // 
            this.edFile.Location = new System.Drawing.Point(52, 275);
            this.edFile.Name = "edFile";
            this.edFile.ReadOnly = true;
            this.edFile.Size = new System.Drawing.Size(293, 20);
            this.edFile.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 428);
            this.Controls.Add(this.grMessage);
            this.Controls.Add(this.grConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP Test";
            this.grConnection.ResumeLayout(false);
            this.grConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPort)).EndInit();
            this.grMessage.ResumeLayout(false);
            this.grMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grConnection;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox cbUseSSL;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown edPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grMessage;
        private System.Windows.Forms.RichTextBox edMessageText;
        private System.Windows.Forms.TextBox edSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

