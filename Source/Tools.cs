using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Globalization;
using System.Threading;

namespace TS4_STBL_Editor
{
	public partial class MainUI : Form
	{
		public ArrayList ReadAndAnalyze(string stblFilePath)
		{
			ArrayList useForReturn = new ArrayList();

			FileStream stblStream = new FileStream(stblFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			BinaryReader stblReader = new BinaryReader(stblStream);

			if ((char)stblReader.ReadByte() != 'S' || (char)stblReader.ReadByte() != 'T' || (char)stblReader.ReadByte() != 'B' || (char)stblReader.ReadByte() != 'L')
			{
				stblStream.Dispose();
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("这个不是STBL文件。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
						MessageBox.Show("這個不是STBL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "ZHH":
					case "ZHM":
						MessageBox.Show("呢個唔係STBL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("This is not a STBL file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				return useForReturn;
			}

			uint version = (uint)stblReader.ReadByte();
			if (version == 2)
			{
				stblStream.Dispose();
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("这个是《模拟人生3》的STBL文件", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					case "CHT":
						MessageBox.Show("這個是《模擬市民3》的STBL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					case "ZHH":
					case "ZHM":
						MessageBox.Show("呢個係《模擬市民3》嘅STBL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					default:
						MessageBox.Show("This is a STBL file of The Sims 3.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
				}
				return useForReturn;
			}
			else if (version != 5)
			{
				stblStream.Dispose();
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("未知版本的SBTL文件。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					case "CHT":
						MessageBox.Show("未知版本的SBTL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					case "ZHH":
					case "ZHM":
						MessageBox.Show("唔知咩版本嘅SBTL檔案。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					default:
						MessageBox.Show("Unknow version of STBL.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
				}
				return useForReturn;
			}

			uint zeroZone = stblReader.ReadUInt16();
			uint entrynTotal = stblReader.ReadUInt32();
			zeroZone = stblReader.ReadUInt16();
			zeroZone = (uint)stblReader.ReadUInt32();

			long entrySize = stblReader.ReadUInt32();

			long verifySize = 0;
			int currentSize = 0;   // use for current entry size
			ArrayList textResourceID = new ArrayList();
			ArrayList currrentString = new ArrayList();


			for (int i = 0; i < entrynTotal; i++)
			{
				textResourceID.Add(stblReader.ReadUInt32());
				stblReader.ReadByte();  // zero byte
				currentSize = stblReader.ReadUInt16();
				currrentString.Add(Encoding.UTF8.GetString(stblReader.ReadBytes(currentSize)));
				verifySize = currentSize + verifySize + 1;
			}

			if (verifySize != entrySize)
			{
				stblStream.Dispose();
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("STBL文件读取失败。\n" + verifySize.ToString() + "\n" + entrynTotal.ToString(), "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("STBL檔案讀取失敗。\n" + verifySize.ToString() + "\n" + entrynTotal.ToString(), "出錯", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					default:
						MessageBox.Show("STBL file reads failed.\n" + verifySize.ToString() + "\n" + entrynTotal.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
				}
				return useForReturn;
			}

			stblStream.Dispose();

			useForReturn.Add(textResourceID);
			useForReturn.Add(currrentString);

			return useForReturn;
		}

		public string WriteSTBLFile(ArrayList mainArrayList, bool isSaveAs, string stblFilePath)
		{
			ArrayList textResourceID = (ArrayList)mainArrayList[0];
			ArrayList textString = (ArrayList)mainArrayList[1];

			byte[] stblLetter = new byte[5];
			stblLetter[0] = 0x53;   // S
			stblLetter[1] = 0x54;   // T
			stblLetter[2] = 0x42;   // B
			stblLetter[3] = 0x4C;   // L
			stblLetter[4] = 5;   // Version 5

			byte zero = 0;
			ushort zeroZone = 0;
			uint entrynTotal = (uint)textString.Count;

			ushort[] countBytes = new ushort[entrynTotal];

			uint entrySize = 0;

			// count bytes
			for (int i = 0; i < entrynTotal; i++)
			{
				countBytes[i] = (ushort)Encoding.UTF8.GetByteCount((string)textString[i]);
				entrySize = countBytes[i] + entrySize + 1;
			}

			MemoryStream stblMemoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(stblMemoryStream);

			binaryWriter.Write(stblLetter);

			binaryWriter.Write(zeroZone);
			binaryWriter.Write(entrynTotal);
			binaryWriter.Write(zeroZone);
			binaryWriter.Write(zeroZone);
			binaryWriter.Write(zeroZone);
			binaryWriter.Write(entrySize);

			for (int i = 0; i < entrynTotal; i++)
			{
				binaryWriter.Write((uint)textResourceID[i]);
				binaryWriter.Write(zero);
				binaryWriter.Write(countBytes[i]);
				binaryWriter.Write(((string)textString[i]).ToCharArray());
			}

			if (isSaveAs || canAlsoSave)
			{
				SaveFileDialog SaveFile = new SaveFileDialog();
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						SaveFile.Filter = "STBL文件 (*.stbl)|*.stbl|所有文件 (*.*)|*.*";
						SaveFile.FilterIndex = 1;
						SaveFile.Title = "保存STBL文件";
						SaveFile.FileName = stblFilePath;
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						SaveFile.Filter = "STBL檔案 (*.stbl)|*.stbl|所有檔案 (*.*)|*.*";
						SaveFile.FilterIndex = 1;
						SaveFile.Title = "儲存STBL檔案";
						SaveFile.FileName = stblFilePath;
						break;
					default:
						SaveFile.Filter = "STBL Files (*.stbl)|*.stbl|All Files (*.*)|*.*";
						SaveFile.FilterIndex = 1;
						SaveFile.Title = "Save STBL File";
						SaveFile.FileName = stblFilePath;
						break;
				}
				if (SaveFile.ShowDialog() == DialogResult.OK)
				{
					stblFilePath = SaveFile.FileName;
				}
				else
				{
					stblMemoryStream.Dispose();
					return stblFilePath;
				}
			}

			FileStream stblStream = new FileStream(stblFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
			BinaryWriter stblFileWriter = new BinaryWriter(stblStream);
			stblFileWriter.Write(stblMemoryStream.ToArray());
			stblStream.Dispose();
			stblMemoryStream.Dispose();

			return stblFilePath;
		}

		public void WriteXML(string xmlFilePath, ArrayList mainArrayList)
		{
			ArrayList textResourceIDInString = (ArrayList)mainArrayList[0];
			ArrayList textString = (ArrayList)mainArrayList[1];

			XmlDocument translateXML = new XmlDocument();

			XmlNode rootNode = translateXML.CreateElement("STBLKeyStringList");
			translateXML.AppendChild(rootNode);
			translateXML.InsertBefore(translateXML.CreateXmlDeclaration("1.0", "UTF-8", "yes"), rootNode);

			XmlElement text;
			for (int i = 0; i < textResourceIDInString.Count; i++)
			{
				text = translateXML.CreateElement("Text");
				text.SetAttribute("Key", (string)textResourceIDInString[i]);
				text.InnerText = (string)textString[i];
				rootNode.AppendChild(text);
			}

			translateXML.AppendChild(rootNode);
			try
			{
				translateXML.Save(xmlFilePath);
			}
			catch
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("写入XML文件失败。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("寫入XML檔案失敗。", "出錯", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					default:
						MessageBox.Show("Failed to write XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
				}
			}
		}

		public ArrayList ReadXML(string xmlFilePath)
		{
			ArrayList textResourceID = new ArrayList();
			ArrayList textString = new ArrayList();
			bool readSuccess = false;

			XmlDocument translateXML = new XmlDocument();
			translateXML.Load(xmlFilePath);

			XmlNodeList stblxmlNodeList = translateXML.SelectNodes("/STBLKeyStringList/Text");

			try
			{
				for (int i = 0; i < stblxmlNodeList.Count; i++)
				{
					textResourceID.Add(Convert.ToUInt32(stblxmlNodeList[i].Attributes[0].Value, 16));
					textString.Add(stblxmlNodeList[i].InnerText);
				}
				readSuccess = true;

			}
			catch (Exception)
			{
				readSuccess = false;
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("读取XML文件失败。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("讀取XML檔案失敗。", "出錯", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					default:
						MessageBox.Show("Failed to write XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
				}
				//throw;
			}

			ArrayList mainArrayList = new ArrayList();
			mainArrayList.Add(textResourceID);
			mainArrayList.Add(textString);
			mainArrayList.Add(readSuccess);

			return mainArrayList;
		}

		public void SaveSTBLFile(bool isSaveAs)
		{
			if (dataGridView1.Rows.Count == 0) return;

			ArrayList textResourceID = new ArrayList();
			ArrayList textString = new ArrayList();

			uint convert = 0;
			string hexText;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				hexText = ((string)dataGridView1.Rows[i].Cells[0].Value).Replace("0x", "");
				convert = Convert.ToUInt32(hexText, 16);
				textResourceID.Add(convert);
				textString.Add(dataGridView1.Rows[i].Cells[1].Value);
			}

			ArrayList tempList = new ArrayList();
			tempList.Add(textResourceID);
			tempList.Add(textString);

			publicPath = WriteSTBLFile(tempList, isSaveAs, publicPath);
			filenameLabel.Text = publicPath;
			pathOpened = true;
		}

		public void STBLToDataGridView(ArrayList tempList)
		{
			if (tempList.Count == 0)
			{
				UseWaitCursor = false;
				progressBar1.Visible = false;
				return;
			}

			ArrayList textResourceID = (ArrayList)tempList[0];
			ArrayList textString = (ArrayList)tempList[1];

			DataTable dataTable = new DataTable();
			DataColumn dc;
			DataRow dr;
			dc = new DataColumn(dataGridView1.Columns[0].HeaderText);
			dataTable.Columns.Add(dc);
			dc = new DataColumn(dataGridView1.Columns[1].HeaderText);
			dataTable.Columns.Add(dc);

			for (int i = 0; i < textResourceID.Count; i++)
			{
				dr = dataTable.NewRow();
				dr[0] = "0x" + ((uint)textResourceID[i]).ToString("X8");
				dr[1] = textString[i];
				dataTable.Rows.Add(dr);
			}


			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = dataTable;
			RestoreDataGridViewSettings();

			for (int i = 0; i < textString.Count; i++)
			{
				dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
				progressBar1.Value = progressBar1.Maximum * i / textString.Count;
			}
			progressBar1.Value = progressBar1.Maximum;
		}

		public void XMLToDataGridView(ArrayList tempList, string xmlFilePath)
		{
			ArrayList textResourceID = (ArrayList)tempList[0];
			ArrayList textString = (ArrayList)tempList[1];
			ArrayList dataGridViewTextResourceID = new ArrayList();

			uint convert = 0;
			int searchIndex = 0;

			if (dataGridView1.Rows.Count == 0)
			{
				DataTable dataTable = new DataTable();
				DataColumn dc;
				DataRow dr;
				dc = new DataColumn(dataGridView1.Columns[0].HeaderText);
				dataTable.Columns.Add(dc);
				dc = new DataColumn(dataGridView1.Columns[1].HeaderText);
				dataTable.Columns.Add(dc);

				for (int i = 0; i < textResourceID.Count; i++)
				{
					dr = dataTable.NewRow();
					dr[0] = "0x" + ((uint)textResourceID[i]).ToString("X8");
					dr[1] = textString[i];
					dataTable.Rows.Add(dr);
					progressBar1.Value = progressBar1.Maximum * i / textString.Count;
				}

				dataGridView1.Columns.Clear();
				dataGridView1.DataSource = dataTable;
				RestoreDataGridViewSettings();
			}
			else
			{
				int lastProgressBarValue = 0;
				DataGridView tempDataGridView = new DataGridView();
				tempDataGridView.Columns.Add("Column1", "Text ID");
				tempDataGridView.Columns.Add("Column2", "Display Text");
				tempDataGridView.Columns.Add("Column3", "Line Number");
				tempDataGridView.AllowUserToAddRows = false;
				tempDataGridView.AllowUserToDeleteRows = false;

				tempDataGridView.Rows.Add(dataGridView1.Rows.Count);

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					tempDataGridView.Rows[i].Cells[0].Value = ((string)dataGridView1.Rows[i].Cells[0].Value).Replace("0x", "");
					tempDataGridView.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value;
					tempDataGridView.Rows[i].Cells[2].Value = i.ToString("D6");
					progressBar1.Value = progressBar1.Maximum / 4 * i / dataGridView1.Rows.Count;
				}
				lastProgressBarValue = progressBar1.Value;

				tempDataGridView.Rows[0].Cells[0].Selected = true;
				tempDataGridView.Sort(tempDataGridView.Columns[0], ListSortDirection.Ascending);

				for (int i = 0; i < tempDataGridView.Rows.Count; i++)
				{
					convert = Convert.ToUInt32((string)tempDataGridView.Rows[i].Cells[0].Value, 16);
					dataGridViewTextResourceID.Add(convert);
					progressBar1.Value = lastProgressBarValue + progressBar1.Maximum / 4 * i / tempDataGridView.Rows.Count;
				}
				lastProgressBarValue = progressBar1.Value;

				for (int i = 0; i < textString.Count; i++)
				{
					searchIndex = dataGridViewTextResourceID.BinarySearch(textResourceID[i]);
					if (searchIndex >= 0)
					{
						tempDataGridView.Rows[searchIndex].Cells[1].Value = textString[i];
					}
					else
					{
						tempDataGridView.Rows.Add();
						tempDataGridView.Rows[(tempDataGridView.Rows.Count - 1)].Cells[0].Value = ((uint)textResourceID[i]).ToString();
						tempDataGridView.Rows[(tempDataGridView.Rows.Count - 1)].Cells[1].Value = textString[i];
						tempDataGridView.Rows[(tempDataGridView.Rows.Count - 1)].Cells[2].Value = i.ToString("D6");
					}
					progressBar1.Value = lastProgressBarValue + progressBar1.Maximum / 4 * i / textString.Count;
				}
				lastProgressBarValue = progressBar1.Value;

				tempDataGridView.Rows[0].Cells[2].Selected = true;
				tempDataGridView.Sort(tempDataGridView.Columns[2], ListSortDirection.Ascending);

				DataTable dataTable = new DataTable();
				DataColumn dc;
				DataRow dr;
				dc = new DataColumn(dataGridView1.Columns[0].HeaderText);
				dataTable.Columns.Add(dc);
				dc = new DataColumn(dataGridView1.Columns[1].HeaderText);
				dataTable.Columns.Add(dc);

				for (int i = 0; i < tempDataGridView.Rows.Count; i++)
				{
					dr = dataTable.NewRow();
					dr[0] = "0x" + tempDataGridView.Rows[i].Cells[0].Value;
					dr[1] = tempDataGridView.Rows[i].Cells[1].Value;
					dataTable.Rows.Add(dr);
					progressBar1.Value = lastProgressBarValue + progressBar1.Maximum / 4 * i / tempDataGridView.Rows.Count;
				}

				dataGridView1.Columns.Clear();
				dataGridView1.DataSource = dataTable;
				RestoreDataGridViewSettings();
			}

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value = (row.Index + 1).ToString();
			}

			progressBar1.Value = progressBar1.Maximum;
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
		}
	}

	public struct DataGridViewSettings
	{
		public DataGridViewAutoSizeColumnMode autoSizeColumnMode;
		public DataGridViewCellStyle cellStyle;
		public Type defaultHeaderCellType;
		public bool frozen;
		public string headerText;
		public int minimumWidth;
		public string name;
		public bool readOnly;
		public DataGridViewTriState resizable;
		public DataGridViewColumnSortMode sortMode;
		public int width;

		public void StoreSettings(DataGridView dataGridView1, int columnsIndex)
		{
			autoSizeColumnMode = dataGridView1.Columns[columnsIndex].AutoSizeMode;
			cellStyle = dataGridView1.Columns[columnsIndex].DefaultCellStyle;
			defaultHeaderCellType = dataGridView1.Columns[columnsIndex].DefaultHeaderCellType;
			frozen = dataGridView1.Columns[columnsIndex].Frozen;
			headerText = dataGridView1.Columns[columnsIndex].HeaderText;
			minimumWidth = dataGridView1.Columns[columnsIndex].MinimumWidth;
			name = dataGridView1.Columns[columnsIndex].Name;
			readOnly = dataGridView1.Columns[columnsIndex].ReadOnly;
			resizable = dataGridView1.Columns[columnsIndex].Resizable;
			sortMode = dataGridView1.Columns[columnsIndex].SortMode;
			width = dataGridView1.Columns[columnsIndex].Width;
		}
	}
}