using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chat_Core
{

    public class Chat
    {
        public List<Message> Messages;

        public string UniqueID { get; private set; }
        public string ShortID { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Constructs a new chat with a given password
        /// </summary>
        /// <param name="password"></param>
        private Chat(string password)
        {
            Password = password;

            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_CREATE_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_PASSWORD", Password);

            JsonPacket response = Request.Send(packet);
            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];

            Messages = new List<Message>();
        }

        /// <summary>
        /// Constructs a chat which already exists when the client wishes to join a chat
        /// </summary>
        /// <param name="chatShortID"></param>
        /// <param name="password"></param>
        private Chat(string chatShortID, string password)
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_JOIN_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_SHORT_ID", chatShortID);
            packet.Add("CHAT_PASSWORD", password);

            JsonPacket response = Request.Send(packet);
            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];

            Messages = new List<Message>();
        }

        /// <summary>
        /// Sends an encrypted message to each connected client in the chat
        /// with their public key
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Message message)
        {

            //convert message to XML
            string messageXml = Message.ToXML(message);
            List<ConnectedClientEncryptedMessage> clientEncryptedMessages = new List<ConnectedClientEncryptedMessage>();

            foreach (ConnectedClient client in this.GetConnectedClients())
            {
                string key = "";
                string IV = "";

                string clientEncryptedMessage = Cryptor.AesEncrypt(messageXml, ref key, ref IV);
                string encryptedKey = Cryptor.RsaEncrypt(key, client.PublicKey);
                string encryptedIV = Cryptor.RsaEncrypt(IV, client.PublicKey);

                clientEncryptedMessages.Add(new ConnectedClientEncryptedMessage(client.UniqueID, this.UniqueID, encryptedKey, encryptedIV, clientEncryptedMessage));

            }

            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_SEND_CHAT_MESSAGE);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", this.UniqueID);

            //attach client encryptedMessages
            packet.Add("CHAT_CLIENT_MESSAGES", JsonConvert.SerializeObject(clientEncryptedMessages));

            JsonPacket response = Request.Send(packet);
            //TODO: check response for errors
        }

        /// <summary>
        /// Checks the server for client messages sent by other users it then decrypts these messages storing them
        /// in the chat
        /// </summary>
        public void CheckForMessages()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CHAT_CHECK_MESSAGE);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", this.UniqueID);

            JsonPacket response = Request.Send(packet);

            string messagesJSON = response.Data["MESSAGES"];

            List<ConnectedClientEncryptedMessage> messages = JsonConvert.DeserializeObject<List<ConnectedClientEncryptedMessage>>(messagesJSON);

            if (messages.Count > 0)
            {
                foreach (var message in messages)
                {
                    string decryptedKey = Cryptor.RsaDecrypt(message.EncryptedAESKey, Client.Get().CryptographicKeyPair.PrivateKey);
                    string decryptedIV = Cryptor.RsaDecrypt(message.EncryptedAESIV, Client.Get().CryptographicKeyPair.PrivateKey);

                    Message msg = Message.FromXML(Cryptor.AesDecrypt(message.EncryptedMessage, decryptedKey, decryptedIV));
                    if (!Messages.Any(k => k.UniqueID == msg.UniqueID))
                        Messages.Add(msg);
                }
            }
        }

        /// <summary>
        /// Returns a list of Connected Clients in the chat containing their public ID and RSA public key
        /// </summary>
        /// <returns></returns>
        public List<ConnectedClient> GetConnectedClients()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CHAT_GET_CONNECTED_CLIENTS);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", this.UniqueID);

            JsonPacket response = Request.Send(packet);
            string connectedClientJSON = response.Data["CONNECTED_CLIENTS"];

            List<ConnectedClient> connectedClients = JsonConvert.DeserializeObject<List<ConnectedClient>>(connectedClientJSON);

            return connectedClients;
        }

        /// <summary>
        /// Creates a Chat object sending its details to the server and validating the client
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Chat Create(string password)
        {
            return new Chat(password);
        }


        /// <summary>
        /// Joins an existing chat authenticating on the server
        /// </summary>
        /// <param name="chatShortID"></param>
        /// <param name="chatPassword"></param>
        /// <returns></returns>
        public static Chat Join(string chatShortID, string chatPassword)
        {
            return new Chat(chatShortID, chatPassword);
        }

    }
}
