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

        private Client()
        {
            CryptographicKeyPair = new KeyPair();
            
            JsonPacket packet = new JsonPacket(Constants.REQUEST_GET_CLIENT_IDENTIFIER);
            packet.Add("CLIENT_PUBLIC_KEY", CryptographicKeyPair.PublicKey);
            
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CLIENT_UNIQUE_ID"];
            ShortID = response.Data["CLIENT_SHORT_ID"];
            Token = response.Data["CLIENT_TOKEN"];


        }

        public void SendMessage(Message message, Chat chat)
        {
            
            //convert message to XML
            string messageXml = Message.ToXML(message);
            List<ConnectedClientEncryptedMessage> clientEncryptedMessages = new List<ConnectedClientEncryptedMessage>();



            foreach(ConnectedClient client in chat.GetConnectedClients())
            {
                string key = "";
                string IV = "";

                string clientEncryptedMessage = Cryptor.AesEncrypt(messageXml, ref key, ref IV);
                string encryptedKey = Cryptor.RsaEncrypt(key, client.PublicKey);
                string encryptedIV = Cryptor.RsaEncrypt(IV, client.PublicKey);


                clientEncryptedMessages.Add(new ConnectedClientEncryptedMessage(client.UniqueID, chat.UniqueID, encryptedKey, encryptedIV, clientEncryptedMessage));

            }




            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_SEND_CHAT_MESSAGE);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", chat.UniqueID);

            //attach client encryptedMessages
            packet.Add("CHAT_CLIENT_MESSAGES", JsonConvert.SerializeObject(clientEncryptedMessages));


            JsonPacket response = Request.Send(packet);
            //check response for errors
        }

        public static Client Get()
        {
            if(s_Instance == null)
                s_Instance = new Client();

            return s_Instance;
        }

    }
}
