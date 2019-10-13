using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    class MyDataGridView : System.Windows.Forms.DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            //MessageBox.Show("Key Press Detected");

            //if ((keyData == (Keys.Alt | Keys.S)))
            if ((keyData == (Keys.Delete)))
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewCell c in this.SelectedCells)
                {
                    if (!rows.Contains(c.OwningRow))
                    {
                        rows.Add(c.OwningRow);
                    }

                }


                var confirmResult = MessageBox.Show("Are you sure to delete selected items?",
                                        "Confirm Delete!",
                                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (rows.Count() > 0)
                    {
                        foreach (var r in rows)
                        {
                            //MessageBox.Show(r.Cells[0].Value.ToString());
                            this.Rows.RemoveAt(r.Index);
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
