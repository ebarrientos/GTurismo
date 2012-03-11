using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viagens
{
    class util
    {
        private static System.Windows.Forms.DataGridViewColumn col;
        public static void EsconderColuna(System.Windows.Forms.DataGridView dataGridView, string p)
        {
            EsconderColuna(dataGridView, p, true);
        }

        internal static void EsconderColuna(System.Windows.Forms.DataGridView dataGridView, string p, bool case_sensitive)
        {
            if (!case_sensitive)
                p = p.ToUpper();
            foreach (var colAux in dataGridView.Columns)
            {
                col = (System.Windows.Forms.DataGridViewColumn)colAux;
                if (p.CompareTo((case_sensitive? col.Name: col.Name.ToUpper())) == 0)
                {
                    col.Visible = false;
                }
            }
        }
    }
}
