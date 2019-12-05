using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Modelo;

namespace Negocio
{
    public class Relatorio
    {
        public decimal CalcularTicketMedio()
        {
            PVenda pv = new PVenda();
            List<Venda> car = new List<Venda>();
            car = pv.Open();
            return CalcularReceita() / (car.Count);
        }

        public decimal CalcularReceita()
        {
            PItemVenda p = new PItemVenda();
            List<ItemVenda> itens = new List<ItemVenda>();
            itens = p.Open();
            decimal vendatotal = 0;
            foreach (ItemVenda it in itens)
            {
                vendatotal += it.Preco * it.Qtd;
            }
            return vendatotal;
        }
        public decimal CalcularCusto()
        {
            PItemCompra p = new PItemCompra();
            List<ItemCompra> itens = new List<ItemCompra>();
            itens = p.Open();
            decimal compratotal = 0;
            foreach (ItemCompra it in itens)
            {
                compratotal += it.Preco * it.Qtd;
            }
            return compratotal;
        }
        public decimal CalcularLucro()
        {
            return CalcularReceita() - CalcularCusto();
        }
    }
}
