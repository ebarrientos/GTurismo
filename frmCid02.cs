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
    public partial class frmCid02 : Form
    {
        public Cidade CidadeAtual;
        public long IdPais;
        public frmCid02()
        {
            InitializeComponent();
            CidadeAtual = new Cidade();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            CidadeAtual.Nome = tbCidade.Text;
            CidadeAtual.DDD = tbDDD.Text;
            CidadeAtual.Estado = tbEstado.Text;
            CidadeAtual.IdPais = IdPais;
        }

        private void frmCid02_Load(object sender, EventArgs e)
        {
            tbCidade.Text = CidadeAtual.Nome;
            tbDDD.Text = CidadeAtual.DDD;
            tbEstado.Text = CidadeAtual.Estado;
            IdPais = CidadeAtual.IdPais;
            Pais p = acc.ObtemPais(IdPais);
            if (p != null)
                tbPais.Text = p.Nome;
        }

        private void tbPais_Click(object sender, EventArgs e)
        {
            Pais pais = cad.SelecionaPais(true);

            if (pais != null)
            {
                IdPais = pais.IdPais;
                tbPais.Text = pais.Nome;
            }
        }
    }
}
