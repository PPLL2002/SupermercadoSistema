using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NItemVenda
    {
        public List<ItemVenda> itens;
        public void Insert(ItemVenda it)
        { 
            PItemVenda p = new PItemVenda();
            itens = p.Open();
            itens.Add(it);
            p.Save(itens);
            PEstoque e = new PEstoque();
            List<Produto> estoque = e.Open();
            Produto pro = estoque.Where(x => x.Id == it.IdProduto).Single();
            pro.Qtd -= it.Qtd;
            NEstoque nE = new NEstoque();
            nE.Update(pro);
        }
        public void Delete(ItemVenda i)
        {
            PItemVenda pF = new PItemVenda();
            itens = pF.Open();
            for (int l = 0; l < itens.Count; l++)
                if (itens[l].IdProduto == i.IdProduto && itens[l].IdVenda == i.IdVenda)
                {
                    PEstoque e = new PEstoque();
                    List<Produto> estoque = e.Open();
                    Produto pro = estoque.Where(x => x.Id == i.IdProduto).Single();
                    pro.Qtd += i.Qtd;
                    NEstoque nE = new NEstoque();
                    nE.Update(pro);
                    itens.RemoveAt(l);
                    break;
                }
            pF.Save(itens);
        }
    }
}
