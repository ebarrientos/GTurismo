using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Viagens
{
    public partial class frmCli01 : Form
    {
//        List<Cliente> ClientResult;
        public Cliente ClienteSelecionado;
        List<ClienteView> ClienteResult;

        public string Titulo = "Cadastro de Clientes";

        public frmCli01()
        {
            InitializeComponent();
        }
        
        private void CadCli01_Load(object sender, EventArgs e)
        {
            RefreshClientes();

            //limpa a primeira linha por default -- by erico
            dgv1.ClearSelection();
            
            this.Text = Titulo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FiltraClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsereCliente();
        }

        private void InsereCliente()
        {
            Cliente Cl1 = new Cliente();
            if ((Cl1 = ObtemDadosCliente(Cl1)) != null)
            {
                try
                {
                    acc.InsertOrUpdateCliente(Cl1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshClientes();
            }
        }

        private Cliente ObtemDadosCliente(Cliente Cli)
        {
            Cliente result=null; 
            frmCli02 frm = new frmCli02();
            frm.ClienteAtual = Cli;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                result = frm.ClienteAtualizado;
            }
            return result;
        }


        private void FiltraClientes()
        {
            List<ClienteView> filtro = (from cli in ClienteResult
                          where cli.Nome.ToUpper().Contains(tbNome.Text) &&
                          cli.CPF.StartsWith(tbCPF.Text) &&
                          cli.RG.StartsWith(tbRG.Text)
                           orderby cli.Nome
                          select cli).ToList<ClienteView>();

            dgv1.DataSource = filtro;
        }

        private void RefreshClientes()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            ClienteResult =
                (from cli in ViagensDC.Clientes
                 select new ClienteView{
                     IdCliente = cli.IDCliente,
                     Nome = cli.Nome1 + " " + cli.Nome2 + " " + cli.Nome3,
                     RG = cli.RG,
                     CPF = cli.CPF,
                     Email = cli.email,
                     Endereco = cli.Endereco +","+ cli.Cidade.Nome
                 }).ToList<ClienteView>();

            FiltraClientes();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            EditaCliente(ID);
        }

        private void dgv1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            EditaCliente(ID);
        }

        private void EditaCliente(long ID)
        {
            Cliente Cl1 = acc.ObtemCliente(ID);
            Cliente Cl2 = new Cliente();
            if ((Cl2 = ObtemDadosCliente(Cl1))!=null)
            {
                try
                {
                    acc.InsertOrUpdateCliente(Cl2);
                }
                catch (Exception ex)
                {
                        MessageBox.Show(ex.Message);
                }
                RefreshClientes();
            }
        }

        private void tbRG_TextChanged(object sender, EventArgs e)
        {
            FiltraClientes();
        }

        private void tbCPF_TextChanged(object sender, EventArgs e)
        {
            FiltraClientes();
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Selected)
            {
                ClienteSelecionado = acc.ObtemCliente(long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString()));                
            }
        }

        //Trata evento ao clicar na linha - Para editar um cliente.
        private void dgv1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            long ID = long.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            int index = dgv1.CurrentRow.Index;
            EditaCliente(ID);
            dgv1.ClearSelection();
            dgv1.Rows[index].Selected = true;
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

        internal void desativarBtSelecionar()
        {
            btSelecionar.Enabled = false; 
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
                MessageBox.Show("Um cliente deve está selecionado.");
            }
            
        }

        private void dgv1_DataSourceChanged(object sender, EventArgs e)
        {
//            if ("IdCliente".CompareTo(dgv1.Columns[0].Name) == 0) 
//            {
//                dgv1.Columns[0].Visible = false;
//            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {

        }


    }
}
