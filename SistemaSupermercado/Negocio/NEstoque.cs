using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NEstoque
    {
        private List<Produto> estoque = new List<Produto>();
        private PEstoque pe = new PEstoque();

        public void Insert(List<Produto> produtos)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            foreach (Produto p in produtos)
            {
                for(int i = 0; i < estoque.Count; i++)
                {
                    if (p.Id == estoque[i].Id) estoque[i].Qtd += p.Qtd;
                    else estoque.Add(p);
                }
            }
            pe.Save(estoque);
        }
    }
}
