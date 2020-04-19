using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

    }
}
