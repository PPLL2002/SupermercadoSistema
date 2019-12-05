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

        public List<Produto> Search(DateTime t)
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
    }
}
