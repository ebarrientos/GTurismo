using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viagens
{
    class FornecedorView
    {
        public long _IdFornecedor;
        public string _Fornecedor;
        public long? _IdCidade;
        public string _Cidade;
        public decimal? _Comissao;
        public string _Email;
        public string _Telefone;
        public string _Endereco;
        public string _Numero;
        public string _Cep;
        public string _Comentario;
        public string _TipoFornecedor;
        public string _Complemento;

        public long IdFornecedor
        {
            get { return _IdFornecedor; }
            set { _IdFornecedor = value; }
        }
        public long? IdCidade
        {
            get { return _IdCidade; }
            set { _IdCidade = value; }
        }

        public string Fornecedor
        {
            get { return _Fornecedor; }
            set { _Fornecedor = value; }
        }
        
        public string TipoFornecedor
        {
            get { return _TipoFornecedor; }
            set { _TipoFornecedor = value; }
        }

        public decimal? Comissao
        {
            get { return _Comissao; }
            set { _Comissao = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }

        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }
        
    }

    class ClienteView
    {
        long _IdCliente;
        string _Nome;
        string _CPF;
        string _RG;
        string _Email;
        string _Endereço;

        public long IdCliente{get {return _IdCliente;} set {_IdCliente = value;}}
        public string Nome { get { return _Nome; } set { _Nome = value; } }
        public string CPF{get {return _CPF;} set {_CPF = value;}}
        public string RG { get { return _RG; } set { _RG = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Endereco { get { return _Endereço; } set { _Endereço = value; } }

        public ClienteView()
        {
        }

        public ClienteView(long idCliente, string nome, string cpf, string rg, string email, string endereco)
        {
            _IdCliente = idCliente;
            _Nome = nome;
            _CPF = cpf;
            _RG = rg;
            _Email = email;
            _Endereço = endereco;
        }
    }

    class PassageiroView
    {
        long _IdCategoria;
        long _IdCliente;
        string _Nome;
        DateTime? _DtNascimento;

        public long IdCategoria { get { return _IdCategoria; } set { _IdCategoria = value; } }
        public long IdCliente { get { return _IdCliente; } set { _IdCliente = value; } }
        public string Nome { get { return _Nome; } set { _Nome = value; } }
        public DateTime? DtNascimento { get { return _DtNascimento; } set { _DtNascimento = value; } }


        public PassageiroView()
        {
        }

        public PassageiroView(long idCategoria, long idCliente, string nome, DateTime? Dt)
        {
            _IdCategoria = idCategoria;
            _IdCliente = idCliente;
            _Nome = nome;
            _DtNascimento = (DateTime)(Dt==null?DateTime.Today:Dt);
        }
    }
    class ParcelasView
    {
        long _Item;
        DateTime _DtVencimento;
        string _NumDoc;
        decimal _Valor;
        long _IdFormaPagamento;
        long _IdSituacao;

        public ParcelasView()
        {
            _IdFormaPagamento = 1;
            _IdSituacao = 1;
        }
        public ParcelasView(long item, DateTime dtVencimento, string numDoc, decimal valor,
            long idFormaPagamento, long idSituacao)
        {
            _Item = item;
            _DtVencimento = dtVencimento;
            _NumDoc = numDoc;
            _Valor = valor;
            _IdFormaPagamento = idFormaPagamento;
            _IdSituacao = idSituacao;
        }

        public long Item { get { return _Item; } set { _Item = value; } }
        public DateTime DtVenvimento { get { return _DtVencimento; } set { _DtVencimento = value; } }
        public decimal Valor { get { return _Valor; } set { _Valor = value; } }
        public string NumDoc { get { return _NumDoc; } set { _NumDoc = value; } }
        public long IdFormaPagamento { get { return _IdFormaPagamento; } set { _IdFormaPagamento = value; } }
        public long IdSituacao { get { return _IdSituacao; } set { _IdSituacao = value; } }
    }
    class TelefonesView
    {
        long _idContatoCliente = 0;
        string _telefone=" ";
        public TelefonesView()
        {
        }
        public TelefonesView(long IdContatoCliente, string Telefone)
        {
            _idContatoCliente = IdContatoCliente;
            _telefone = Telefone;
        }
        public string Telefone { get { return _telefone; } set { _telefone = value; } }
        public long IdContatoCliente { get { return _idContatoCliente; } set { _idContatoCliente = value; } }
    }

    class VendasView
    {
        long _IdVenda;
        string _NomeCliente;
        string _NomeOperadora;
        string _Destino;
        DateTime _DataVenda;
        DateTime? _DataEmbarque;
        string _Situacao;

        public VendasView()
        {
        }
        public VendasView(long IdVenda, string NomeCliente, string NomeOperadora, string Destino,
            DateTime DtVenda, DateTime DtEmbarque, string Situacao)
        {
            _IdVenda = IdVenda;
            _NomeCliente = NomeCliente;
            _NomeOperadora = NomeOperadora;
            _Destino = Destino;
            _DataVenda = DtVenda;
            _DataEmbarque = DtEmbarque;
            _Situacao = Situacao;
        }
        public long IdVenda { get { return _IdVenda; } set { _IdVenda = value; } }
        public string NomeCliente { get { return _NomeCliente; } set { _NomeCliente = value; } }
        public string NomeOperadora { get { return _NomeOperadora; } set { _NomeOperadora = value; } }
        public string Destino { get { return _Destino; } set { _Destino = value; } }
        public DateTime DataVenda { get { return _DataVenda; } set { _DataVenda = value; } }
        public DateTime? DataEmbarque { get { return _DataEmbarque; } set { _DataEmbarque = value; } }
        public string Situacao { get { return _Situacao; } set { _Situacao = value; } }
    }

    class Documento
    {
        string _Nome;
        string _Arquivo;
        public Documento()
        {
        }
        public Documento(string Nome, string Arquivo)
        {
            _Nome = Nome;
            _Arquivo = Arquivo;
        }
        public string Nome { get { return _Nome; } set { _Nome = value; } }
        public string Arquivo { get { return _Arquivo; } set {_Arquivo = value;} }
    }

    class HistoricoView
    {
        DateTime _DtReg;
        string _Registro;

        public HistoricoView()
        {
        }
        public HistoricoView(DateTime DtReg, string Registro)
        {
            _DtReg = DtReg;
            _Registro = Registro;
        }
        public DateTime DataRegistro
        {
            get { return _DtReg; }
            set { _DtReg = value; }
        }
        public string Registro
        {
            get { return _Registro; }
            set { _Registro = value; }
        }
    }
}
