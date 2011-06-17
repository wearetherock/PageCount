using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using System.IO;
using System.Diagnostics;

namespace Com.Ko.PageCount
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String date = dateTextBox.Text;
            if (date != String.Empty)
            {
                IService proxy = XmlRpcProxyGen.Create<IService>();
                proxy.Url = urlTextBox.Text;

                String data = proxy.GetData(date);

                String html = String.Format("<html><pre>{0}</pre></html>", data);
                String htmlFile = Path.GetTempFileName() + ".html";
                File.WriteAllText(htmlFile, html);
                Process.Start(htmlFile);

                rsTextBox.Text = data;
            }
        }
    }
}
