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
    public partial class frmCid01 : Form
    {
        public List<CidadeView> CidadeResult;
        public Cidade CidadeSelecionada;
        private string IdPais = "";
        public frmCid01()
        {
            InitializeComponent();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            Pais pais = cad.SelecionaPais(true);

            if (pais != null) {
                IdPais = pais.IdPais.ToString();
                tbPais.Text = pais.Nome;
            }
        }

        private void frmCid01_Load(object sender, EventArgs e)
        {
            RefreshCidades();
            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection(); 
        }

        private void RefreshCidades()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            CidadeResult =
                (from cidade in ViagensDC.Cidades
                 orderby cidade.Nome
                 select new CidadeView
                 {
                     IdCidade = cidade.IdCidade,
                     Cidade = cidade.Nome,
                     Estado = cidade.Estado,
                     DDD = cidade.DDD,
                     IdPais = cidade.Pais.IdPais,
                     Pais = cidade.Pais.Nome,
                     DDI = cidade.Pais.DDI
                 }
                 ).ToList<CidadeView>();

            dgv1.DataSource = CidadeResult;
            filtraCidades();
        }

        private void filtraCidades()
        {
            var filtro = (from cidade in CidadeResult
                          where cidade.Cidade.ToUpper().Contains(tbCidade.Text) &&
                          cidade.Estado.ToUpper().Contains(tbEstado.Text) &&
                          cidade.DDD.StartsWith(tbDDD.Text) &&
                          cidade.IdPais.ToString().StartsWith(IdPais)
                          orderby cidade.Cidade
                          select cidade).ToList<CidadeView>();
            dgv1.DataSource = filtro;
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            InsereCidade();
        }

        private void InsereCidade()
        {
            Cidade cid = new Cidade();
            if ((cid = ObtemDadosCidade(cid))!= null)
            {
                try
                {
                    acc.InsertOrUpdateCidade(cid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshCidades();
            }
        }

        private Cidade ObtemDadosCidade(Cidade cid)
        {
            frmCid02 frm = new frmCid02();
            frm.CidadeAtual = cid;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                cid = frm.CidadeAtual;
                return cid;
            }
            return null;
        }

        private void dgv1_DataSourceChanged(object sender, EventArgs e)
        {
            if ("IdPais".CompareTo(dgv1.Columns[1].Name) == 0)
            {
                dgv1.Columns[1].Visible = false;
            }
            if ("IdCidade".CompareTo(dgv1.Columns[0].Name) == 0)
            {
                dgv1.Columns[0].Visible = false;
            }
            if (dgv1.Rows.Count > 0)
                lblTotalPaises.Text = "Total de Cidades: " + dgv1.Rows.Count;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditaCidadeAux();
        }
        private void dgv1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditaCidadeAux();
        }
        private void EditaCidadeAux() 
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditaCidade(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
        }
        private void EditaCidade(long ID)
        {
            Cidade cidade = acc.ObtemCidade(ID);
            if ((cidade = ObtemDadosCidade(cidade)) != null)
            {
                try
                {
                    acc.InsertOrUpdateCidade(cidade);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshCidades();
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                Cidade cidade = acc.ObtemCidade(ID);
                try
                {
                    acc.DeleteCidade(cidade);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro na Eliminação da Cidade!");
                }
                RefreshCidades();
                dgv1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Uma Cideade deve está selecionado.");
            }
        }

        private void dtSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                CidadeSelecionada = acc.ObtemCidade(ID);
            }
            else
            {
                MessageBox.Show("Uma Cidade deve estar selecionada.");
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            CidadeSelecionada = null;
        }

        private void tbCidade_TextChanged(object sender, EventArgs e)
        {
            filtraCidades();
        }

        private void tbEstado_TextChanged(object sender, EventArgs e)
        {
            filtraCidades();
        }

        private void tbDDD_TextChanged(object sender, EventArgs e)
        {
            filtraCidades();
        }

        private void tbPais_TextChanged(object sender, EventArgs e)
        {
            filtraCidades();
        }

        public void desativarBtNovo()
        {
            btNovo.Enabled = false;
        }

        public void desativarBtSelecionar()
        {
            btSelecionar.Enabled = false;
        }

        public void desativarEventoGrid()
        {
            this.dgv1.RowHeaderMouseDoubleClick -= new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_RowHeaderMouseDoubleClick);
            this.dgv1.CellContentClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
        }
    }
}
