using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Persistencia
{
    public class PVenda
    {
        private string arquivo = "itens_vendas.xml";
        public List<Venda> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(Venda));
            StreamReader f = null;
            List<Venda> l = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                l = x.Deserialize(f) as List<Venda>;
            }
            catch
            {
                l = new List<Venda>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return l;
        } 
        public void Save(List<Venda> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(Venda));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, l);
            f.Close();
        }
    }
}
