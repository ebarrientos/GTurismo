using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Viagens
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

            formLogin login = new formLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Form1 frm = new Form1();
                frm.Operador = login.Operador;
                Application.Run(frm);
            }
        }
    }
}
