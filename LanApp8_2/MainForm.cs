using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LanApp8_2
{
    public partial class MainForm : Form
    {
        CancellationTokenSource cancellationToken;
        CancellationToken token;
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
    }
}
