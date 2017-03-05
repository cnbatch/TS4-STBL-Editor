namespace TS4_STBL_Editor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Add_New_String = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Paste_ALL_copied_values = new System.Windows.Forms.Button();
            this.Show_copied_values = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Copy_Values_By_IDs = new System.Windows.Forms.Button();
            this.Copy_selected_rows = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.Column2,
            this.Column3});
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
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
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OKBtn
            // 
            resources.ApplyResources(this.OKBtn, "OKBtn");
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            resources.ApplyResources(this.CancelBtn, "CancelBtn");
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Add_New_String
            // 
            resources.ApplyResources(this.Add_New_String, "Add_New_String");
            this.Add_New_String.Name = "Add_New_String";
            this.Add_New_String.UseVisualStyleBackColor = true;
            this.Add_New_String.Click += new System.EventHandler(this.Add_New_String_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Paste_ALL_copied_values
            // 
            resources.ApplyResources(this.Paste_ALL_copied_values, "Paste_ALL_copied_values");
            this.Paste_ALL_copied_values.Name = "Paste_ALL_copied_values";
            this.Paste_ALL_copied_values.UseVisualStyleBackColor = true;
            this.Paste_ALL_copied_values.Click += new System.EventHandler(this.Paste_ALL_copied_values_Click);
            // 
            // Show_copied_values
            // 
            resources.ApplyResources(this.Show_copied_values, "Show_copied_values");
            this.Show_copied_values.Name = "Show_copied_values";
            this.Show_copied_values.UseVisualStyleBackColor = true;
            this.Show_copied_values.Click += new System.EventHandler(this.Show_copied_values_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Copy_Values_By_IDs
            // 
            resources.ApplyResources(this.Copy_Values_By_IDs, "Copy_Values_By_IDs");
            this.Copy_Values_By_IDs.Name = "Copy_Values_By_IDs";
            this.Copy_Values_By_IDs.UseVisualStyleBackColor = true;
            this.Copy_Values_By_IDs.Click += new System.EventHandler(this.Copy_Values_By_IDs_Click);
            // 
            // Copy_selected_rows
            // 
            resources.ApplyResources(this.Copy_selected_rows, "Copy_selected_rows");
            this.Copy_selected_rows.Name = "Copy_selected_rows";
            this.Copy_selected_rows.UseVisualStyleBackColor = true;
            this.Copy_selected_rows.Click += new System.EventHandler(this.Copy_selected_rows_Click);
            // 
            // Editor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Copy_selected_rows);
            this.Controls.Add(this.Copy_Values_By_IDs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Show_copied_values);
            this.Controls.Add(this.Paste_ALL_copied_values);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Add_New_String);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add_New_String;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Paste_ALL_copied_values;
        private System.Windows.Forms.Button Show_copied_values;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Copy_Values_By_IDs;
        private System.Windows.Forms.Button Copy_selected_rows;
    }
}