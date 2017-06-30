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
using FNVHasherDLL;
using System.Numerics;

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

        private void saveAndExit()
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

        private void OKBtn_Click(object sender, EventArgs e)
        {
            saveAndExit();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_New_String_Click(object sender, EventArgs e)
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

                MainUI.copiedValuesStrHolders.Add(sh);
            }
        }

        private void Paste_ALL_copied_values_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < MainUI.copiedValuesStrHolders.Count; x++)
            {
                StringHolder sh = MainUI.copiedValuesStrHolders[x];

                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = sh.textIDFld;
                dr[2] = sh.displayTextFld;
                dt.Rows.Add(dr);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].HeaderCell.Value = (dataGridView1.Rows.Count).ToString();

            }
        }

        private void Show_copied_values_Click(object sender, EventArgs e)
        {
            StringPicker sp = new StringPicker(null);
            sp.Show();
        }

        private void Copy_Values_By_IDs_Click(object sender, EventArgs e)
        {
            string idsStr = "";
            if (ShowInputDialog(ref idsStr) == DialogResult.OK)
            {
                string[] idsArray = idsStr.Split(new string[] { "," }, StringSplitOptions.None);
                for (int x = 0; x < idsArray.Length; x++)
                {
                    string id = idsArray[x];
                    if (id.Length > 3)
                    {

                        if (id.StartsWith("0x") || id.StartsWith("0X"))
                        {
                            id = id.Replace("0X", "0x");
                        }
                        else
                        {
                            id = FNVHasherStrFunctions.decimalToHex(id);
                        }

                        if (dataGridView1.Rows.Count != 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(id))
                                {
                                    dataGridView1.Rows[i].Selected = true;
                                }
                            }

                        }
                    }
                }
                CopySelectedRows();
            }
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter ids, comma separated";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void CopySelectedRows()
        {
            for (int x = 0; x < dataGridView1.SelectedRows.Count; x++)
            {
                StringHolder sh = new StringHolder();
                sh.textIDFld = dataGridView1.SelectedRows[x].Cells[0].Value.ToString();
                sh.displayTextFld = dataGridView1.SelectedRows[x].Cells[1].Value.ToString();

                MainUI.copiedValuesStrHolders.Add(sh);
            }

            MessageBox.Show(dataGridView1.SelectedRows.Count + " rows copied!");
        }

        private void deleteThisElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cell = contextMenuStrip1.Tag as DataGridViewCell;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                if (!rows.Contains(c.OwningRow))
                {
                    rows.Add(c.OwningRow);
                }

            }

            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                        "Confirm Delete!!",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (rows.Count() > 1)
                {
                    foreach (var r in rows)
                    {
                        //MessageBox.Show(r.Cells[0].Value.ToString());
                        dataGridView1.Rows.RemoveAt(r.Index);
                    }
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(cell.OwningRow.Index);
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell.OwningRow.Selected = true;
                contextMenuStrip1.Tag = dataGridView1.CurrentCell;
                contextMenuStrip1.Show(dataGridView1, e.Location);
            }

        }

        private void copyThisRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cell = contextMenuStrip1.Tag as DataGridViewCell;
            var row = cell.OwningRow;
            StringHolder sh = new StringHolder();
            sh.textIDFld = row.Cells[0].Value.ToString();
            sh.displayTextFld = row.Cells[1].Value.ToString();

            MainUI.copiedValuesStrHolders.Add(sh);
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
                if ((keyData & Keys.Control) == Keys.Control && (keyData & Keys.S) == Keys.S)  // Ctrl-S Save
                {
                    saveAndExit();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void copySelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedRows();
        }
    }
}
