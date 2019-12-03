using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modelo
{
    [XmlInclude(typeof(Gerente))]
    [XmlInclude(typeof(OperadorDeCaixa))]
    public class Funcionario
    {
        private string nome, email, telefone, cpf, formacao, nconta, foto, login, senha;

        public int IdSupermercado { get; set; }
        public DateTime DataIngresso { get; set; }
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
        public string Telefone
        {
            get { return telefone; }
            set { if (value != null && value != "") telefone = value; else throw new ArgumentNullException(); }
        }
        public string Cpf
        {
            get { return cpf; }
            set { if (value != null && value != "") cpf = value; else throw new ArgumentNullException(); }
        }
        public string Formacao
        {
            get { return formacao; }
            set { if (value != null && value != "") formacao = value; else throw new ArgumentNullException(); }
        }
        public string NumeroConta
        {
            get { return nconta; }
            set { if (value != null && value != "") nconta = value; else throw new ArgumentNullException(); }
        }
        public string Foto
        {
            get { return foto; }
            set { if (value != null && value != "") foto = value; else throw new ArgumentNullException(); }
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
