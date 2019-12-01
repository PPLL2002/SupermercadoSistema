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
        }
    }
}
