using FNVHasherDLL;
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
    public partial class AddMultipleStrings : Form
    {
        public bool isOK = false;
        public Dictionary<string, string> translations = new Dictionary<string, string>();

        public AddMultipleStrings()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            foreach (var line in richTextBox1.Lines)
            {
                if (line.Length < 1)
                {
                    continue;
                }
                var hash = FNVHasherStrFunctions.fnv32HexString(line).Replace("0x", "");
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = hash;
                row.Cells[1].Value = line;
                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow line in dataGridView1.Rows)
            {
                if (line.Cells[1].Value != null)
                    translations["0x" + line.Cells[0].Value.ToString()] = line.Cells[1].Value.ToString();
            }
            isOK = true;

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow line in dataGridView1.Rows)
            {
                if (line.Cells[1].Value != null)
                {
                    var sh = new StringHolder();
                    sh.textIDFld = "0x" + line.Cells[0].Value.ToString();
                    sh.displayTextFld = line.Cells[1].Value.ToString();

                    MainUI.copiedValuesStrHolders.Add(sh);
                }
            }
            isOK = true;

            Close();
        }
    }
}
