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

namespace LanApp7_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            using (Stream stream=web.OpenRead(edAddress.Text))
            {
                StringBuilder builder = new StringBuilder();
                using (StreamReader reader=new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        builder.AppendLine(line);
                    }
                    edResponse.Text = builder.ToString();
                }
            }
        }
    }
}
