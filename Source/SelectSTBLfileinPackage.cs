using s4pi.Interfaces;
using s4pi.WrapperDealer;
using System;
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

        public string selectedElement = null;

        public SelectSTBLfileinPackage(List<IResourceIndexEntry> lrieInp, IPackage imppkgInp)
        {
            InitializeComponent();

            this.lrie = lrieInp;
            this.imppkg = imppkgInp;

            foreach (IResourceIndexEntry rie in lrie)
            {
                IResource res = WrapperDealer.GetResource(0, imppkg, rie, true);

                BigInteger bi = BigInteger.Parse(rie.Instance.ToString());

                String fileName = "0x"+bi.ToString("X");


                listBox1.Items.Add(fileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedElement = listBox1.SelectedItem.ToString();
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            selectedElement = listBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
