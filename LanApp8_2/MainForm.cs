using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace LanApp8_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = edHost.Text;
            smtp.Port = (int)edPort.Value;
            smtp.EnableSsl = cbUseSSL.Checked;
            smtp.Credentials = new NetworkCredential(edUser.Text, edPassword.Text);

            MailMessage message = new MailMessage(edFrom.Text, edTo.Text);
            message.Subject = edSubject.Text;
            message.Body = edMessageText.Text;

            if (!string.IsNullOrEmpty(edFile.Text))
                message.Attachments.Add(new Attachment(edFile.Text));

            try
            {
                grConnection.Enabled = false;
                grMessage.Enabled = false;
                //await smtp.SendMailAsync(message);
                smtp.Send(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message);
            }
            finally
            {
                grConnection.Enabled = true;
                grMessage.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                edFile.Text = dlgOpen.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edFile.Text = string.Empty;
        }
    }
}
