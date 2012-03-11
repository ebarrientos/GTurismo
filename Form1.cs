using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Viagens
{
    public partial class Form1 : Form
    {

        public Usuario Operador;

        public Form1()
        {
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(5000);
            th.Abort();
            Thread.Sleep(1000);
        }

        private void DoSplash()
        {
            frmSplash sp = new frmSplash();
            sp.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente cliente = cad.SelecionaCliente(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = cad.SelecionaFornecedor(false);
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto produto = cad.SelecionaProduto(false);
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pais pais = cad.SelecionaPais(false);
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cidade cid = cad.SelecionaCidade(false);
        }

        private void realizarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venda venda = cad.EditarVenda(null,Operador);
        }

        private void pesquisarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venda venda = cad.SelecionaV_Vendas(false,Operador);
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario U1 = cad.SelecionaUsuario(false, Operador);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDocs frm = new frmDocs();
            frm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.Hide();
            this.Dispose();
        }

        private void vendasPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
