using System;
using System.Collections.Generic;

namespace Chat_Core
{
    public class Chat
    {

        private Client m_Client;

        public string UniqueID { get; private set; }
        public string ShortID { get; private set; }

        private Chat()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_CREATE_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];


        }

        private Chat(string chat, string password)
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_CREATE_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];


        }

        public void SendMessage(Message message)
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_CREATE_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];
        }

        public static Chat Create()
        {
            return new Chat();
        }

        public static Chat Join(string chatID, string chatPassword)
        {
            return new Chat(chatID, chatPassword);
        }
    }
}
