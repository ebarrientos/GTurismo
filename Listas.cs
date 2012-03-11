using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viagens
{
    enum eTipoRegHistorico
    {
        Alteracao_de_status ='A', 
        Cancelamento = 'C', 
        Observacoes = 'O',
        Pendencias = 'P',
        Vouchers = 'V' 
    }
    enum eStatusUsuario
    {
        Ok = 'O',
        Bloqueado = 'B'
    }

    enum eTipoUsuario
    {
        Administrador = 'A', 
        Vendedor = 'V',
        Gerente = 'G'
    }

    enum eSituacaoVenda
    {
        Inicial = 0,
        Liberada = 1,
        Vouchers_Entregues = 2,
        Pendencias = 3,
        Cancelamento_em_andamento = 4,
        Cancelamento_Concluido = 5
    }

    enum eTPagamento
    {
        AVista = 1,
        ParceladoComEntrada = 2,
        ParceladoSemEntrada = 3
    }

    enum eFPagamento
    {
        Cartao = 1,
        Cheque = 2,
        Dinheiro = 3,
        CartaDeCredito = 4,
        Boleto = 5,
        CreditoInterno = 6
    }

    enum eTBandeira
    {
        VISA = 1,
        MASTERCARD = 2,
        AMEX = 3,
        DINERS = 4,
        SOLLO = 5
    }

    class TStatusUsuario
    {
        char _Status;
        string _Nome;
        public TStatusUsuario()
        {
        }
        public TStatusUsuario(char Status, string Nome)
        {
            _Status = Status;
            _Nome = Nome;
        }
        public char Status {get {return _Status;} set {_Status = value;}}
        public string Nome { get { return _Nome; } set { _Nome = value; } }
    }

    class TTipoUsuario
    {
        char _Tipo;
        string _Nome;
        public TTipoUsuario()
        {
        }
        public TTipoUsuario(char Tipo, string Nome)
        {
            _Tipo = Tipo;
            _Nome = Nome;
        }
        public char Tipo {get {return _Tipo;} set {_Tipo = value;}}
        public string Nome {get {return _Nome;} set {_Nome = value;}}
    }
    class TSituacaoVenda
    {
        long _IdSituacaoVenda;
        string _Nome;
        public TSituacaoVenda()
        {
        }
        public TSituacaoVenda(long IdSituacao, string Nome)
        {
            _IdSituacaoVenda = IdSituacao;
            _Nome = Nome;
        }
        public long IdSituacaoVenda { get { return _IdSituacaoVenda; } set { _IdSituacaoVenda = value; } }
        public string Nome { get { return _Nome; } set { _Nome = value; } }
    }

    class TBandeira
    {
        eTBandeira _idBandeira;
        string _nome;
        public TBandeira()
        {
        }
        public TBandeira(eTBandeira IdBandeira, string Nome)
        {
            _idBandeira = IdBandeira;
            _nome = Nome;
        }
        public eTBandeira IdBandeira { get { return _idBandeira; } set { _idBandeira = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }

    class Categoria
    {
        long _idCategoria;
        string _nome;
        public Categoria()
        {
        }
        public Categoria(long IdCategoria, string Nome)
        {
            _idCategoria = IdCategoria;
            _nome = Nome;
        }

        public long IdCategoria { get { return _idCategoria; } set { _idCategoria = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }

    class TMotivoViagem
    {
        long _idMotivo;
        string _nome;
        public TMotivoViagem()
        {
        }
        public TMotivoViagem(long IdMotivo, string Nome)
        {
            _idMotivo = IdMotivo;
            _nome = Nome;
        }

        public long IdMotivo { get { return _idMotivo; } set { _idMotivo = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }

    class TPagamento
    {
        long _idTipoPagamento;
        string _nome;

        public TPagamento()
        {
        }
        public TPagamento(long IdTipoPagamento, string Nome)
        {
            _idTipoPagamento = IdTipoPagamento;
            _nome = Nome;
        }

        public long IdTipoPagamento { get { return _idTipoPagamento; } set { _idTipoPagamento = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }
    class FPagamento
    {
        long _idFormaPagamento;
        string _nome;

        public FPagamento()
        {
        }
        public FPagamento(long IdFormaPagamento, string Nome)
        {
            _idFormaPagamento = IdFormaPagamento;
            _nome = Nome;
        }

        public long IdFormaPagamento { get { return _idFormaPagamento; } set { _idFormaPagamento = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
    }

    class Listas
    {
        public List<Categoria> Categorias = new List<Categoria>();
        public List<TMotivoViagem> TMotivosViagem = new List<TMotivoViagem>();
        public List<TSituacaoVenda> TSituacoesVenda = new List<TSituacaoVenda>();
        public List<TBandeira> Bandeiras = new List<TBandeira>();
        public List<FPagamento> FormasPagamento = new List<FPagamento>();
        public List<SituacaoParcela> SituacoesParcela = new List<SituacaoParcela>();
        public List<TipoFornecedor> TiposFornecedor = new List<TipoFornecedor>();
        public List<TipoMoeda> TiposMoeda = new List<TipoMoeda>();
        public List<TPagamento> TiposPagamento = new List<TPagamento>();
        public List<TipoProduto> TiposProduto = new List<TipoProduto>();
        public List<TipoReembolso> TiposReembolso = new List<TipoReembolso>();
        public List<MotivoCancelamento> MotivosCancelamento = new List<MotivoCancelamento>();
        public List<TTipoUsuario> TiposUsuario = new List<TTipoUsuario>();
        public List<TStatusUsuario> StatusUsuario = new List<TStatusUsuario>();

        public Listas()
        {
            InicializaCategorias();
            InicializaMotivosViagem();
            InicializaSituacoesVenda();
            InicializaListasBD();
            InicializaTiposPagamento();
            InicializaFormasPagamento();
            InicializaBandeiras();
            InicializaStatusUsuario();
            InicializaTiposUsuario();

        }

        private void InicializaTiposUsuario()
        {
            TiposUsuario.Add(new TTipoUsuario('A', "Administrador"));
            TiposUsuario.Add(new TTipoUsuario('V', "Vendedor"));
            TiposUsuario.Add(new TTipoUsuario('G', "Gerente"));
        }

        private void InicializaStatusUsuario()
        {
            StatusUsuario.Add(new TStatusUsuario('O', "Ok"));
            StatusUsuario.Add(new TStatusUsuario('B', "Bloqueado"));
        }


        private void InicializaSituacoesVenda()
        {
            TSituacoesVenda.Add(new TSituacaoVenda((long)eSituacaoVenda.Liberada,"Liberada"));
            TSituacoesVenda.Add(new TSituacaoVenda((long)eSituacaoVenda.Vouchers_Entregues,"Vouchers Entregues"));
            TSituacoesVenda.Add(new TSituacaoVenda((long)eSituacaoVenda.Pendencias,"Pendencias"));
            TSituacoesVenda.Add(new TSituacaoVenda((long)eSituacaoVenda.Cancelamento_em_andamento,"Cancelamento em andamento"));
            TSituacoesVenda.Add(new TSituacaoVenda((long)eSituacaoVenda.Cancelamento_Concluido, "Cancelamento concluido"));
        }

        private void InicializaMotivosViagem()
        {
            TMotivosViagem.Add(new TMotivoViagem(1, "Lua de Mel"));
            TMotivosViagem.Add(new TMotivoViagem(2, "Eventos"));
            TMotivosViagem.Add(new TMotivoViagem(3, "Lazer"));
            TMotivosViagem.Add(new TMotivoViagem(4, "Trabalho"));
            TMotivosViagem.Add(new TMotivoViagem(5, "Outros"));
        }

        private void InicializaBandeiras()
        {
            Bandeiras.Add(new TBandeira(eTBandeira.VISA,"VISA"));
            Bandeiras.Add(new TBandeira(eTBandeira.MASTERCARD, "MASTERCARD"));
            Bandeiras.Add(new TBandeira(eTBandeira.AMEX, "AMEX"));
            Bandeiras.Add(new TBandeira(eTBandeira.DINERS, "DINERS"));
            Bandeiras.Add(new TBandeira(eTBandeira.SOLLO, "SOLLO"));
        }

        private void InicializaTiposPagamento()
        {
            TiposPagamento.Add(new TPagamento((long)eTPagamento.AVista, "A Vista"));
            TiposPagamento.Add(new TPagamento((long)eTPagamento.ParceladoComEntrada, "Parcelado com entrada"));
            TiposPagamento.Add(new TPagamento((long)eTPagamento.ParceladoSemEntrada, "Parcelado sem entrada"));
        }

        private void InicializaFormasPagamento()
        {
            FormasPagamento.Add(new FPagamento((long)eFPagamento.Cartao, "Cartão"));
            FormasPagamento.Add(new FPagamento((long)eFPagamento.Cheque, "Cheque"));
            FormasPagamento.Add(new FPagamento((long)eFPagamento.Dinheiro, "Dinheiro"));
            FormasPagamento.Add(new FPagamento((long)eFPagamento.Boleto, "Boleto"));
            FormasPagamento.Add(new FPagamento((long)eFPagamento.CartaDeCredito, "Carta De Crédito"));
            FormasPagamento.Add(new FPagamento((long)eFPagamento.CreditoInterno, "Crédito Interno"));
        }

        /// <summary>
        /// Retorna nome da forma de pagamento
        /// </summary>
        /// <param name="IdFormaPagamento">IdFormaPagamento</param>
        /// <returns>Nome da Forma de Pagamento</returns>
        public string GetFPagamento(long IdFormaPagamento)
        {
            string fpag;
            switch ((eFPagamento)IdFormaPagamento)
            {
                case eFPagamento.Boleto:
                    fpag = "Boleto";
                    break;
                case eFPagamento.CartaDeCredito:
                    fpag = "Carta De Crédito";
                    break;
                case eFPagamento.Cartao:
                    fpag = "Cartão";
                    break;
                case eFPagamento.Cheque:
                    fpag = "Cheque";
                    break;
                case eFPagamento.CreditoInterno:
                    fpag = "Crédito Interno";
                    break;
                case eFPagamento.Dinheiro:
                    fpag = "Dinheiro";
                    break;
                default:
                    fpag = "Desconhecido";
                    break;
            }
            return fpag;
        }

        private void InicializaListasBD()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();

            SituacoesParcela = (from sp in ViagensDC.SituacaoParcelas
                                select sp).ToList<SituacaoParcela>();
            TiposFornecedor = (from tf in ViagensDC.TipoFornecedors
                               select tf).ToList<TipoFornecedor>();
            TiposMoeda = (from m in ViagensDC.TipoMoedas select m).ToList<TipoMoeda>();
            TiposProduto = (from tp in ViagensDC.TipoProdutos
                            select tp).ToList<TipoProduto>();
            TiposReembolso = (from tr in ViagensDC.TipoReembolsos
                              select tr).ToList<TipoReembolso>();
            MotivosCancelamento = (from mc in ViagensDC.MotivoCancelamentos
                                   select mc).ToList<MotivoCancelamento>();
        }

        private void InicializaCategorias()
        {
            Categoria c1 = new Categoria(1, "ADT");
            Categoria c2 = new Categoria(2, "CHD");
            Categoria c3 = new Categoria(3, "INF");
            Categorias.Add(c1);
            Categorias.Add(c2);
            Categorias.Add(c3);
        }

        public TipoMoeda Moeda(long TMoeda)
        {
            return (from tm in TiposMoeda where tm.IdTipoMoeda == TMoeda select tm).SingleOrDefault<TipoMoeda>();
        }
        public TSituacaoVenda getSituacaoVenda(long IdSituacaoVenda)
        {
            return (from sv in TSituacoesVenda
                    where sv.IdSituacaoVenda == IdSituacaoVenda
                    select sv).SingleOrDefault<TSituacaoVenda>();
        }
    }
}