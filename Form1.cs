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

            
        }
        //移动文件
        private void btn_mobileFile_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("您确定要移动选择列表中的所有文件？","提示",MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                if (list_changedFileList.Items.Count < 1)
                {
                    MessageBox.Show("您还未选择任何文件！");
                }
                else
                {
                    mobileFile(fb.SelectedPath);
                }
            }
        }
        //将选择的文件移动到指定目录
        private void mobileFile(string mobilePath)
        {
            foreach (string path in list_changedFileList.Items)
            {
                if (File.Exists(path))
                {
                    string filename=path.Substring(path.LastIndexOf("\\"));
                    if (!File.Exists(mobilePath + filename))
                    {
                        File.Move(path, mobilePath + filename);//将文件移动到目标目录下
                        moveNum++;
                    }
                    else
                    {
                        DialogResult result=MessageBox.Show("文件" + filename + "在" + mobilePath + "已存在，是否替换？", "提示", MessageBoxButtons.YesNo);
                        if (result==DialogResult.Yes)
                        {
                            File.Delete(mobilePath+filename);//删除目标目录下对应的文件
                            File.Move(path, mobilePath + filename);//将文件移动到目标目录下
                            moveNum++;
                        }
                    }
                }
            }
            list_changedFileList.Items.Clear();
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
            string[] str = txt_containsText.Text.Replace("，",",").Split(',');
            foreach (FileInfo fi in fileListData)
            {
                Boolean res = false;
                foreach (string s in str)
                {
                    if (fi.Name.Contains(s))
                    {
                        res = true;
                    }
                }
                if (checkBox1.Checked && res)//包含指定字符的文件
                {
                    list_fileList.Items.Add(fi.FullName);
                }
                else if (!checkBox1.Checked && !res)//不包含指定字符的文件
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

        private void btn_reName_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count > 1)
            {
                MessageBox.Show("重命名只能对单个文件重命名！如需对多个文件重命名请使用序列重命名！");
                return;
            }
            if (txt_newFileName.Text.Length < 1)
            {
                MessageBox.Show("请输入新的文件名！");
                return;
            }
            string filePath = list_changedFileList.Items[0].ToString().Substring(0,list_changedFileList.Items[0].ToString().LastIndexOf("\\")+1);
            string filename = list_changedFileList.Items[0].ToString().Substring(list_changedFileList.Items[0].ToString().LastIndexOf("\\") + 1);
            string type = filename.Substring(filename.LastIndexOf("."));
            txt_debug.Text = filePath + "\r\n" + filename + "\r\n" + type;
            DialogResult res = MessageBox.Show("您确定要将【" + filename + "】重命名为【 " + txt_newFileName.Text + type + " 】?", "提示", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                File.Move(list_changedFileList.Items[0].ToString(), filePath + txt_newFileName.Text + type);
                list_changedFileList.Items.Clear();
                list_changedFileList.Items.Add(filePath + txt_newFileName.Text + type);
                MessageBox.Show("重命名完成！");
            }
        }

        private void btn_allReName_Click(object sender, EventArgs e)
        {
            if (txt_order.Text.Length < 1)
            {
                MessageBox.Show("请输入序列名字！");
                return;
            }
            int a = 0;
            if (!int.TryParse(txt_orderStartNum.Text,out a))
            {
                MessageBox.Show("起始序号只能为数字！");
                return;
            }
            int i=Convert.ToInt32(txt_orderStartNum.Text);
            string[] newFile=new string[list_changedFileList.Items.Count];
            int j = 0;
            foreach (string s in list_changedFileList.Items)
            {
                string filePath = s.Substring(0, s.LastIndexOf("\\") + 1);
                string filename = s.Substring(s.LastIndexOf("\\") + 1);
                string type = filename.Substring(filename.LastIndexOf("."));
                if (File.Exists(filePath + txt_order.Text + i.ToString() + type))
                {
                    File.Move(s, filePath + txt_order.Text + i.ToString()+"(1)" + type);
                    newFile[j] = filePath + txt_order.Text + i.ToString() + "(1)" + type;
                }
                else
                {
                    File.Move(s, filePath + txt_order.Text + i.ToString() + type);
                    newFile[j] = filePath + txt_order.Text + i.ToString() + type;
                }
                i++;
                j++;
            }
            list_changedFileList.Items.Clear();
            foreach(string nf in newFile){
                list_changedFileList.Items.Add(nf);
            }
            MessageBox.Show("序列重命名完成！");
        }
    }
}
