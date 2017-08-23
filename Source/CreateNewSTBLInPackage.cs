using Newtonsoft.Json;
using s4pi.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class CreateNewSTBLInPackage : Form
    {
        MainUI mainUI;
        public CreateNewSTBLInPackage(MainUI mainUI)
        {
            InitializeComponent();
            this.mainUI = mainUI;
        }

        private void CreateNewSTBLInPackage_Load(object sender, EventArgs e)
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

                UInt64 fnU = Convert.ToUInt64(fn, 16);
                //ulong a = (ulong)FNVHasherStrFunctions.fnv64HighBit("qqqq");

                TGIBlock newnmrk = new TGIBlock(0,
                    null,
                    0x220557DA,
                    0x80000000,
                    fnU);
                Stream s = new MemoryStream();

                List<uint> textResourceID = new List<uint>();
                List<string> textString = new List<string>();

                ArrayList tempList = new ArrayList();

                tempList.Add(textResourceID);
                tempList.Add(textString);

                mainUI.WriteSTBLStream(tempList, s);
                var addedResIndexEntry = MainUI.imppkg.AddResource(newnmrk, s, true);
                MainUI.lrie.Add(addedResIndexEntry);

                BigInteger bi = BigInteger.Parse(addedResIndexEntry.Instance.ToString());
                MainUI.packageElId = bi;

                ArrayList textResourceID2 = new ArrayList();
                ArrayList textString2 = new ArrayList();

                tempList = new ArrayList();

                tempList.Add(textResourceID2);
                tempList.Add(textString2);

                mainUI.STBLToDataGridView(tempList);

                MainUI.imppkg.SavePackage();
                MainUI.imppkg.Dispose();

                mainUI.openPackageFile(MainUI.pathToOpenedPackageFile);

                //this.Close();

                MessageBox.Show("Successfully done!");

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
