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
using System.IO;

namespace LanApp9_1
{
    public partial class MainForm : Form
    {
        string ftpLogin;
        string ftpPassword;
        public MainForm()
        {
            InitializeComponent();
            dlgSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edAddress.Text))
            {
                MessageBox.Show("Address cannot be empty");
                return;
            }
            lsbFileList.Items.Clear();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(edAddress.Text);
            //request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            if (!string.IsNullOrEmpty(ftpLogin) && !string.IsNullOrEmpty(ftpPassword))
                request.Credentials = new NetworkCredential(ftpLogin, ftpPassword);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (Stream stream=response.GetResponseStream())
            {
                using (StreamReader reader=new StreamReader(stream))
                {
                    string line;
                    while ((line=reader.ReadLine())!=null)
                    {
                        //lsbFileList.Items.Add(line);
                        FtpItem item = new FtpItem(line);
                        lsbFileList.Items.Add(item);
                    }

                    if (lsbFileList.Items.Count==0)
                        MessageBox.Show("No items found!!!");
                }
            }

            response.Close();
        }

        private void lsbFileList_DoubleClick(object sender, EventArgs e)
        {
            if (lsbFileList.SelectedIndex == ListBox.NoMatches)
                return;

            FtpItem item = lsbFileList.SelectedItem as FtpItem;
            if (item == null)
                return;

            if (item.IsDirectory)
            {
                edAddress.Text += item + '/';
                btnLoad_Click(null, null);
            }
            else
            {
                string filePath = edAddress.Text + item;
                //MessageBox.Show("File: " + filePath);
                dlgSave.FileName = item;
                if (dlgSave.ShowDialog() != DialogResult.OK)
                    return;
                //pbDownload.ProgressBar.Value = 100;
                pbDownload.Style = ProgressBarStyle.Marquee;
                //StartDownloadingFile(filePath, dlgSave.FileName);
                Task.Run(() => StartDownloadingFile(filePath, dlgSave.FileName));
            }
        }

        private void StartDownloadingFile(string fileFrom, string fileTo)
        {
            if (string.IsNullOrEmpty(fileFrom)
                || string.IsNullOrEmpty(fileTo))
                return;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileFrom);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;

            if (!string.IsNullOrEmpty(ftpLogin) && !string.IsNullOrEmpty(ftpPassword))
                request.Credentials = new NetworkCredential(ftpLogin, ftpPassword);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using(Stream stream = response.GetResponseStream())
            {
                FileStream fs = new FileStream(fileTo, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[1024];
                int bytes = 0;

                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, bytes);
                } while (bytes > 0);

                fs.Close();
            }
            response.Close();
            MessageBox.Show("Download complete!!!");
            Action action = () =>
            {
                pbDownload.Value = 0;
                pbDownload.Style = ProgressBarStyle.Blocks;
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void edLogin_TextChanged(object sender, EventArgs e)
        {
            ftpLogin = edLogin.Text;
        }

        private void edPassword_TextChanged(object sender, EventArgs e)
        {
            ftpPassword = edPassword.Text;
        }
    }
}
