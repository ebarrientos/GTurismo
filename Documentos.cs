using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using ImpDoc;

namespace Viagens
{
    class Documentos
    {
        string _ArqDocs;
        string _DirDocs;
        string _DirTrab;
        string _DirAtual;
        string _Arq;
        Listas Lista1 = new Listas();
        List<Documento> _Docs = new List<Documento>();

        public Documentos()
        {
            _DirAtual = System.IO.Directory.GetCurrentDirectory() +"\\";
            _ArqDocs = _DirAtual+Properties.SpecialSettings.Default.ArquivoContratos;
            _DirDocs = _DirAtual+Properties.SpecialSettings.Default.DiretorioContratos;
            _DirTrab = _DirAtual+Properties.SpecialSettings.Default.DiretórioTrabalho;
        }

        public Documentos(string ArqListaContratos, string DirContratos, string DirTrabalho)
        {
            _ArqDocs = ArqListaContratos;
            _DirDocs = DirContratos;
            _DirTrab = DirTrabalho;
        }

        public void CarregaLista()
        {
            try
            {
                StreamReader sr = File.OpenText(_ArqDocs);
                string linha = string.Empty;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] elementos = linha.Split(';');
                    Documento d = new Documento(elementos[0], elementos[1]);
                    _Docs.Add(d);
                }
                sr.Close();
            }
            catch
            {
            }
        }
        public void SalvaLista()
        {
            if (_Docs.Count > 0)
            {
                string[] strDocs = new string[_Docs.Count];
                for (int ix = 0; ix < strDocs.Length; ix++)
                {
                    strDocs[ix] = _Docs[ix].Nome + ";" + _Docs[ix].Arquivo;
                }
                File.WriteAllLines(_ArqDocs, strDocs);
            }
        }

        public List<Documento> Lista
        {
            get { return _Docs; }
        }

        public string DiretorioDocumentos
        {
            get { return _DirDocs; }
        }
        public string DiretorioTrabalho
        {
            get { return _DirTrab; }
        }
        public string ArquivoIni
        {
            get { return _ArqDocs; }
        }
        /// <summary>
        /// Copia Arquivo para diretorio destino com nome aleatório
        /// </summary>
        /// <param name="ArquivoOrigem">Caminho completo do arquivo a ser copiado</param>
        /// <param name="DireDestino">Diretorio destino</param>
        /// <returns>Nome do arquivo criado</returns>
        private string CopiaArquivo(string ArquivoOrigem, string DiretorioDestino)
        {
            string Ext = Path.GetExtension(ArquivoOrigem);
            string NomeArqTemp = DiretorioDestino+"\\"+ RandomString(10, false) + Ext;
            File.Copy(ArquivoOrigem, NomeArqTemp);
            return NomeArqTemp;
        }

        public void PrepararDoc(string Doc, Venda VAtual)
        {
            string NomeArquivo = _DirDocs+ "\\"+Doc;    
            PrepararDocCaminhoCompleto(NomeArquivo, VAtual);
        }

        public void PrepararDocCaminhoCompleto(string Doc, Venda VAtual)
        {
            CCWordAppBasic wdoc = new CCWordAppBasic();
            string AuxDoc = CopiaArquivo(Doc, _DirTrab);

            wdoc.OpenCaminhoCompleto(AuxDoc);
            GeraDoc(wdoc, VAtual);
        }

        private void GeraDoc(CCWordAppBasic wdoc, Venda VAtual)
        {
            wdoc.NaoExibir();

            string Nome1 = VAtual.Cliente.Nome1 + " " + VAtual.Cliente.Nome2 + " " + VAtual.Cliente.Nome3;
            string RG = VAtual.Cliente.RG;
            string CPF = VAtual.Cliente.CPF;
            string CidadeD = (VAtual.Cidade == null ? " " : VAtual.Cidade.Nome);
            string PaisD = (VAtual.Cidade == null ? " " : VAtual.Cidade.Pais.Nome);
            string DataE = (VAtual.DataEmbarque == null ? "____/____/______" : VAtual.DataEmbarque.Value.ToShortDateString());
            string DataV = VAtual.DataVenda.Value.ToLongDateString();
            string DataR = (VAtual.DataRetorno == null ? "____/____/______" : VAtual.DataRetorno.Value.ToShortDateString());
            string IdVenda = VAtual.IdVenda.ToString();
            string Produto = VAtual.Produto.Nome;
            string DescProduto = VAtual.Produto.Descricao;
            string Operadora = VAtual.Fornecedor.Nome;
            string Vendedor = VAtual.Usuario.Nome;
            string Hotel = VAtual.Fornecedor1.Nome;

            string Telefones = VAtual.Cliente.Telefone;
            foreach (ContatoCliente cc in VAtual.Cliente.ContatoClientes)
            {
                Telefones = Telefones + ", " + cc.Telefone;
            }


            wdoc.PreencherPorReplaceAll("[@RG]", RG);
            wdoc.PreencherPorReplaceAll("[@CPF]", CPF);
            wdoc.PreencherPorReplaceAll("[@CidadeD]", CidadeD);
            wdoc.PreencherPorReplaceAll("[@PaisD]", PaisD);
            wdoc.PreencherPorReplaceAll("[@DataE]", DataE);
            wdoc.PreencherPorReplaceAll("[@DataV]", DataV);
            wdoc.PreencherPorReplaceAll("[@Nome1]", Nome1);
            wdoc.PreencherPorReplaceAll("[@IdVenda]", IdVenda);
            wdoc.PreencherPorReplaceAll("[@Telefones]", Telefones);
            wdoc.PreencherPorReplaceAll("[@Produto]", Produto);
            wdoc.PreencherPorReplaceAll("[@DescProduto]", DescProduto);
            wdoc.PreencherPorReplaceAll("[@Hotel]", Hotel); 
            wdoc.PreencherPorReplaceAll("[@Operadora]", Operadora);
            wdoc.PreencherPorReplaceAll("[@DataR]", DataR);
            wdoc.PreencherPorReplaceAll("[@Vendedor]", Vendedor);

            string Estilo = Properties.SpecialSettings.Default.EstiloTabelaImp;

            DataTable dtVPassageiros = PreparaDTVPassageiros(VAtual);
            wdoc.InsereTabela("[@ValoresPorPassageiro]", Estilo, dtVPassageiros);

            DataTable dtParcelas = PreparaDTParcelas(VAtual);
            wdoc.InsereTabela("[@ListaParcelas]", Estilo, dtParcelas);

            DataTable dtCartoes = new DataTable();
            try
            {
                dtCartoes = PreparaDTCartoes(VAtual);
            }
            catch
            {
            }
            Estilo = Properties.SpecialSettings.Default.EstiloTabelaCar;
            wdoc.InsereTabela("[@Cartões]",Estilo,dtCartoes);

            DataTable dtPassageiros = PreparaDTPassageiros(VAtual);
            wdoc.InsereTabela("[@Passageiros]", Estilo, dtPassageiros);
            wdoc.Exibir();
        }


        private DataTable PreparaDTCartoes(Venda VAtual)
        {
            Cartoes LCart = new Cartoes();
            DataTable dtRet = new DataTable();
            dtRet.Columns.Add(new DataColumn("Bandeira", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Cartão", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Código", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Validade", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Valor", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Parcelas", typeof(string)));
            dtRet.Columns.Add(new DataColumn("1a. Parcela", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Parcelas Restantes", typeof(string)));

            dtRet.Columns[0].MaxLength = 20;
            dtRet.Columns[1].MaxLength = 40;
            dtRet.Columns[2].MaxLength = 20;
            dtRet.Columns[3].MaxLength = 20;
            dtRet.Columns[4].MaxLength = 20;
            dtRet.Columns[5].MaxLength = 20;
            dtRet.Columns[6].MaxLength = 20;
            dtRet.Columns[7].MaxLength = 30;
            foreach (Parcela p in VAtual.Parcelas)
            {
                if ((eFPagamento)p.IdFormaPagamento == eFPagamento.Cartao)
                {
                    LCart.Incluir(p.NumDoc, p.Valor);
                }
            }
            foreach (Cartao car in LCart.Lista)
            {
                dtRet.Rows.Add(new string[] { car.Bandeira, car.Numero, car.Codigo, car.Validade,
                    FormataValor(car.VTotal,false), car.NumParcelas.ToString(), 
                    FormataValor(car.VPParc,false), FormataValor(car.VOParc,false)});
            }
            return dtRet;
            
        }


        private DataTable PreparaDTParcelas(Venda VAtual)
        {
            DataTable dtRet = new DataTable();
            dtRet.Columns.Add(new DataColumn("Parcela", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Vencimento", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Valor", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Forma", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Documentos", typeof(string)));

            dtRet.Columns["Parcela"].MaxLength = 10;
            dtRet.Columns["Vencimento"].MaxLength = 30;
            dtRet.Columns["Valor"].MaxLength = 30;
            dtRet.Columns["Forma"].MaxLength = 25;
            dtRet.Columns["Documentos"].MaxLength = 100;
            
            decimal VTotal = 0;
            foreach (Parcela p in VAtual.Parcelas)
            {
                string item = p.Item.ToString();
                string DtVenc = p.DtVencimento.ToShortDateString();
                string Valor = FormataValor(p.Valor);
                string Forma = Lista1.GetFPagamento(p.IdFormaPagamento);
                string Docs = p.NumDoc;
                dtRet.Rows.Add(new string[] { item, DtVenc, Valor, Forma, Docs });
                VTotal += p.Valor;
            }
            dtRet.Rows.Add(new string[] { "Total R$", " ", FormataValor(VTotal,true), " ", " " });
            return dtRet;
        }

        private DataTable PreparaDTPassageiros(Venda VAtual)
        {
            DataTable dtRet = new DataTable();
            dtRet.Columns.Add(new DataColumn("NOME", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Categoria", typeof(string)));
            dtRet.Columns["NOME"].MaxLength = 100;
            dtRet.Columns["Categoria"].MaxLength = 50;

            foreach (Passageiro p in VAtual.Passageiros)
            {
                Cliente cl = acc.ObtemCliente(p.IdPassageiro);
                string Nome = cl.Nome1 + " " + cl.Nome2 + " " + cl.Nome3;
                string Categoria = string.Empty;
                switch (p.IdCategoria)
                {
                    case 1:
                        Categoria = "ADT";
                        break;
                    case 2:
                        Categoria = "CHD";
                        break;
                    default:
                        Categoria = "INF";
                        break;
                }
                dtRet.Rows.Add(new string[] { Nome, Categoria});
            }
            return dtRet;
        }

        private DataTable PreparaDTVPassageiros(Venda VAtual)
        {
            DataTable dtRet = new DataTable();
            string SimboloMoeda = VAtual.TipoMoeda.Simbolo;
            string NomeColTaxa = "Taxa(" + SimboloMoeda + ")";
            string NomeColValor = "Valor(" + SimboloMoeda + ")";
            string NomeColTotal = "Total(" + SimboloMoeda + ")";

            dtRet.Columns.Add(new DataColumn("NOME", typeof(string)));
            dtRet.Columns.Add(new DataColumn("Categoria", typeof(string)));
            dtRet.Columns.Add(new DataColumn(NomeColTaxa, typeof(string)));
            dtRet.Columns.Add(new DataColumn(NomeColValor, typeof(string)));
            dtRet.Columns.Add(new DataColumn(NomeColTotal, typeof(string)));

            dtRet.Columns["NOME"].MaxLength = 150;
            dtRet.Columns["Categoria"].MaxLength = 15;
            dtRet.Columns[NomeColTaxa].MaxLength = 15;
            dtRet.Columns[NomeColValor].MaxLength = 20;
            dtRet.Columns[NomeColTotal].MaxLength = 20;

            Decimal TValor = 0;
            Decimal TTaxa = 0;
            Decimal TTotal = 0;
            Decimal TValorR = 0; // Valores em Reias
            Decimal TTaxaR = 0;
            Decimal TTotalR = 0;
            foreach (Passageiro p in VAtual.Passageiros)
            {
                Cliente cl = acc.ObtemCliente(p.IdPassageiro);
                string Nome = cl.Nome1 + " " + cl.Nome2 + " " + cl.Nome3;
                string Categoria = string.Empty;
                decimal? Valor = 0;
                decimal? Taxa = 0;
                decimal? TotalI = 0;
                switch (p.IdCategoria)
                {
                    case 1:
                        Categoria = "ADT";
                        Valor = VAtual.PrecoAdult;
                        Taxa  = VAtual.TaxaAdult;
                        break;
                    case 2:
                        Categoria = "CHD";
                        Valor = VAtual.PrecoCHD;
                        Taxa = VAtual.TaxaCHD;
                        break;
                    default:
                        Categoria = "INF";
                        Valor = VAtual.PrecoINF;
                        Taxa = VAtual.TaxaInf;
                        break;
                }
                TotalI = Valor + Taxa;
                TValor += (decimal)Valor;
                TTaxa += (decimal)Taxa;
                TTotal += (decimal)TotalI;
                dtRet.Rows.Add(new string[] { Nome, Categoria, FormataValor(Taxa), FormataValor(Valor),FormataValor(TotalI)});
            }
            //Adiciona linha de totais
            dtRet.Rows.Add(new string[] { "Total", " ", FormataValor(TTaxa), FormataValor(TValor),FormataValor(TTotal) });
            if (VAtual.IdTipoMoeda == 1) // é Real
            {
                TValorR = TValor;
                TTaxaR = TTaxa;
                TTotalR = TTotal;
            }
            else
            {
                decimal TaxaCambio = (decimal)(VAtual.CambioDoDia==null? 1: VAtual.CambioDoDia);
                string Cambio = "x R$"+FormataValor(TaxaCambio);
                dtRet.Rows.Add(new string[]{"Taxa de Cambio", " ",Cambio,Cambio,Cambio});
                TValorR = TValor * TaxaCambio;
                TTaxaR = TTaxa * TaxaCambio;
                TTotalR = TTotal * TaxaCambio;
                dtRet.Rows.Add(new string[] { "Total em R$", " ", FormataValor(TTaxaR),FormataValor(TValorR),FormataValor(TTotalR,true)});
            }
            return dtRet;
        }

        public string addTraco(string texto, int sizeFinal)
        {
            int tracoAdd = sizeFinal - texto.Length;
            int tracoAntes, tracoDepois;
            if (tracoAdd % 2 != 0)
            {
                //impar
                tracoAntes = tracoAdd / 2;
                tracoDepois = 1 + (tracoAdd / 2);
            }
            else
            {
                tracoAntes = tracoAdd / 2;
                tracoDepois = tracoAdd / 2;
            }

            string retorno = "";
            for (int i = 0; i < tracoAntes; i++)
            {
                retorno +="_";
            }

            retorno += texto;

            for (int i = 0; i < tracoAntes; i++)
            {
                retorno +="_";
            }
            return retorno;
        }

        /// <summary>
        /// Gera um string aleatório com o tamanho especificado
        /// </summary>
        /// <param name="size">Tamanho do string</param>
        /// <param name="lowerCase">Se true, gera string em minusculas</param>
        /// <returns>Random string</returns>
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private string FormataValor(decimal? Valor)
        {
            return string.Format("{0:###,##0.00}", (Valor == null ? 0 : Valor));
        }

        private string FormataValor(decimal Valor, bool Moeda, string Simbolo)
        {
            return string.Format("{0:###,##0.00}", Valor);
        }
        private string FormataValor(decimal Valor, bool Moeda)
        {
            string ret = string.Format("{0:###,##0.00}", Valor);
            if (Moeda)
                ret = string.Format("{0:C2}", Valor);
            return ret;
        }
    }
    class Cartao
    {
        string _bandeira;
        string _numero;
        string _codigo;
        string _validade;
        int _ncorr;         // Numero de parcelas computadas
        decimal _vtotal;    // Valor total das parcelas computadas
        decimal _vpparc;    // Valor da primeira parcela
        decimal _voparc;    // Valor das outras parcelas 
        bool _pparc ;       // Indica primeira parcela computada

        public Cartao(string Bandeira, string Numero, string Codigo, string Validade)
        {
            _bandeira = Bandeira;
            _numero = Numero;
            _codigo = Codigo;
            _validade = Validade;
            _ncorr = 0;    
            _vtotal = 0;   
            _vpparc = 0;   
            _voparc = 0;   
            _pparc = true; 
        }

        public void Somar(decimal Valor)
        {
            _ncorr += 1;
            _vtotal += Valor;
            if (_pparc)
            {
                _vpparc = Valor;
                _pparc = false;
            }
            _voparc = Valor;
        }

        public string Bandeira {get { return _bandeira; } }
        public string Numero { get { return _numero; } }
        public string Codigo { get { return _codigo; } }
        public string Validade { get { return _validade; } }
        public int NumParcelas { get { return _ncorr; } }
        public decimal VTotal { get { return _vtotal; } }
        public decimal VPParc { get { return _vpparc; } }
        public decimal VOParc { get { return _voparc; } }
    }

    class Cartoes
    {
        List<Cartao> _cartoes = new List<Cartao>();

        public List<Cartao> Lista
        {
            get { return _cartoes; }
        }

        public void Incluir(string NumDoc, decimal Valor)
        {
            string[] doc = NumDoc.Split(new char[] { ';' });
            string bandeira = doc[0];
            string validade = doc[1];
            string numero = doc[2];
            string codigo = doc[3];
            Cartao car;
            if ((car = ObtemCartao(bandeira, numero)) == null)
            {
                car = new Cartao(bandeira, numero, codigo, validade);
                _cartoes.Add(car);
            }
            car.Somar(Valor);
        }

        /// <summary>
        /// Verifica se cartão já esta no array _cartoes
        /// </summary>
        /// <param name="Bandeira">Bandeira</param>
        /// <param name="Numero">Número do Cartão</param>
        /// <returns>Verdadeiro se cartão já está no array</returns>
        public Cartao ObtemCartao(string Bandeira, string Numero)
        {
            Cartao ret = null;
            foreach (Cartao c in _cartoes)
            {
                if ((c.Bandeira.Contains(Bandeira)) && c.Numero.Contains(Numero))
                    ret = c;
            }
            return ret;
        }
    }
}
