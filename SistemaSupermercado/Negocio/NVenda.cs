using Modelo;
using System;
using Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NVenda
    {
        List<Venda> vendas;
        private int id;
        public void Insert(Venda v)
        {
            PVenda p = new PVenda();
            vendas = p.Open();
            id = 1;
            if (vendas.Count > 1) id = vendas.Max(x => x.Id) + 1;
            v.Id = id;
            vendas.Add(v);
            p.Save(vendas);
        }
        public void Delete(Venda c)
        {
            PItemVenda pIC = new PItemVenda();
            NItemVenda nIC = new NItemVenda();
            List<ItemVenda> lIC = pIC.Open();
            foreach (ItemVenda i in lIC) if (i.IdVenda == c.Id) nIC.Delete(i);

            PVenda pC = new PVenda();
            vendas = pC.Open();

            for (int i = 0; i < vendas.Count; i++)
                if (vendas[i].Id == c.Id)
                {
                    vendas.RemoveAt(i);
                    break;
                }
            pC.Save(vendas);
        }
    }
}
