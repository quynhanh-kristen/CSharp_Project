using Lab3.dto;
using Lab3.util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new frmStudent());
        }
    }
}
