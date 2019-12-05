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
    public class PDono
    {
        private string arquivo = "dono.xml";
        public Dono Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(Dono));
            StreamReader f = null;
            Dono d = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                d = x.Deserialize(f) as Dono;
            }
            catch
            {
                d = new Dono();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return d;
        }
        public void Save(Dono d)
        {
            XmlSerializer x = new XmlSerializer(typeof(Dono));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, d);
            f.Close();
        }
    }
}