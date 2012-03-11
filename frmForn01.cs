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
    public partial class frmForn01 : Form
    {
        public Fornecedor FornecedorSelecionado;
        public long IdTipoFornecedor = 0;

        Listas lista1;
        public long idCidade = 0;

        private List<FornecedorView> FornecedorResult = new List<FornecedorView>();
        public frmForn01()
        {
            InitializeComponent();
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

        public void desativarBtSelecionar()
        {
            btSelecionar.Enabled = false;
        }

        private void frmForn01_Load(object sender, EventArgs e)
        {
            lista1 = new Listas();
            cbTipo.DataSource = lista1.TiposFornecedor;
            cbTipo.DisplayMember = "Nome";
            cbTipo.ValueMember = "IdTipoFornecedor";
            cbTipo.SelectedValue = IdTipoFornecedor;

            RefreshFornecedor();
            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection(); 
        }

        private void RefreshFornecedor()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            FornecedorResult =
                (from fornecedor in ViagensDC.Fornecedors
                 orderby fornecedor.Nome
                 select new FornecedorView
                 {
                     IdFornecedor = fornecedor.IdFornecedor,
                     IdCidade = fornecedor.IdCidade,
                     Fornecedor = fornecedor.Nome,
                     TipoFornecedor = fornecedor.TipoFornecedor.Nome,
                     Cidade = fornecedor.Cidade.Nome,
                     Comissao = fornecedor.Comissao,
                     Email = fornecedor.email,
                     Telefone = fornecedor.Telefone,
                     Endereco = fornecedor.Endereco,
                     Numero = fornecedor.Numero,
                     Complemento = fornecedor.Complemento,
                     Cep = fornecedor.CEP,
                     Comentario = fornecedor.Comentarios,
                 }
                 ).ToList<FornecedorView>();

            dgv1.DataSource = FornecedorResult;
            filtraFornecedores();
        }

        private void filtraFornecedores()
        {
            List<FornecedorView> filtro;
            //if (IdTipoFornecedor != 0)
            //{
            //    TipoFornecedor f = acc.ObtemTipoFornecedor(IdTipoFornecedor);
            //    cbTipo.Text = f.Nome;
            //}
            if (idCidade != 0)
            {
                Cidade C = acc.ObtemCidade(idCidade);
                tbCidade.Text = C.Nome;
            }
            if (idCidade == 0)
            {
                filtro = (from fornecedor in FornecedorResult
                          where fornecedor.Fornecedor.ToUpper().Contains(tbNome.Text) &&
                          fornecedor.Comissao.ToString().Contains(tbComissao.Text) &&
                          fornecedor.Email.Contains(tbEmail.Text) &&
                          fornecedor.Telefone.Contains(tbTelefone.Text) &&
                          fornecedor.TipoFornecedor.Contains(cbTipo.Text)
                          orderby fornecedor.Fornecedor
                          select fornecedor).ToList<FornecedorView>();
            }
            else
            {
                filtro = (from fornecedor in FornecedorResult
                          where fornecedor.Fornecedor.ToUpper().Contains(tbNome.Text) &&
                          fornecedor.IdCidade == idCidade &&
                          fornecedor.Comissao.ToString().Contains(tbComissao.Text) &&
                          fornecedor.Email.Contains(tbEmail.Text) &&
                          fornecedor.Telefone.Contains(tbTelefone.Text) &&
                          fornecedor.TipoFornecedor.Contains(cbTipo.Text)
                          orderby fornecedor.Fornecedor
                          select fornecedor).ToList<FornecedorView>();
            }
            dgv1.DataSource = filtro;
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell != null)
            {
                if (dgv1.CurrentCell.Selected)
                {
                    long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                    FornecedorSelecionado = acc.ObtemFornecedor(ID);
                }
                else
                {
                    MessageBox.Show("Um Fornecedor deve estar selecionado.");
                }
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                Fornecedor fornecedor = acc.ObtemFornecedor(ID);
                acc.DeleteFornecedor(fornecedor);
                RefreshFornecedor();
                dgv1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Um País deve está selecionado.");
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            FornecedorSelecionado = null;
        }

        private void tbCidade_TextChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
        }

        private void tbComissao_TextChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
        }

        private void tbTelefone_TextChanged(object sender, EventArgs e)
        {
            filtraFornecedores();
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

        private void btNovo_Click(object sender, EventArgs e)
        {
            InsereFornecedor();
        }

        private void InsereFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            if ((fornecedor = ObtemDadosFornecedor(fornecedor)) != null)
            {
                try
                {
                    acc.InsertOrUpdateFornecedor(fornecedor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshFornecedor();
            }
        }

        private Fornecedor ObtemDadosFornecedor(Fornecedor fornecedor)
        {
            frmForn02 frm = new frmForn02();
            frm.FornecedorAtual = fornecedor;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                fornecedor = frm.FornecedorAtual;
                return fornecedor;
            }
            return null;
        }

        private void dgv1_DataSourceChanged(object sender, EventArgs e)
        {
            util.EsconderColuna(this.dgv1, "IdFornecedor", false);
            util.EsconderColuna(this.dgv1, "IdCidade", false);
        }

        private void EditaFornecedorAux() 
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditaFornecedor(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
        }

        private void EditaFornecedor(long ID)
        {
            Fornecedor fornecedor = acc.ObtemFornecedor(ID);
            if ((fornecedor = ObtemDadosFornecedor(fornecedor)) != null)
            {
                try
                {
                    acc.InsertOrUpdateFornecedor(fornecedor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshFornecedor();
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditaFornecedorAux();
        }

        private void dgv1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditaFornecedorAux();
        }

        private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("cbTipo_SelectedValueChanged");
        }
    }
}
