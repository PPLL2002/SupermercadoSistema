using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    class NItemVenda
    {
        public List<ItemVenda> itens;
        public void Insert(int idv, int idp, int qt, decimal pr)
        {
            ItemVenda it = new ItemVenda();
            PItemVenda p = new PItemVenda();
            itens = p.Open();
            it.IdVenda = idv;
            it.IdProduto = idp;
            it.Qtd = qt;
            it.Preco = pr;
            itens.Add(it);
            p.Save(itens);

        }
        public void Delete(ItemVenda i)
        {
            PItemVenda pF = new PItemVenda();
            itens = pF.Open();
            for (int l = 0; l < itens.Count; l++)
                if (itens[l].IdProduto == i.IdProduto && itens[l].IdVenda == i.IdVenda)
                {
                    itens.RemoveAt(l);
                    break;
                }
            pF.Save(itens);
        }
    }
}
