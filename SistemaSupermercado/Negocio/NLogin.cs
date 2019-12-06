using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NLogin
    {
        public bool VerificarSenha(string login, string senha, int tipo)
        {
            PFuncionario pf = new PFuncionario();
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios = pf.Open();
            NCriptografia crp = new NCriptografia();
            if (tipo == 0)
            {
                PDono Pd = new PDono();
                Dono d = Pd.Open();
                if (d.Login == login && d.Senha == senha) return true;
            }
            foreach(Funcionario f in funcionarios)
            {
                if (f.Login == login && crp.Criptografar(f.Senha) == senha)
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
            NCriptografia crp = new NCriptografia();
            foreach (Funcionario f in funcionarios)
            {
                if (f.Login == login)
                {
                    f.Senha = crp.Criptografar(novasenha);
                    return true;
                }
            }
            return false;
        }
    }
}
