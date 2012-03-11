using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viagens
{
    public class CidadeView
    {
        private long _IdCidade;
        private long _IdPais;
        private string _Cidade;
        private string _Estado;
        private string _DDD;
        private string _Pais;
        private string _DDI;

        public long IdCidade 
        { 
            get {return _IdCidade;}
            set { _IdCidade = value; }
        }
        public long IdPais 
        {
            get { return _IdPais; }
            set { _IdPais = value; } 
        }
        public string Cidade 
        {
            get { return _Cidade; }
            set { _Cidade = value; } 
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public string DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }
        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }
        public string DDI
        {
            get { return _DDI; }
            set { _DDI = value; }
        }
        
    }
}
