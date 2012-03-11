using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viagens
{
    public partial class frmPais02 : Form
    {
        public Pais PaisAtual;

        public frmPais02()
        {
            InitializeComponent();
            PaisAtual = new Pais();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            PaisAtual.Nome = txtPais.Text;
            PaisAtual.DDI = txtDDI.Text;
        }

        private void frmPais02_Load(object sender, EventArgs e)
        {
            if (PaisAtual != null) 
            {
                txtPais.Text = PaisAtual.Nome;
                txtDDI.Text = PaisAtual.DDI;
            }
        }
    }
}
