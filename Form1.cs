using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
/*
 * QQ：412035160
 * Author phhui 
 * */
namespace FileManager
{
    public partial class Form1 : Form
    {
        private List<FileInfo> fileListData = new List<FileInfo>(); //保存所有的文件信息 
        private int moveNum = 0;
        private int deleteNum = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public List<FileInfo> GetAllFilesInDirectory(string strDirectory)
        {
            if(!Directory.Exists(strDirectory)){
                MessageBox.Show("请选择有效目录！");
                return null;
            }
            DirectoryInfo directory = new DirectoryInfo(strDirectory);
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            FileInfo[] fileInfoArray = directory.GetFiles();
            if (fileInfoArray.Length > 0) fileListData.AddRange(fileInfoArray);
            foreach (DirectoryInfo _directoryInfo in directoryArray)
            {//遍历子目录
                GetAllFilesInDirectory(_directoryInfo.FullName);
            }
            return fileListData;
        }
        //选择目录
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb=new FolderBrowserDialog();
            if (fb.ShowDialog()==DialogResult.OK)
            {
                list_changedFileList.Items.Clear();
                filePath.Text = fb.SelectedPath;
                readFileList();
            }
        }

        private void autoClassification_Click(object sender, EventArgs e)
        {
            //自动归类
            MessageBox.Show("sorry this feature is not implemented!");
        }
        //取消选择
        private void changedFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_changedFileList.SelectedItem==null) return;
            list_fileList.Items.Add(list_changedFileList.SelectedItem);
            list_changedFileList.Items.Remove(list_changedFileList.SelectedItem);
        }
        //
        private void deleteFile_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("您还未选择任何文件！");
            }
            else
            {
                if (MessageBox.Show("您确定要删除选中的文件？","提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    removeFile();
                }
            }
        }
        //删除文件
        private void removeFile()
        {
            foreach (string path in list_changedFileList.Items)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    deleteNum++;
                }
            }
            list_changedFileList.Items.Clear();//清空选择列表
            MessageBox.Show("文件删除成功，总共"+deleteNum.ToString()+"个文件被删除！");
            deleteNum = 0;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                mobilePath.Text = fb.SelectedPath;
            }
        }
        //移动文件
        private void btn_mobileFile_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("您还未选择任何文件！");
            }
            else if (mobilePath.Text.Length < 1 || mobilePath.Text == "点击此处选择移动目标")
            {
                MessageBox.Show("请选择目标路径，点击左边的文本框进行选择！");
            }
            else if (!Directory.Exists(mobilePath.Text))
            {
                MessageBox.Show("目标路径不存在！");
            }
            else
            {
                mobilePath.Enabled = false;
                mobileFile();
            }
        }
        //将选择的文件移动到指定目录
        private void mobileFile()
        {
            foreach (string path in list_changedFileList.Items)
            {
                if (File.Exists(path))
                {
                    string filename=path.Substring(path.LastIndexOf("\\"));
                    if (!File.Exists(mobilePath.Text + filename))
                    {
                        File.Move(path, mobilePath.Text+filename);//将文件移动到目标目录下
                        moveNum++;
                    }
                    else
                    {
                        DialogResult result=MessageBox.Show("文件" + filename + "在" + mobilePath.Text + "已存在，是否替换？", "提示", MessageBoxButtons.YesNo);
                        if (result==DialogResult.OK)
                        {
                            File.Delete(mobilePath.Text+filename);//删除目标目录下对应的文件
                            File.Move(path, mobilePath.Text + filename);//将文件移动到目标目录下
                            moveNum++;
                        }
                    }
                }
            }
            list_changedFileList.Items.Clear();
            mobilePath.Enabled = true;
            MessageBox.Show("文件移动完成！总共"+moveNum.ToString()+"个文件被移动！");
        }
        //清空选择列表
        private void btn_clearChange_Click(object sender, EventArgs e)
        {
            list_changedFileList.Items.Clear();
        }
        //选择文件
        private void fileList_DoubleClick(object sender, EventArgs e)
        {
            if (list_fileList.SelectedItem == null) return;
            list_changedFileList.Items.Add(list_fileList.SelectedItem);
            list_fileList.Items.Remove(list_fileList.SelectedItem);
        }
        //刷新文件列表
        private void btn_refreshFileList_Click(object sender, EventArgs e)
        {
            list_changedFileList.Items.Clear();
            readFileList();
        }
        private void readFileList()
        {
            fileListData = new List<FileInfo>();
            list_fileList.Items.Clear();
            GetAllFilesInDirectory(filePath.Text);
            showFileList();
        }
        //将文件列表添加到显示列表中
        private void showFileList()
        {
            foreach (FileInfo fi in fileListData)
            {
                list_fileList.Items.Add(fi.FullName);
            }
        }
        //过滤文件
        private void btn_filter_Click(object sender, EventArgs e)
        {
            if (txt_containsText.Text.Length < 1 || txt_containsText.Text == "过滤的字符串")
            {
                MessageBox.Show("请填写过滤字符！");
                return;
            }
            list_fileList.Items.Clear();
            foreach (FileInfo fi in fileListData)
            {
                if (checkBox1.Checked && fi.Name.Contains(txt_containsText.Text))//包含指定字符的文件
                {
                    list_fileList.Items.Add(fi.FullName);
                }
                else if (!checkBox1.Checked && !fi.Name.Contains(txt_containsText.Text))//不包含指定字符的文件
                {
                    list_fileList.Items.Add(fi.FullName);
                }
            }
        }
        //全选
        private void btn_changeAll_Click(object sender, EventArgs e)
        {
            foreach (string i in list_fileList.Items)
            {
                list_changedFileList.Items.Add(i);
            }
            list_fileList.Items.Clear();
        }

        private void txt_containsText_Click(object sender, EventArgs e)
        {
            if (txt_containsText.Text == "过滤的字符串")
            {
                txt_containsText.Text = "";
            }
        }
    }
}
