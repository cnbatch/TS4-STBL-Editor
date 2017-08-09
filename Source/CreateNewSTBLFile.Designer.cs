namespace TS4_STBL_Editor
{
    partial class CreateNewSTBLFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.stblNameFld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calculatedHashOfNameFld = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LangCodesDS = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.LangCodesDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Name of your MOD";
            // 
            // stblNameFld
            // 
            this.stblNameFld.Location = new System.Drawing.Point(173, 18);
            this.stblNameFld.Name = "stblNameFld";
            this.stblNameFld.Size = new System.Drawing.Size(260, 20);
            this.stblNameFld.TabIndex = 1;
            this.stblNameFld.TextChanged += new System.EventHandler(this.stblNameFld_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Calculated hash of STBL Name";
            // 
            // calculatedHashOfNameFld
            // 
            this.calculatedHashOfNameFld.Location = new System.Drawing.Point(173, 47);
            this.calculatedHashOfNameFld.Name = "calculatedHashOfNameFld";
            this.calculatedHashOfNameFld.ReadOnly = true;
            this.calculatedHashOfNameFld.Size = new System.Drawing.Size(260, 20);
            this.calculatedHashOfNameFld.TabIndex = 1;
            this.calculatedHashOfNameFld.TextChanged += new System.EventHandler(this.calculatedHashOfNameFld_TextChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(346, 85);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(173, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select language of STBL file";
            // 
            // LangCodesDS
            // 
            this.LangCodesDS.DataSetName = "LangCodesDS";
            // 
            // CreateNewSTBLFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 135);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.calculatedHashOfNameFld);
            this.Controls.Add(this.stblNameFld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateNewSTBLFile";
            this.Text = "CreateNewSTBLFile";
            this.Load += new System.EventHandler(this.CreateNewSTBLFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LangCodesDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stblNameFld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox calculatedHashOfNameFld;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Data.DataSet LangCodesDS;
    }
}