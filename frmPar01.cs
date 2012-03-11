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
    public partial class frmPar01 : Form
    {
        Listas lista1 = new Listas();

        public string Bandeira;
        public string Vencimento;
        public string NumCar;
        public string CodSeg;

        public frmPar01()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            //InicializaBandeira
            cbBandeira.DataSource = lista1.Bandeiras;
            cbBandeira.DisplayMember = "Nome";
            cbBandeira.ValueMember = "IdBandeira";
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Bandeira = ((TBandeira)cbBandeira.SelectedItem).Nome;
            Vencimento = mtbVcto.Text;
            NumCar = mtbNumCar.Text;
            CodSeg = mtbCodSeg.Text;
        }

        private void frmPar01_Load(object sender, EventArgs e)
        {
            mtbVcto.Text = (Vencimento == null ? " " : Vencimento);
            mtbCodSeg.Text = (CodSeg == null ? " " : CodSeg);
            mtbNumCar.Text = (NumCar == null ? " " : NumCar);
            if (Bandeira != null)
                cbBandeira.Text = Bandeira;
            else
                cbBandeira.SelectedValue = eTBandeira.VISA;
        }
    }
}
