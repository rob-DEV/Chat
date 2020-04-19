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

        private Chat()
        {
            Password = "ABCD";

            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_CREATE_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_PASSWORD", Password);

            JsonPacket response = Request.Send(packet);
            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];

            Messages = new List<Message>();
        }

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
                    Message msg = Message.FromXML(Cryptor.Decrypt(message.EncryptedMessage, Client.Get().CryptographicKeyPair));
                    if (!Messages.Any(k => k.UniqueID == msg.UniqueID))
                        Messages.Add(msg);
                }
            }
        }

        public static Chat Create()
        {
            return new Chat();
        }

        public static Chat Join(string chatShortID, string chatPassword)
        {
            return new Chat(chatShortID, chatPassword);
        }
    }
}
