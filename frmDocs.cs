using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Viagens
{
    public partial class frmDocs : Form
    {
        string _ArqDocs;
        string _DirDocs;
        string _Arq ;
        Documentos _Documentos = new Documentos();

        public frmDocs()
        {
            InitializeComponent();
        }

        private void frmDocs_Load(object sender, EventArgs e)
        {
            try
            {
                _Documentos.CarregaLista();
            }
            catch
            {
                MessageBox.Show("Será criado um novo arquivo", "Arquivo não encontrado");
            }
            dgvDocs.DataSource = _Documentos.Lista;
            dgvDocs.Columns[0].FillWeight = 1;
            dgvDocs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDocs.Columns[1].FillWeight = 1;
            dgvDocs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Inicializa diálogo OpenFile
            ofdDoc.InitialDirectory = _Documentos.DiretorioDocumentos;
        }

        private void SalvaDocs()
        {
            try
            {
                _Documentos.SalvaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no salvamento da lista de documentos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            ofdDoc.Title = "Selecione o(s) Arquivo(s)";
            if (ofdDoc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string NomeArq in ofdDoc.FileNames)
                {
                    string NomeDoc = Path.GetFileName(NomeArq);
                    string filename = Path.GetFileNameWithoutExtension(NomeArq);
                    _Documentos.Lista.Add(new Documento(filename, NomeDoc));
                }
            }
            RefreshDocs();
        }

        private void RefreshDocs()
        {
            List<Documento> filtro = (from d in _Documentos.Lista orderby d.Nome select d).ToList<Documento>();
            dgvDocs.DataSource = filtro;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dgvDocs.SelectedRows)
                {
                    _Documentos.Lista.RemoveAt(r.Index);
                }
            }
            RefreshDocs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalvaDocs();
        }
    }
}
