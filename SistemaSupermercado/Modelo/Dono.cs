using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Dono
    {
        private string nome;
        private string cpf;
        private string login = "admin";
        private string senha = "1234";
        public string Nome
        {
            get { return nome; }
            set { if (value != null && value != "") nome = value; else throw new ArgumentNullException(); }
        }
        public string Cpf
        {
            get { return cpf; }
            set { if (value != null && value != "") cpf = value; else throw new ArgumentNullException(); }
        }
        public string Login
        {
            get { return login; }
            set { if (value != null && value != "") login = value; else throw new ArgumentNullException(); }
        }
        public string Senha
        {
            get { return senha; }
            set { if (value != null && value != "") senha = value; else throw new ArgumentNullException(); }
        }
    }
}
