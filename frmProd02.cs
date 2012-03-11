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
    public partial class frmProd02 : Form
    {
        public Produto ProdutoAtual;
        long IdTipoProduto;

        public frmProd02()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ProdutoAtual.Nome = tbNome.Text;
            ProdutoAtual.Descricao = tbDescricao.Text;
            ProdutoAtual.IdTipoProduto = IdTipoProduto;
        }

        private void frmProd02_Load(object sender, EventArgs e)
        {
            tbNome.Text = ProdutoAtual.Nome;
            tbDescricao.Text = ProdutoAtual.Descricao;
            TipoProduto tp = acc.ObtemTipoProduto(ProdutoAtual.IdTipoProduto);
            if (tp != null)
            {
                tbTipoProduto.Text = tp.Nome;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            TipoProduto tp = cad.SelecionaTipoProduto(true);
            if (tp != null)
            {
                IdTipoProduto = tp.IdTipoProduto;
                tbTipoProduto.Text = tp.Nome;
            }
        }
    }
}
