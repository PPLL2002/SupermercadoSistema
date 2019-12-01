using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ItemCompra
    {
        private int idCompra;
        public int IdProduto { get; set; }
        public int IdCompra
        {
            set { if (value > 0) idCompra = value; }
            get { return idCompra; }
        }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
    }
}
