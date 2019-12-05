using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Produto
    {
        private string nome, descricao;
        private int qtd;
        private decimal preco;
        private DateTime validade;

        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public int IdSupermercado { get; set; }

        public string Nome
        {
            get { return nome; }
            set { if (value != null && value != "") nome = value; else throw new ArgumentNullException(); }
        }

        public string Descricao
        {
            get { return descricao; }
            set { if (value != null && value != "") descricao = value; else throw new ArgumentNullException(); }
        }

        public int Qtd
        {
            get { return qtd; }
            set { if (value >= 0) qtd = value; else throw new ArgumentNullException(); }
        }

        public decimal Preco
        {
            get { return preco; }
            set { if (value >= 0) preco = value; else throw new ArgumentNullException(); }
        }

        public DateTime Validade
        {
            get { return validade; }
            set { if (value != null) validade = value; else throw new ArgumentNullException(); }
        }
    }
}
