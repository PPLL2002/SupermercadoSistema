using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Modelo;

namespace Persistencia
{
    public class PFuncionario
    {
        private string arquivo = "funcionarios.xml";

        public List<Funcionario> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Funcionario>), new Type[] { typeof(Gerente), typeof(OperadorDeCaixa) });
            StreamReader f = null;
            List<Funcionario> l = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                l = x.Deserialize(f) as List<Funcionario>;
            }
            catch
            {
                l = new List<Funcionario>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return l;
        }

        public void Save(List<Funcionario> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Funcionario>), new Type[] { typeof(Gerente), typeof(OperadorDeCaixa) });
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);

            x.Serialize(f, l);
            f.Close();
        }
    }
}