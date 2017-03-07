namespace TS4_STBL_Editor
{
    partial class LangCodesHelp
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LangCodesDS = new System.Data.DataSet();
            this.aboutEditorFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangCodesDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutEditorFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(317, 419);
            this.dataGridView1.TabIndex = 0;
            // 
            // LangCodesDS
            // 
            this.LangCodesDS.DataSetName = "LangCodesDS";
            // 
            // aboutEditorFormBindingSource
            // 
            this.aboutEditorFormBindingSource.DataSource = typeof(TS4_STBL_Editor.AboutEditorForm);
            // 
            // LangCodesHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 419);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LangCodesHelp";
            this.Text = "LangCodesHelp";
            this.Load += new System.EventHandler(this.LangCodesHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangCodesDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutEditorFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource aboutEditorFormBindingSource;
        private System.Data.DataSet LangCodesDS;
    }
}