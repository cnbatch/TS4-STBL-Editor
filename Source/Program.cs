﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS4_STBL_Editor
{
    static class Program
    {
        public static MainUI mainUI;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainUI = new MainUI(args);
            Application.Run(mainUI);
            //Application.Run(new CreateNewSTBLFile());
        }
    }
}
