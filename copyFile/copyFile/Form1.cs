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

namespace copyFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        void copyFile()
        {
            DirectoryInfo directoryUri = new DirectoryInfo(sourceTxtbox.Text);
            var cacFiles = directoryUri.GetFiles();
            int u = 0;
            foreach (var file in cacFiles)
            {
                u += 1;
                File.Copy(file.FullName, hostTxtbox.Text + @"\" + file.Name, true);
                backgroundWorker1.ReportProgress(u);
            }
              
               
            //try
            //{
            //    FileStream fsIn = new FileStream(source, FileMode.Open); // loi denied
            //    FileStream fsout = new FileStream(des, FileMode.Create);
            //    byte[] bt = new byte[1048756];
            //    int readByte;
            //    while ((readByte = fsIn.Read(bt, 0, bt.Length)) > 0)
            //    {
            //        fsout.Write(bt, 0, readByte);
            //        backgroundWorker1.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length));
            //    }

            //    fsIn.Close();
            //    fsout.Close();
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                hostTxtbox.Text = openFolder.SelectedPath.ToString();
            }
        }

        private void sourceBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if(openFolder.ShowDialog() == DialogResult.OK)
            {
                sourceTxtbox.Text = openFolder.SelectedPath.ToString();
            }
            
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

      
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã hoàn thành !");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            MessageBox.Show("Đã hoàn thành !");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile();
        }
            
           
    }
}
