using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImpDoc;

namespace Viagens
{
    public partial class frmRealizarVenda01 : Form
    {
        const long Operadoras = 2;
        const long Hoteis = 1;
        const long VendaLiberada = 1;
        const long ParcelaLiquidada = 2;

        public Usuario Vendedor;

        //Armazena tabelas para combobox
        Listas Listas1 = new Listas();
        Documentos _wDocs = new Documentos();

        private Venda _VendaSelecionada;
        private Venda _VendaAtual;

        private long _IdCliente;
        private long _IdCidade;
        private long _IdPais;
        private long _IdProduto;
        private long _IdTipoProduto;
        private long _IdOperadora;
        private long? _IdHotel;
        private long _IdUsuario;
        private long? _IdMotivo;
        private DateTime? _DataVenda;
        private DateTime? _DataEmbarque;
        private DateTime? _DataRetorno;

        private long? _IdTipoMoeda;
        private decimal? _CambioDoDia;
        private decimal? _PrecoAdult;
        private decimal? _PrecoCHD;
        private decimal? _PrecoINF;
        private decimal? _Desconto;
        private decimal? _TaxaAdult;
        private decimal? _TaxaCHD;
        private decimal? _TaxaINF;
        private decimal? _TaxaAdm;
        private List<PassageiroView> Passageiros;

        List<HistoricoVenda> _HistVenda;

        List<Parcela> Parcelas;
        Parcela _VEntrada;
        private long _IdTipoPagamento;
        private long? _IdSituacaoVenda;

        private long? _IdMotivoCancelamento;
        private long? _IdTipoReembolso;
        private bool _FechaVenda;

        public frmRealizarVenda01()
        {
            InitializeComponent();
        }

        public Venda VendaSelecionada
        {
            get { return _VendaSelecionada; }
            set { _VendaSelecionada = value; }
        }

        public long IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        public long IdCidade
        {
            get { return _IdCidade; }
            set { _IdCidade = value; }
        }

        public long IdProduto
        {
            get { return _IdProduto; }
            set { _IdProduto = value; }
        }

        public long IdTipoProduto
        {
            get { return _IdTipoProduto; }
            set { _IdTipoProduto = value; }
        }

        public long IdOperadora
        {
            get { return _IdOperadora; }
            set { _IdOperadora = value; }
        }

        public long IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        private void frmRealizarVenda01_Load(object sender, EventArgs e)
        {
            _VendaAtual = new Venda();
            

            if (_VendaSelecionada == null)
            {
                MoveVendaDefaults();
            }
            else
                MoveVendaVars();
            //Inicializa Pacote
            InicializaPacote();

            //Inicializa Passageiros
            InicializaPassageiros();

            //Inicializa DGVParcelas
            InicializaParcelas();
            
            //Inicializa Cancelamento
            InicializaCancelamento();

            //Inicializa Observacoes
            InicializaObservacoes();

            //Inicializa Documentos
            InicializaDocumentos();

            //Inicializa Interface de acordo com o status da Venda
            InicializaInterface((eSituacaoVenda)_IdSituacaoVenda);
        }

        private void MoveVendaDefaults()
        {
            _IdCliente = 0;
            _IdCidade = 0;
            _IdProduto = 0;
            _IdTipoProduto = 1;
            _IdOperadora = 0;
            _IdHotel = null;

            _IdUsuario = Vendedor.IDUsuario;
            _VendaAtual.Usuario = Vendedor; 
            _IdMotivo = 0;
            _DataVenda = DateTime.Now;
            _DataEmbarque = _DataVenda.Value.AddDays(10);
            _DataRetorno = _DataEmbarque.Value.AddDays(7);

            Passageiros = new List<PassageiroView>();

            _IdTipoMoeda = 1;
            _CambioDoDia = 1;
            _PrecoAdult = 0;
            _PrecoCHD = 0;
            _PrecoINF = 0;
            _Desconto = 0;
            _TaxaAdult = 0;
            _TaxaCHD = 0;
            _TaxaINF = 0;
            _TaxaAdm = 10;

            _IdTipoPagamento = 1;
            InicializaParcelamento();
            _IdSituacaoVenda = (long)eSituacaoVenda.Inicial;
            _HistVenda = new List<HistoricoVenda>();
        }

        /// <summary>
        /// inicializa List Parcelas, incluindo entrada 0
        /// </summary>
        private void InicializaParcelamento()
        {
            Parcelas = new List<Parcela>();
            _VEntrada = new Parcela();
            _VEntrada.DtVencimento = DateTime.Now.Date;
            _VEntrada.IdFormaPagamento = (long)eFPagamento.Dinheiro;
            _VEntrada.IdSituacao = ParcelaLiquidada;
            _VEntrada.Item = 0;
            _VEntrada.NumDoc = " ";
            _VEntrada.Valor = 0;
            Parcelas.Add(_VEntrada);
        }

        private void InicializaInterface(eSituacaoVenda Situacao)
        {
            // Inibe disparo da trigger dos radio buttons
            gbSituacaoVenda.Tag = false;
            EnableTBCancelamento(false);
            EnableDocumentos(true);
            EnableSalvarFechar(true);
            switch (Situacao)
            {
                case Viagens.eSituacaoVenda.Inicial:
                    rbOpt1.Text = "Em Elaboração";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = false;
                    rbOpt3.Visible = false;
                    rbOpt4.Visible = false;
                    rbOpt1.Tag = eSituacaoVenda.Inicial;
                    rbOpt2.Tag = eSituacaoVenda.Liberada;
                    rbOpt2.Tag = eSituacaoVenda.Pendencias;
                    EnableDocumentos(false);
                    EnableSalvarFechar(false);
                    break;
                case Viagens.eSituacaoVenda.Liberada:
                    rbOpt1.Text = "Liberada";
                    rbOpt2.Text = "Vouchers Ok";
                    rbOpt3.Text = "Pendente";
                    rbOpt4.Text = "Cancelada";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = true;
                    rbOpt3.Visible = true;
                    rbOpt4.Visible = true;
                    rbOpt1.Tag = eSituacaoVenda.Liberada;
                    rbOpt2.Tag = eSituacaoVenda.Vouchers_Entregues;
                    rbOpt3.Tag = eSituacaoVenda.Pendencias;
                    rbOpt4.Tag = eSituacaoVenda.Cancelamento_em_andamento;
                    break;
                case Viagens.eSituacaoVenda.Pendencias:
                    rbOpt1.Text = "Pendente";
                    rbOpt2.Text = "Liberada";
                    rbOpt3.Text = "Cancelar";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = true;
                    rbOpt3.Visible = true;
                    rbOpt4.Visible = false;
                    rbOpt1.Tag = eSituacaoVenda.Pendencias;
                    rbOpt2.Tag = eSituacaoVenda.Liberada;
                    rbOpt3.Tag = eSituacaoVenda.Cancelamento_em_andamento;
                    break;
                case Viagens.eSituacaoVenda.Vouchers_Entregues:
                    rbOpt1.Text = "Vouchers Ok";
                    rbOpt2.Text = "Cancelada";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = true;
                    rbOpt3.Visible = false;
                    rbOpt4.Visible = false;
                    rbOpt1.Tag = eSituacaoVenda.Vouchers_Entregues;
                    rbOpt2.Tag = eSituacaoVenda.Cancelamento_em_andamento;
                    break;
                case Viagens.eSituacaoVenda.Cancelamento_em_andamento:
                    rbOpt1.Text = "Cancelada";
                    rbOpt2.Text = "Cancelamento Ok";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = true;
                    rbOpt3.Visible = false;
                    rbOpt4.Visible = false;
                    rbOpt1.Tag = eSituacaoVenda.Cancelamento_em_andamento;
                    rbOpt2.Tag = eSituacaoVenda.Cancelamento_Concluido;
                    EnableTBCancelamento(true);
                    tcDatas.SelectedIndex = 5;
                    break;
                case Viagens.eSituacaoVenda.Cancelamento_Concluido:
                    rbOpt1.Text = "Cancelamento Ok";
                    rbOpt1.Visible = true;
                    rbOpt2.Visible = false;
                    rbOpt3.Visible = false;
                    rbOpt4.Visible = false;
                    rbOpt1.Tag = eSituacaoVenda.Cancelamento_Concluido;
                    EnableTBCancelamento(true);
                    tcDatas.SelectedIndex = 5;
                    break;
                default:
                    break;
            }
            rbOpt1.Checked = true;
            gbSituacaoVenda.Tag = true;
        }

        private void EnableSalvarFechar(bool p)
        {
            _FechaVenda = p;
            if (p)
                btSalvaVenda.Text = "Salvar e Fechar";
            else
                btSalvaVenda.Text = "Salvar";
        }

        private void EnableDocumentos(bool p)
        {
            dgvDocs.Enabled = p;
            btEmitir.Enabled = p;
        }

        private void AlteraSituacaoVenda(eSituacaoVenda Situacao)
        {
            if ((bool)gbSituacaoVenda.Tag)
            {
                _IdSituacaoVenda = (long)Situacao;
                InicializaInterface(Situacao);
            }
        }
        private void rbOpt1_CheckedChanged(object sender, EventArgs e)
        {
            AlteraSituacaoVenda((eSituacaoVenda)rbOpt1.Tag);
        }

        private void rbOpt2_CheckedChanged(object sender, EventArgs e)
        {
            AlteraSituacaoVenda((eSituacaoVenda)rbOpt2.Tag);
        }

        private void rbOpt3_CheckedChanged(object sender, EventArgs e)
        {
            AlteraSituacaoVenda((eSituacaoVenda)rbOpt3.Tag);
        }

        private void rbOpt4_CheckedChanged(object sender, EventArgs e)
        {
            AlteraSituacaoVenda((eSituacaoVenda)rbOpt4.Tag);
        }

        // Move dados da Venda para variáveis locais
        private void MoveVendaVars()
        {
            _VendaAtual = _VendaSelecionada;

            _IdCliente = _VendaSelecionada.IdCliente;
            _IdCidade = _VendaSelecionada.IdCidade;
            _IdProduto = _VendaSelecionada.IdProduto;
            _IdTipoProduto = _VendaSelecionada.Produto.IdTipoProduto;
            _IdOperadora = _VendaSelecionada.IdOperadora;
            _IdHotel = _VendaSelecionada.IdHotel;
            _IdUsuario = _VendaSelecionada.IdUsuario;
            _IdMotivo = _VendaSelecionada.IdMotivoViagem;
            _DataVenda = _VendaSelecionada.DataVenda;
            _DataEmbarque = (_VendaSelecionada.DataEmbarque==null?DateTime.Now:_VendaSelecionada.DataEmbarque);
            _DataRetorno = (_VendaSelecionada.DataRetorno==null?DateTime.Now:_VendaSelecionada.DataRetorno);

            Passageiros = (from c in _VendaSelecionada.Passageiros
                           select new PassageiroView
                           {
                               IdCliente = c.Cliente.IDCliente,
                               IdCategoria = c.IdCategoria,
                               DtNascimento = c.Cliente.DataNascimento,
                               Nome = c.Cliente.Nome1 + " " + c.Cliente.Nome2 + " " + c.Cliente.Nome3
                           }).ToList<PassageiroView>();

            _IdTipoMoeda = _VendaSelecionada.IdTipoMoeda;
            _CambioDoDia = _VendaSelecionada.CambioDoDia;
            _PrecoAdult = _VendaSelecionada.PrecoAdult;
            _PrecoCHD = _VendaSelecionada.PrecoCHD;
            _PrecoINF = _VendaSelecionada.PrecoINF;
            _Desconto = _VendaSelecionada.Desconto;
            _TaxaAdult = _VendaSelecionada.TaxaAdult;
            _TaxaCHD = _VendaSelecionada.TaxaCHD;
            _TaxaINF = _VendaSelecionada.TaxaInf;
            _TaxaAdm = _VendaSelecionada.TaxaAdm;

            _IdTipoReembolso = _VendaSelecionada.IdTipoReembolso;
            _IdMotivoCancelamento = _VendaSelecionada.IdMotivoCancelamento;
            _VendaAtual.HistoricoVendas.Clear();

            _IdTipoPagamento = _VendaSelecionada.IdTipoPagamento;
            Parcelas = (from p in _VendaSelecionada.Parcelas
                        orderby p.Item
                        select p).ToList<Parcela>();
            if (Parcelas.Count == 0)
                InicializaParcelamento();
            _VEntrada = Parcelas[0];
            _IdSituacaoVenda = _VendaSelecionada.IdSituacaoVenda;
            tbLocalizador.Text = _VendaSelecionada.Localizador;
            DisplayContaR(_VendaSelecionada.Cliente);
            rtbObs.Text = _VendaSelecionada.Observacoes;

            ViagensDataContext ViagensDC = new ViagensDataContext();
            _HistVenda = (from h in ViagensDC.HistoricoVendas
                          where h.IdVenda == _VendaSelecionada.IdVenda
                          select h).ToList<HistoricoVenda>();

            //_HistVenda = (from h in _VendaSelecionada.HistoricoVendas
            //              orderby h.DtRegistro
            //              select h).ToList<HistoricoVenda>();
        }

        private void DisplayContaR(Cliente cliente)
        {
            string[] AuxContaR = (cliente.ContaReembolso==null? 
                new string[]{"","",""}:cliente.ContaReembolso.Split(new char[] { ';' }));
            tbBancoR.Text = AuxContaR[0];
            tbAgenciaR.Text = AuxContaR[1];
            tbContaR.Text = AuxContaR[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalvaVenda();
        }

        private void SalvaVenda()
        {
            if (CamposObrigatoriosOk())
            {
                if (VendaOk())
                {
                    SalvaDados();
                }
                else
                {
                    if (MessageBox.Show("Há pendências. Quer salvar mesmo assim?", "Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _IdSituacaoVenda = (long)eSituacaoVenda.Pendencias;
                        SalvaDados();
                    }
                }
            }
            else
                MessageBox.Show("Favor preencher campos obrigatórios");
        }

        private void SalvaDados()
        {
            MoveVarsVenda();
            acc.InsertOrUpdateCliente(_VendaAtual.Cliente);
            acc.InsertOrUpdateVenda(_VendaAtual);
            if (_FechaVenda)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Venda Registrada com Sucesso", "Operação executado com Sucesso");
                // Para recuperar dados relacionados aa venda 
                _VendaAtual = acc.ObtemVenda(_VendaAtual.IdVenda);
                AlteraSituacaoVenda((eSituacaoVenda)_VendaAtual.IdSituacaoVenda);
            }
        }

        /// <summary>
        /// Verifica se campos obrigatórios foram preenchidos
        /// </summary>
        /// <returns></returns>
        private bool CamposObrigatoriosOk()
        {
            bool ret = true;
            ret = ret && ValidaCliente();
            ret = ret && ValidaProduto();
            ret = ret && ValidaCidade();
            ret = ret && ValidaOperadora();
            return ret;
        }

        private bool ValidaPais()
        {
            bool ret = true;
            if (tbPais.Text == " ")
            {
                epPacote.SetError(tbPais, "Favor preencher País de Destino!");
                ret = false;
            }
            else
            {
                epPacote.SetError(tbPais, "");
                var FonteCid = new AutoCompleteStringCollection();
                FonteCid.AddRange(acc.ListaCidades(tbPais.Text));
                tbCidade.AutoCompleteCustomSource = FonteCid;
            }
            return ret;
        }

        private bool ValidaCidade()
        {
            bool ret = true;
            if (ValidaPais())
            {
                if (tbCidade.Text == " ")
                {
                    epPacote.SetError(tbCidade, "Favor preencher Cidade de Destino!");
                    ret = false;
                }
                else
                {
                    epPacote.SetError(tbCidade, "");
                    _IdPais = acc.BuscaOuInserePais(tbPais.Text);
                    _VendaAtual.Cidade = acc.BuscaOuInsereCidade(_IdPais, tbCidade.Text);
                    _IdCidade = _VendaAtual.Cidade.IdCidade;
                }
            }
            return ret;
        }

        private bool ValidaOperadora()
        {
            bool ret = true;
            if (_IdOperadora == 0)
            {
                epPacote.SetError(tbOPeradora, "Favor selecionar Operadora!");
                ret = false;
            }
            else
                epPacote.SetError(tbOPeradora, "");
            return ret;
        }

        private bool ValidaProduto()
        {
            bool ret = true;
            if (_IdProduto == 0)
            {
                epPacote.SetError(tbProduto, "Favor selecionar Produto!");
                ret = false;
            }
            else
                epPacote.SetError(tbProduto, "");
            return ret;
        }

        private bool ValidaCliente()
        {
            bool ret = true;
            if (_IdCliente == 0)
            {
                epPacote.SetError(tbCliente, "Favor selecionar cliente!");
                ret = false;
            }
            else
                epPacote.SetError(tbCliente, "");
            return ret;
        }

        private void MoveVarsVenda()
        {
            _VendaAtual.IdCidade = _IdCidade;
            _VendaAtual.IdCliente = _IdCliente;
            _VendaAtual.IdOperadora = _IdOperadora;
            _VendaAtual.IdProduto = _IdProduto;
            _VendaAtual.IdHotel = _IdHotel;
            _VendaAtual.IdMotivoViagem = _IdMotivo;
            _VendaAtual.DataVenda = dtpDtVenda.Value;
            _VendaAtual.DataEmbarque = dtpDtEmbarque.Value;
            _VendaAtual.DataRetorno = dtpDtRetorno.Value;

            _VendaAtual.Passageiros.Clear();
            foreach (PassageiroView pv in Passageiros)
            {
                Passageiro p = new Passageiro();
                p.IdCategoria = (int)pv.IdCategoria;
                p.IdPassageiro = pv.IdCliente;
                _VendaAtual.Passageiros.Add(p);
            }
            
            _VendaAtual.IdTipoMoeda = _IdTipoMoeda;
            _VendaAtual.CambioDoDia = _CambioDoDia;
            _VendaAtual.PrecoAdult = _PrecoAdult;
            _VendaAtual.PrecoCHD = _PrecoCHD;
            _VendaAtual.PrecoINF = _PrecoINF;
            _VendaAtual.Desconto = _Desconto;
            _VendaAtual.TaxaAdult = _TaxaAdult;
            _VendaAtual.TaxaCHD = _TaxaCHD;
            _VendaAtual.TaxaInf = _TaxaINF;
            _VendaAtual.TaxaAdm = _TaxaAdm;

            //Pagamentos
            _VendaAtual.IdTipoPagamento = _IdTipoPagamento;
            _VendaAtual.Parcelas.Clear();
            foreach (Parcela p in Parcelas)
            {
                Parcela par = new Parcela();
                par.DtVencimento = p.DtVencimento;
                par.IdFormaPagamento = p.IdFormaPagamento;
                par.IdSituacao = p.IdSituacao;
                par.Item = p.Item;
                par.NumDoc = p.NumDoc;
                par.Valor = p.Valor;
                _VendaAtual.Parcelas.Add(par);
            }
            if ((_IdSituacaoVenda == ((long)eSituacaoVenda.Cancelamento_Concluido)) ||
                (_IdSituacaoVenda == ((long)eSituacaoVenda.Cancelamento_em_andamento)))
            {
            _VendaAtual.IdMotivoCancelamento = _IdMotivoCancelamento;
            _VendaAtual.IdTipoReembolso = _IdTipoReembolso;
            }

            _VendaAtual.IdSituacaoVenda = (_IdSituacaoVenda == (long)eSituacaoVenda.Inicial?
                (long)eSituacaoVenda.Liberada:_IdSituacaoVenda);

            _VendaAtual.IdUsuario = _IdUsuario;
            _VendaAtual.Localizador = tbLocalizador.Text;
            _VendaAtual.Cliente.ContaReembolso = tbBancoR.Text + ";" + tbAgenciaR.Text +
                ";" + tbContaR.Text;
            _VendaAtual.Observacoes = rtbObs.Text;
        }

        private bool VendaOk()
        {
            bool rc = true;
            rc = rc && PacoteEstaOk();
            //rc = rc && PassageirosEstaOk();
            //rc = rc && DatasEstaOk();
            rc = rc && PagamentoEstaOk();
            return rc;
        }

        private bool PagamentoEstaOk()
        {
            //throw new NotImplementedException();
            return true;
        }

        private bool PacoteEstaOk()
        {
            bool ret = true;
            ret = ret && (_IdCliente != 0);
            ret = ret && (_IdProduto != 0);
            ret = ret && (_IdCidade != 0);
            ret = ret && (_IdOperadora != 0);
            //ret = ret && (_IdHotel != 0);
            //ret = ret && (_IdMotivo != 0);
            //ret = ret && (_DataVenda != null);
            return ret;
        }

        // Controle do pacote
        private void InicializaPacote()
        {
            //Inicializa Combobox TipoProduto
            cbTProd.Tag = false;
            cbTProd.DataSource = Listas1.TiposProduto;
            cbTProd.DisplayMember = "Nome";
            cbTProd.ValueMember = "IdTipoProduto";
            cbTProd.SelectedValue = _IdTipoProduto;
            cbTProd.Tag = true;

            cbMotivoViagem.Tag = false;
            cbMotivoViagem.DataSource = Listas1.TMotivosViagem;
            cbMotivoViagem.DisplayMember = "Nome";
            cbMotivoViagem.ValueMember = "IdMotivo";
            cbMotivoViagem.SelectedValue = _IdMotivo;
            cbMotivoViagem.Tag = true;

            tbCliente.Text = (_VendaAtual.Cliente == null ? " " : _VendaAtual.Cliente.Nome1 + " "
                + _VendaAtual.Cliente.Nome2 + " " + _VendaAtual.Cliente.Nome3);
            tbProduto.Text = (_VendaAtual.Produto == null ? " " : _VendaAtual.Produto.Nome);

            tbPais.Text = (_VendaAtual.Cidade == null ? "BRASIL" : _VendaAtual.Cidade.Pais.Nome);
            tbCidade.Text = (_VendaAtual.Cidade == null ? "RIO DE JANEIRO" : _VendaAtual.Cidade.Nome);
            var FontePais = new AutoCompleteStringCollection();
            FontePais.AddRange(acc.ListaPaises());
            tbPais.AutoCompleteCustomSource = FontePais;
            var FonteCid = new AutoCompleteStringCollection();
            FonteCid.AddRange(acc.ListaCidades(tbPais.Text));
            tbCidade.AutoCompleteCustomSource = FonteCid;

            tbOPeradora.Text = (_VendaAtual.Fornecedor == null ? " " : _VendaAtual.Fornecedor.Nome);
            tbHotel.Text = (_VendaAtual.Fornecedor1 == null ? " " : _VendaAtual.Fornecedor1.Nome);

            dtpDtVenda.Value = (DateTime)_DataVenda;
            dtpDtEmbarque.Value = (DateTime)_DataEmbarque;
            dtpDtRetorno.Value = (DateTime)_DataRetorno;
        }

        private void tbCliente_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = cad.SelecionaCliente(true);

            if (cliente != null)
            {
                _IdCliente = cliente.IDCliente;
                _VendaAtual.Cliente = cliente;
                tbCliente.Text = cliente.Nome1 +" "+ cliente.Nome2 +" "+ cliente.Nome3;
                DisplayContaR(cliente);
            }
        }

        private void cbTProd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((bool)cbTProd.Tag)
            {
                _IdTipoProduto = (long)cbTProd.SelectedValue;
                if (_IdProduto != 0)
                {
                    Produto prod = acc.ObtemProduto(_IdProduto);
                    if (prod != null)
                    {
                        if (prod.IdTipoProduto != _IdTipoProduto)
                        {
                            _IdProduto = 0;
                            tbProduto.Text = "";
                        }
                    }
                }
            }
        }

        private void tbProduto_Click(object sender, EventArgs e)
        {
            _IdTipoProduto = long.Parse(cbTProd.SelectedValue.ToString());
            Produto produto = cad.SelecionaProduto(true, _IdTipoProduto);

            if (produto != null)
            {
                _IdProduto = produto.IdProduto;
                _VendaAtual.Produto = produto;
                tbProduto.Text = produto.Nome;
                // Atualiza campo TipoProduto
                _IdTipoProduto = produto.IdTipoProduto;
                cbTProd.SelectedValue = _IdTipoProduto;
            }
        }

        private void SelecionaCidade()
        {
            Cidade cidade = cad.SelecionaCidade(true);
            if (cidade != null)
            {
                _IdCidade = cidade.IdCidade;
                _VendaAtual.Cidade = cidade;
                tbCidade.Text = cidade.Nome;
            }
        }

        private void tbFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor operadora = cad.SelecionaFornecedor(true, Operadoras, 0);

            if (operadora != null)
            {
                _IdOperadora = operadora.IdFornecedor;
                _VendaAtual.Fornecedor = operadora;
                this.tbOPeradora.Text = operadora.Nome;
            }
        }

        private void tbHotel_Click(object sender, EventArgs e)
        {
            Fornecedor hotel = cad.SelecionaFornecedor(true,Hoteis,_IdCidade);

            if (hotel != null)
            {
                _IdHotel = hotel.IdFornecedor;
                _VendaAtual.Fornecedor1 = hotel;
                this.tbHotel.Text = hotel.Nome;
                if (_IdTipoProduto == Hoteis)
                {
                    if (_IdOperadora == 0)
                    {
                        _IdOperadora = hotel.IdFornecedor;
                        _VendaAtual.Fornecedor = hotel;
                        this.tbOPeradora.Text = hotel.Nome;
                    }
                }
            }
        }

        private void cbMotivoViagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bool)cbMotivoViagem.Tag)
                _IdMotivo = ((TMotivoViagem)cbMotivoViagem.SelectedItem).IdMotivo ;
        }

        // Controle de Passageiros
        private bool PassageirosEstaOk()
        {
            return (Decimal.Parse(ctbPrecoT.NumericText) > 0);
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            Cliente c = cad.SelecionaCliente(true);
            AdicionaPassageiro(c);
        }

        private void AdicionaPassageiro(Cliente c)
        {
            if (c != null)
            {
                PassageiroView pv = new PassageiroView(1, c.IDCliente,
                    c.Nome1 + " " + c.Nome2 + " " + c.Nome3, c.DataNascimento);
                Passageiros.Add(pv);
                RefreshPassageiros();
                AtualizaContadorPassageiros();
            }
        }

        private void AtualizaPreco()
        {
            decimal AuxCb = 0;
            decimal AuxPA = 0;
            decimal AuxPC = 0;
            decimal AuxPI = 0;
            decimal AuxTA = 0;
            decimal AuxTC = 0;
            decimal AuxTI = 0;
            decimal AuxPS = 0;
            decimal AuxPD = 0;
            decimal AuxPT = 0;
            decimal AuxTT = 0;
            
            try
            {
                AuxCb = decimal.Parse(ctbCambio.NumericText);
                AuxPA = decimal.Parse(ctbPrecoA.NumericText);
                AuxPC = decimal.Parse(ctbPrecoC.NumericText);
                AuxPI = decimal.Parse(ctbPrecoI.NumericText);
                AuxTA = decimal.Parse(ctbTaxaA.NumericText);
                AuxTC = decimal.Parse(ctbTaxaC.NumericText);
                AuxTI = decimal.Parse(ctbTaxaI.NumericText);
                AuxPD = decimal.Parse(ctbPrecoD.NumericText);
                _CambioDoDia = AuxCb;
                _PrecoAdult = AuxPA;
                _PrecoCHD = AuxPC;
                _PrecoINF = AuxPI;
                _Desconto = AuxPD;
                _TaxaAdult = AuxTA;
                _TaxaCHD = AuxTC;
                _TaxaINF = AuxTI;
                AuxPS = (AuxPA * int.Parse(tbQtdA.Text) +
                    AuxPC * int.Parse(tbQtdC.Text) +
                    AuxPI * int.Parse(tbQtdI.Text)) * AuxCb;
                AuxPT = AuxPS - AuxPD;

                AuxTT = (AuxTA * int.Parse(tbQtdA.Text) +
                    AuxTC * int.Parse(tbQtdC.Text) +
                    AuxTI * int.Parse(tbQtdI.Text)) * AuxCb;
                ctbPrecoS.Text = AuxPS.ToString();
                ctbPrecoT.Text = AuxPT.ToString();
                ctbTaxaT.Text = AuxTT.ToString();

                //Atualiza total do pacote na aba Pagamento
                ctbTotalPacote.Text = AuxPT.ToString();
                ctbVTaxas.Text = AuxTT.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AtualizaContadorPassageiros()
        {
            int[] ContadorPassageiros = new int[] { 0, 0, 0, 0 }; //Total,Adult,CHD,INF
            foreach (PassageiroView pv in Passageiros)
            {
                ContadorPassageiros[pv.IdCategoria]++;
            }
            ContadorPassageiros[0] = ContadorPassageiros[1] + ContadorPassageiros[2] +
                ContadorPassageiros[3];
            tbQtdA.Text = ContadorPassageiros[1].ToString();
            tbQtdC.Text = ContadorPassageiros[2].ToString();
            tbQtdI.Text = ContadorPassageiros[3].ToString();
            AtualizaPreco();
        }



        private void InicializaPassageiros()
        {
            dgvPassageiros.DataSource = Passageiros;
            dgvPassageiros.Columns.Remove("IdCategoria");

            //Adiciona coluna categoria passageiro
            DataGridViewComboBoxColumn dgvcb1 = new DataGridViewComboBoxColumn();
            dgvcb1.HeaderText = "Categoria";
            dgvcb1.DataSource = Listas1.Categorias;
            dgvcb1.DisplayMember = "Nome";
            dgvcb1.ValueMember = "IdCategoria";
            dgvcb1.DataPropertyName = "IdCategoria";
            dgvPassageiros.Columns.Insert(0, dgvcb1);

            //Inicializa Combobox TipoMoeda
            cbTipoMoeda.Tag = false;
            cbTipoMoeda.DataSource = Listas1.TiposMoeda;
            cbTipoMoeda.DisplayMember = "Nome";
            cbTipoMoeda.ValueMember = "Simbolo";
            cbTipoMoeda.Tag = true;
            cbTipoMoeda.SelectedItem = Listas1.Moeda((long)_IdTipoMoeda);
            AlteraMoeda();

            //valores 
            ctbCambio.Text = _CambioDoDia.ToString();
            ctbPrecoA.Text = _PrecoAdult.ToString();
            ctbPrecoC.Text = _PrecoCHD.ToString() ;
            ctbPrecoI.Text = _PrecoINF.ToString();
            ctbPrecoD.Text = _Desconto.ToString();
            ctbTaxaA.Text = _TaxaAdult.ToString() ;
            ctbTaxaC.Text = _TaxaCHD.ToString();
            ctbTaxaI.Text = _TaxaINF.ToString();

            //Atualiza Contadores de Passageiros
            AtualizaContadorPassageiros();
        }

        //Altera simbolo da moeda nos precos 
        private void AlteraMoeda()
        {
            if ((bool)cbTipoMoeda.Tag)
            {
                string Simbolo = cbTipoMoeda.SelectedValue.ToString();
                _IdTipoMoeda = ((TipoMoeda)(cbTipoMoeda.SelectedItem)).IdTipoMoeda;

                ctbPrecoA.Prefix = ctbPrecoC.Prefix = ctbPrecoI.Prefix = Simbolo;
                ctbTaxaA.Prefix = ctbTaxaC.Prefix = ctbTaxaI.Prefix = Simbolo;
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r1 in dgvPassageiros.SelectedRows)
            {
                PassageiroView pv = (from p in Passageiros
                              where p.IdCliente == long.Parse(r1.Cells[1].Value.ToString())
                              select p).SingleOrDefault<PassageiroView>();
                if (pv != null)
                    Passageiros.Remove(pv);
            }
            RefreshPassageiros();
            AtualizaContadorPassageiros();
        }

        private void RefreshPassageiros()
        {
            List<PassageiroView> pvs = (from p in Passageiros 
                                       orderby p.Nome select p).ToList<PassageiroView>();
            dgvPassageiros.DataSource = pvs;
        }

        private void dgvPassageiros_Click(object sender, EventArgs e)
        {
            if (dgvPassageiros.CurrentRow != null)
                dgvPassageiros.CurrentRow.Selected = true;
        }

        private void dgvPassageiros_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPassageiros.IsCurrentCellDirty)
            {
                dgvPassageiros.CommitEdit(DataGridViewDataErrorContexts.Commit);
                AtualizaContadorPassageiros();
            }

        }

        private void cbTipoMoeda_SelectedValueChanged(object sender, EventArgs e)
        {
            AlteraMoeda();
        }

        private void ctbCambio_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbPrecoA_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbTaxaA_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbPrecoC_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbTaxaC_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbPrecoI_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbTaxaI_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void ctbPrecoD_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void tbQtdA_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void tbQtdC_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        private void tbQtdI_Validated(object sender, EventArgs e)
        {
            AtualizaPreco();
        }

        //--------------------------------------------------------------------
        // Datas

        private bool DatasEstaOk()
        {
            return true;
        }

        private void dtpDtEmbarque_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDtEmbarque.Value > dtpDtRetorno.Value)
            {
                dtpDtRetorno.Value = dtpDtEmbarque.Value.AddDays(7);
            }
        }

        private void dtpDtRetorno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDtRetorno_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDtRetorno.Value < dtpDtEmbarque.Value)
            {
                e.Cancel = true;
            }
        }

        //--------------------------------------------------------------------
        // Controle de Pagamentos

        //Inicializa DGVParcelas
        private void InicializaParcelas()
        {
            cbTipoPagamento.DataSource = Listas1.TiposPagamento;
            cbTipoPagamento.DisplayMember = "Nome";
            cbTipoPagamento.ValueMember = "IdTipoPagamento";
            cbTipoPagamento.SelectedValue = _IdTipoPagamento;


            dgvParcelas.DataSource = Parcelas;
            dgvParcelas.Columns.Remove("IdFormaPagamento");
            dgvParcelas.Columns.Remove("IdSituacao");

            DataGridViewComboBoxColumn dgvcbSP = new DataGridViewComboBoxColumn();
            dgvcbSP.DataSource = Listas1.SituacoesParcela;
            dgvcbSP.HeaderText = "Situação";
            dgvcbSP.DisplayMember = "Nome";
            dgvcbSP.ValueMember = "IdSituacao";
            dgvcbSP.DataPropertyName = "IdSituacao";
            dgvcbSP.Name = "Situação";
            dgvcbSP.AutoComplete = true;
            dgvParcelas.Columns.Insert(1, dgvcbSP);

            DataGridViewComboBoxColumn dgvcbFP = new DataGridViewComboBoxColumn();
            dgvcbFP.DataSource = Listas1.FormasPagamento;
            dgvcbFP.HeaderText = "Pagamento";
            dgvcbFP.ValueMember = "IdFormaPagamento";
            dgvcbFP.DisplayMember = "Nome";
            dgvcbFP.DataPropertyName = "IdFormaPagamento";
            dgvcbFP.Name = "Pagamento";
            dgvParcelas.Columns.Insert(4, dgvcbFP);

            ntbTaxaAdm.Text = (_TaxaAdm==null? "0":_TaxaAdm.ToString());
            ctbVEntrada.Text = _VEntrada.Valor.ToString();
            if (((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento == (long)eTPagamento.ParceladoSemEntrada)
                nudNumParcelas.Value = Parcelas.Count - 1;
            else
                nudNumParcelas.Value = Parcelas.Count ;
            decimal AuxVP = 0;
            for (int ix = 1; ix < Parcelas.Count; ix++)
            {
                AuxVP = AuxVP + Parcelas[ix].Valor;
            }
            ctbVParcelar.Text = AuxVP.ToString();
            RefreshParcelas();
        }

        /// <summary>
        /// Ajusta o numero de parcelas de acordo com o tipo de pagamento
        /// </summary>
        /// <param name="np">Mumero real considerando a entrada</param>
        /// <returns>retorna número de parcelas a apresentar</returns>
        private int NumeroParcelas(int np)
        {
            int Ret = np;
            if (((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento == (long)eTPagamento.ParceladoSemEntrada)
                Ret = np - 1;
            return Ret;
        }
        private void nudNumParcelas_Validating(object sender, CancelEventArgs e)
        {
            int np = (int)nudNumParcelas.Value;
            if (((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento == (long)eTPagamento.AVista)
            {
                if (np > 1)
                {
                    nudNumParcelas.Value = 1;
                    e.Cancel = true;
                }
            }
            else
            {
                if (np < 2)
                {
                    nudNumParcelas.Value = 2;
                    e.Cancel = true;
                }
            }
        }

        private void nudNumParcelas_Validated(object sender, EventArgs e)
        {
//            int np = (int)nudNumParcelas.Value;
//            AjustaNumeroParcelas(np);
        }

        private void AjustaNumeroParcelas(int np)
        {
            int nr = Parcelas.Count; //dgvParcelas.Rows.Count;

            if (np > nr)
            {
                AdicionaParcelas(np);
            }
            else if (np < nr)
            {
                RemoveParcelas(np);
            }
        }

        private void RefreshParcelas()
        {
            if (Parcelas != null)
            {
                int init = 0;
                if (((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento == (long)eTPagamento.ParceladoSemEntrada)
                    init = 1;
                List<Parcela> pvs = (from p in Parcelas where p.Item >= init
                                          orderby p.Item
                                          select p).ToList<Parcela>();
                dgvParcelas.DataSource = pvs;
                dgvParcelas.Columns.Remove("IdParcela");
                dgvParcelas.Columns.Remove("IdVenda");
                dgvParcelas.Columns.Remove("FormaPagamento");
                dgvParcelas.Columns.Remove("SituacaoParcela");
                dgvParcelas.Columns.Remove("Venda");
                dgvParcelas.Columns["Item"].DisplayIndex = 0;
                dgvParcelas.Columns["Item"].Width = 30;
                dgvParcelas.Columns["Situação"].Width = 80;
                dgvParcelas.Columns["DtVencimento"].DisplayIndex = 2;
                dgvParcelas.Columns["Valor"].DisplayIndex = 3;
                
                dgvParcelas.Columns["Valor"].Width = 70;
                dgvParcelas.Columns["NumDoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        /// <summary>
        /// Deixa o array com p elementos
        /// Remove as parcelas "p" a Parcelas.Count
        /// </summary>
        /// <param name="p">Numero parcelas a manter</param>
        private void RemoveParcelas(int p)
        {
            int np = Parcelas.Count;
            Parcelas.RemoveRange(p, Parcelas.Count - p);
        }

        private void AjustaValorParcelas()
        {
            if (Parcelas != null)
            {
                decimal total = decimal.Parse(ctbVParcelar.NumericText);
                int np = Parcelas.Count - 1;
                decimal vp = (np == 0 ? 0 : total / np);
                for (short ix = 1; ix < Parcelas.Count; ix++)
                {
                    Parcelas[ix].Valor = vp;
                    Parcelas[ix].Item = ix;
                }
            }
        }

        private void AdicionaParcelas(int p)
        {
            if (Parcelas != null)
            {
                int np = Parcelas.Count;
                DateTime dti = (np == 0 ? DateTime.Now : Parcelas[np - 1].DtVencimento.AddMonths(1));
                string Documento = (np == 0 ? " " : Parcelas[np - 1].NumDoc);
                long idfp = (np == 0 ? 1 : Parcelas[np - 1].IdFormaPagamento);
                for (short ix = (short) np; ix < p; ix++)
                {
                    Parcela AuxP = new Parcela();
                    AuxP.Item = ix;
                    AuxP.DtVencimento = dti;
                    AuxP.Valor = 0;
                    AuxP.NumDoc = Documento;
                    AuxP.IdSituacao = 1;
                    AuxP.IdFormaPagamento = idfp;
                    Parcelas.Add(AuxP);
                    dti = dti.AddMonths(1);
                }
            }
        }

        private void AjustaVctoParcelas(DateTime DataInicial)
        {
            if (Parcelas != null)
            {
                DateTime DtVcto = DataInicial.AddMonths(1).Date;
                for (int ix = 1; ix < Parcelas.Count; ix++)
                {
                    Parcelas[ix].DtVencimento = DtVcto;
                    DtVcto = DtVcto.AddMonths(1).Date;
                }
            }
        }

        private void AjustaPagAVista()
        {
            nudNumParcelas.Enabled = false;
            decimal AuxTP = decimal.Parse(ctbTotalPacote.NumericText);
            decimal AuxVT = decimal.Parse(ctbVTaxas.NumericText);
            decimal Entrada = AuxTP + AuxVT;
            decimal VParcelar = 0;
            ctbVEntrada.Text = Entrada.ToString();
            ctbVParcelar.Text = VParcelar.ToString();
            _VEntrada.Valor = Entrada;
        }

        /// <summary>
        /// Ajusta parcelas para Pagamento Parcelado com Entrada
        /// </summary>
        private void AjustaPagParceladoComEnt()
        {
            nudNumParcelas.Enabled = true;
            decimal AuxTP = decimal.Parse(ctbTotalPacote.NumericText);
            decimal AuxVT = decimal.Parse(ctbVTaxas.NumericText);
            decimal AuxTAdm = decimal.Parse(ntbTaxaAdm.NumericText) / 100;
            decimal Entrada = (AuxTAdm * AuxTP) + AuxVT;
            decimal VParcelar = (1 - AuxTAdm)*AuxTP ;
            ctbVEntrada.Text = Entrada.ToString();
            ctbVParcelar.Text = VParcelar.ToString();
            _VEntrada.Valor = Entrada;
            _TaxaAdm = decimal.Parse(ntbTaxaAdm.NumericText);
        }


        /// <summary>
        /// Ajusta parcelas para Pagamento Parcelado sem Entrada
        /// </summary>
        private void AjustaPagParceladoSemEnt()
        {
            nudNumParcelas.Enabled = true;
            decimal AuxTP = decimal.Parse(ctbTotalPacote.NumericText);
            decimal AuxVT = decimal.Parse(ctbVTaxas.NumericText);
            decimal AuxTAdm = decimal.Parse(ntbTaxaAdm.NumericText) / 100;
            decimal Entrada = 0;
            decimal VParcelar = AuxTP + AuxVT;
            ctbVEntrada.Text = Entrada.ToString();
            ctbVParcelar.Text = VParcelar.ToString();
            _VEntrada.Valor = Entrada;
        }

        private void AjustarTipoPagamento()
        {
            eTPagamento tp = (eTPagamento)((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento;
            switch (tp)
            {
                case eTPagamento.AVista:
                    nudNumParcelas.Value = 1;
                    AjustaPagAVista();
                    break;
                case eTPagamento.ParceladoComEntrada:
                    if (nudNumParcelas.Value < 2)
                        nudNumParcelas.Value = 2;
                    AjustaPagParceladoComEnt();
                    break;
                case eTPagamento.ParceladoSemEntrada:
                    if (nudNumParcelas.Value < 2)
                        nudNumParcelas.Value = 2;
                    AjustaPagParceladoSemEnt();
                    break;
                default:
                    break;
            }
            _IdTipoPagamento = (long)((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento;
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
//            _IdSituacaoVenda = long.Parse(cbStatus.SelectedValue.ToString());
        }

        private void tcDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcDatas.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    AjustarTipoPagamento();
                    //AjustaParcelas();
                    RefreshParcelas();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void dtpDtInicial_ValueChanged(object sender, EventArgs e)
        {
            AjustaVctoParcelas(dtpDtInicial.Value);
            RefreshParcelas();
        }

        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditaNumDocPag(e.RowIndex, e.ColumnIndex);
        }

        private void EditaNumDocPag(int row, int col)
        {
            if (Parcelas != null)
            {
                if (dgvParcelas.Columns[col].HeaderText == "NumDoc")
                {
                    if (row >= 0)
                    {
                        Parcela ps = Parcelas[row];
                        switch ((eFPagamento)ps.IdFormaPagamento)
                        {
                            case eFPagamento.Cartao:
                                ps.NumDoc = ObtemDadosCartao(ps.NumDoc);
                                break;
                            case eFPagamento.Cheque:
                                ps.NumDoc = ObtemDadosCheque(ps.NumDoc);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                    dgvParcelas.Rows[row].Cells[col].Selected = true;
            }
            //RefreshParcelas();
        }

        private string ObtemDadosCheque(string doc)
        {
            frmPar02 frm = new frmPar02();
            string ret;
            string[] docs = doc.Split(new char[] { ';' });
            if (docs.Length == 4)
            {
                frm.Banco = docs[0];
                frm.Agencia = docs[1];
                frm.Conta = docs[2];
                frm.Cheque = docs[3];
            }
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ret = frm.Banco + ";" + frm.Agencia + ";"
                    + frm.Conta + ";" + frm.Cheque;
            }
            else
                ret = doc;
            frm.Dispose();
            return ret;
        }

        private void btRecalcular_Click(object sender, EventArgs e)
        {
            AjustarTipoPagamento();
        }

        private void btRecalcularParcela_Click(object sender, EventArgs e)
        {
            AjustaParcelas();
        }

        private void AjustaParcelas()
        {
            int np = (int)nudNumParcelas.Value;
            if (((TPagamento)cbTipoPagamento.SelectedItem).IdTipoPagamento == (long)eTPagamento.ParceladoSemEntrada)
                np++;
            AjustaNumeroParcelas(np);
            AjustaValorParcelas();
            //AjustaVctoParcelas(DateTime.Now.Date);
            RefreshParcelas();
        }

        /// <summary>
        /// Obtem dados do cartao de credito
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private string ObtemDadosCartao(string doc)
        {
            frmPar01 frm = new frmPar01();
            string ret;
            string[] docs = doc.Split(new char[] { ';' });
            if (docs.Length == 4)
            {
                frm.Bandeira = docs[0];
                frm.Vencimento = docs[1];
                frm.NumCar = docs[2];
                frm.CodSeg = docs[3];
            }
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ret = frm.Bandeira + ";" + frm.Vencimento + ";"
                    + frm.NumCar + ";" + frm.CodSeg;
            }
            else
                ret = doc;
            frm.Dispose();
            return ret;
        }

        //----------------------------
        // Controle de Documentos
        //
        private void InicializaDocumentos()
        {
            _wDocs.CarregaLista();
            dgvDocs.DataSource = _wDocs.Lista;
            dgvDocs.Columns[1].Visible = false;
            dgvDocs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDocs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocs.ReadOnly = true;
        }

        private void EmiteDoc(int Index)
        {
            MoveVarsVenda();
            string doc = _wDocs.Lista[Index].Arquivo;
            //_wDocs.PrepararDocCaminhoCompleto(doc, _VendaAtual);
            _wDocs.PrepararDoc(doc, _VendaAtual);
        }
        private void dgvDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            EmiteDoc(r);
        }

        private void btEmitir_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocs.SelectedRows)
            {
                int r = row.Index;
                EmiteDoc(r);
            }
        }

        //-------------------------------
        // Controle de Observações (Historico)
        //-------------------------------
        private void InicializaObservacoes()
        {
            dgvHistVenda.ReadOnly = true;
            RefreshObservacoes();
        }

        private void RefreshObservacoes()
        {
            List<HistoricoView> Refresh = (from hv in _HistVenda 
                                            where hv.TipoRegistro != (char)eTipoRegHistorico.Cancelamento
                                            orderby hv.DtRegistro select new HistoricoView
                                            {
                                                DataRegistro= hv.DtRegistro,
                                                Registro = hv.Registro
                                            }).ToList<HistoricoView>();
            dgvHistVenda.DataSource = Refresh;
            dgvHistVenda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btSalvaEntHistVenda_Click(object sender, EventArgs e)
        {
            HistoricoVenda h1 = new HistoricoVenda();
            h1.DtRegistro = DateTime.Now;
            h1.Registro = tbEntHistVenda.Text;
            h1.TipoRegistro = (char)eTipoRegHistorico.Observacoes;
            _HistVenda.Add(h1);
            _VendaAtual.HistoricoVendas.Add(h1);
            tbEntHistVenda.Text = string.Empty;
            RefreshObservacoes();
        }
       
        //-------------------------------
        // Controle de Cancelamento
        //-------------------------------

        private void InicializaCancelamento()
        {
            cbMotivoCancelamento.Tag = false;
            cbMotivoCancelamento.DataSource = Listas1.MotivosCancelamento;
            cbMotivoCancelamento.DisplayMember = "Motivo";
            cbMotivoCancelamento.ValueMember = "IdMotivoCancelamento";
            cbMotivoCancelamento.SelectedValue = (_IdMotivoCancelamento==null?1:_IdMotivoCancelamento) ;
            cbMotivoCancelamento.Tag = true;

            cbTipoReembolso.Tag = false;
            cbTipoReembolso.DataSource = Listas1.TiposReembolso;
            cbTipoReembolso.DisplayMember = "Nome";
            cbTipoReembolso.ValueMember = "IdTipoReembolso";
            cbTipoReembolso.SelectedValue = (_IdTipoReembolso==null?1:_IdTipoReembolso);
            cbTipoReembolso.Tag = true;
        }

        private void cbMotivoCancelamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((bool)cbMotivoCancelamento.Tag) 
                _IdMotivoCancelamento = (long)cbMotivoCancelamento.SelectedValue;
        }

        private void cbTipoReembolso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((bool)cbTipoReembolso.Tag)
                _IdTipoReembolso = (long)cbTipoReembolso.SelectedValue;
        }

        private void btSalvaEntHistCan_Click(object sender, EventArgs e)
        {
            HistoricoVenda h1 = new HistoricoVenda();
            h1.DtRegistro = DateTime.Now;
            h1.Registro = tbEntHistCan.Text;
            h1.TipoRegistro = (char)eTipoRegHistorico.Cancelamento;
            _HistVenda.Add(h1);
            _VendaAtual.HistoricoVendas.Add(h1);
            tbEntHistCan.Text = string.Empty;
            RefreshCancelamento();
        }

        private void RefreshCancelamento()
        {
            List<HistoricoView> Refresh = (from hv in _HistVenda
                                           where hv.TipoRegistro == (char)eTipoRegHistorico.Cancelamento
                                           orderby hv.DtRegistro
                                           select new HistoricoView
                                           {
                                               DataRegistro = hv.DtRegistro,
                                               Registro = hv.Registro
                                           }).ToList<HistoricoView>();
            dgvHistCancelamento.DataSource = Refresh;
            dgvHistCancelamento.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void EnableTBCancelamento(bool p)
        {
            cbMotivoCancelamento.Enabled = p;
            cbTipoReembolso.Enabled = p;
            btSalvaEntHistCan.Enabled = p;
            tbEntHistCan.Enabled = p;

            if (p)
            {
                dgvHistCancelamento.ReadOnly = true;
                RefreshCancelamento();
            }
        }

        private void tbCliente_Validating(object sender, CancelEventArgs e)
        {
            ValidaCliente();
        }

        private void tbProduto_Validating(object sender, CancelEventArgs e)
        {
            ValidaProduto();
        }

        private void tbOPeradora_Validating(object sender, CancelEventArgs e)
        {
            ValidaOperadora();
        }

        private void tpCancelamento_Click(object sender, EventArgs e)
        {

        }

        private void tbPais_Leave(object sender, EventArgs e)
        {
            ValidaPais();
        }

        private void tbCidade_Leave(object sender, EventArgs e)
        {
            ValidaCidade();
        }

    }
}
