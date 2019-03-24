namespace TS4_STBL_Editor
{
    partial class MainUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTBLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSTBLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSTBLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pACKAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openpackageFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createANewSTBLFileInpackageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.donatePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officialPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLangCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.filenameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.importBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.languageLable = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.parseS4PEstrings = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sTBLToolStripMenuItem,
            this.pACKAGEToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePackageToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // savePackageToolStripMenuItem
            // 
            this.savePackageToolStripMenuItem.Name = "savePackageToolStripMenuItem";
            resources.ApplyResources(this.savePackageToolStripMenuItem, "savePackageToolStripMenuItem");
            this.savePackageToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sTBLToolStripMenuItem
            // 
            this.sTBLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSTBLFileToolStripMenuItem,
            this.openSTBLFileToolStripMenuItem,
            this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem});
            this.sTBLToolStripMenuItem.Name = "sTBLToolStripMenuItem";
            resources.ApplyResources(this.sTBLToolStripMenuItem, "sTBLToolStripMenuItem");
            // 
            // newSTBLFileToolStripMenuItem
            // 
            this.newSTBLFileToolStripMenuItem.Name = "newSTBLFileToolStripMenuItem";
            resources.ApplyResources(this.newSTBLFileToolStripMenuItem, "newSTBLFileToolStripMenuItem");
            this.newSTBLFileToolStripMenuItem.Click += new System.EventHandler(this.newSTBLFileToolStripMenuItem_Click);
            // 
            // openSTBLFileToolStripMenuItem
            // 
            this.openSTBLFileToolStripMenuItem.Name = "openSTBLFileToolStripMenuItem";
            resources.ApplyResources(this.openSTBLFileToolStripMenuItem, "openSTBLFileToolStripMenuItem");
            this.openSTBLFileToolStripMenuItem.Click += new System.EventHandler(this.openSTBLFileToolStripMenuItem_Click);
            // 
            // sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem
            // 
            this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem.Name = "sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem";
            resources.ApplyResources(this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem, "sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem");
            this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem.Click += new System.EventHandler(this.sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem_Click);
            // 
            // pACKAGEToolStripMenuItem
            // 
            this.pACKAGEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openpackageFileToolStripMenuItem1,
            this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1,
            this.createANewSTBLFileInpackageFileToolStripMenuItem});
            this.pACKAGEToolStripMenuItem.Name = "pACKAGEToolStripMenuItem";
            resources.ApplyResources(this.pACKAGEToolStripMenuItem, "pACKAGEToolStripMenuItem");
            // 
            // openpackageFileToolStripMenuItem1
            // 
            this.openpackageFileToolStripMenuItem1.Name = "openpackageFileToolStripMenuItem1";
            resources.ApplyResources(this.openpackageFileToolStripMenuItem1, "openpackageFileToolStripMenuItem1");
            this.openpackageFileToolStripMenuItem1.Click += new System.EventHandler(this.openpackageFileToolStripMenuItem1_Click);
            // 
            // packageFilesMassInsertOfCopiedValuesToolStripMenuItem1
            // 
            this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1.Name = "packageFilesMassInsertOfCopiedValuesToolStripMenuItem1";
            resources.ApplyResources(this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1, "packageFilesMassInsertOfCopiedValuesToolStripMenuItem1");
            this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1.Click += new System.EventHandler(this.packageFilesMassInsertOfCopiedValuesToolStripMenuItem1_Click);
            // 
            // createANewSTBLFileInpackageFileToolStripMenuItem
            // 
            this.createANewSTBLFileInpackageFileToolStripMenuItem.Name = "createANewSTBLFileInpackageFileToolStripMenuItem";
            resources.ApplyResources(this.createANewSTBLFileInpackageFileToolStripMenuItem, "createANewSTBLFileInpackageFileToolStripMenuItem");
            this.createANewSTBLFileInpackageFileToolStripMenuItem.Click += new System.EventHandler(this.createANewSTBLFileInpackageFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.donatePageToolStripMenuItem,
            this.officialPageToolStripMenuItem,
            this.showLangCodesToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // donatePageToolStripMenuItem
            // 
            this.donatePageToolStripMenuItem.Name = "donatePageToolStripMenuItem";
            resources.ApplyResources(this.donatePageToolStripMenuItem, "donatePageToolStripMenuItem");
            this.donatePageToolStripMenuItem.Click += new System.EventHandler(this.donatePageToolStripMenuItem_Click);
            // 
            // officialPageToolStripMenuItem
            // 
            this.officialPageToolStripMenuItem.Name = "officialPageToolStripMenuItem";
            resources.ApplyResources(this.officialPageToolStripMenuItem, "officialPageToolStripMenuItem");
            this.officialPageToolStripMenuItem.Click += new System.EventHandler(this.officialPageToolStripMenuItem_Click);
            // 
            // showLangCodesToolStripMenuItem
            // 
            this.showLangCodesToolStripMenuItem.Name = "showLangCodesToolStripMenuItem";
            resources.ApplyResources(this.showLangCodesToolStripMenuItem, "showLangCodesToolStripMenuItem");
            this.showLangCodesToolStripMenuItem.Click += new System.EventHandler(this.showLangCodesToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.filenameLabel,
            this.toolStripStatusLabel3,
            this.progressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // filenameLabel
            // 
            this.filenameLabel.Name = "filenameLabel";
            resources.ApplyResources(this.filenameLabel, "filenameLabel");
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.Spring = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            resources.ApplyResources(this.progressBar1, "progressBar1");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // editBtn
            // 
            resources.ApplyResources(this.editBtn, "editBtn");
            this.editBtn.Name = "editBtn";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // exportBtn
            // 
            resources.ApplyResources(this.exportBtn, "exportBtn");
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtn
            // 
            resources.ApplyResources(this.importBtn, "importBtn");
            this.importBtn.Name = "importBtn";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // languageLable
            // 
            resources.ApplyResources(this.languageLable, "languageLable");
            this.languageLable.Name = "languageLable";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // parseS4PEstrings
            // 
            resources.ApplyResources(this.parseS4PEstrings, "parseS4PEstrings");
            this.parseS4PEstrings.Name = "parseS4PEstrings";
            this.parseS4PEstrings.UseVisualStyleBackColor = true;
            this.parseS4PEstrings.Click += new System.EventHandler(this.parseS4PEstrings_Click);
            // 
            // MainUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.parseS4PEstrings);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.languageLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainUI_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainUI_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel filenameLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem showLangCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        public System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label languageLable;
        private System.Windows.Forms.ToolStripMenuItem officialPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donatePageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem sTBLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSTBLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSTBLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pACKAGEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openpackageFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sTBLFilesMassInsertOfCopiedValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packageFilesMassInsertOfCopiedValuesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createANewSTBLFileInpackageFileToolStripMenuItem;
        private System.Windows.Forms.Button parseS4PEstrings;
    }
}

