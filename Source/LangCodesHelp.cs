using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class LangCodesHelp : Form
    {
        public LangCodesHelp()
        {
            InitializeComponent();
        }

        private void LangCodesHelp_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TS4_STBL_Editor.LangCodesList.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                TextReader tr = new StringReader(result);

                LangCodesDS.ReadXml(tr);

                dataGridView1.DataSource = LangCodesDS;
                dataGridView1.DataMember = "lang";
            }

        }
    }
}
