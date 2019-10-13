using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class CreateNewSTBLFile : Form
    {
        MainUI mainUI;
        public CreateNewSTBLFile(MainUI mainUI)
        {
            InitializeComponent();
            this.mainUI = mainUI;
        }

        private void calculatedHashOfNameFld_TextChanged(object sender, EventArgs e)
        {


        }

        private void CreateNewSTBLFile_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TS4_STBL_Editor.LangCodesList.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                TextReader tr = new StringReader(result);
                LangCodesDS.ReadXml(tr);

                comboBox1.DataSource = LangCodesDS.Tables[0];
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
            }

            if (File.Exists("settings.json"))
            {
                string json = File.ReadAllText("settings.json", Encoding.UTF8);
                Dictionary<string, string> settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                stblNameFld.Text = settings["stblFileName"];
            }
        }

        private void stblNameFld_TextChanged(object sender, EventArgs e)
        {
            var s = FNVHasherDLL.FNVHasherStrFunctions.fnv64HighBitHexString(stblNameFld.Text);

            string fn = s.Replace("0x", "");
            fn = fn.Substring(2);

            string langCode = comboBox1.SelectedValue.ToString();
            langCode = langCode.Substring(2);

            s = langCode + fn;

            calculatedHashOfNameFld.Text = "0x" + s;

            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("stblFileName", stblNameFld.Text);

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText("settings.json", json, Encoding.UTF8);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (calculatedHashOfNameFld.Text.Length < 5)
            {
                MessageBox.Show("Enter file name!");
            }
            else
            {
                string fn = calculatedHashOfNameFld.Text.Replace("0x", "");
                fn = fn.Substring(2);

                string langCode = comboBox1.SelectedValue.ToString();
                langCode = langCode.Substring(2);

                fn = langCode + fn;

                saveFileDialog1.FileName = "S4_220557DA_80000000_" + fn + "_" + stblNameFld.Text + "%%+STBL.stbl";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(saveFileDialog1.FileName);

                    if (mainUI.pathOpened)
                    {
                        mainUI.saveSTBL();
                        mainUI.closeSTBL();
                        mainUI.SavePackage();
                        mainUI.closePackage();
                    }

                    mainUI.publicPath = saveFileDialog1.FileName;
                    mainUI.SaveSTBL_V2(false);
                    mainUI.openSTBLfile(saveFileDialog1.FileName);
                    this.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = FNVHasherDLL.FNVHasherStrFunctions.fnv64HighBitHexString(stblNameFld.Text);

            string fn = s.Replace("0x", "");
            fn = fn.Substring(2);

            string langCode = comboBox1.SelectedValue.ToString();
            langCode = langCode.Substring(2);

            s = langCode + fn;

            calculatedHashOfNameFld.Text = "0x" + s;
        }
    }
}
