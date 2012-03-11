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
    public partial class frmPar02 : Form
    {
        public string Banco;
        public string Agencia;
        public string Conta;
        public string Cheque;

        public frmPar02()
        {
            InitializeComponent();
        }

        private void frmPar02_Load(object sender, EventArgs e)
        {
            mtbBanco.Text = (Banco == null ? "" : Banco);
            mtbAgencia.Text = (Agencia == null ? "" : Agencia);
            mtbConta.Text = (Conta == null ? "" : Conta);
            mtbCheque.Text = (Cheque == null ? "" : Cheque);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Banco = mtbBanco.Text;
            Agencia = mtbAgencia.Text;
            Conta = mtbConta.Text;
            Cheque = mtbCheque.Text;
        }
    }
}
