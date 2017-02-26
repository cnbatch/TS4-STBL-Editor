using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    public partial class StringPicker : Form
    {
        private AddString addstr;

        public StringPicker(AddString addstrInp)
        {
            addstr = addstrInp;
            InitializeComponent();
        }

        private void StringPicker_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.List;
            //listView1.View = View.Details;
            for (int x = 0; x < MainUI.strHolders.Count; x++)
            {
                StringHolder sh = MainUI.strHolders[x];
                listView1.Items.Add(sh.textIDFld + " - " + sh.displayTextFld);

            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                addstr.setFldsValues(MainUI.strHolders[listView1.SelectedIndices[0]]);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            addstr.setFldsValues(MainUI.strHolders[listView1.SelectedIndices[0]]);

            this.Close();
        }
    }
}
