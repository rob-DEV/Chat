using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Chat_Core
{
    public class Cryptor
    {

        /// <summary>
        /// Encrypts plaintext data with a given public key
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicKey"></param>
        /// <returns>Public key encrypted base 64 data</returns>
        public static string RsaEncrypt(string plainText, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = rsa.Encrypt(Encoding.ASCII.GetBytes(plainText), false);

            string result = Convert.ToBase64String(encryptedData);
            return result;
        }

        /// <summary>
        /// Decrypts encrypted base 64 data to plaintext with a given private key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicPrivateKeyPair"></param>
        /// <returns>Private key decrpyted plain text data</returns>
        public static string RsaDecrypt(string base64Data, string privateKey)
        {

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(base64Data), false);

            string result = Encoding.Default.GetString(decryptedData);
            return result;
        }

        /// <summary>
        /// Encrypts plaintext with a given Key and IV.
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="base64Key"></param>
        /// <param name="base64IV"></param>
        /// <returns>AES encrypted base 64 data</returns>
        public static string AesEncrypt(string plainText, ref string base64Key, ref string base64IV)
        {

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                base64Key = Convert.ToBase64String(aesAlg.Key);
                base64IV = Convert.ToBase64String(aesAlg.IV);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
   
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {                     
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
    
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decrypts AES encrypted, base 64 encoded data with a given Key and IV./
        /// </summary>
        /// <param name="cipherBase64"></param>
        /// <param name="base64Key"></param>
        /// <param name="base64IV"></param>
        /// <returns>AES decrypted plaintext data</returns>
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

        /// <summary>
        /// Generates a pseudo random string of a particular length.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char character;
            for (int i = 0; i < size; i++)
            {
                character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(character);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}
