using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Core
{
    class ConnectedClientEncryptedMessage
    {
        [JsonProperty("unique_client_id")]
        public string UniqueClientID { get; set; }
        [JsonProperty("unique_chat_id")]
        public string UniqueChatID { get; set; }
        [JsonProperty("crypt_aes_key")]
        public string EncryptedAESKey { get; set; }
        [JsonProperty("crypt_aes_iv")]
        public string EncryptedAESIV { get; set; }
        [JsonProperty("message_content")]
        public string EncryptedMessage { get; set; }

        public ConnectedClientEncryptedMessage(string uniqueClientID, string uniqueChatID, string encryptedAESKey, string encryptedAESIV, string encryptedMessage)
        {
            this.UniqueClientID = uniqueClientID;
            this.UniqueChatID = uniqueChatID;
            this.EncryptedAESKey = encryptedAESKey;
            this.EncryptedAESIV = encryptedAESIV;
            this.EncryptedMessage = encryptedMessage;
        }
    }
}
