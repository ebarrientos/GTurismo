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
    public partial class frmUsr03 : Form
    {
        public Usuario UsuarioSelecionado;
        bool SenhaAtualOk = false;
        bool SenhaNovaOk = false;
        public frmUsr03()
        {
            InitializeComponent();
        }

        private void frmUsr03_Load(object sender, EventArgs e)
        {
            tbApelido.Text = UsuarioSelecionado.Apelido;
            tbApelido.Enabled = false;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (SenhaAtualOk && SenhaNovaOk)
                UsuarioSelecionado.Senha = tbNovaSenha1.Text;
            else
                MessageBox.Show("Senha não foi alterada");
        }

        private void tbSenhaAtual_Validating(object sender, CancelEventArgs e)
        {
            ValidaSenhaAtual();
        }

        private bool ValidaSenhaAtual()
        {
            bool tbStatus = true;
            if (tbSenhaAtual.Text != UsuarioSelecionado.Senha)
            {
                ep1.SetError(tbSenhaAtual, "Senha inválida");
                tbStatus = false;
            }
            else
            {
                ep1.SetError(tbSenhaAtual, "");
                SenhaAtualOk = true;
            }
            return tbStatus;
        }

        private void tbNovaSenha2_Validating(object sender, CancelEventArgs e)
        {
            ValidaSenhaNova(e);
        }

        private bool ValidaSenhaNova(CancelEventArgs e)
        {
            bool tbStatus = true;
            if (tbNovaSenha1.Text != tbNovaSenha2.Text)
            {
                ep1.SetError(tbNovaSenha2, "Senha não confere");
                tbStatus = false;
            }
            else
            {
                ep1.SetError(tbNovaSenha2, "");
                SenhaNovaOk = true;
            }
            return tbStatus;
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
        }

    }
}
