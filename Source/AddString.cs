﻿using System;
using System.Threading;
using System.Windows.Forms;
using FNVHasherDLL;

namespace TS4_STBL_Editor
{
    public partial class AddString : Form
    {
        public string dataGridText;
        public bool isOK;
        public bool stopOnChangeEvent;

        public string textID;

        public AddString()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textIDFld.Text.Trim() == string.Empty && displayTextFld.Text.Trim() == string.Empty)
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
                        MessageBox.Show("Nothing is input.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        break;
                }

                isOK = false;
                Close();
            }
            else if (textIDFld.Text.Trim() == string.Empty)
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
                        MessageBox.Show("Text ID is blank. Please input a Text ID", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        break;
                }

                isOK = false;
            }
            else if (textIDFld.Text.Contains("G") || textIDFld.Text.Contains("H") || textIDFld.Text.Contains("I")
                     || textIDFld.Text.Contains("J") || textIDFld.Text.Contains("K") || textIDFld.Text.Contains("L")
                     || textIDFld.Text.Contains("M") || textIDFld.Text.Contains("N") || textIDFld.Text.Contains("O")
                     || textIDFld.Text.Contains("P") || textIDFld.Text.Contains("Q") || textIDFld.Text.Contains("R")
                     || textIDFld.Text.Contains("S") || textIDFld.Text.Contains("T") || textIDFld.Text.Contains("U")
                     || textIDFld.Text.Contains("V") || textIDFld.Text.Contains("W") || textIDFld.Text.Contains("X")
                     || textIDFld.Text.Contains("Y") || textIDFld.Text.Contains("Z"))
            {
                switch (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName)
                {
                    case "CHS":
                    case "ZHI":
                        MessageBox.Show("请在“字串索引”中键入十六进制字串(0-9, A-F)。", "提示", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        break;
                    case "CHT":
                    case "ZHH":
                    case "ZHM":
                        MessageBox.Show("請在「字串索引」中鍵入十六進制字串(0-9, A-F)。", "提示", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Please input Hexadecimal String (0-9, A-F) in Text ID.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }

                isOK = false;
            }
            else if (textIDFld.TextLength < 8)
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
                        MessageBox.Show("Text ID is too less.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        break;
                }

                isOK = false;
            }
            else
            {
                textID = "0x" + textIDFld.Text.Trim();
                dataGridText = displayTextFld.Text;
                isOK = true;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isOK = false;
            Close();
        }

        private void calculateTextIDOfDisplayText(object sender, EventArgs e)
        {
            if (!stopOnChangeEvent)
                textIDFld.Text = FNVHasherStrFunctions.fnv32HexString(displayTextFld.Text).Replace("0x", "");
        }

        private void copyStrFldsValues_Click(object sender, EventArgs e)
        {
            var sh = new StringHolder();
            sh.textIDFld = textIDFld.Text;
            sh.displayTextFld = displayTextFld.Text;

            MainUI.copiedValuesStrHolders.Add(sh);

            Clipboard.SetText("0x" + textIDFld.Text + " # " + displayTextFld.Text);
        }

        private void pasteStrFldsValues_Click(object sender, EventArgs e)
        {
            var sp = new StringPicker(this);
            sp.Show();
        }

        public void setFldsValues(StringHolder sh)
        {
            stopOnChangeEvent = true;

            displayTextFld.Text = sh.displayTextFld;

            stopOnChangeEvent = false;

            textIDFld.Text = sh.textIDFld.Replace("0x", "");
        }
    }
}