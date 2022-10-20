
namespace LanApp9_1
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
            this.label1 = new System.Windows.Forms.Label();
            this.edAddress = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lsbFileList = new System.Windows.Forms.ListBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbDownload = new System.Windows.Forms.ToolStripProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.edLogin = new System.Windows.Forms.TextBox();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // edAddress
            // 
            this.edAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edAddress.Location = new System.Drawing.Point(63, 11);
            this.edAddress.Name = "edAddress";
            this.edAddress.Size = new System.Drawing.Size(388, 20);
            this.edAddress.TabIndex = 1;
            this.edAddress.Text = "ftp://ftp.intel.com/";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(457, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lsbFileList
            // 
            this.lsbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbFileList.FormattingEnabled = true;
            this.lsbFileList.Location = new System.Drawing.Point(15, 63);
            this.lsbFileList.Name = "lsbFileList";
            this.lsbFileList.Size = new System.Drawing.Size(517, 316);
            this.lsbFileList.TabIndex = 3;
            this.lsbFileList.DoubleClick += new System.EventHandler(this.lsbFileList_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDownload});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbDownload
            // 
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(200, 16);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Login";
            // 
            // edLogin
            // 
            this.edLogin.Location = new System.Drawing.Point(63, 37);
            this.edLogin.Name = "edLogin";
            this.edLogin.Size = new System.Drawing.Size(159, 20);
            this.edLogin.TabIndex = 6;
            this.edLogin.TextChanged += new System.EventHandler(this.edLogin_TextChanged);
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(292, 37);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(159, 20);
            this.edPassword.TabIndex = 8;
            this.edPassword.TextChanged += new System.EventHandler(this.edPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 410);
            this.Controls.Add(this.edPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lsbFileList);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.edAddress);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Test";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edAddress;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lsbFileList;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pbDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.Label label3;
    }
}

