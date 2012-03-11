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
    public partial class frmPais01 : Form
    {
        public List<Pais> PaisResult;
        public Pais PaisSelecionado;
        public frmPais01()
        {
            InitializeComponent();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            filtraPaises();
        }

        private void filtraPaises()
        {
            var filtro = (from pais in PaisResult
                          where pais.Nome.ToUpper().Contains(txtNome.Text) &&
                          pais.DDI.StartsWith(txtDDI.Text)
                          orderby pais.Nome
                          select pais).ToList<Pais>();
            dgv1.DataSource = filtro;
        }

        private void frmPais01_Load(object sender, EventArgs e)
        {
            RefreshPaises();
            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection(); 
        }

        private void RefreshPaises()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            PaisResult =
                (from cli in ViagensDC.Pais
                 orderby cli.Nome
                 select cli).ToList<Pais>();
            dgv1.DataSource = PaisResult;
            filtraPaises();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            InserePaises();
        }

        private void InserePaises()
        {
            Pais pais = new Pais();
            if ((pais=ObtemDadosPaises(pais))!= null)
            {
                try
                {
                    acc.InsertOrUpdatePaises(pais);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshPaises();
            }
        }

        private Pais ObtemDadosPaises(Pais pais)
        {
            frmPais02 frm = new frmPais02();
            frm.PaisAtual = pais;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                pais = frm.PaisAtual;
                return pais;
            }
            return null;
        }

        private void dgv1_DataSourceChanged(object sender, EventArgs e)
        {
            if ("IdPais".CompareTo(dgv1.Columns[0].Name) == 0)
            {
                dgv1.Columns[0].Visible = false;
            }
            if (dgv1.Rows.Count > 0)
                lblTotalPaises.Text = "Total de Paises: " + dgv1.Rows.Count;
        }

        private void dgv1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditaPais(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditaPais(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
        }
        
        private void EditaPais(long ID)
        {
            Pais pais = acc.ObtemPais(ID);
            if ((pais = ObtemDadosPaises(pais)) != null)
            {
                try
                {
                    acc.InsertOrUpdatePaises(pais);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshPaises();
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell.Selected)
            {
                long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                Pais pais = acc.ObtemPais(ID);
                acc.DeletePais(pais);
                RefreshPaises();
                dgv1.ClearSelection();
            }
            else 
            {
                MessageBox.Show("Um País deve está selecionado.");
            }
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Selected)
            {
                PaisSelecionado = acc.ObtemPais(long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString()));
            }
        }

        private void btSelecionar_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgv1.CurrentRow.Selected)
            {
                btSelecionar.DialogResult = DialogResult.OK;
            }
            else
            {
                btSelecionar.DialogResult = DialogResult.None;
                MessageBox.Show("Um País deve está selecionado.");
            }
        }

        public void habilitarSelecionar() 
        {
            btSelecionar.Enabled = true;
        }

        private void txtDDI_TextChanged(object sender, EventArgs e)
        {
            filtraPaises();
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

        public void desativarBtSelecionar()
        {
            btSelecionar.Enabled = false;
        }
    }
}
