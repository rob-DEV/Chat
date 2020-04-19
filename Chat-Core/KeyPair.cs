using System.Security.Cryptography;


namespace Chat_Core
{
    public class KeyPair
    {
        private RSACryptoServiceProvider m_RSA;
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public KeyPair()
        {
            m_RSA = new RSACryptoServiceProvider(2048);
            PublicKey = m_RSA.ToXmlString(false);
            PrivateKey = m_RSA.ToXmlString(true);
        }

    }
}
