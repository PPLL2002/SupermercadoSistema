using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NFuncionario
    {
        private List<Funcionario> funcionarios = new List<Funcionario>();

        public void Insert(Funcionario f)
        {
            PFuncionario pF = new PFuncionario();
            funcionarios = pF.Open();
            int i = 0;
            foreach (Funcionario x in funcionarios) if (x.IdSupermercado > i) i = x.IdSupermercado;
            f.IdSupermercado = i + 1;
            funcionarios.Add(f);
            pF.Save(funcionarios);
        }

        public void Update(Funcionario f)
        {
            PFuncionario pF = new PFuncionario();
            funcionarios = pF.Open();
            for (int i = 0; i < funcionarios.Count; i++)
                if (funcionarios[i].IdSupermercado == f.IdSupermercado)
                {
                    funcionarios.RemoveAt(i);
                    break;
                }
            funcionarios.Add(f);
            pF.Save(funcionarios);
        }
        public List<Funcionario> Select()
        {
            PFuncionario pF = new PFuncionario();
            funcionarios = pF.Open();
            return pF.Open().OrderBy(c => c.Nome).ToList();
        }
        public void Delete(Funcionario f)
        {
            PFuncionario pF = new PFuncionario();
            funcionarios = pF.Open();
            for (int i = 0; i < funcionarios.Count; i++)
                if (funcionarios[i].IdSupermercado == f.IdSupermercado)
                {
                    funcionarios.RemoveAt(i);
                    break;
                }
            pF.Save(funcionarios);
        }
    }
}
