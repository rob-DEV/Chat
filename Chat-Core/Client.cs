using System;
using System.Collections.Generic;
using System.Text;

namespace Chat_Core
{
    public class Client
    {
        private string m_ID;
        private string m_Username;
        private string m_Token;

        private Client()
        {
            JsonPacket packet = new JsonPacket(Constants.REQUEST_GET_CLIENT_IDENTIFIER);

            JsonPacket response = Request.Send(packet);

        }

        public static Client Create()
        {
            return new Client();
        }

    }
}
