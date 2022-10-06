
namespace LanApp3_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edAddress = new System.Windows.Forms.TextBox();
            this.edPort = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lsbMessages = new System.Windows.Forms.ListBox();
            this.grSendMessage = new System.Windows.Forms.GroupBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.edMessage = new System.Windows.Forms.TextBox();
            this.grConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPort)).BeginInit();
            this.grSendMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grConnection
            // 
            this.grConnection.Controls.Add(this.btnConnect);
            this.grConnection.Controls.Add(this.edPort);
            this.grConnection.Controls.Add(this.edAddress);
            this.grConnection.Controls.Add(this.label2);
            this.grConnection.Controls.Add(this.label1);
            this.grConnection.Location = new System.Drawing.Point(12, 12);
            this.grConnection.Name = "grConnection";
            this.grConnection.Size = new System.Drawing.Size(442, 53);
            this.grConnection.TabIndex = 0;
            this.grConnection.TabStop = false;
            this.grConnection.Text = "Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // edAddress
            // 
            this.edAddress.Location = new System.Drawing.Point(82, 23);
            this.edAddress.Name = "edAddress";
            this.edAddress.Size = new System.Drawing.Size(125, 20);
            this.edAddress.TabIndex = 2;
            this.edAddress.Text = "127.0.0.1";
            // 
            // edPort
            // 
            this.edPort.Location = new System.Drawing.Point(253, 24);
            this.edPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.edPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edPort.Name = "edPort";
            this.edPort.Size = new System.Drawing.Size(82, 20);
            this.edPort.TabIndex = 3;
            this.edPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(341, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lsbMessages
            // 
            this.lsbMessages.FormattingEnabled = true;
            this.lsbMessages.Location = new System.Drawing.Point(12, 69);
            this.lsbMessages.Name = "lsbMessages";
            this.lsbMessages.Size = new System.Drawing.Size(442, 238);
            this.lsbMessages.TabIndex = 1;
            // 
            // grSendMessage
            // 
            this.grSendMessage.Controls.Add(this.btnSendMessage);
            this.grSendMessage.Controls.Add(this.edMessage);
            this.grSendMessage.Enabled = false;
            this.grSendMessage.Location = new System.Drawing.Point(12, 318);
            this.grSendMessage.Name = "grSendMessage";
            this.grSendMessage.Size = new System.Drawing.Size(442, 49);
            this.grSendMessage.TabIndex = 2;
            this.grSendMessage.TabStop = false;
            this.grSendMessage.Text = "Message";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(341, 13);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(91, 23);
            this.btnSendMessage.TabIndex = 7;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // edMessage
            // 
            this.edMessage.Location = new System.Drawing.Point(6, 15);
            this.edMessage.Name = "edMessage";
            this.edMessage.Size = new System.Drawing.Size(329, 20);
            this.edMessage.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 374);
            this.Controls.Add(this.grSendMessage);
            this.Controls.Add(this.lsbMessages);
            this.Controls.Add(this.grConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcpClient Test";
            this.grConnection.ResumeLayout(false);
            this.grConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPort)).EndInit();
            this.grSendMessage.ResumeLayout(false);
            this.grSendMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown edPort;
        private System.Windows.Forms.TextBox edAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbMessages;
        private System.Windows.Forms.GroupBox grSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox edMessage;
    }
}

