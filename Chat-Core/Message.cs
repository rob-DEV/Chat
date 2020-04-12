using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Core
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public string UniqueID { get; set; }

        public Message(string sender, string content)
        {
            Sender = sender;
            Content = content;
        }

        public Message(string sender, string content, string uniqueID)
        {
            Sender = sender;
            Content = content;
            UniqueID = uniqueID;
        }
    }
}
