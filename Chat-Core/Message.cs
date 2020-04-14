using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [JsonConstructor]
        public Message(string uid, string sender, string content)
        {
            this.UniqueID = uid;
            this.Sender = sender;
            this.Content = content;
        }

        public Message(string sender, string content)
        {
            Sender = sender;
            Content = content;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.UniqueID == ((Message)(obj)).UniqueID;

        }

    }
}
