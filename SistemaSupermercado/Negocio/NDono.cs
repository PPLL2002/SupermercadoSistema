using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NDono
    {
        private Dono dono = new Dono();
        public void Update(Dono d)
        {
            PDono pD = new PDono();
            dono = d;
            pD.Save(dono);
        }

        public Dono Listar()
        {
            PDono pD = new PDono();
            dono = pD.Open();
            return dono;
        }
    }
}
