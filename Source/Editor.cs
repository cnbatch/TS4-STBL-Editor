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
        private DataGridViewSettings settings0 = new DataGridViewSettings();
        private DataGridViewSettings settings1 = new DataGridViewSettings();
        private DataGridViewSettings settings2 = new DataGridViewSettings();

        public DataGridView tempDataGridView;
        public delegate void UpdateProgressBar(double num);
        public UpdateProgressBar updateProgressBar;
        public DataTable dataTable;
        public bool isTextChanged = false;

        public Editor()
        {
            InitializeComponent();
        }
        private void Editor_Load(object sender, EventArgs e)
        {
            DataTable mainDataTable = new DataTable();

            DataColumn dc;
            dc = new DataColumn(dataGridView1.Columns[0].HeaderText);
            mainDataTable.Columns.Add(dc);
            dc = new DataColumn(dataGridView1.Columns[1].HeaderText);
            mainDataTable.Columns.Add(dc);
            dc = new DataColumn(dataGridView1.Columns[2].HeaderText);
            mainDataTable.Columns.Add(dc);
            DataRow dr;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dr = mainDataTable.NewRow();
                dr[0] = dataTable.Rows[i][0];
                dr[1] = dataTable.Rows[i][1];
                dr[2] = dataTable.Rows[i][1];
                mainDataTable.Rows.Add(dr);
            }

            settings0.StoreSettings(dataGridView1, 0);
            settings1.StoreSettings(dataGridView1, 1);
            settings2.StoreSettings(dataGridView1, 2);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = mainDataTable;

            RestoreDataGridViewSettings();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
                updateProgressBar((double)row.Index / (double)dataTable.Rows.Count);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable tempDataTable = dataTable.Clone();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempDataTable.Rows.Add();
                    tempDataTable.Rows[i][0] = dt.Rows[i][0];
                    tempDataTable.Rows[i][1] = dt.Rows[i][2];
                }

                dataTable.Rows.Clear();
                dataTable = tempDataTable.Copy();
            }
            isTextChanged = true;
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
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = addString.textID;
                dr[2] = addString.dataGridText;
                dt.Rows.Add(dr);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].HeaderCell.Value = (dataGridView1.Rows.Count).ToString();
            }
            addString.Dispose();
        }

        private void RestoreDataGridViewSettings()
        {
            dataGridView1.Columns[0].AutoSizeMode = settings0.autoSizeColumnMode;
            dataGridView1.Columns[0].DefaultCellStyle = settings0.cellStyle;
            dataGridView1.Columns[0].DefaultHeaderCellType = settings0.defaultHeaderCellType;
            dataGridView1.Columns[0].Frozen = settings0.frozen;
            dataGridView1.Columns[0].HeaderText = settings0.headerText;
            dataGridView1.Columns[0].MinimumWidth = settings0.minimumWidth;
            dataGridView1.Columns[0].Name = settings0.name;
            dataGridView1.Columns[0].ReadOnly = settings0.readOnly;
            dataGridView1.Columns[0].Resizable = settings0.resizable;
            dataGridView1.Columns[0].SortMode = settings0.sortMode;
            dataGridView1.Columns[0].Width = settings0.width;

            dataGridView1.Columns[1].AutoSizeMode = settings1.autoSizeColumnMode;
            dataGridView1.Columns[1].DefaultCellStyle = settings1.cellStyle;
            dataGridView1.Columns[1].DefaultHeaderCellType = settings1.defaultHeaderCellType;
            dataGridView1.Columns[1].Frozen = settings1.frozen;
            dataGridView1.Columns[1].HeaderText = settings1.headerText;
            dataGridView1.Columns[1].MinimumWidth = settings1.minimumWidth;
            dataGridView1.Columns[1].Name = settings1.name;
            dataGridView1.Columns[1].ReadOnly = settings1.readOnly;
            dataGridView1.Columns[1].Resizable = settings1.resizable;
            dataGridView1.Columns[1].SortMode = settings1.sortMode;
            dataGridView1.Columns[1].Width = settings1.width;

            dataGridView1.Columns[2].AutoSizeMode = settings2.autoSizeColumnMode;
            dataGridView1.Columns[2].DefaultCellStyle = settings2.cellStyle;
            dataGridView1.Columns[2].DefaultHeaderCellType = settings2.defaultHeaderCellType;
            dataGridView1.Columns[2].Frozen = settings2.frozen;
            dataGridView1.Columns[2].HeaderText = settings2.headerText;
            dataGridView1.Columns[2].MinimumWidth = settings2.minimumWidth;
            dataGridView1.Columns[2].Name = settings2.name;
            dataGridView1.Columns[2].ReadOnly = settings2.readOnly;
            dataGridView1.Columns[2].Resizable = settings2.resizable;
            dataGridView1.Columns[2].SortMode = settings2.sortMode;
            dataGridView1.Columns[2].Width = settings2.width;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("Value " +
                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
                    " - " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() +
                    " copied!");

                StringHolder sh = new StringHolder();
                sh.textIDFld = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sh.displayTextFld = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                MainUI.strHolders.Add(sh);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < MainUI.strHolders.Count; x++)
            {
                StringHolder sh = MainUI.strHolders[x];

                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = sh.textIDFld;
                dr[2] = sh.displayTextFld;
                dt.Rows.Add(dr);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].HeaderCell.Value = (dataGridView1.Rows.Count).ToString();

            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringPicker sp = new StringPicker(null);
            sp.Show();
        }
    }
}
