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
    public class PProduto
    {
        private string arquivo = "produtos.xml";

        public List<Produto> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Produto>));
            StreamReader f = null;
            List<Produto> p = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                p = x.Deserialize(f) as List<Produto>;
            }
            catch
            {
                p = new List<Produto>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return p;
        }

        public void Save(List<Produto> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Produto>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, l);
            f.Close();
        }
    }
}