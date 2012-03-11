using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace Viagens
{
    public partial class formLogin : Form
    {
        public Usuario Operador;

        public formLogin()
        {
            InitializeComponent();
        }

        private bool validaUsuario(string usuario, string senha)
        {
            Boolean ret = true;

            this.Cursor = Cursors.WaitCursor;
            
            ViagensDataContext viagensDC = new ViagensDataContext();
            try
            {
                Usuario usr = (from u in viagensDC.Usuarios
                               where u.Apelido == usuario.ToUpper() &&
                               u.Senha == senha
                               select u).SingleOrDefault<Usuario>();
                if (usr == null)
                    ret = false;
                else
                    Operador = usr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro na conexão com Banco de Dados!", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                ret = false;
            }
            this.Cursor = Cursors.Default;
            return ret;
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            if (validaUsuario(tbUsuario.Text, tbSenha.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha inválido.x");
                tbUsuario.Focus();
                tbUsuario.SelectAll();
            }
        }
    }
}
