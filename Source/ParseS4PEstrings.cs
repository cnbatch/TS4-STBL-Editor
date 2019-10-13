using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TS4_STBL_Editor
{
    public partial class ParseS4PEstrings : Form
    {
        public ParseS4PEstrings()
        {
            InitializeComponent();
        }

        private void ParseS4PEstrings_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] strings = richTextBox1.Lines;

            String tmpFilePath = Path.GetTempPath() + "translationTmp.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement listElem = (XmlElement)doc.AppendChild(doc.CreateElement("STBLKeyStringList"));

            foreach (string str in strings)
            {
                String strTmp = str.Substring(str.IndexOf(" Key ") + 5);
                String key = strTmp.Substring(0, strTmp.IndexOf(","));

                key = key.Replace("0x", "");

                strTmp = strTmp.Substring(strTmp.IndexOf(",") + 1);
                String value = strTmp.Substring(strTmp.IndexOf(" : ") + 3);

                XmlElement trElem = (XmlElement)listElem.AppendChild(doc.CreateElement("Text"));
                trElem.SetAttribute("Key", key);
                trElem.InnerText = value;

            }

            var fs = new FileStream(tmpFilePath, FileMode.Create);
            doc.Save(fs);
            fs.Close();

            string xmlFilePath;


            ArrayList tempList = new ArrayList();

            xmlFilePath = tmpFilePath;
            tempList = Program.mainUI.ReadXML(xmlFilePath);

            if (!(bool)tempList[2])
            {
                return;
            }

            Program.mainUI.UseWaitCursor = true;
            Program.mainUI.progressBar1.Visible = true;
            Program.mainUI.progressBar1.Value = 0;

            Program.mainUI.XMLToDataGridView(tempList, xmlFilePath);

            Program.mainUI.UseWaitCursor = false;
            Program.mainUI.progressBar1.Visible = false;
            if (!Program.mainUI.pathOpened)
                Program.mainUI.canAlsoSave = true;
            else Program.mainUI.canAlsoSave = false;
            Program.mainUI.isTextChanged = true;

            this.Close();

        }
    }
}
