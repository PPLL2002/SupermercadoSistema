using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class Login
    {
        public bool VerificarSenha(string login, string senha, int tipo)
        {
            PFuncionario pf = new PFuncionario();
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios = pf.Open();
            if(tipo == 0)
            {
                Dono d = new Dono();
                if (d.Usuario == login && d.Senha == senha) return true;
            }
            foreach(Funcionario f in funcionarios)
            {
                if (f.Login == login && f.Senha == senha)
                {
                    if (tipo == 1)
                    {
                        if (f is Gerente) return true;
                    }
                    else
                    {
                        if (f is OperadorDeCaixa) return true;
                    }
                }
            }
            return false;
        }

        public bool TrocarSenha(string login, string novasenha)
        {
            PFuncionario pf = new PFuncionario();
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios = pf.Open();
            foreach (Funcionario f in funcionarios)
            {
                if (f.Login == login)
                {
                    f.Senha = novasenha;
                    return true;
                }
            }
            return false;
        }
    }
}
