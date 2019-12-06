using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class PItemVenda
    {
        private string arquivo = "itens_vendas.xml";
        public List<ItemVenda> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<ItemVenda>));
            StreamReader f = null;
            List<ItemVenda> l = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                l = x.Deserialize(f) as List<ItemVenda>;
            }
            catch
            {
                l = new List<ItemVenda>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return l;
        }
        public void Save(List<ItemVenda> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<ItemVenda>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, l);
            f.Close();
        }
    }
}
