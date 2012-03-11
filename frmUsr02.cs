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
    public partial class frmUsr02 : Form
    {
        public Usuario UsuarioSelecionado;
        private Listas Lista1 = new Listas();

        public frmUsr02()
        {
            InitializeComponent();
        }

        private void frmUsr02_Load(object sender, EventArgs e)
        {
            atbApelido.Text = UsuarioSelecionado.Apelido;
            tbNome.Text = UsuarioSelecionado.Nome;
            tbPasswd.Text = UsuarioSelecionado.Senha;

            cbStatus.DataSource = Lista1.StatusUsuario;
            cbStatus.DisplayMember = "Nome";
            cbStatus.ValueMember = "Status";
            cbStatus.SelectedValue = UsuarioSelecionado.Status;

            cbTipoUsr.DataSource = Lista1.TiposUsuario;
            cbTipoUsr.DisplayMember = "Nome";
            cbTipoUsr.ValueMember = "Tipo";
            cbTipoUsr.SelectedValue = UsuarioSelecionado.Tipo;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            UsuarioSelecionado.Apelido = atbApelido.Text;
            UsuarioSelecionado.Nome = tbNome.Text;
            UsuarioSelecionado.Senha = tbPasswd.Text;
            UsuarioSelecionado.Tipo = (char)cbTipoUsr.SelectedValue;
            UsuarioSelecionado.Status = (char)cbStatus.SelectedValue;
        }
    }
}
