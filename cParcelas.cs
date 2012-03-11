using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viagens
{
    class cParcelas
    {
        List<Parcela> _Parcelas;
        eTPagamento _TipoPagamento;
        eFPagamento _IdFPagEntrada;
        eFPagamento _IdFPagParcela;
        long _IdSitParcela;
        short _IxParcela;
        short _NumParcelas;
        decimal _VPacote;
        decimal _VTaxas;
        decimal _VEntrada;
        decimal _VParcelar;
        decimal _TaxaAdm;
        DateTime _DtVencimento;

        public long IdSituacaoParcela
        {
            get { return _IdSitParcela; }
            set { _IdSitParcela = value; }
        }
        public decimal TaxaAdm
        {
            get { return _TaxaAdm; }
            set { _TaxaAdm = value; }
        }

        public eFPagamento FormaPagEntrada
        {
            get { return _IdFPagEntrada; }
            set { _IdFPagEntrada = value; }
        }
        public eFPagamento FormaPagParcela
        {
            get { return _IdFPagParcela; }
            set { _IdFPagParcela = value; }
        }

        public DateTime DataVencimento
        {
            get { return _DtVencimento; }
            set { _DtVencimento = value; }
        }

        public decimal ValorEntrada
        {
            get {return _VEntrada;}
            set 
            { 
                _VEntrada = value; 
            }
        }

        public eTPagamento TipoPagamento
        {
            get { return _TipoPagamento; }
            set 
            { 
                _TipoPagamento = value;
                if (_TipoPagamento == eTPagamento.ParceladoSemEntrada)
                    _IxParcela = 0;
                else // Ignora o item 0 (Entrada)
                    _IxParcela = 1;
            }
        }

        public short NumParcelas
        {
            get { return _NumParcelas; }
            set
            {
                if (_TipoPagamento == eTPagamento.AVista)
                    _NumParcelas = 1;
                else
                {
                    if (_NumParcelas < 2)
                        _NumParcelas = 2;
                    else
                        _NumParcelas = value;
                }
            }
        }

        public cParcelas(decimal VPacote, decimal VTaxas)
        {
            _VPacote = VPacote;
            _VTaxas = VTaxas;
            _VEntrada = 0;
            _NumParcelas = 1;
            _IxParcela = 1;
        }

        public List<Parcela> Parcelas
        {
            get { return _Parcelas; }
        }

        public void Add(Parcela p)
        {
            _Parcelas.Add(p);
        }

        public List<Parcela> CalculaParcelas()
        {
            switch (_TipoPagamento)
            {
                case eTPagamento.AVista:
                    CalculaPgtoAVista();
                    break;
                case eTPagamento.ParceladoComEntrada:
                    CalculaPgtoComEntrada();
                    break;
                case eTPagamento.ParceladoSemEntrada:
                    CalculaPgtoSemEntrada();
                    break;
                default:
                    break;
            }

            return _Parcelas;
        }

        private void CalculaPgtoSemEntrada()
        {
            _VEntrada = 0;
            _VParcelar = _VPacote + _VTaxas;
            decimal VParcela = _VParcelar / _NumParcelas;
            _Parcelas.Clear();
            DateTime ND = _DtVencimento.AddMonths(1);
            for (short ix = 1; ix < _NumParcelas; ix++)
            {
                CriaParcela(ix, ND, (long)_IdFPagParcela, _IdSitParcela, " ", VParcela);
            }
        }

        private void CalculaPgtoComEntrada()
        {
            _VEntrada = (_VPacote * _TaxaAdm)/100 + _VTaxas;
            _VParcelar = _VPacote - _VEntrada;
            decimal VParcela = _VParcelar / (_NumParcelas - 1);
            _Parcelas.Clear();
            CriaParcela(0, _DtVencimento, (long)_IdFPagEntrada, 1, " ", _VEntrada);
            DateTime ND = _DtVencimento.AddMonths(1);
            for (short ix = 1; ix < _NumParcelas; ix++)
            {
                CriaParcela(ix, ND, (long)_IdFPagParcela, _IdSitParcela, " ", VParcela);
            }
        }

        private void CalculaPgtoAVista()
        {
            _VEntrada = _VPacote + _VTaxas;
            _Parcelas.Clear();
            CriaParcela(0, _DtVencimento, (long)_IdFPagEntrada, 1, " ", _VEntrada);
        }

        private void CriaParcela(short Item, DateTime DTV, long IdFP, long IdSP, string NDOC,decimal VLR) 
        {
            Parcela p = new Parcela();
            p.DtVencimento = DTV;
            p.IdFormaPagamento = IdFP;
            p.IdSituacao = IdSP;
            p.NumDoc = NDOC;
            p.Valor = VLR;
            _Parcelas.Add(p);
        }
    }
}
