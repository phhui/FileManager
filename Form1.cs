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
            txt_info.Text = "功能已完成，欢迎试用\r\n\r\n使用中发现什么问题或是有什么意见建议欢迎咨询QQ:412035160";
        }
        public List<FileInfo> GetAllFilesInDirectory(string strDirectory,Boolean contains)
        {
            if(!Directory.Exists(strDirectory)){
                MessageBox.Show("请选择有效目录！");
                return null;
            }
            DirectoryInfo directory = new DirectoryInfo(strDirectory);
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            FileInfo[] fileInfoArray = directory.GetFiles();
            if (fileInfoArray.Length > 0) fileListData.AddRange(fileInfoArray);
            if (contains)
            {
                foreach (DirectoryInfo _directoryInfo in directoryArray)
                {//遍历子目录
                    GetAllFilesInDirectory(_directoryInfo.FullName,contains);
                }
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
                    if (IsUsed(path))
                    {
                        MessageBox.Show("文件正在使用中，无法进行操作！");
                        continue;
                    }
                    File.Delete(path);
                    deleteNum++;
                }
            }
            list_changedFileList.Items.Clear();//清空选择列表
            MessageBox.Show("文件删除成功，总共"+deleteNum.ToString()+"个文件被删除！");
            deleteNum = 0;
        }
        //移动文件
        private void btn_mobileFile_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择文件！");
                return;
            }
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
                    if (IsUsed(path))
                    {
                        MessageBox.Show("文件正在使用中，无法进行操作！");
                        continue;
                    }
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
            lb_selectNum.Text = "/已选择 " + list_changedFileList.Items.Count.ToString() + " 个文件";
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
            GetAllFilesInDirectory(filePath.Text,cb_contains.Checked);
            showFileList();
        }
        //将文件列表添加到显示列表中
        private void showFileList()
        {
            foreach (FileInfo fi in fileListData)
            {
                list_fileList.Items.Add(fi.FullName);
            }
            list_fileList.Sorted = true;
            lb_allNum.Text = "共 "+list_fileList.Items.Count.ToString()+" 个文件";
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
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择文件！");
                return;
            }
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
            string file = list_changedFileList.Items[0].ToString();
            string filePath = file.Substring(0, list_changedFileList.Items[0].ToString().LastIndexOf("\\") + 1);
            string filename = file.Substring(file.LastIndexOf("\\") + 1);
            string type = filename.Substring(filename.LastIndexOf("."));
            reName(list_changedFileList.Items[0].ToString(), txt_newFileName.Text, true);
            list_changedFileList.Items.Clear();
            list_changedFileList.Items.Add(filePath + txt_newFileName.Text + type);
            MessageBox.Show("重命名完成！");
        }
        private void reName(string file,string newName,Boolean check)
        {
            if (IsUsed(file))
            {
                MessageBox.Show("文件正在使用中，无法进行操作！");
                return;
            }
            string filePath = file.Substring(0, list_changedFileList.Items[0].ToString().LastIndexOf("\\") + 1);
            string filename = file.Substring(file.LastIndexOf("\\") + 1);
            string type = filename.Substring(filename.LastIndexOf("."));
            DialogResult res=DialogResult.No;
            if (check == true)
            {
                res = MessageBox.Show("您确定要将【" + filename + "】重命名为【 " + newName + type + " 】?", "提示", MessageBoxButtons.YesNo);
            }
            if (!check||res == DialogResult.Yes)
            {//需要检测是否存在新的文件名的文件
                File.Move(file, filePath + newName + type);
            }
        }
        private void btn_allReName_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择要操作的文件！");
                return;
            }
            if (txt_order.Text.Length < 1)
            {
                MessageBox.Show("请输入序列名字！");
                return;
            }
            if (txt_orderStartNum.Text == "起始数字(默认为0)")
            {
                txt_orderStartNum.Text = "0";
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

        private void btn_addPrefix_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择要操作的文件！");
                return;
            }
            int j = 0;
            string[] newFile = new string[list_changedFileList.Items.Count];
            foreach (string s in list_changedFileList.Items)
            {
                string filePath = s.Substring(0, s.LastIndexOf("\\") + 1);
                string filename = s.Substring(s.LastIndexOf("\\") + 1);
                string type = filename.Substring(filename.LastIndexOf("."));
                reName(s, filePath + txt_char.Text + filename, false);
                newFile[j] = filePath + txt_char.Text + filename;
                j++;
            }
            list_changedFileList.Items.Clear();
            foreach (string nf in newFile)
            {
                list_changedFileList.Items.Add(nf);
            }

        }

        private void btn_addSuffix_Click(object sender, EventArgs e)
        {
            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择要操作的文件！");
                return;
            }
            int j = 0;
            string[] newFile = new string[list_changedFileList.Items.Count];
            foreach (string s in list_changedFileList.Items)
            {
                string filePath = s.Substring(0, s.LastIndexOf("\\") + 1);
                string filename = s.Substring(s.LastIndexOf("\\") + 1);
                string type = filename.Substring(filename.LastIndexOf("."));
                reName(s, filePath + filename.Replace(type, "") + txt_char.Text + type, false);
                newFile[j] = filePath + filename.Replace(type, "") + txt_char.Text + type;
                j++;
            }
            list_changedFileList.Items.Clear();
            foreach (string nf in newFile)
            {
                list_changedFileList.Items.Add(nf);
            }
        }

        private void btn_replace_Click(object sender, EventArgs e)
        {

            if (list_changedFileList.Items.Count < 1)
            {
                MessageBox.Show("请先选择要操作的文件！");
                return;
            }
            if (txt_fileChar.Text.Length < 1)
            {
                MessageBox.Show("请填写要替换的内容！");
                return;
            }
            int j = 0;
            string[] newFile = new string[list_changedFileList.Items.Count];
            foreach (string s in list_changedFileList.Items)
            {
                string filePath = s.Substring(0, s.LastIndexOf("\\") + 1);
                string filename = s.Substring(s.LastIndexOf("\\") + 1);
                string type = filename.Substring(filename.LastIndexOf("."));
                string useChar = txt_useChar.Text.Length < 1 ? "" : txt_useChar.Text;
                reName(s, filename.Replace(type, "").Replace(txt_fileChar.Text, useChar), false);
                newFile[j] = filePath + filename.Replace(type, "").Replace(txt_fileChar.Text, useChar) + type;
                j++;
            }
            list_changedFileList.Items.Clear();
            foreach (string nf in newFile)
            {
                list_changedFileList.Items.Add(nf);
            }
        }

        private void filePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                list_changedFileList.Items.Clear();
                filePath.Text = fb.SelectedPath;
                readFileList();
            }
        }

        private void list_changedFileList_DoubleClick(object sender, EventArgs e)
        {
            if (list_changedFileList.SelectedItem == null) return;
            list_fileList.Items.Add(list_changedFileList.SelectedItem);
            list_changedFileList.Items.Remove(list_changedFileList.SelectedItem);
        }

        private void list_fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_fileList.SelectedItem == null) return;
            txt_select.Text = list_fileList.SelectedItem.ToString();
        }

        private void list_changedFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_changedFileList.SelectedItem == null) return;
            txt_select.Text = list_changedFileList.SelectedItem.ToString();
        }

        public bool IsUsed(String fileName)
        {
            bool result = false;

            try
            {
                FileStream fs = File.OpenWrite(fileName);
                fs.Close();
            }
            catch
            {
                result = true;
            }

            return result;
        }
        private void btn_filter_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_filter, "过滤文件列表中的文件");
        }

        private void btn_changeAll_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_changeAll, "将文件列表中的所有文件移到选择列表中");
        }

        private void btn_refreshFileList_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_refreshFileList, "刷新文件列表中的文件");
        }

        private void btn_clearChange_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_clearChange, "清空选择列表");
        }

        private void btn_reName_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_reName, "重命名选择列表的文件，只能重命名一个文件，\r\n如果需要修改多个文件请使用批量重命名");
        }

        private void btn_mobileFile_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_mobileFile, "将选择的文件移动到指定目录，点击选择目标目录并移动");
        }

        private void deleteFile_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(deleteFile, "删除选择列表中的所有文件");
        }

        private void btn_allReName_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_allReName, "对选择列表中的所有文件按设置规则进行便命名，\r\n如：选择100张jpg图片，序列名为a，起始数字为0，\r\n则重命名后的文件名为（a0.jpg, a1.jpg, a2.jpg, a3.jpg ......）");
        }

        private void btn_addPrefix_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_addPrefix, "将选择列表中的所有文件的名字前面加上一串文字，\r\n如：文件ww.rar,字符串填aaa，则选择的文件加完后都变成 aaaww.rar");
        }

        private void btn_addSuffix_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_addSuffix, "将选择列表中的所有文件的名字的末尾加上一串文字，\r\n如：文件ww.rar,字符串填aaa，则选择的文件加完后都变成 wwaaa.rar");
        }

        private void btn_replace_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_replace, "将选择列表中的所有文件的名字中包含的字符替换成自己需要的，\r\n如：aa天啊bb.rar，要替换的字符为 “天啊”，\r\n替换后的字符为“cc”，则执行替换后文件名为 aaccbb.rar");
        }

        private void txt_containsText_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txt_containsText, "文件名中包含或不包含的文字");
        }

        private void cb_contains_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cb_contains, "选中后将会显示所选的目录及基子目录下的所有文件");
        }

        private void cb_contains_CheckedChanged(object sender, EventArgs e)
        {
            list_changedFileList.Items.Clear();
            readFileList();
        }
    }
}
