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
            reloadListView();
        }

        private void reloadListView()
        {
            listView1.Items.Clear();
            listView1.View = View.List;
            for (int x = 0; x < MainUI.copiedValuesStrHolders.Count; x++)
            {
                StringHolder sh = MainUI.copiedValuesStrHolders[x];
                listView1.Items.Add(sh.textIDFld + " - " + sh.displayTextFld);

            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (addstr != null)
                    {
                        addstr.setFldsValues(MainUI.copiedValuesStrHolders[listView1.SelectedIndices[0]]);
                    }
                }
                else
                {
                    MainUI.copiedValuesStrHolders.RemoveAt(listView1.SelectedIndices[0]);
                    reloadListView();
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (addstr != null)
            {
                addstr.setFldsValues(MainUI.copiedValuesStrHolders[listView1.SelectedIndices[0]]);
            }

            this.Close();
        }
    }
}
