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
    public partial class frmCli03 : Form
    {
        private Cliente _CA;

        public Cliente ClienteAtual
        {
            get { return _CA; }
            set { _CA = value; }
        }

        public frmCli03()
        {
            InitializeComponent();
        }

        private void frmCli03_Load(object sender, EventArgs e)
        {
            tbCliente.Text = _CA.Nome1 + " " + _CA.Nome2 + " " + _CA.Nome3;
            List<TelefonesView> telefones = new List<TelefonesView>();
            foreach (ContatoCliente cc in _CA.ContatoClientes)
            {
                TelefonesView tv = new TelefonesView(_CA.IDCliente, cc.Telefone);
                telefones.Add(tv);
            }
            dgvTelefones.DataSource = telefones;

        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            List<TelefonesView> telefones = (List<TelefonesView>)dgvTelefones.DataSource;
            _CA.ContatoClientes.Clear();
            foreach (TelefonesView fone in telefones)
            {
                ContatoCliente cc = new ContatoCliente();
                cc.Telefone = fone.Telefone;
                _CA.ContatoClientes.Add(cc);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            List<TelefonesView> telefones = (List<TelefonesView>)dgvTelefones.DataSource;
            TelefonesView tv = new TelefonesView();
            telefones.Add(tv);
            List<TelefonesView> lista = (from t in telefones orderby t.Telefone
                                             select t).ToList<TelefonesView>();
            dgvTelefones.DataSource = lista;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            List<TelefonesView> telefones = (List<TelefonesView>)dgvTelefones.DataSource;
            foreach (DataGridViewRow r in dgvTelefones.SelectedRows)
            {
                long id = long.Parse(r.Cells[1].Value.ToString());
                string fone = r.Cells[0].Value.ToString();
                if (id != 0)
                {
                    ContatoCliente cc = acc.ObtemContatoCliente(id);
                    acc.DeleteContatoCliente(cc);
                }
                foreach (TelefonesView t in telefones)
                {
                    if (t.Telefone == fone)
                        telefones.Remove(t);
                    break;
                }
            }
            List<TelefonesView> cclist = (from c in telefones
                                           orderby c.Telefone
                                           select c).ToList<TelefonesView>();
            dgvTelefones.DataSource = cclist;
        }
    }
}
