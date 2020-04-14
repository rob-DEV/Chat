using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Core
{
    public static class Constants
    {
        //CHAT HOST
        public static readonly string HOST = "https://chat.nxslabs.com/";

        ///REQUESTS
        public static readonly string REQUEST_GET_CLIENT_IDENTIFIER = "GET_CLIENT_IDENTIFIER";
        public static readonly string REQUEST_CLIENT_CREATE_CHAT = "CLIENT_CREATE_CHAT";
        public static readonly string REQUEST_CLIENT_JOIN_CHAT = "CLIENT_JOIN_CHAT";
        public static readonly string REQUEST_CLIENT_SEND_CHAT_MESSAGE = "CLIENT_CHAT_SEND_MESSAGE";
        public static readonly string REQUEST_CHAT_CHECK_MESSAGE = "CHAT_CHECK_MESSAGE";


        ///RESPONSES
        public static readonly string RESPONSE_CLIENT_INDENTIFIER = "CLIENT_INDENTIFIER";
        public static readonly string RESPONSE_CLIENT_CHAT = "CLIENT_CHAT";
        public static readonly string RESPONSE_CLIENT_SEND_CHAT_MESSAGE = "CLIENT_CHAT_SENT_MESSAGE";
        public static readonly string RESPONSE_CHAT_CHECK_MESSAGE = "CHAT_MESSAGES";


    }
}
