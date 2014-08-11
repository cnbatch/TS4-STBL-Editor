using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace TS4_STBL_Editor
{
    public partial class Editor : Form
    {
        public DataGridView tempDataGridView;

        public Editor()
        {
            InitializeComponent();
            tempDataGridView = new DataGridView();
            tempDataGridView.Columns.Add("Column1", "Text ID");
            tempDataGridView.Columns.Add("Column2", "Display Text");
            tempDataGridView.AllowUserToAddRows = false;
            tempDataGridView.AllowUserToDeleteRows = false;
            tempDataGridView.AllowUserToOrderColumns = false;
        }

        public void InitialDataGridView(DataGridView mainDataGridView)
        {
            if (mainDataGridView.Rows.Count != 0)
            {
                dataGridView1.Rows.Add(mainDataGridView.Rows.Count);

                for (int i = 0; i < mainDataGridView.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = mainDataGridView.Rows[i].Cells[0].Value;
                    dataGridView1.Rows[i].Cells[1].Value = mainDataGridView.Rows[i].Cells[1].Value;
                    dataGridView1.Rows[i].Cells[2].Value = mainDataGridView.Rows[i].Cells[1].Value;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                tempDataGridView.Rows.Add(dataGridView1.Rows.Count);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tempDataGridView.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value;
                    tempDataGridView.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[2].Value;
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddString addString = new AddString();
            addString.ShowDialog();
            if (addString.isOK)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = addString.textID;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = addString.dataGridText;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].HeaderCell.Value = (dataGridView1.Rows.Count).ToString();
            }
            addString.Dispose();
        }
    }
}
