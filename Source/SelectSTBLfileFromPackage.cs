using s4pi.Interfaces;
using s4pi.WrapperDealer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class SelectSTBLfileinPackage : Form
    {
        List<IResourceIndexEntry> lrie;
        IPackage imppkg;

        public List<string> selectedSTBLObjects = new List<string>();

        public SelectSTBLfileinPackage(List<IResourceIndexEntry> lrieInp, IPackage imppkgInp, bool allowMultiSelection)
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

                String fileName = "0x" + bi.ToString("X");
                listBox1.Items.Add(fileName);
            }
        }

        private void getSelectedItemsAndCloseForm()
        {
            foreach (string a in listBox1.SelectedItems)
            {
                selectedSTBLObjects.Add(a);
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
    }
}
