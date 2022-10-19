
namespace LanApp8_1
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
            this.edResponse = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.edAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbHeader = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // edResponse
            // 
            this.edResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edResponse.Location = new System.Drawing.Point(12, 42);
            this.edResponse.Name = "edResponse";
            this.edResponse.Size = new System.Drawing.Size(522, 230);
            this.edResponse.TabIndex = 7;
            this.edResponse.Text = "";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(441, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(93, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // edAddress
            // 
            this.edAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edAddress.Location = new System.Drawing.Point(63, 16);
            this.edAddress.Name = "edAddress";
            this.edAddress.Size = new System.Drawing.Size(372, 20);
            this.edAddress.TabIndex = 5;
            this.edAddress.Text = "http://google.com/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address";
            // 
            // lsbHeader
            // 
            this.lsbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbHeader.FormattingEnabled = true;
            this.lsbHeader.Location = new System.Drawing.Point(12, 278);
            this.lsbHeader.Name = "lsbHeader";
            this.lsbHeader.Size = new System.Drawing.Size(522, 108);
            this.lsbHeader.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 395);
            this.Controls.Add(this.lsbHeader);
            this.Controls.Add(this.edResponse);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.edAddress);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTTP Web-Request/Response";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox edResponse;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox edAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbHeader;
    }
}

