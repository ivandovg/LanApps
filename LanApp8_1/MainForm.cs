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

namespace LanApp8_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lsbHeader.Items.Clear();
            edResponse.Text = "";

            if (string.IsNullOrEmpty(edAddress.Text))
            {
                MessageBox.Show("Addres is empty!!!");
                return;
            }

            HttpWebRequest request = WebRequest.CreateHttp(edAddress.Text);
            request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(new Cookie("username", "admin"));

            //request.Credentials = new NetworkCredential("user", "password");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream=response.GetResponseStream())
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader=new StreamReader(stream))
                {
                    string line;
                    while ((line=reader.ReadLine())!=null)
                    {
                        sb.AppendLine(line);
                    }

                    edResponse.Text = sb.ToString();
                }
            }

            WebHeaderCollection headers = response.Headers;
            for (int i = 0; i < headers.Count; i++)
            {
                lsbHeader.Items.Add($"{headers.GetKey(i)}: {headers[i]}");
            }

            lsbHeader.Items.Add("Cookies: ");
            foreach (Cookie item in response.Cookies)
            {
                lsbHeader.Items.Add($"{item.Name}: {item.Value}");
            }
            response.Close();

            Uri uri = new Uri(edAddress.Text);
            ServicePoint servicePoint = ServicePointManager.FindServicePoint(uri);

            lsbHeader.Items.Add("");
            lsbHeader.Items.Add("Service point:");
            lsbHeader.Items.Add($"ConnectionLimit: {servicePoint.ConnectionLimit}");
            lsbHeader.Items.Add($"MaxIdleTime: {servicePoint.MaxIdleTime}");
            lsbHeader.Items.Add($"ConnectionLeaseTimeout: {servicePoint.ConnectionLeaseTimeout}");
        }
    }
}
