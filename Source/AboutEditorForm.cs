using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class AboutEditorForm : Form
    {
        public AboutEditorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutEditorForm_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            label1.Text = "Version " + version + " by ArtUrlWWW, cnbatch & C major";
        }
    }
}
