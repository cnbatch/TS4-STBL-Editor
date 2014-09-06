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
	public partial class AddString : Form
	{
		public AddString()
		{
			InitializeComponent();
		}

		public string textID;
		public string dataGridText;
		public bool isOK = false;

		private void button1_Click(object sender, EventArgs e)
		{
			if (maskedTextBox1.Text.Trim() == String.Empty && textBox1.Text.Trim() == String.Empty)
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("你未键入任何内容。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("你未鍵入任何內容。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("Nothing is input.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				isOK = false;
				Close();
			}
			else if (maskedTextBox1.Text.Trim() == String.Empty)
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("字串索引值不能留空，请键入字串索引值。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("字串索引值不能留空，請鍵入字串索引值。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("Text ID is blank. Please input a Text ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				isOK = false;
			}
			else if (maskedTextBox1.Text.Contains("G") || maskedTextBox1.Text.Contains("H") || maskedTextBox1.Text.Contains("I")
			   || maskedTextBox1.Text.Contains("J") || maskedTextBox1.Text.Contains("K") || maskedTextBox1.Text.Contains("L")
			   || maskedTextBox1.Text.Contains("M") || maskedTextBox1.Text.Contains("N") || maskedTextBox1.Text.Contains("O")
			   || maskedTextBox1.Text.Contains("P") || maskedTextBox1.Text.Contains("Q") || maskedTextBox1.Text.Contains("R")
			   || maskedTextBox1.Text.Contains("S") || maskedTextBox1.Text.Contains("T") || maskedTextBox1.Text.Contains("U")
			   || maskedTextBox1.Text.Contains("V") || maskedTextBox1.Text.Contains("W") || maskedTextBox1.Text.Contains("X")
			   || maskedTextBox1.Text.Contains("Y") || maskedTextBox1.Text.Contains("Z"))
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("请在“字串索引”中键入十六进制字串(0-9, A-F)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("請在「字串索引」中鍵入十六進制字串(0-9, A-F)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("Please input Hexadecimal String (0-9, A-F) in Text ID.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				isOK = false;
			}
			else if (maskedTextBox1.TextLength < 8)
			{
				switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
				{
					case "CHS":
					case "ZHI":
						MessageBox.Show("字串索引值太短。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					case "CHT":
					case "ZHH":
					case "ZHM":
						MessageBox.Show("字串索引值太短。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					default:
						MessageBox.Show("Text ID is too less.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
				}
				isOK = false;
			}
			else
			{
				textID = "0x" + maskedTextBox1.Text.Trim();
				dataGridText = textBox1.Text;
				isOK = true;
				Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			isOK = false;
			Close();
		}
	}
}
