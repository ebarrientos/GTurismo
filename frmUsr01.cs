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
    public partial class frmUsr01 : Form
    {
        public Usuario Operador;

        public Usuario UsuarioSelecionado;

        private Listas Lista1 = new Listas();
        public frmUsr01()
        {
            InitializeComponent();
        }

        private void frmUsr01_Load(object sender, EventArgs e)
        {
            InicializaInterface();
        }

        private void InicializaInterface()
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            List<Usuario> Usuarios = new List<Usuario>();
            dgvUsuarios.DataSource = Usuarios;

            dgvUsuarios.Columns.Remove("Status");
            DataGridViewComboBoxColumn dgvcbTipo = new DataGridViewComboBoxColumn();
            dgvcbTipo.DataSource = Lista1.TiposUsuario;
            dgvcbTipo.DisplayMember = "Nome";
            dgvcbTipo.ValueMember = "Tipo";
            dgvcbTipo.DataPropertyName = "Tipo";
            dgvcbTipo.HeaderText = "Tipo";
            dgvcbTipo.ReadOnly = true;
            dgvUsuarios.Columns.Insert(1, dgvcbTipo);

            dgvUsuarios.Columns.Remove("Tipo");
            DataGridViewComboBoxColumn dgvcbStatus = new DataGridViewComboBoxColumn();
            dgvcbStatus.DataSource = Lista1.StatusUsuario;
            dgvcbStatus.DisplayMember = "Nome";
            dgvcbStatus.ValueMember = "Status";
            dgvcbStatus.DataPropertyName = "Status";
            dgvcbStatus.HeaderText = "Status";
            dgvcbStatus.ReadOnly = true;
            dgvUsuarios.Columns.Insert(2, dgvcbStatus);

            // Habilita botões
            bool Habilita = false;
            if (Operador.Tipo == (char)eTipoUsuario.Administrador)
            {
                Habilita = true;
            }
            btBloqueio.Enabled = Habilita;
            btEditar.Enabled = Habilita;
            btNovo.Enabled = Habilita;
            refreshUsuarios();
        }

        private void refreshUsuarios()
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            List<Usuario> Usuarios = (from u in ViagemDC.Usuarios
                                      select u).ToList<Usuario>();
            dgvUsuarios.DataSource = Usuarios;
            dgvUsuarios.Columns["IDUsuario"].Width = 60;
            dgvUsuarios.Columns["Senha"].Visible = false;
            dgvUsuarios.ClearSelection();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
                ViagensDataContext ViagemDC = new ViagensDataContext();
                Usuario U1 = new Usuario();
                frmUsr02 frm = new frmUsr02();
                frm.UsuarioSelecionado = U1;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    UsuarioSelecionado = frm.UsuarioSelecionado;
                    ViagemDC.Usuarios.InsertOnSubmit(U1);
                    ViagemDC.SubmitChanges();
                }
                refreshUsuarios();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            foreach (DataGridViewRow r in dgvUsuarios.SelectedRows)
            {
                long idUsuario = long.Parse(r.Cells["IDUsuario"].Value.ToString());
                Usuario Usr = (from u in ViagemDC.Usuarios
                               where u.IDUsuario == idUsuario
                               select u).SingleOrDefault<Usuario>();
                frmUsr02 frm = new frmUsr02();
                frm.UsuarioSelecionado = Usr;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    ViagemDC.SubmitChanges();
                }
            }
            refreshUsuarios();
        }

        private void btBloqueio_Click(object sender, EventArgs e)
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            foreach (DataGridViewRow r in dgvUsuarios.SelectedRows)
            {
                long idUsuario = long.Parse(r.Cells["IDUsuario"].Value.ToString());
                Usuario Usr = (from u in ViagemDC.Usuarios
                               where u.IDUsuario == idUsuario
                               select u).SingleOrDefault<Usuario>();
                Usr.Status = (Usr.Status == 'O' ? 'B' : 'O');
                ViagemDC.SubmitChanges();
            }
            refreshUsuarios();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {

        }

        private void btMudaSenha_Click(object sender, EventArgs e)
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            if (Operador.Tipo == (char)eTipoUsuario.Administrador)
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow r in dgvUsuarios.SelectedRows)
                    {
                        long IdUsr = long.Parse(r.Cells["IDUsuario"].Value.ToString());
                        MudaSenha(IdUsr);
                    }
                }
                else
                    MessageBox.Show("Selecione um Usuário para mudar a senha!", "Atenção");
            }
            else
                MudaSenha(Operador.IDUsuario);
        }

        private void MudaSenha(long IdUsr)
        {
            ViagensDataContext ViagemDC = new ViagensDataContext();
            Usuario Usr = (from u in ViagemDC.Usuarios
                           where u.IDUsuario == IdUsr
                           select u).SingleOrDefault<Usuario>();
            frmUsr03 frm = new frmUsr03();
            frm.UsuarioSelecionado = Usr;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ViagemDC.SubmitChanges();
            }
        }
    }
}
