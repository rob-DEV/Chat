using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Chat_Core
{
    public class Message
    {
        [JsonProperty("unique_id")]
        public string UniqueID { get; set; }
        [JsonProperty("message_sender")]
        public string Sender { get; set; }
        [JsonProperty("message_content")]
        public string Content { get; set; }
        [JsonProperty("message_timestamp")]
        public int TimeStamp { get; set; }

        public Message()
        {
            this.UniqueID = string.Empty;
            this.Sender = string.Empty;
            this.Content = string.Empty;
            this.TimeStamp = 0;
        }

        [JsonConstructor]
        public Message(string uid, string sender, string content, int timestamp)
        {
            this.UniqueID = uid;
            this.Sender = sender;
            this.Content = content;
            this.TimeStamp = timestamp;
        }

        public Message(string sender, string content)
        {
            UniqueID = Cryptor.GenerateRandomString(16, true);
            Sender = sender;
            Content = content;
        }

        public Message(Message message)
        {
            Sender = message.Sender;
            Content = message.Content;
        }

        public static string ToXML(Message message)
        {
            string xml = FileIO.SerializeToXML<Message>(message);
            return xml;
        }

        public static Message FromXML(string messageXML)
        {
            return FileIO.DeserializeFromXML<Message>(messageXML);
        }

    }
}
