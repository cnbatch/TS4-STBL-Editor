namespace TS4_STBL_Editor
{
    partial class AddString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddString));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.displayTextFld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textIDFld = new System.Windows.Forms.MaskedTextBox();
            this.copyStrFldsValues = new System.Windows.Forms.Button();
            this.pasteStrFldsValues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // displayTextFld
            // 
            resources.ApplyResources(this.displayTextFld, "displayTextFld");
            this.displayTextFld.Name = "displayTextFld";
            this.displayTextFld.KeyUp += new System.Windows.Forms.KeyEventHandler(this.calculateTextIDOfDisplayText);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textIDFld
            // 
            resources.ApplyResources(this.textIDFld, "textIDFld");
            this.textIDFld.AsciiOnly = true;
            this.textIDFld.Culture = new System.Globalization.CultureInfo("");
            this.textIDFld.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.textIDFld.HidePromptOnLeave = true;
            this.textIDFld.Name = "textIDFld";
            this.textIDFld.ResetOnPrompt = false;
            this.textIDFld.ResetOnSpace = false;
            this.textIDFld.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // copyStrFldsValues
            // 
            resources.ApplyResources(this.copyStrFldsValues, "copyStrFldsValues");
            this.copyStrFldsValues.Name = "copyStrFldsValues";
            this.copyStrFldsValues.UseVisualStyleBackColor = true;
            this.copyStrFldsValues.Click += new System.EventHandler(this.copyStrFldsValues_Click);
            // 
            // pasteStrFldsValues
            // 
            resources.ApplyResources(this.pasteStrFldsValues, "pasteStrFldsValues");
            this.pasteStrFldsValues.Name = "pasteStrFldsValues";
            this.pasteStrFldsValues.UseVisualStyleBackColor = true;
            this.pasteStrFldsValues.Click += new System.EventHandler(this.pasteStrFldsValues_Click);
            // 
            // AddString
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pasteStrFldsValues);
            this.Controls.Add(this.copyStrFldsValues);
            this.Controls.Add(this.textIDFld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayTextFld);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AddString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox displayTextFld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox textIDFld;
        private System.Windows.Forms.Button copyStrFldsValues;
        private System.Windows.Forms.Button pasteStrFldsValues;
    }
}