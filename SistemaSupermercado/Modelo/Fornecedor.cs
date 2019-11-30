using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Fornecedor
    {
        private string nome, email, categoria;
        
        public int Id { get; set; }
        public string Nome
        {
            get { return nome; }
            set { if (value != null && value != "") nome = value; else throw new ArgumentNullException(); }
        }
        public string Email
        {
            get { return email; }
            set { if (value != null && value != "") email = value; else throw new ArgumentNullException(); }
        }
        public string Categoria
        {
            get { return categoria; }
            set { if (value != null && value != "") categoria = value; else throw new ArgumentNullException(); }
        }
    }
}
