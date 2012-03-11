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
    public partial class frmTProd01 : Form
    {
        List<TipoProduto> TipoProdutosResult;
        public TipoProduto TipoProdutoSelecionado;

        public frmTProd01()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            InsereTipoProduto();
        }

        private void InsereTipoProduto()
        {
            TipoProduto tp = new TipoProduto();
            if ((tp = ObtemDadosTipoProduto(tp)) != null)
            {
                try
                {
                    acc.InsertOrUpdateTipoProduto(tp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            RefreshTipoProduto();

        }

        private void RefreshTipoProduto()
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            TipoProdutosResult = (from tp in ViagemDC.TipoProdutos
                                  orderby tp.Nome
                                  select tp).ToList<TipoProduto>();
            dgv1.DataSource = TipoProdutosResult;
            FiltraTipoProduto();
        }

        private void FiltraTipoProduto()
        {
            var filtro = (from tp in TipoProdutosResult
                          where tp.Nome.Contains(tbNome.Text)
                          orderby tp.Nome
                          select tp).ToList<TipoProduto>();
            dgv1.DataSource = filtro;
        }

        private TipoProduto ObtemDadosTipoProduto(TipoProduto tp)
        {
            frmTProd02 frm = new frmTProd02();
            frm.TipoProdutoSelecionado = tp;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                tp = frm.TipoProdutoSelecionado;
            }
            else
                tp = null;
            return tp;
        }

        private void frmTProd01_Load(object sender, EventArgs e)
        {
            RefreshTipoProduto();
            dgv1.ClearSelection();
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                TipoProdutoSelecionado = acc.ObtemTipoProduto(ID);
            }
            else
            {
                MessageBox.Show("Selecione um dos items.");
            }

        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                TipoProduto tp = acc.ObtemTipoProduto(ID);
                if (tp == null)
                {
                    MessageBox.Show("Erro ao remover item. Motivo: Tipo de Produto não encontrado.");
                    return;
                }
                acc.DeleteTipoProduto(tp);
                RefreshTipoProduto();
                dgv1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Selecione um dos items.");
            }

        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            TipoProdutoSelecionado = null;
        }
    }
}
