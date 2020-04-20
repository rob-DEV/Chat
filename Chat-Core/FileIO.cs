using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Chat_Core
{
    public static class FileIO
    {

        public static void Save(Client client)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlDeclarationNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclarationNode);

            XmlNode xmlClientNode = xmlDocument.CreateElement("ClientDetails");
            xmlDocument.AppendChild(xmlClientNode);

            XmlNode xmlUniqueIDNode = xmlDocument.CreateElement("UniqueID");
            xmlUniqueIDNode.AppendChild(xmlDocument.CreateTextNode(client.UniqueID));
            xmlClientNode.AppendChild(xmlUniqueIDNode);

            XmlNode xmlShortIDNode = xmlDocument.CreateElement("ShortID");
            xmlShortIDNode.AppendChild(xmlDocument.CreateTextNode(client.ShortID));
            xmlClientNode.AppendChild(xmlShortIDNode);

            XmlNode xmlToken = xmlDocument.CreateElement("Token");
            xmlToken.AppendChild(xmlDocument.CreateTextNode(client.Token));
            xmlClientNode.AppendChild(xmlToken);

            xmlDocument.Save("Client.xml");

        }

        public static void Save(Chat chat)
        {

        }

        public static string SerializeToXML<T>(T obj)
        {
            if(obj == null)
            {
                return "";
            }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(writer, obj);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static T DeserializeFromXML<T>(string xmlData)
        {
            if(xmlData.Length < 10)
            {

                return default(T);

            }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var stringReader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(xmlData)));

                T obj = (T)xmlSerializer.Deserialize(stringReader);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

    }
}
