using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Chat_Core
{
    public class Client
    {

        public string UniqueID { get; private set; }
        public string ShortID { get; private set; }
        public string Token { get; private set; }

        private Client()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_GET_CLIENT_IDENTIFIER);
            JsonPacket response = Request.Send(packet);

            UniqueID = response.Data["CLIENT_UNIQUE_ID"];
            ShortID = response.Data["CLIENT_SHORT_ID"];
            Token = response.Data["CLIENT_TOKEN"];

        }

        public void Save()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlDeclarationNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclarationNode);

            XmlNode xmlClientNode = xmlDocument.CreateElement("ClientDetails");
            xmlDocument.AppendChild(xmlClientNode);

            XmlNode xmlUniqueIDNode = xmlDocument.CreateElement("UniqueID");
            xmlUniqueIDNode.AppendChild(xmlDocument.CreateTextNode(this.UniqueID));
            xmlClientNode.AppendChild(xmlUniqueIDNode);

            XmlNode xmlShortIDNode = xmlDocument.CreateElement("ShortID");
            xmlShortIDNode.AppendChild(xmlDocument.CreateTextNode(this.ShortID));
            xmlClientNode.AppendChild(xmlShortIDNode);

            XmlNode xmlToken = xmlDocument.CreateElement("Token");
            xmlToken.AppendChild(xmlDocument.CreateTextNode(this.Token));
            xmlClientNode.AppendChild(xmlToken);



            xmlDocument.Save("Client.xml");

        }

        public static Client Create()
        {
            return new Client();
        }

    }
}
