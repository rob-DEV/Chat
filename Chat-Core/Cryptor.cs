using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Core
{
    public class Cryptor
    {


        public static string Encrypt(string data, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = rsa.Encrypt(Encoding.ASCII.GetBytes(data), false);
            string result = Convert.ToBase64String(encryptedData);
            return result;
        }

        public static string Decrypt(string data, KeyPair publicPrivateKeyPair)
        {

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicPrivateKeyPair.PrivateKey);
            byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(data), false);

            string result = Encoding.Default.GetString(decryptedData);
            return result;
        }

        public static string GenerateRandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}
