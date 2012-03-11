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
    public partial class frmTProd02 : Form
    {
        public TipoProduto TipoProdutoSelecionado;

        public frmTProd02()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            TipoProdutoSelecionado.Descricao = this.tbDescricao.Text;
            TipoProdutoSelecionado.Nome = this.tbNome.Text;
        }

        private void frmTProd02_Load(object sender, EventArgs e)
        {
            if (TipoProdutoSelecionado != null)
            {
                tbDescricao.Text = TipoProdutoSelecionado.Descricao;
                tbNome.Text = TipoProdutoSelecionado.Nome;
            }
        }
    }
}
