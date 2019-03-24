using s4pi.Interfaces;
using s4pi.WrapperDealer;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class SelectSTBLfileFromPackage : Form
    {
        List<IResourceIndexEntry> lrie;
        IPackage imppkg;

        public List<string> selectedSTBLObjects = new List<string>();

        public SelectSTBLfileFromPackage(List<IResourceIndexEntry> lrieInp, IPackage imppkgInp, bool allowMultiSelection)
        {
            InitializeComponent();

            if (allowMultiSelection)
            {
                listBox1.SelectionMode = SelectionMode.MultiExtended;
            }

            this.lrie = lrieInp;
            this.imppkg = imppkgInp;

            foreach (IResourceIndexEntry rie in lrie)
            {
                IResource res = WrapperDealer.GetResource(0, imppkg, rie, true);
                BigInteger bi = BigInteger.Parse(rie.Instance.ToString());

                String fileName = "0x" + (bi.ToString("X").Length < 16 ? "0" + bi.ToString("X") : bi.ToString("X"));

                String fileNameLang = fileName.Substring(0, 4);
                switch (fileNameLang)
                {
                    case "0x00":
                        fileName = "ENG_US " + fileName;
                        break;
                    case "0x02":
                        fileName = "CHT_CN " + fileName;
                        break;
                    case "0x03":
                        fileName = "CZE_CZ " + fileName;
                        break;
                    case "0x04":
                        fileName = "DAN_DK " + fileName;
                        break;
                    case "0x05":
                        fileName = "DUT_NL " + fileName;
                        break;
                    case "0x06":
                        fileName = "FIN_FI " + fileName;
                        break;
                    case "0x07":
                        fileName = "FRE_FR " + fileName;
                        break;
                    case "0x08":
                        fileName = "GER_DE " + fileName;
                        break;
                    case "0x0B":
                        fileName = "ITA_IT " + fileName;
                        break;
                    case "0x0C":
                        fileName = "JPN_JP " + fileName;
                        break;
                    case "0x0D":
                        fileName = "KOR_KR " + fileName;
                        break;
                    case "0x0E":
                        fileName = "NOR_NO " + fileName;
                        break;
                    case "0x0F":
                        fileName = "POL_PL " + fileName;
                        break;
                    case "0x11":
                        fileName = "POR_BR " + fileName;
                        break;
                    case "0x12":
                        fileName = "RUS_RU " + fileName;
                        break;
                    case "0x13":
                        fileName = "SPA_ES " + fileName;
                        break;
                    case "0x15":
                        fileName = "SWE_SE " + fileName;
                        break;
                }
                listBox1.Items.Add(fileName);
            }
        }

        private void getSelectedItemsAndCloseForm()
        {
            foreach (string a in listBox1.SelectedItems)
            {
                String a1 = a.Substring(7);
                selectedSTBLObjects.Add(a1);
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getSelectedItemsAndCloseForm();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            getSelectedItemsAndCloseForm();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else
            {
                if ((keyData & Keys.Control) == Keys.Control && (keyData & Keys.A) == Keys.A)  // Ctrl-A
                {
                    for (int x = 0; x < listBox1.Items.Count; x++)
                    {
                        listBox1.SetSelected(x, true);
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
