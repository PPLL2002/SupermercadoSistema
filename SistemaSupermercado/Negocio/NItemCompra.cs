using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NItemCompra
    {
        List<ItemCompra> itens;
        public void Insert(ItemCompra iv)
        {
            PItemCompra pIC = new PItemCompra();
            itens = pIC.Open();
            itens.Add(iv);
            pIC.Save(itens);
            PProduto pP = new PProduto();
            List<Produto> pro = pP.Open();
            Produto p = pro.Where(x => x.Id == iv.IdProduto).Single();
            p.Qtd -= iv.Qtd;
            NProduto nP = new NProduto();
            nP.Update(p);
            
            }
        public void Delete(ItemCompra i)
        {
            PItemCompra pF = new PItemCompra();
            itens = pF.Open();
            for (int l = 0; l < itens.Count; l++)
            {
                if (itens[l].IdProduto == i.IdProduto && itens[l].IdCompra == i.IdCompra)
                {
                    PProduto pP = new PProduto();
                    List<Produto> pro = pP.Open();
                    Produto p = pro.Where(x => x.Id == i.IdProduto).Single();
                    p.Qtd += i.Qtd;
                    NProduto nP = new NProduto();
                    nP.Update(p);
                    itens.RemoveAt(l);
                    break;
                }
            }
            pF.Save(itens);
        }
    }
}
