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
    public class PCompra
    {
        private string arquivo = "compras.xml";

        public List<Compra> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Compra>));
            StreamReader f = null;
            List<Compra> p = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                p = x.Deserialize(f) as List<Compra>;
            }
            catch
            {
                p = new List<Compra>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return p;
        }

        public void Save(List<Compra> l)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Compra>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, l);
            f.Close();
        }
    }
}
