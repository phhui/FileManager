namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.autoClassification = new System.Windows.Forms.Button();
            this.list_fileList = new System.Windows.Forms.ListBox();
            this.list_changedFileList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteFile = new System.Windows.Forms.Button();
            this.btn_mobileFile = new System.Windows.Forms.Button();
            this.btn_clearChange = new System.Windows.Forms.Button();
            this.btn_refreshFileList = new System.Windows.Forms.Button();
            this.btn_changeAll = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_containsText = new System.Windows.Forms.TextBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.txt_newFileName = new System.Windows.Forms.TextBox();
            this.btn_reName = new System.Windows.Forms.Button();
            this.btn_addPrefix = new System.Windows.Forms.Button();
            this.btn_addSuffix = new System.Windows.Forms.Button();
            this.txt_order = new System.Windows.Forms.TextBox();
            this.txt_char = new System.Windows.Forms.TextBox();
            this.btn_allReName = new System.Windows.Forms.Button();
            this.txt_orderStartNum = new System.Windows.Forms.TextBox();
            this.txt_fileChar = new System.Windows.Forms.TextBox();
            this.txt_useChar = new System.Windows.Forms.TextBox();
            this.btn_replace = new System.Windows.Forms.Button();
            this.txt_debug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(53, 9);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(257, 21);
            this.filePath.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "选择目录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "目录：";
            // 
            // autoClassification
            // 
            this.autoClassification.Location = new System.Drawing.Point(397, 8);
            this.autoClassification.Name = "autoClassification";
            this.autoClassification.Size = new System.Drawing.Size(75, 23);
            this.autoClassification.TabIndex = 5;
            this.autoClassification.Tag = "";
            this.autoClassification.Text = "自动归类";
            this.autoClassification.UseVisualStyleBackColor = true;
            this.autoClassification.Click += new System.EventHandler(this.autoClassification_Click);
            // 
            // list_fileList
            // 
            this.list_fileList.FormattingEnabled = true;
            this.list_fileList.ItemHeight = 12;
            this.list_fileList.Location = new System.Drawing.Point(12, 56);
            this.list_fileList.Name = "list_fileList";
            this.list_fileList.Size = new System.Drawing.Size(245, 388);
            this.list_fileList.TabIndex = 7;
            this.list_fileList.DoubleClick += new System.EventHandler(this.fileList_DoubleClick);
            // 
            // list_changedFileList
            // 
            this.list_changedFileList.FormattingEnabled = true;
            this.list_changedFileList.ItemHeight = 12;
            this.list_changedFileList.Location = new System.Drawing.Point(263, 56);
            this.list_changedFileList.Name = "list_changedFileList";
            this.list_changedFileList.Size = new System.Drawing.Size(209, 424);
            this.list_changedFileList.TabIndex = 8;
            this.list_changedFileList.SelectedIndexChanged += new System.EventHandler(this.changedFileList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "文件列表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "选择的文件:";
            // 
            // deleteFile
            // 
            this.deleteFile.Location = new System.Drawing.Point(62, 484);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(46, 23);
            this.deleteFile.TabIndex = 11;
            this.deleteFile.Text = "删除";
            this.deleteFile.UseVisualStyleBackColor = true;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // btn_mobileFile
            // 
            this.btn_mobileFile.Location = new System.Drawing.Point(8, 484);
            this.btn_mobileFile.Name = "btn_mobileFile";
            this.btn_mobileFile.Size = new System.Drawing.Size(48, 23);
            this.btn_mobileFile.TabIndex = 14;
            this.btn_mobileFile.Text = "移动";
            this.btn_mobileFile.UseVisualStyleBackColor = true;
            this.btn_mobileFile.Click += new System.EventHandler(this.btn_mobileFile_Click);
            // 
            // btn_clearChange
            // 
            this.btn_clearChange.Location = new System.Drawing.Point(430, 33);
            this.btn_clearChange.Name = "btn_clearChange";
            this.btn_clearChange.Size = new System.Drawing.Size(42, 23);
            this.btn_clearChange.TabIndex = 15;
            this.btn_clearChange.Text = "清空";
            this.btn_clearChange.UseVisualStyleBackColor = true;
            this.btn_clearChange.Click += new System.EventHandler(this.btn_clearChange_Click);
            // 
            // btn_refreshFileList
            // 
            this.btn_refreshFileList.Location = new System.Drawing.Point(220, 32);
            this.btn_refreshFileList.Name = "btn_refreshFileList";
            this.btn_refreshFileList.Size = new System.Drawing.Size(38, 23);
            this.btn_refreshFileList.TabIndex = 16;
            this.btn_refreshFileList.Text = "刷新";
            this.btn_refreshFileList.UseVisualStyleBackColor = true;
            this.btn_refreshFileList.Click += new System.EventHandler(this.btn_refreshFileList_Click);
            // 
            // btn_changeAll
            // 
            this.btn_changeAll.Location = new System.Drawing.Point(178, 32);
            this.btn_changeAll.Name = "btn_changeAll";
            this.btn_changeAll.Size = new System.Drawing.Size(40, 23);
            this.btn_changeAll.TabIndex = 17;
            this.btn_changeAll.Text = "全选";
            this.btn_changeAll.UseVisualStyleBackColor = true;
            this.btn_changeAll.Click += new System.EventHandler(this.btn_changeAll_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 449);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "包含";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_containsText
            // 
            this.txt_containsText.Location = new System.Drawing.Point(62, 445);
            this.txt_containsText.Name = "txt_containsText";
            this.txt_containsText.Size = new System.Drawing.Size(136, 21);
            this.txt_containsText.TabIndex = 19;
            this.txt_containsText.Text = "过滤的字符串,逗号隔开";
            this.txt_containsText.Click += new System.EventHandler(this.txt_containsText_Click);
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(208, 445);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(49, 23);
            this.btn_filter.TabIndex = 20;
            this.btn_filter.Text = "过滤";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // txt_newFileName
            // 
            this.txt_newFileName.Location = new System.Drawing.Point(8, 513);
            this.txt_newFileName.Name = "txt_newFileName";
            this.txt_newFileName.Size = new System.Drawing.Size(107, 21);
            this.txt_newFileName.TabIndex = 21;
            this.txt_newFileName.Text = "新的文件名";
            // 
            // btn_reName
            // 
            this.btn_reName.Location = new System.Drawing.Point(121, 513);
            this.btn_reName.Name = "btn_reName";
            this.btn_reName.Size = new System.Drawing.Size(57, 23);
            this.btn_reName.TabIndex = 22;
            this.btn_reName.Text = "重命名";
            this.btn_reName.UseVisualStyleBackColor = true;
            this.btn_reName.Click += new System.EventHandler(this.btn_reName_Click);
            // 
            // btn_addPrefix
            // 
            this.btn_addPrefix.Location = new System.Drawing.Point(121, 570);
            this.btn_addPrefix.Name = "btn_addPrefix";
            this.btn_addPrefix.Size = new System.Drawing.Size(54, 23);
            this.btn_addPrefix.TabIndex = 23;
            this.btn_addPrefix.Text = "加前缀";
            this.btn_addPrefix.UseVisualStyleBackColor = true;
            // 
            // btn_addSuffix
            // 
            this.btn_addSuffix.Location = new System.Drawing.Point(180, 570);
            this.btn_addSuffix.Name = "btn_addSuffix";
            this.btn_addSuffix.Size = new System.Drawing.Size(51, 23);
            this.btn_addSuffix.TabIndex = 24;
            this.btn_addSuffix.Text = "加后缀";
            this.btn_addSuffix.UseVisualStyleBackColor = true;
            // 
            // txt_order
            // 
            this.txt_order.Location = new System.Drawing.Point(8, 542);
            this.txt_order.Name = "txt_order";
            this.txt_order.Size = new System.Drawing.Size(107, 21);
            this.txt_order.TabIndex = 25;
            this.txt_order.Text = "序列名";
            // 
            // txt_char
            // 
            this.txt_char.Location = new System.Drawing.Point(8, 570);
            this.txt_char.Name = "txt_char";
            this.txt_char.Size = new System.Drawing.Size(107, 21);
            this.txt_char.TabIndex = 26;
            this.txt_char.Text = "字符串";
            // 
            // btn_allReName
            // 
            this.btn_allReName.Location = new System.Drawing.Point(227, 542);
            this.btn_allReName.Name = "btn_allReName";
            this.btn_allReName.Size = new System.Drawing.Size(75, 23);
            this.btn_allReName.TabIndex = 27;
            this.btn_allReName.Text = "序列重命名";
            this.btn_allReName.UseVisualStyleBackColor = true;
            this.btn_allReName.Click += new System.EventHandler(this.btn_allReName_Click);
            // 
            // txt_orderStartNum
            // 
            this.txt_orderStartNum.Location = new System.Drawing.Point(121, 543);
            this.txt_orderStartNum.Name = "txt_orderStartNum";
            this.txt_orderStartNum.Size = new System.Drawing.Size(100, 21);
            this.txt_orderStartNum.TabIndex = 28;
            this.txt_orderStartNum.Text = "0";
            // 
            // txt_fileChar
            // 
            this.txt_fileChar.Location = new System.Drawing.Point(8, 598);
            this.txt_fileChar.Name = "txt_fileChar";
            this.txt_fileChar.Size = new System.Drawing.Size(107, 21);
            this.txt_fileChar.TabIndex = 29;
            this.txt_fileChar.Text = "文件名中的字符";
            // 
            // txt_useChar
            // 
            this.txt_useChar.Location = new System.Drawing.Point(121, 598);
            this.txt_useChar.Name = "txt_useChar";
            this.txt_useChar.Size = new System.Drawing.Size(100, 21);
            this.txt_useChar.TabIndex = 30;
            this.txt_useChar.Text = "替换后的字符";
            // 
            // btn_replace
            // 
            this.btn_replace.Location = new System.Drawing.Point(227, 596);
            this.btn_replace.Name = "btn_replace";
            this.btn_replace.Size = new System.Drawing.Size(75, 23);
            this.btn_replace.TabIndex = 31;
            this.btn_replace.Text = "替 换";
            this.btn_replace.UseVisualStyleBackColor = true;
            // 
            // txt_debug
            // 
            this.txt_debug.Location = new System.Drawing.Point(302, 487);
            this.txt_debug.Multiline = true;
            this.txt_debug.Name = "txt_debug";
            this.txt_debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_debug.Size = new System.Drawing.Size(170, 147);
            this.txt_debug.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 636);
            this.Controls.Add(this.txt_debug);
            this.Controls.Add(this.btn_replace);
            this.Controls.Add(this.txt_useChar);
            this.Controls.Add(this.txt_fileChar);
            this.Controls.Add(this.txt_orderStartNum);
            this.Controls.Add(this.btn_allReName);
            this.Controls.Add(this.txt_char);
            this.Controls.Add(this.txt_order);
            this.Controls.Add(this.btn_addSuffix);
            this.Controls.Add(this.btn_addPrefix);
            this.Controls.Add(this.btn_reName);
            this.Controls.Add(this.txt_newFileName);
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.txt_containsText);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_changeAll);
            this.Controls.Add(this.btn_refreshFileList);
            this.Controls.Add(this.btn_clearChange);
            this.Controls.Add(this.btn_mobileFile);
            this.Controls.Add(this.deleteFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_changedFileList);
            this.Controls.Add(this.list_fileList);
            this.Controls.Add(this.autoClassification);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.filePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件管理辅助工具 by phhui";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button autoClassification;
        private System.Windows.Forms.ListBox list_fileList;
        private System.Windows.Forms.ListBox list_changedFileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button deleteFile;
        private System.Windows.Forms.Button btn_mobileFile;
        private System.Windows.Forms.Button btn_clearChange;
        private System.Windows.Forms.Button btn_refreshFileList;
        private System.Windows.Forms.Button btn_changeAll;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_containsText;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.TextBox txt_newFileName;
        private System.Windows.Forms.Button btn_reName;
        private System.Windows.Forms.Button btn_addPrefix;
        private System.Windows.Forms.Button btn_addSuffix;
        private System.Windows.Forms.TextBox txt_order;
        private System.Windows.Forms.TextBox txt_char;
        private System.Windows.Forms.Button btn_allReName;
        private System.Windows.Forms.TextBox txt_orderStartNum;
        private System.Windows.Forms.TextBox txt_fileChar;
        private System.Windows.Forms.TextBox txt_useChar;
        private System.Windows.Forms.Button btn_replace;
        private System.Windows.Forms.TextBox txt_debug;
    }
}

