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
    public partial class frmCli02 : Form
    {
        private  Cliente _ClienteAtual;
        public Cliente ClienteAtual
        {
            set { _ClienteAtual = value; }
        }

        private Cliente _ClienteAtualizado;
        public Cliente ClienteAtualizado
        {
            get { return _ClienteAtualizado; }
        }

        private ToolTip toolTip;
        public frmCli02()
        {
            InitializeComponent();
        }

        private void frmCli02_Load(object sender, EventArgs e)
        {
            toolTip = new ToolTip();
            _ClienteAtualizado = new Cliente();
            if (_ClienteAtual != null)
            {
                _ClienteAtualizado.IDCliente = _ClienteAtual.IDCliente;
                mtbNome1.Text = _ClienteAtualizado.Nome1= _ClienteAtual.Nome1;
                mtbNome2.Text = _ClienteAtualizado.Nome2 = _ClienteAtual.Nome2;
                mtbNome3.Text = _ClienteAtualizado.Nome3 = _ClienteAtual.Nome3;
                mtbRG.Text = _ClienteAtual.RG;
                mtbCPF.Text = _ClienteAtual.CPF;
                mtbCEP.Text = _ClienteAtual.CEP;
                mtbEndereco.Text = _ClienteAtual.Endereco;
                mtbTelefone.Text = _ClienteAtual.Telefone;
                mtbEmail.Text = _ClienteAtual.email;
                rtbComentarios.Text = _ClienteAtual.Comentarios;
                if (_ClienteAtual.DataNascimento != null)
                {
                    mtbDtNascimento.Text = String.Format("{0,2}/{1,2}/{2,2}",
                        _ClienteAtual.DataNascimento.Value.Day, _ClienteAtual.DataNascimento.Value.Month,
                        _ClienteAtual.DataNascimento.Value.Year);
                }
                else
                    mtbDtNascimento.Text = "01/01/1960";
                
                if (_ClienteAtual.IdResp != null)
                {
                    Cliente Resp = acc.ObtemCliente(_ClienteAtual.IdResp);
                    tbIdResponsavel.Text = Resp.Nome1 + " " + Resp.Nome2 + " " + Resp.Nome3;
                    toolTip.SetToolTip(tbIdResponsavel, tbIdResponsavel.Text);
                }
                if (_ClienteAtual.IdCidade != null)
                {
                    Cidade Cid = acc.ObtemCidade(_ClienteAtual.IdCidade);
                    tbIdCidade.Text = Cid.Nome;
                    toolTip.SetToolTip(tbIdCidade, Cid.Nome);
                }
                foreach (ContatoCliente cc in _ClienteAtual.ContatoClientes)
                {
                    ContatoCliente c1 = new ContatoCliente();
                    c1.Telefone = cc.Telefone;
                    _ClienteAtualizado.ContatoClientes.Add(c1);
                }
                mtbNomeMae.Text = _ClienteAtualizado.NomeMae;
                ctbRendaMensal.Text = (_ClienteAtualizado.RendaMensal == null ? 0 :
                    _ClienteAtualizado.RendaMensal).ToString();
            }

        }


        private void btOk_Click(object sender, EventArgs e)
        {
            _ClienteAtualizado.Nome1 = mtbNome1.Text;
            _ClienteAtualizado.Nome2 = mtbNome2.Text;
            _ClienteAtualizado.Nome3 = mtbNome3.Text;
            _ClienteAtualizado.RG = mtbRG.Text;
            _ClienteAtualizado.CPF = mtbCPF.Text;
            _ClienteAtualizado.CEP = mtbCEP.Text;
            _ClienteAtualizado.Endereco = mtbEndereco.Text;
            _ClienteAtualizado.Telefone = mtbTelefone.Text;
            _ClienteAtualizado.email = mtbEmail.Text;
            _ClienteAtualizado.Comentarios = rtbComentarios.Text;
            _ClienteAtualizado.DataNascimento = DateTime.Parse(mtbDtNascimento.Text);
            _ClienteAtualizado.RendaMensal = decimal.Parse(ctbRendaMensal.NumericText);
            _ClienteAtualizado.NomeMae = mtbNomeMae.Text;
        }

        private void btSelecResp_Click(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = cad.SelecionaCliente(true);
            if (clienteSelecionado != null) 
            {
                _ClienteAtualizado.IdResp = clienteSelecionado.IDCliente;
                tbIdResponsavel.Text = clienteSelecionado.Nome3 + ", " +
                                     clienteSelecionado.Nome1 + " " +
                                     clienteSelecionado.Nome2;
            }
            
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            Cidade CidadeSelecionada = cad.SelecionaCidade(true);
            if (CidadeSelecionada != null)
            {
                _ClienteAtualizado.IdCidade = CidadeSelecionada.IdCidade;
                tbIdCidade.Text = CidadeSelecionada.Nome;
                toolTip.SetToolTip(tbIdCidade, CidadeSelecionada.Nome);
            }
        }

        private void tbIdResponsavel_Click(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = cad.SelecionaCliente(true);
            if (clienteSelecionado != null)
            {
                _ClienteAtualizado.IdResp = clienteSelecionado.IDCliente;
                string txt = clienteSelecionado.Nome1 + " " +
                             clienteSelecionado.Nome2 + " " + 
                             clienteSelecionado.Nome3;
                tbIdResponsavel.Text = txt;
                toolTip.SetToolTip(tbIdResponsavel, txt);
            }
        }

        private void tbIdCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void btTelefone_Click(object sender, EventArgs e)
        {
            frmCli03 frm = new frmCli03();
            frm.ClienteAtual = _ClienteAtualizado;
            frm.ShowDialog();
        }

        private void mtbTelefone_TextChanged(object sender, EventArgs e)
        {
            if (mtbTelefone.Text == "")
                btTelefone.Enabled = false;
            else
                btTelefone.Enabled = true;
        }
    }
}
