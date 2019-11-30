using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NProduto
    { 
        private List<Produto> produtos = new List<Produto>();

        public void Insert(Produto p)
        {
            PProduto pP = new PProduto();
            produtos = pP.Open();
            int id = 1;
            if (produtos.Count > 0) id = produtos.Max(x => x.Id) + 1;
            p.Id = id;
            produtos.Add(p);
            pP.Save(produtos);
        }

        public void Update(Produto p)
        {
            PProduto pP = new PProduto();
            produtos = pP.Open();
            for (int i = 0; i < produtos.Count; i++)
                if (produtos[i].Id == p.Id)
                {
                    produtos.RemoveAt(i);
                    break;
                }
            produtos.Add(p);
            pP.Save(produtos);
        }
        public List<Produto> Select(int id)
        {
            PProduto pP = new PProduto();
            produtos = pP.Open();
            List<Produto> prod = new List<Produto>();

            foreach(Produto p in produtos)
            {
                if (p.IdFornecedor == id) prod.Add(p);
            }

            return prod.OrderBy(c => c.Descricao).ToList();
        }
        public void Delete(Produto p)
        {
            PProduto pP = new PProduto();
            produtos = pP.Open();
            for (int i = 0; i < produtos.Count; i++)
                if (produtos[i].Id == p.Id)
                {
                    produtos.RemoveAt(i);
                    break;
                }
            pP.Save(produtos);
        }
        public List<Produto> Search(string nome, int id)
        {
            PProduto pP = new PProduto();
            produtos = pP.Open();
            List<Produto> retorno = new List<Produto>();
            foreach (Produto p in produtos)
            {
                if (p.Nome == nome && p.IdFornecedor == id) retorno.Add(p);
            }
            return retorno;
        }
    }
}
