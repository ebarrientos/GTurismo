using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Viagens
{
    class acc
    {
        
        public static Cliente ObtemCliente(System.Nullable<long> ID)
        {
            
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var ClienteSelecionado =
                (from cli in ViagensDC.Clientes 
                 where cli.IDCliente == ID
                 select cli);
            return ClienteSelecionado.SingleOrDefault<Cliente>();
        }

        public static void InsertOrUpdateCliente(Cliente Cli)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Cliente ClienteSelecionado =
                (from clt in ViagensDC.Clientes
                 where clt.IDCliente == Cli.IDCliente
                 select clt).SingleOrDefault<Cliente>();

            if (ClienteSelecionado == null)
            {
                ViagensDC.Clientes.InsertOnSubmit(Cli);
            }
            else 
            {
                ClienteSelecionado.IdResp = Cli.IdResp;
                ClienteSelecionado.Nome1 = Cli.Nome1;
                ClienteSelecionado.Nome2 = Cli.Nome2;
                ClienteSelecionado.Nome3 = Cli.Nome3;
                //ClienteSelecionado.Passageiros = Cli.Passageiros;
                ClienteSelecionado.RG = Cli.RG;
                ClienteSelecionado.Telefone = Cli.Telefone;
                ClienteSelecionado.IdCidade = Cli.IdCidade;
                ClienteSelecionado.Endereco = Cli.Endereco;
                ClienteSelecionado.email = Cli.email;
                ClienteSelecionado.CPF = Cli.CPF;
                ClienteSelecionado.Comentarios = Cli.Comentarios;
                ClienteSelecionado.CEP = Cli.CEP;
                ClienteSelecionado.DataNascimento = Cli.DataNascimento;
                ViagensDC.ContatoClientes.DeleteAllOnSubmit(ClienteSelecionado.ContatoClientes);
                foreach (ContatoCliente cc in Cli.ContatoClientes)
                {
                    ContatoCliente c1 = new ContatoCliente();
                    c1.Telefone = cc.Telefone;
                    ClienteSelecionado.ContatoClientes.Add(c1);
                }
                ClienteSelecionado.NomeMae = Cli.NomeMae;
                ClienteSelecionado.RendaMensal = Cli.RendaMensal;
                ClienteSelecionado.ContaReembolso = Cli.ContaReembolso;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ContatoCliente ObtemContatoCliente(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var CCSelecionado = (from cc in ViagensDC.ContatoClientes
                                where cc.IdContatoCliente == ID
                                select cc).SingleOrDefault<ContatoCliente>();
            return CCSelecionado;
        }
        public static void InsertOrUpdateContatoCliente(ContatoCliente CC)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            ContatoCliente ContatoClienteSelecionado =
                (from clt in ViagensDC.ContatoClientes
                 where clt.IdContatoCliente == CC.IdContatoCliente
                 select clt).SingleOrDefault<ContatoCliente>();

            if (ContatoClienteSelecionado == null)
            {
                ViagensDC.ContatoClientes.InsertOnSubmit(CC);
            }
            else
            {
                ContatoClienteSelecionado.Telefone = CC.Telefone;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteContatoCliente(ContatoCliente CC)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            ContatoCliente CCSelecionado = (from c in ViagensDC.ContatoClientes
                                 where c.IdContatoCliente == CC.IdContatoCliente
                                 select c).SingleOrDefault<ContatoCliente>();

            if (CCSelecionado != null)
            {
                ViagensDC.ContatoClientes.DeleteOnSubmit(CCSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Se Não existe Cadastra Cidade
        /// </summary>
        /// <param name="IdPais">Id do Pais</param>
        /// <param name="NomeCidade">Nome da Cidade a Buscar ou Inserir</param>
        /// <returns>Id da Cidade</returns>
        public static Cidade BuscaOuInsereCidade(long IdPais, string NomeCidade)
        {
            Cidade ret ;
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var C = (from c in ViagensDC.Cidades
                     where c.IdPais == IdPais && c.Nome == NomeCidade
                     select c).SingleOrDefault<Cidade>();
            if (C == null)
            {
                Cidade cid = new Cidade();
                cid.Nome = NomeCidade.ToUpper();
                cid.IdPais = IdPais;
                cid.DDD = "00";
                cid.Estado = "XX";
                ViagensDC.Cidades.InsertOnSubmit(cid);
                try
                {
                    ViagensDC.SubmitChanges();
                    ret = cid;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                ret = C;
            return ret;
        }

        public static long BuscaOuInserePais(string NomePais)
        {
            long ret = 0;
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var P = (from p in ViagensDC.Pais
                     where p.Nome == NomePais
                     select p).SingleOrDefault<Pais>();
            if (P == null)
            {
                Pais pais = new Pais();
                pais.Nome = NomePais.ToUpper();
                pais.DDI = "000";
                ViagensDC.Pais.InsertOnSubmit(pais);
                ViagensDC.SubmitChanges();
                ret = pais.IdPais;
            }
            else
                ret = P.IdPais;
            return ret;
        }

        public static Cidade ObtemCidade(System.Nullable<long> ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var CidadeSelecionada =
                (from cid in ViagensDC.Cidades
                 where cid.IdCidade == ID
                 select cid).SingleOrDefault<Cidade>();
            return CidadeSelecionada;
        }
        
        public static Cidade ObtemCidade(long IdPais, string NomeCidade)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var CidadeSelecionada =
                (from cid in ViagensDC.Cidades
                 where cid.IdPais == IdPais && cid.Nome == NomeCidade
                 select cid).SingleOrDefault<Cidade>();
            return CidadeSelecionada;
        }

        public static string[] ListaCidades()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            string[] lc = (from cid in ViagensDC.Cidades
                 orderby cid.Nome select cid.Nome.ToUpper()).ToArray<string>();
            return lc;
        }

        public static string[] ListaCidades(string Pais)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            string[] lc = (from cid in ViagensDC.Cidades
                           where cid.Pais.Nome == Pais
                           orderby cid.Nome
                           select cid.Nome.ToUpper()).ToArray<string>();
            return lc;
        }

        public static string[] ListaPaises()
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            string[] lp = (from p in ViagensDC.Pais
                           orderby p.Nome
                           select p.Nome.ToUpper()).ToArray<string>();
            return lp;
        }

        public static void DeletePais(Pais pais) 
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Pais PaisSelecionado =
                (from p in ViagensDC.Pais
                 where p.IdPais == pais.IdPais
                 select p).SingleOrDefault<Pais>();
            
            if (PaisSelecionado != null)
            {
                ViagensDC.Pais.DeleteOnSubmit(PaisSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertOrUpdatePaises(Pais pais)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Pais PaisSelecionado =
                (from p in ViagensDC.Pais
                 where p.IdPais == pais.IdPais
                 select p).SingleOrDefault<Pais>();

            if (PaisSelecionado == null)
            {
                ViagensDC.Pais.InsertOnSubmit(pais);
            }
            else
            {
                PaisSelecionado.Nome = pais.Nome;
                PaisSelecionado.DDI = pais.DDI;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Pais ObtemPais(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var PaisSelecionado =
                (from pais in ViagensDC.Pais
                 where pais.IdPais == ID
                 select pais).SingleOrDefault<Pais>();
            return PaisSelecionado;
        }

        public static Pais ObtemPais(string Pais)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var PaisSelecionado =
                (from pais in ViagensDC.Pais
                 where pais.Nome == Pais
                 select pais).SingleOrDefault<Pais>();
            return PaisSelecionado;
        }

        public static void InsertOrUpdateCidade(Cidade cid)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Cidade CidadeSelecionada =
                (from c in ViagensDC.Cidades
                 where c.IdCidade == cid.IdCidade
                 select c).SingleOrDefault<Cidade>();

            if (CidadeSelecionada == null)
            {
                ViagensDC.Cidades.InsertOnSubmit(cid);
            }
            else
            {
                CidadeSelecionada.Nome = cid.Nome;
                CidadeSelecionada.DDD = cid.DDD;
                CidadeSelecionada.Estado = cid.Estado;
                CidadeSelecionada.IdPais = cid.IdPais;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void DeleteCidade(Cidade cidade)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Cidade CidadeSelecionada =
                (from c in ViagensDC.Cidades
                 where c.IdCidade == cidade.IdCidade
                 select c).SingleOrDefault<Cidade>();

            if (CidadeSelecionada != null)
            {
                ViagensDC.Cidades.DeleteOnSubmit(CidadeSelecionada);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Produto ObtemProduto(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var ProdutoSelecionado =
                (from produto in ViagensDC.Produtos
                 where produto.IdProduto == ID
                 select produto).SingleOrDefault<Produto>();
            return ProdutoSelecionado;
        }

        public static void DeleteProduto(Produto produto)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Produto ProdutoSelecionado =
                (from p in ViagensDC.Produtos
                 where p.IdProduto == produto.IdProduto
                 select p).SingleOrDefault<Produto>();

            if (ProdutoSelecionado != null)
            {
                ViagensDC.Produtos.DeleteOnSubmit(ProdutoSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertOrUpdateProduto(Produto produto)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Produto ProdutoSelecionado =
                (from p in ViagensDC.Produtos
                 where p.IdProduto == produto.IdProduto
                 select p).SingleOrDefault<Produto>();

            if (ProdutoSelecionado == null)
            {
                ViagensDC.Produtos.InsertOnSubmit(produto);
            }
            else
            {
                ProdutoSelecionado.Nome = produto.Nome;
                ProdutoSelecionado.Descricao = produto.Descricao;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Produto[] ProdutosPorTipo(long tipoDeProduto)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Produto[] tps = (from p in ViagensDC.Produtos
                             where p.IdTipoProduto == tipoDeProduto
                             select p).ToArray<Produto>();
            return tps;
        }

        public static TipoProduto ObtemTipoProduto(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var TipoProdutoSelecionado =
                (from Tipoproduto in ViagensDC.TipoProdutos
                 where Tipoproduto.IdTipoProduto == ID
                 select Tipoproduto).SingleOrDefault<TipoProduto>();
            return TipoProdutoSelecionado;
        }

        public static void DeleteTipoProduto(TipoProduto TipoProduto)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            TipoProduto TipoProdutoSelecionado =
                (from tp in ViagensDC.TipoProdutos 
                 where tp.IdTipoProduto == TipoProduto.IdTipoProduto
                 select tp).SingleOrDefault<TipoProduto>();

            if (TipoProdutoSelecionado != null)
            {
                ViagensDC.TipoProdutos.DeleteOnSubmit(TipoProdutoSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertOrUpdateTipoProduto(TipoProduto TipoProduto)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            TipoProduto TipoProdutoSelecionado =
                (from tp in ViagensDC.TipoProdutos
                 where tp.IdTipoProduto == TipoProduto.IdTipoProduto
                 select tp).SingleOrDefault<TipoProduto>();

            if (TipoProdutoSelecionado == null)
            {
                ViagensDC.TipoProdutos.InsertOnSubmit(TipoProduto);
            }
            else
            {
                TipoProdutoSelecionado.Nome = TipoProduto.Nome;
                TipoProdutoSelecionado.Descricao = TipoProduto.Descricao;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TipoFornecedor ObtemTipoFornecedor(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var TipoFornecedorSelecionado =
                (from tf in ViagensDC.TipoFornecedors 
                 where tf.IdTipoFornecedor == ID
                 select tf).SingleOrDefault<TipoFornecedor>();
            return TipoFornecedorSelecionado;
        }

        public static void DeleteTipoFornecedor(TipoFornecedor tf)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            TipoFornecedor TipoFornecedorSelecionado =
                (from tf1 in ViagensDC.TipoFornecedors
                 where tf1.IdTipoFornecedor == tf.IdTipoFornecedor
                 select tf1).SingleOrDefault<TipoFornecedor>();

            if (TipoFornecedorSelecionado != null)
            {
                ViagensDC.TipoFornecedors.DeleteOnSubmit(TipoFornecedorSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertOrUpdateTipoFornecedor(TipoFornecedor tf)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            TipoFornecedor TipoFornecedorSelecionado =
                (from tf1 in ViagensDC.TipoFornecedors 
                 where tf1.IdTipoFornecedor == tf.IdTipoFornecedor 
                 select tf1).SingleOrDefault<TipoFornecedor>();

            if (TipoFornecedorSelecionado == null)
            {
                ViagensDC.TipoFornecedors.InsertOnSubmit(tf);
            }
            else
            {
                TipoFornecedorSelecionado.Nome = tf.Nome;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static Fornecedor ObtemFornecedor(long ID)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            var FornecedorSelecionado =
                (from fornecedor in ViagensDC.Fornecedors
                 where fornecedor.IdFornecedor == ID
                 select fornecedor).SingleOrDefault<Fornecedor>();
            return FornecedorSelecionado;
        }

        public static void DeleteFornecedor(Fornecedor fornecedor)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Fornecedor FornecedorSelecionado =
                (from p in ViagensDC.Fornecedors
                 where p.IdFornecedor == fornecedor.IdFornecedor
                 select p).SingleOrDefault<Fornecedor>();

            if (FornecedorSelecionado != null)
            {
                ViagensDC.Fornecedors.DeleteOnSubmit(FornecedorSelecionado);
            }
            else
            {
                //Elemento nao encontrado...Tratar situacao    
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertOrUpdateFornecedor(Fornecedor fornecedor)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Fornecedor FornecedorSelecionado =
                (from f in ViagensDC.Fornecedors
                 where f.IdFornecedor == fornecedor.IdFornecedor
                 select f).SingleOrDefault<Fornecedor>();

            if (FornecedorSelecionado == null)
            {
                ViagensDC.Fornecedors.InsertOnSubmit(fornecedor);
            }
            else
            {
                FornecedorSelecionado.Nome = fornecedor.Nome;
                FornecedorSelecionado.IdCidade = fornecedor.IdCidade;
                FornecedorSelecionado.Comissao = fornecedor.Comissao;
                FornecedorSelecionado.email = fornecedor.email;
                FornecedorSelecionado.Telefone = fornecedor.Telefone;
                FornecedorSelecionado.Endereco = fornecedor.Endereco;
                FornecedorSelecionado.Numero = fornecedor.Numero;
                FornecedorSelecionado.CEP = fornecedor.CEP;
                FornecedorSelecionado.Comentarios = fornecedor.Comentarios;
                FornecedorSelecionado.Complemento = fornecedor.Complemento;
                FornecedorSelecionado.IdTipoFornecedor = fornecedor.IdTipoFornecedor;
            }
            try
            {
                ViagensDC.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteVenda(long IdVenda)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Venda VendaSelecionada =
                (from v in ViagensDC.Vendas
                 where v.IdVenda == IdVenda
                 select v).SingleOrDefault<Venda>();

            if (VendaSelecionada != null)
            {
                ViagensDC.Vendas.DeleteOnSubmit(VendaSelecionada);
                ViagensDC.SubmitChanges();                
            }
        }

        public static void InsertOrUpdateVenda(Venda venda)
        {
            bool VendaExiste = true;
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Venda VendaSelecionada =
                (from v in ViagensDC.Vendas
                 where v.IdVenda == venda.IdVenda
                 select v).SingleOrDefault<Venda>();

            if (VendaSelecionada == null)
            {
                VendaSelecionada = new Venda();
                VendaExiste = false;
            }
            VendaSelecionada.IdCidade = venda.IdCidade;
            VendaSelecionada.IdCliente = venda.IdCliente;
            VendaSelecionada.IdOperadora = venda.IdOperadora;
            VendaSelecionada.IdProduto = venda.IdProduto;
            VendaSelecionada.IdHotel = venda.IdHotel;
            VendaSelecionada.DataVenda = venda.DataVenda;
            VendaSelecionada.DataEmbarque = venda.DataEmbarque;
            VendaSelecionada.DataRetorno = venda.DataRetorno;
            VendaSelecionada.IdMotivoViagem = venda.IdMotivoViagem;
            VendaSelecionada.IdMotivoCancelamento = venda.IdMotivoCancelamento;
            foreach (HistoricoVenda hv in venda.HistoricoVendas)
            {
                HistoricoVenda h1 = new HistoricoVenda();
                h1.DtRegistro = hv.DtRegistro;
                h1.Registro = hv.Registro;
                h1.TipoRegistro = hv.TipoRegistro;
                VendaSelecionada.HistoricoVendas.Add(h1);
            }
                
            VendaSelecionada.Desconto = venda.Desconto;
            VendaSelecionada.PrecoAdult = venda.PrecoAdult;
            VendaSelecionada.PrecoCHD = venda.PrecoCHD;
            VendaSelecionada.PrecoINF = venda.PrecoINF;
            VendaSelecionada.TaxaAdult = venda.TaxaAdult;
            VendaSelecionada.TaxaCHD = venda.TaxaCHD;
            VendaSelecionada.TaxaInf = venda.TaxaInf;
            VendaSelecionada.TaxaAdm = venda.TaxaAdm;

            VendaSelecionada.CambioDoDia = venda.CambioDoDia;
            VendaSelecionada.IdTipoMoeda = venda.IdTipoMoeda;

            ViagensDC.Passageiros.DeleteAllOnSubmit(VendaSelecionada.Passageiros);
            foreach (Passageiro p in venda.Passageiros)
            {
                Passageiro pas = new Passageiro();
                pas.IdCategoria = p.IdCategoria;
                pas.IdPassageiro = p.IdPassageiro;
                VendaSelecionada.Passageiros.Add(pas);
            }

            VendaSelecionada.IdTipoPagamento = venda.IdTipoPagamento;
            VendaSelecionada.IdTipoReembolso = venda.IdTipoReembolso;
            
            ViagensDC.Parcelas.DeleteAllOnSubmit(VendaSelecionada.Parcelas);
            foreach (Parcela p in venda.Parcelas)
            {
                Parcela par = new Parcela();
                par.DtVencimento = p.DtVencimento;
                par.IdFormaPagamento = p.IdFormaPagamento;
                par.IdSituacao = p.IdSituacao;
                par.Item = p.Item;
                par.NumDoc = p.NumDoc;
                par.Valor = p.Valor;
                VendaSelecionada.Parcelas.Add(par);
            }

            VendaSelecionada.Observacoes = venda.Observacoes;
            VendaSelecionada.IdSituacaoVenda = venda.IdSituacaoVenda;

            VendaSelecionada.IdComissionado = venda.IdComissionado;
            VendaSelecionada.IdUsuario = venda.IdUsuario;
            VendaSelecionada.Localizador = venda.Localizador;
            if (!VendaExiste)
                ViagensDC.Vendas.InsertOnSubmit(VendaSelecionada);
            try
            {
                ViagensDC.SubmitChanges();
                venda.IdVenda = VendaSelecionada.IdVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Venda ObtemVenda(long IdVenda)
        {
            ViagensDataContext ViagensDC = new ViagensDataContext();
            Venda vs = (from v in ViagensDC.Vendas
                        where v.IdVenda == IdVenda
                        select v).SingleOrDefault<Venda>();
            return vs;
        }


    }
}
