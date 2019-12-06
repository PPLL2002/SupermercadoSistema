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

        public void Insert(Produto p)
        {
            PEstoque pE = new PEstoque();
            List<Produto> lP = pE.Open();
            lP.Add(p);
            pE.Save(lP);
        }
        public void UpdateEstoque(List<ItemCompra> c)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            PProduto PP = new PProduto();
            List<Produto> lPP = PP.Open();
            ItemCompra item;
            foreach(ItemCompra x in c)
            {
                item = null;
                for(int i = 0; i < estoque.Count; i++)
                {
                    if (estoque[i].Id == x.IdProduto) { estoque[i].Qtd += x.Qtd; break; }
                    if (i == estoque.Count - 1) item = x;
                }
                if (estoque.Count == 0)
                {
                    item = x;
                    foreach (Produto p in lPP)
                    {
                        if (item.IdProduto == p.Id) { p.Qtd = x.Qtd; estoque.Add(p); break; }
                    }
                }
                if (item != null)
                {
                    foreach(Produto p in lPP)
                    {
                        if (item.IdProduto == p.Id) { p.Qtd = item.Qtd; estoque.Add(p); break; }
                    }
                }
            }
            pe.Save(estoque);
        }

        public void Update(Produto p)
        {
            PEstoque pE = new PEstoque();
            List<Produto> lP = pE.Open();
            for(int k = 0; k < lP.Count; k++)
            {
                if(lP[k].Id == p.Id)
                {
                    lP.RemoveAt(k);
                }
            }
            lP.Add(p);
            pE.Save(lP);
        }
        public List<Produto> VerificarValidade()
        {
            pe = new PEstoque();
            estoque = pe.Open();
            List<Produto> vencidos = new List<Produto>();
            foreach (Produto p in estoque)
            {
                if (p.Validade < DateTime.Now) vencidos.Add(p);
            }

            return vencidos;
        }

        public void Delete(Produto p)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            for (int i = 0; i < estoque.Count; i++)
                if (estoque[i].Id == p.Id)
                {
                    estoque.RemoveAt(i);
                    break;
                }
            pe.Save(estoque);
        }

        public void AlterarPreco(Produto p, decimal preco)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            for (int i = 0; i < estoque.Count; i++)
                if (estoque[i].Id == p.Id)
                {
                    estoque[i].Preco = preco;
                    break;
                }
            pe.Save(estoque);
        }

        public List<Produto> Select()
        {
            pe = new PEstoque();
            return pe.Open().OrderBy(c => c.Nome).ToList();
        }

        public List<Produto> SearchData(DateTime t)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            List<Produto> pesquisados = new List<Produto>();
            foreach (Produto p in estoque)
            {
                if (p.Validade < t) pesquisados.Add(p);
            }

            return pesquisados;
        }

        public List<Produto> SearchNome(string n)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            List<Produto> pesquisados = new List<Produto>();
            foreach (Produto p in estoque)
            {
                if (p.Nome == n) pesquisados.Add(p);
            }

            return pesquisados;
        }

        public List<Produto> SearchID(int i)
        {
            pe = new PEstoque();
            estoque = pe.Open();
            List<Produto> pesquisados = new List<Produto>();
            foreach (Produto p in estoque)
            {
                if (p.Id == i) pesquisados.Add(p);
            }

            return pesquisados;
        }
    }
}
