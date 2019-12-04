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
    }
}
