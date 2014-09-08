using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace TS4_STBL_Editor
{
	public partial class MainUI : Form
	{
		private DataGridViewSettings settings0 = new DataGridViewSettings();
		private DataGridViewSettings settings1 = new DataGridViewSettings();

		public MainUI()
		{
			InitializeComponent();

			toolTip1.AutoPopDelay = 5000;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 500;
			toolTip1.ShowAlways = true;

			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
					toolTip1.SetToolTip(this.button1, "在新窗口中编辑");
					toolTip1.SetToolTip(this.button2, "导出到XML文件");
					toolTip1.SetToolTip(this.button3, "从XML文件导入");
					break;
				case "CHT":
					toolTip1.SetToolTip(this.button1, "在新視窗中編輯");
					toolTip1.SetToolTip(this.button2, "匯出到XML檔案");
					toolTip1.SetToolTip(this.button3, "從XML檔案匯入");
					break;
				default:
					toolTip1.SetToolTip(this.button1, "Edit in a new Window");
					toolTip1.SetToolTip(this.button2, "Export to XML file");
					toolTip1.SetToolTip(this.button3, "Import from XML file");
					break;
			}

			settings0.StoreSettings(dataGridView1, 0);
			settings1.StoreSettings(dataGridView1, 1);
		}

		private string publicPath = string.Empty;
		private bool pathOpened = false;

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void openPackageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string stblFilePath = string.Empty;
			bool fileIsOpened = false;

			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
				case "ZHI":
					openFileDialog1.Filter = "STBL文件 (*.stbl)|*.stbl|所有文件 (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "选择STBL文件";
					break;
				case "CHT":
				case "ZHH":
				case "ZHM":
					openFileDialog1.Filter = "STBL檔案 (*.stbl)|*.stbl|所有檔案 (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "選取STBL檔案";
					break;
				default:
					openFileDialog1.Filter = "STBL Files (*.stbl)|*.stbl|All Files (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "Choose STBL File";
					break;
			}

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				stblFilePath = openFileDialog1.FileName;
				toolStripStatusLabel2.Text = stblFilePath;
				publicPath = stblFilePath;
				pathOpened = fileIsOpened = true;
			}
			else
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						toolStripStatusLabel2.Text = "未打开任何文件。";
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						toolStripStatusLabel2.Text = "未開啟任何檔案。";
						break;
					default:
						toolStripStatusLabel2.Text = "No file is opened.";
						break;
				}
				pathOpened = false;
			}

			if (fileIsOpened)
			{
				UseWaitCursor = true;
				progressBar1.Visible = true;
				progressBar1.Value = 0;

				ArrayList tempList = ReadAndAnalyze(stblFilePath);
				STBLToDataGridView(tempList);

				UseWaitCursor = false;
				progressBar1.Visible = false;
			}
		}

		private void savePackageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveSTBLFile(false);
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveSTBLFile(true);
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AboutEditorForm about = new AboutEditorForm();
			about.ShowDialog();
			about.Dispose();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Editor stblEditor = new Editor();
			progressBar1.Visible = true;
			progressBar1.Value = 0;

			stblEditor.updateProgressBar = delegate(double i)
			{
				progressBar1.Value = (int)(progressBar1.Maximum * i);
			};

			DataTable dataTable = (DataTable)dataGridView1.DataSource;

			if (dataGridView1.Rows.Count != 0)
			{
				stblEditor.dataTable = dataTable;
				progressBar1.Visible = false;
			}
			stblEditor.ShowDialog();
			dataGridView1.DataSource = stblEditor.dataTable;

			for (int k = 0; k < dataGridView1.Rows.Count; k++)
			{
				dataGridView1.Rows[k].HeaderCell.Value = (k + 1).ToString();
			}

			stblEditor.Dispose();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count == 0)
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("没有东西可以导出", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
						MessageBox.Show("沒有東西可以匯出", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "ZHH":
					case "ZHM":
						MessageBox.Show("無嘢可以匯出", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("Nothing can be exported.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				return;
			}

			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
				case "ZHI":
					saveFileDialog1.Filter = "XML文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
					saveFileDialog1.FilterIndex = 1;
					saveFileDialog1.Title = "从XML文件导入";
					break;
				case "CHT":
				case "ZHH":
				case "ZHM":
					saveFileDialog1.Filter = "XML檔案 (*.xml)|*.xml|所有檔案 (*.*)|*.*";
					saveFileDialog1.FilterIndex = 1;
					saveFileDialog1.Title = "匯出到XML檔案";
					break;
				default:
					saveFileDialog1.Filter = "XML File (*.xml)|*.xml|All File (*.*)|*.*";
					saveFileDialog1.FilterIndex = 1;
					saveFileDialog1.Title = "Export to XML File";
					break;
			}

			ArrayList textResourceIDInString = new ArrayList();
			ArrayList textString = new ArrayList();

			string hexText;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				hexText = ((string)dataGridView1.Rows[i].Cells[0].Value).Replace("0x", "");
				textResourceIDInString.Add(hexText);
				textString.Add(dataGridView1.Rows[i].Cells[1].Value);
			}

			ArrayList tempList = new ArrayList();
			tempList.Add(textResourceIDInString);
			tempList.Add(textString);

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				WriteXML(saveFileDialog1.FileName, tempList);

		}

		private void button3_Click(object sender, EventArgs e)
		{
			string xmlFilePath;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
				case "ZHI":
					openFileDialog1.Filter = "XML文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "从XML文件导入";
					break;
				case "CHT":
				case "ZHH":
				case "ZHM":
					openFileDialog1.Filter = "XML檔案 (*.xml)|*.xml|所有檔案 (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "從XML檔案匯入";
					break;
				default:
					openFileDialog1.Filter = "XML File (*.xml)|*.xml|All File (*.*)|*.*";
					openFileDialog1.FilterIndex = 1;
					openFileDialog1.Title = "Import from XML File";
					break;
			}

			ArrayList tempList = new ArrayList();

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				xmlFilePath = openFileDialog1.FileName;
				tempList = ReadXML(xmlFilePath);
			}
			else return;

			if (!(bool)tempList[2])
			{
				return;
			}

			UseWaitCursor = true;
			progressBar1.Visible = true;
			progressBar1.Value = 0;

			XMLToDataGridView(tempList, xmlFilePath);

			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
				case "ZHI":
					MessageBox.Show("导入成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				case "CHT":
				case "ZHH":
				case "ZHM":
					MessageBox.Show("匯入成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				default:
					MessageBox.Show("Successfully Imported!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
			}

			UseWaitCursor = false;
			progressBar1.Visible = false;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//dataGridView1.Rows.Clear();
			dataGridView1.DataSource = null;
			dataGridView1.Columns.Add("Column1", "");
			dataGridView1.Columns.Add("Column2", "");
			RestoreDataGridViewSettings();

			switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
			{
				case "CHS":
				case "ZHI":
					toolStripStatusLabel2.Text = "未打开任何文件。";
					break;
				case "CHT":
				case "ZHH":
				case "ZHM":
					toolStripStatusLabel2.Text = "未開啟任何檔案。";
					break;
				default:
					toolStripStatusLabel2.Text = "No file is opened.";
					break;
			}
			publicPath = string.Empty;
			pathOpened = false;
		}
	}
}
