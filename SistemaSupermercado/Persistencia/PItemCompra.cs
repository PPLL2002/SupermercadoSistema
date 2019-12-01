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
    public class PItemCompra
    {
        private string arquivo = "itensVendidos.xml";

        public List<ItemCompra> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<ItemCompra>));
            StreamReader f = null;
            List<ItemCompra> p = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                p = x.Deserialize(f) as List<ItemCompra>;
            }
            catch
            {
                p = new List<ItemCompra>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return p;
        }

        public void Save(List<ItemCompra> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<ItemCompra>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, l);
            f.Close();
        }
    }
}
