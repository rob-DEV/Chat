using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Core
{
    public class Cryptor
    {


        public static string RsaEncrypt(string data, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = rsa.Encrypt(Encoding.ASCII.GetBytes(data), false);
            string result = Convert.ToBase64String(encryptedData);
            return result;
        }

        public static string RsaDecrypt(string data, KeyPair publicPrivateKeyPair)
        {

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(publicPrivateKeyPair.PrivateKey);
            byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(data), false);

            string result = Encoding.Default.GetString(decryptedData);
            return result;
        }

        public static string AesEncrypt(string plainText, ref string base64Key, ref string base64IV)
        {

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                base64Key = Convert.ToBase64String(aesAlg.Key);
                base64IV = Convert.ToBase64String(aesAlg.IV);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);

        }

        public static string AesDecrypt(string cipherBase64, string base64Key, string base64IV)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherBase64);

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(base64Key);
                aesAlg.IV = Convert.FromBase64String(base64IV);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
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
