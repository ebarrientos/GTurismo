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
    public partial class frmPesquisarVenda01 : Form
    {
        public Venda _VendaSelecionado;
        public List<Venda> VendaResult;
        public Usuario Vendedor;

        private long _IdCliente = 0;
        private long _IdCidade = 0;
        private long _IdProduto = 0;
        private long _IdOperadora = 0;
        private long _IdUsuario = 0;
        private long _IdSituacaoVenda = 0;

        private Listas Lista1;
        public frmPesquisarVenda01()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            Lista1 = new Listas();
            cbStatus.DataSource = Lista1.TSituacoesVenda;
            cbStatus.DisplayMember = "Nome";
            cbStatus.ValueMember = "IdSituacaoVenda";
        }

        private void frmPesquisarVenda01_Load(object sender, EventArgs e)
        {
            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection();
            InicializaInterface();
        }

        private void InicializaInterface()
        {
            int Dias = 30;
            DateTime DI = DateTime.Now.Subtract(new TimeSpan(Dias,0,0,0));
            DateTime DF = DateTime.Now;
            dtpDataI.Value = DI;
            dtpDataF.Value = DF;
        }

        private void RefreshVendas()
        {
            DateTime DI = dtpDataI.Value;
            DateTime DF = dtpDataF.Value;
            ViagensDataContext ViagensDC = new ViagensDataContext();
            VendaResult =
                (from v in ViagensDC.Vendas
                 where v.DataVenda >= DI && v.DataVenda <=DF
                 orderby v.IdVenda
                 select v).ToList<Venda>();
            filtraVendas();
        }

        private void filtraVendas()
        {
            if (VendaResult != null)
            {
                var filtro = (from v in VendaResult
                              where
                               (_IdCidade == 0 ? true : v.IdCidade == _IdCidade) &&
                               (_IdProduto == 0 ? true : v.IdProduto == _IdProduto) &&
                               (_IdOperadora == 0 ? true : v.IdOperadora == _IdOperadora) &&
                               (_IdCliente == 0 ? true : v.IdCliente == _IdCliente) &&
                               (_IdSituacaoVenda == 0 ? true : v.IdSituacaoVenda == _IdSituacaoVenda)
                              orderby v.IdVenda
                              select new VendasView
                              {
                                  IdVenda = v.IdVenda,
                                  NomeCliente = v.Cliente.Nome1 + " " + v.Cliente.Nome2 + " " + v.Cliente.Nome3,
                                  NomeOperadora = v.Fornecedor.Nome,
                                  Destino = v.Cidade.Nome,
                                  DataVenda = (DateTime)v.DataVenda,
                                  DataEmbarque = v.DataEmbarque,
                                  Situacao=v.SituacaoVenda.Nome
                              }).ToList<VendasView>();
                dgv1.DataSource = filtro;
            }
        }

        public Venda VendaSelecionado
        {
            get { return _VendaSelecionado; }
            set { _VendaSelecionado = value; }
        }

        private void FiltraDatas()
        {
            //verificar se a datainicial e menor ou igual a final.
            if (dtpDataF.Value < dtpDataI.Value)
            {
                dtpDataF.Value = dtpDataI.Value.AddDays(1) ;
            }
            RefreshVendas();
        }

        private void tbCliente_TextChanged(object sender, EventArgs e)
        {
            filtraVendas();
        }

        private void tbProduto_TextChanged(object sender, EventArgs e)
        {
            filtraVendas();
        }

        private void tbCidade_TextChanged(object sender, EventArgs e)
        {
            filtraVendas();
        }

        private void tbFornecedor_TextChanged(object sender, EventArgs e)
        {
            filtraVendas();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IdSituacaoVenda = ((TSituacaoVenda)cbStatus.SelectedItem).IdSituacaoVenda;
            filtraVendas();
        }

        private void tbCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = cad.SelecionaCliente(true);

            if (cliente != null)
            {
                _IdCliente = cliente.IDCliente;
                tbCliente.Text = cliente.Nome1 + " " + cliente.Nome2 + " " + cliente.Nome3;
            }
        }

        private void tbProduto_Click(object sender, EventArgs e)
        {
            Produto produto = cad.SelecionaProduto(true);

            if (produto != null)
            {
                _IdProduto = produto.IdProduto;
                tbProduto.Text = produto.Nome;
            }
        }

        private void tbCidade_Click(object sender, EventArgs e)
        {
            Cidade cidade = cad.SelecionaCidade(true);

            if (cidade != null)
            {
                _IdCidade = cidade.IdCidade;
                tbCidade.Text = cidade.Nome;
            }
        }

        private void tbFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = cad.SelecionaFornecedor(true);

            if (fornecedor != null)
            {
                _IdOperadora = fornecedor.IdFornecedor;
                tbFornecedor.Text = fornecedor.Nome;
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            Venda venda = cad.EditarVenda(null, Vendedor);
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dgv1.SelectedRows)
                {
                    long idVenda = (long)row.Cells["IdVenda"].Value;
                    Venda v = acc.ObtemVenda(idVenda);
                    v = cad.EditarVenda(v, null);
                    RefreshVendas();
                }
            }
        }

        private void dtpDataI_ValueChanged(object sender, EventArgs e)
        {
            FiltraDatas();
        }

        private void dtpDataF_ValueChanged(object sender, EventArgs e)
        {
            FiltraDatas();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dgv1.SelectedRows)
                {
                    long idVenda = (long)row.Cells["IdVenda"].Value;
                    if (MessageBox.Show("Confirma Eliminação da Venda", "ATENÇÂO!",
                            MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        acc.DeleteVenda(idVenda);
                        RefreshVendas();
                    }
                }
            }

        }
    }
}
