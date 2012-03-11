using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viagens
{
    class cad
    {
        private static string[] _CategoriaPassageiro = new string[] {"Adult","CHD","INF"};

        public static string CategoriaPassageiro(int IxCatPassageiro)
        {
            int Ix = 0;
            if (IxCatPassageiro > 2)
                Ix = 0;
            else
                Ix = IxCatPassageiro;
            return _CategoriaPassageiro[Ix];
        }
        public static int IxCategoriaPassageiro(string CategoriaPassageiro)
        {
            int Ix = 0;
            for (int j = 0; j < _CategoriaPassageiro.Length; j++ )
            {
                if (_CategoriaPassageiro[j] == CategoriaPassageiro)
                {
                    Ix = j;
                    break;
                }
            }
            return Ix;
        }

        public static string[] Categorias
        {
            get { return _CategoriaPassageiro; }
        }

        public static Cliente SelecionaCliente(bool Selecionar)
        {
            Cliente Ret = null;
            frmCli01 frm = new frmCli01();
            
            if (Selecionar)
            {
            //    frm.desativarBtNovo();
                //frm.desativarEventoGrid();
                frm.Titulo = "Seleção de Clientes";
            }
            else 
            {
                frm.desativarBtSelecionar();
            }

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.ClienteSelecionado;
                frm.Dispose();
            }
            
            return Ret;
        }
        public static Cidade SelecionaCidade(bool Selecionar)
        {
            Cidade Ret = null;
            frmCid01 frm = new frmCid01();

            if (Selecionar)
            {
                //frm.desativarBtNovo();
                frm.desativarEventoGrid();
            }
            else
            {
                frm.desativarBtSelecionar();
            }

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.CidadeSelecionada;
                frm.Dispose();
            }

            return Ret;
        }
        public static Pais SelecionaPais(bool Selecionar)
        {
            Pais Ret = null;
            frmPais01 frm = new frmPais01();

            if (Selecionar)
            {
                //frm.desativarBtNovo();
                frm.desativarEventoGrid();
                frm.habilitarSelecionar();
            }
            else
            {
                frm.desativarBtSelecionar();
            }

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.PaisSelecionado;
                frm.Dispose();
            }

            return Ret;
        }

        public static Produto SelecionaProduto(bool Selecionar)
        {
            return SelecionaProduto(Selecionar, 0);
        }

        public static Produto SelecionaProduto(bool Selecionar, long idTipoProduto)
        {
            Produto Ret = null;
            frmProd01 frm = new frmProd01();

            frm.idTipoProduto = idTipoProduto;

            if (Selecionar)
            {
                //frm.desativarBtNovo();
                frm.desativarEventoGrid();
                frm.habilitarSelecionar();
            }
            else
            {
                frm.desativarBtSelecionar();
            }
            
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.ProdutoSelecionado;
                frm.Dispose();
            }
            return Ret;
        }

        public static Fornecedor SelecionaFornecedor(bool Selecionar)
        {
            return SelecionaFornecedor(Selecionar, 0,0);
        }

        /// <summary>
        /// Permite seleção de fornecedor por tipo e cidade
        /// </summary>
        /// <param name="Selecionar">modo seleção ou cadastro</param>
        /// <param name="idTipoFornecedor">Id do Tipo Fornecedor</param>
        /// <param name="IdCidade">Id da Cidade</param>
        /// <returns>Fornecedor selecionado</returns>
        public static Fornecedor SelecionaFornecedor(bool Selecionar, long idTipoFornecedor, long IdCidade)
        {
            Fornecedor Ret = null;
            frmForn01 frm = new frmForn01();

            frm.IdTipoFornecedor = idTipoFornecedor;
            frm.idCidade = IdCidade;

            if (Selecionar)
            {
                //frm.desativarBtNovo();
                frm.desativarEventoGrid();
                frm.habilitarSelecionar();
            }
            else
            {
                frm.desativarBtSelecionar();
            }

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.FornecedorSelecionado;
                frm.Dispose();
            }

            return Ret;
        }

        public static Venda EditarVenda(Venda VendaSelecionada, Usuario Vendedor)
        {
            Venda Ret = null;
            frmRealizarVenda01 frm = new frmRealizarVenda01();
            frm.Vendedor = Vendedor;
            frm.VendaSelecionada = VendaSelecionada;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.VendaSelecionada;
                frm.Dispose();
            }

            return Ret;
        }

        public static TipoProduto SelecionaTipoProduto(bool Selecionar)
        {
            TipoProduto tp = null;
            frmTProd01 frm = new frmTProd01();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                tp = frm.TipoProdutoSelecionado;
            }
            return tp;
        }

        internal static Venda SelecionaV_Vendas(bool p,Usuario Vendedor)
        {
            Venda Ret = null;
            frmPesquisarVenda01 frm = new frmPesquisarVenda01();
            frm.Vendedor = Vendedor;

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ret = frm.VendaSelecionado;
                frm.Dispose();
            }

            return Ret;
        }
        public static Usuario SelecionaUsuario(bool Selecionar, Usuario Operador)
        {
            Usuario ret = null;
            frmUsr01 frm = new frmUsr01();
            frm.Operador = Operador;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ret = frm.UsuarioSelecionado;
                frm.Dispose();
            }
            return ret;
        }
    }
}
