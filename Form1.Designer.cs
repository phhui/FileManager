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
            this.label4 = new System.Windows.Forms.Label();
            this.mobilePath = new System.Windows.Forms.TextBox();
            this.btn_mobileFile = new System.Windows.Forms.Button();
            this.btn_clearChange = new System.Windows.Forms.Button();
            this.btn_refreshFileList = new System.Windows.Forms.Button();
            this.btn_changeAll = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_containsText = new System.Windows.Forms.TextBox();
            this.btn_filter = new System.Windows.Forms.Button();
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
            this.list_changedFileList.Size = new System.Drawing.Size(209, 412);
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
            this.deleteFile.Location = new System.Drawing.Point(388, 474);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(82, 23);
            this.deleteFile.TabIndex = 11;
            this.deleteFile.Text = "删除选中文件";
            this.deleteFile.UseVisualStyleBackColor = true;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "移动到";
            // 
            // mobilePath
            // 
            this.mobilePath.Location = new System.Drawing.Point(53, 474);
            this.mobilePath.Name = "mobilePath";
            this.mobilePath.Size = new System.Drawing.Size(248, 21);
            this.mobilePath.TabIndex = 13;
            this.mobilePath.Text = "点击此处选择移动目标";
            this.mobilePath.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_mobileFile
            // 
            this.btn_mobileFile.Location = new System.Drawing.Point(307, 474);
            this.btn_mobileFile.Name = "btn_mobileFile";
            this.btn_mobileFile.Size = new System.Drawing.Size(75, 23);
            this.btn_mobileFile.TabIndex = 14;
            this.btn_mobileFile.Text = "移  动";
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
            this.checkBox1.Location = new System.Drawing.Point(12, 451);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "包含";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_containsText
            // 
            this.txt_containsText.Location = new System.Drawing.Point(66, 447);
            this.txt_containsText.Name = "txt_containsText";
            this.txt_containsText.Size = new System.Drawing.Size(136, 21);
            this.txt_containsText.TabIndex = 19;
            this.txt_containsText.Text = "过滤的字符串";
            this.txt_containsText.Click += new System.EventHandler(this.txt_containsText_Click);
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(208, 447);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(49, 23);
            this.btn_filter.TabIndex = 20;
            this.btn_filter.Text = "过滤";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.txt_containsText);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_changeAll);
            this.Controls.Add(this.btn_refreshFileList);
            this.Controls.Add(this.btn_clearChange);
            this.Controls.Add(this.btn_mobileFile);
            this.Controls.Add(this.mobilePath);
            this.Controls.Add(this.label4);
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
            this.Text = "文件管理辅助工具";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mobilePath;
        private System.Windows.Forms.Button btn_mobileFile;
        private System.Windows.Forms.Button btn_clearChange;
        private System.Windows.Forms.Button btn_refreshFileList;
        private System.Windows.Forms.Button btn_changeAll;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_containsText;
        private System.Windows.Forms.Button btn_filter;
    }
}

