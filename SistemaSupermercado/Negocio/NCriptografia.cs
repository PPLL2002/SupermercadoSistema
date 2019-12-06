using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace Negocio
{
    public class NCriptografia
    {
        public string Criptografar(string entrada)
        {
            string resultadotxt = "";

            for (int i = 0; i < entrada.Length; i++){
                resultadotxt += (char)( ( (int)entrada[i]) +3);
            }
            return resultadotxt;
        }
    }
}
