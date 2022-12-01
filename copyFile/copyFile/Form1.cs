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
            foreach (var file in cacFiles)
            {
                File.Copy(file.FullName, hostTxtbox.Text + @"\" + file.Name, true);
            }
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
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFile();
        }
    }
}
