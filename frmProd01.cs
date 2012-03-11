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
    public partial class frmProd01 : Form
    {
        public List<Produto> ProdutoResult;
        public Produto ProdutoSelecionado;
        public long idTipoProduto;
        public frmProd01()
        {
            InitializeComponent();
        }

        private void frmProd01__Load(object sender, EventArgs e)
        {
            RefreshProdutos();
            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection();
            
            if (idTipoProduto != 0)
            {
                TipoProduto tp = acc.ObtemTipoProduto(idTipoProduto);
                this.tbTipoProduto.Text = tp.Nome;
            }
        }

        private void RefreshProdutos()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            ProdutoResult =
                (from produto in ViagensDC.Produtos
                 orderby produto.Nome
                 select produto
                 ).ToList<Produto>();

            dgv1.DataSource = ProdutoResult;
            filtraProduto();
        }

        private void filtraProduto()
        {
            List<Produto> filtro;
            if (idTipoProduto == 0)
                filtro = (from p in ProdutoResult
                            where p.Nome.ToUpper().Contains(tbNome.Text)
                            orderby p.Nome
                            select p).ToList<Produto>();
            else
                filtro = (from p in ProdutoResult
                          where p.Nome.ToUpper().Contains(tbNome.Text) && p.IdTipoProduto == idTipoProduto 
                          orderby p.Nome
                          select p).ToList<Produto>();

            dgv1.DataSource = filtro;
        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {
            filtraProduto();
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                ProdutoSelecionado = acc.ObtemProduto(ID);
            }
            else
            {
                MessageBox.Show("Um Produto deve estar selecionado.");
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                Produto produto = acc.ObtemProduto(ID);
                if (produto == null) 
                {
                    MessageBox.Show("Erro ao remover Produto. Motivo: Produto não encontrado.");
                    return;
                }
                acc.DeleteProduto(produto);
                RefreshProdutos();
                dgv1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Um Produto deve está selecionado.");
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            InsereProduto();
        }

        private void InsereProduto()
        {
            Produto produto = new Produto();
            if ((produto = ObtemDadosProduto(produto)) != null)
            {
                try
                {
                    acc.InsertOrUpdateProduto(produto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshProdutos();
            }
        }

        private Produto ObtemDadosProduto(Produto produto)
        {
            frmProd02 frm = new frmProd02();
            frm.ProdutoAtual = produto;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                produto = frm.ProdutoAtual;
                return produto;
            }
            return null;
        }

        private void EditarProdutoAux()
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditarProduto(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
        }

        private void EditarProduto(long ID)
        {
            Produto produto = acc.ObtemProduto(ID);
            if ((produto = ObtemDadosProduto(produto)) != null)
            {
                try
                {
                    acc.InsertOrUpdateProduto(produto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshProdutos();
            }
        }


        private void dgv1_DataSourceChanged(object sender, EventArgs e)
        {
            if ("IdProduto".CompareTo(dgv1.Columns[0].Name) == 0)
            {
                dgv1.Columns[0].Visible = false;
            }
            if (dgv1.Rows.Count > 0)
                lblTotalProdutos.Text = "Total de Produtos: " + dgv1.Rows.Count;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarProdutoAux();
        }

        private void dgv1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditarProdutoAux();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            ProdutoSelecionado = null;
        }



        public void desativarBtNovo()
        {
            btNovo.Enabled = false;
        }

        public void desativarEventoGrid()
        {
            this.dgv1.RowHeaderMouseDoubleClick -= new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_RowHeaderMouseDoubleClick);
            this.dgv1.CellContentClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
        }

        public void habilitarSelecionar()
        {
            btSelecionar.Enabled = true;
        }

        internal void desativarBtSelecionar()
        {
            btSelecionar.Enabled = false;
        }

        private void tbTipoProduto_Click(object sender, EventArgs e)
        {
            TipoProduto tp = cad.SelecionaTipoProduto(true);
            if (tp != null)
            {
                idTipoProduto = tp.IdTipoProduto;
                tbTipoProduto.Text = tp.Nome;
            }
            filtraProduto();
        }
    }
}
