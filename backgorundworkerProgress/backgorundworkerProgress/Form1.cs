using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace backgorundworkerProgress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        void ham()
        {
            DirectoryInfo dr = new DirectoryInfo(sourceTxtb.Text);
            var cacFiles = dr.GetFiles();
            int u = 0;
            if (cacFiles.Length == 0)
            {
                MessageBox.Show("Thư mục này không có file nào cả");
            }
            else
            {

                foreach (var file in cacFiles)
                {
                    u += 1;
                    File.Copy(file.FullName, desTxtb.Text + @"\" + file.Name, true);
                    backgroundWorker1.ReportProgress((int)(u * 100 / cacFiles.Length));

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        
                        label3.Visible = true;
                        label3.Text = "Đang sao chép " + file.FullName;
                        toolTip1.SetToolTip(label3, label3.Text);
                    }));
                }
            }
           

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ham();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã sao chép xong !");
            label3.Visible = false;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch
            {
                MessageBox.Show("Tiến trình sao chép bị can thiệp khi đang chạy ! Lỗi !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            sourceTxtb.Text = fd.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            desTxtb.Text = fd.SelectedPath;
        }

       
    }
}
