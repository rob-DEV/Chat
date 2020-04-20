using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace Chat_Core
{
    public class Client
    {

        public string UniqueID { get; private set; }
        public string ShortID { get; private set; }
        public string Token { get; private set; }
        public KeyPair CryptographicKeyPair { get; private set; }

        private static Client s_Instance = null;

        /// <summary>
        /// Constructs an instance of the user Client saving the details on disk
        /// </summary>
        private Client()
        {
            CryptographicKeyPair = new KeyPair();
            
            JsonPacket packet = new JsonPacket(Constants.REQUEST_GET_CLIENT_IDENTIFIER);
            packet.Add("CLIENT_PUBLIC_KEY", CryptographicKeyPair.PublicKey);
            
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CLIENT_UNIQUE_ID"];
            ShortID = response.Data["CLIENT_SHORT_ID"];
            Token = response.Data["CLIENT_TOKEN"];

            FileIO.Save(this);
        }


        /// <summary>
        /// Returns the singleton Client instance, representing the current client running the chat program
        /// </summary>
        /// <returns>Client singleton instance</returns>
        public static Client Get()
        {
            if(s_Instance == null)
                s_Instance = new Client();

            return s_Instance;
        }

    }
}
