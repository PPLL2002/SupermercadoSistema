using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace Negocio
{
    public class Criptografia
    {
        public string Criptografar(string entrada)
        {
            string resultadotxt = "";
            byte[] mensagemtxt = System.Text.Encoding.Default.GetBytes(entrada);
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] hashcode = x.ComputeHash(mensagemtxt);

            for (int i = 0; i < hashcode.Length; i++){
                resultadotxt += (char)(hashcode[i]);
            }
            return resultadotxt;
        }
    }
}
