using FNVHasherDLL;
using s4pi.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        private void calculatedHashOfNameFld_TextChanged(object sender, EventArgs e)
        {


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

                uint fnU=0;

                UInt64 fnU2 = Convert.ToUInt64(fn, 16);
                //ulong a = (ulong)FNVHasherStrFunctions.fnv64HighBit("qqqq");

                TGIBlock newnmrk = new TGIBlock(0,
                    null,
                    0x220557DA,
                    0x80000000,
                    fnU2);
                Stream s = new MemoryStream();

                List<uint> textResourceID = new List<uint>();
                List<string> textString = new List<string>();

                ArrayList tempList = new ArrayList();

                tempList.Add(textResourceID);
                tempList.Add(textString);

                mainUI.WriteSTBLStream(tempList, s);
                MainUI.imppkg.AddResource(newnmrk, s, true);
                MainUI.imppkg.SavePackage();
                MainUI.imppkg.Dispose();

                this.Close();

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
