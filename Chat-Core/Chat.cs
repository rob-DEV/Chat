using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Chat_Core
{

    public class Chat
    {
        public List<Message> Messages;

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

            Messages = new List<Message>();
        }

        private Chat(string chatShortID, string password)
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_JOIN_CHAT);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_SHORT_ID", chatShortID);
            packet.Add("CHAT_PASSWORD", Client.Get().Token);

            JsonPacket response = Request.Send(packet);
            UniqueID = response.Data["CHAT_UNIQUE_ID"];
            ShortID = response.Data["CHAT_SHORT_ID"];

            Messages = new List<Message>();
        }

        public void SendMessage(Message message)
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CLIENT_SEND_CHAT_MESSAGE);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", this.UniqueID);
            packet.Add("MESSAGE_SENDER", message.Sender);
            packet.Add("MESSAGE_CONTENT", message.Content);

            JsonPacket response = Request.Send(packet);
            //check response for errors
        }

        public void CheckForMessages()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_CHAT_CHECK_MESSAGE);
            packet.Add("CLIENT_UNIQUE_ID", Client.Get().UniqueID);
            packet.Add("CLIENT_TOKEN", Client.Get().Token);
            packet.Add("CHAT_UNIQUE_ID", this.UniqueID);

            JsonPacket response = Request.Send(packet);

            string messagesJSON = response.Data["MESSAGES"];

            List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(messagesJSON);

            foreach(Message message in messages)
            {
                if(!Messages.Any(k => k.UniqueID == message.UniqueID))
                    Messages.Add(message);
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
