using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private List<FileInfo> listFiles = new List<FileInfo>(); //保存所有的文件信息 
        private List<key, num> fileNum = new List<key, num>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void GetAllFilesInDirectory(string strDirectory)
        {
            DirectoryInfo directory = new DirectoryInfo(strDirectory);
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            FileInfo[] fileInfoArray = directory.GetFiles();
            if (fileInfoArray.Length > 0) listFiles.AddRange(fileInfoArray);
            foreach (DirectoryInfo _directoryInfo in directoryArray)
            {
                DirectoryInfo directoryA = new DirectoryInfo(_directoryInfo.FullName);
                DirectoryInfo[] directoryArrayA = directoryA.GetDirectories();
                FileInfo[] fileInfoArrayA = directoryA.GetFiles();
                if (fileInfoArrayA.Length > 0)
                {
                    listFiles.AddRange(fileInfoArrayA);
                }
                GetAllFilesInDirectory(_directoryInfo.FullName);
            }
            foreach (FileInfo fi in listFiles)
            {
                fileList.Items.Add(fi.FullName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb=new FolderBrowserDialog();
            if (fb.ShowDialog()==DialogResult.OK)
            {
                filePath.Text = fb.SelectedPath;
                GetAllFilesInDirectory(filePath.Text);
            }
        }
        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedFile.Text = fileList.SelectedItem.ToString();
        }

        private void autoClassification_Click(object sender, EventArgs e)
        {
            foreach (FileInfo fi in listFiles)
            {
                fileList.Items.Add(fi.FullName);
            }
        }
    }
}
