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
    public partial class frmForn02 : Form
    {
        public Fornecedor FornecedorAtual;
        Listas Lista1 = new Listas();

        private long? idCidade;
        private long idTipoFornecedor;
        private TipoFornecedor[] Tipos;

        public frmForn02()
        {
            InitializeComponent();
        }

        private void tbCidade_Click(object sender, EventArgs e)
        {
            Cidade cidade = cad.SelecionaCidade(true);

            if (cidade != null)
            {
                idCidade = cidade.IdCidade;
                tbCidade.Text = cidade.Nome;
            }
        }

        private void frmForn02_Load(object sender, EventArgs e)
        {
            decimal com = (FornecedorAtual.Comissao==null? 0: (decimal)FornecedorAtual.Comissao);

            tbNome.Text = FornecedorAtual.Nome;
            tbEmail.Text = FornecedorAtual.email;
            tbTelefone.Text = FornecedorAtual.Telefone;
            
            nbComissao.Text = com.ToString();

            //Carrega combo TipoFornecedor
            idTipoFornecedor = FornecedorAtual.IdTipoFornecedor;

            cbTipo.DataSource = Lista1.TiposFornecedor;
            cbTipo.DisplayMember = "Nome";
            cbTipo.ValueMember = "IdTipoFornecedor";
            cbTipo.SelectedValue = FornecedorAtual.IdTipoFornecedor;

            tbComplemento.Text = FornecedorAtual.Complemento;
            tbNome.Text = FornecedorAtual.Numero;
            tbCEP.Text = FornecedorAtual.CEP;
            tbComentarios.Text = FornecedorAtual.Comentarios;
            tbEndereco.Text = FornecedorAtual.Endereco;

            idCidade = FornecedorAtual.IdCidade;
            Cidade p = acc.ObtemCidade(idCidade);
            if (p != null)
                tbCidade.Text = p.Nome;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            FornecedorAtual.Nome = tbNome.Text;
            FornecedorAtual.email = tbEmail.Text;
            FornecedorAtual.Telefone = tbTelefone.Text;
            FornecedorAtual.Comissao = Decimal.Parse(nbComissao.NumericText);
            //Obtem IdTipoFornecedor
            FornecedorAtual.IdTipoFornecedor = long.Parse(cbTipo.SelectedValue.ToString());

            FornecedorAtual.Numero = tbNumero.Text;
            FornecedorAtual.CEP = tbCEP.Text;
            FornecedorAtual.Comentarios = tbComentarios.Text;
            FornecedorAtual.Endereco = tbEndereco.Text;
            FornecedorAtual.IdCidade = idCidade;
        }
    }
}
