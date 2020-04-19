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
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlDeclarationNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclarationNode);

            XmlNode xmlClientNode = xmlDocument.CreateElement("MessageDetails");
            xmlDocument.AppendChild(xmlClientNode);

            XmlNode xmlUniqueIDNode = xmlDocument.CreateElement("UniqueID");
            xmlUniqueIDNode.AppendChild(xmlDocument.CreateTextNode(message.UniqueID));
            xmlClientNode.AppendChild(xmlUniqueIDNode);

            XmlNode xmlSenderNode = xmlDocument.CreateElement("Sender");
            xmlSenderNode.AppendChild(xmlDocument.CreateTextNode(message.Sender));
            xmlClientNode.AppendChild(xmlSenderNode);

            XmlNode xmlContentNode = xmlDocument.CreateElement("Content");
            xmlContentNode.AppendChild(xmlDocument.CreateTextNode(message.Content));
            xmlClientNode.AppendChild(xmlContentNode);

            XmlNode xmlTimestampNode = xmlDocument.CreateElement("Timestamp");
            xmlTimestampNode.AppendChild(xmlDocument.CreateTextNode(message.TimeStamp.ToString()));
            xmlClientNode.AppendChild(xmlTimestampNode);

            string xml = xmlDocument.OuterXml;
            return xml;
        }

        public static Message FromXML(string messageXML)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(messageXML);

            string uniqueID = xmlDocument.GetElementsByTagName("UniqueID")[0].InnerXml;
            string sender = xmlDocument.GetElementsByTagName("Sender")[0].InnerXml;
            string content = xmlDocument.GetElementsByTagName("Content")[0].InnerXml;
            int timestamp = Convert.ToInt32(xmlDocument.GetElementsByTagName("Timestamp")[0].InnerXml);

            return new Message(uniqueID, sender, content, timestamp);
        }

    }
}
