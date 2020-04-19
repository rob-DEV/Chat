using Newtonsoft.Json;

namespace Chat_Core
{
    public class ConnectedClient
    {
        [JsonProperty("unique_client_id")]
        public string UniqueID { get; private set; }
        [JsonProperty("public_key")]
        public string PublicKey { get; private set; }

        [JsonConstructor]
        public ConnectedClient(string uid, string publicKey)
        {
            this.UniqueID = uid;
            this.PublicKey = publicKey;
        }

    }

    public class ConnectedClientEncryptedMessage
    {
        [JsonProperty("unique_client_id")]
        public string UniqueClientID { get; set; }
        [JsonProperty("unique_chat_id")]
        public string UniqueChatID { get; set; }
        [JsonProperty("message_content")]
        public string EncryptedMessage { get; set; }

        public ConnectedClientEncryptedMessage(string uniqueClientID, string uniqueChatID, string encryptedMessage)
        {
            this.UniqueClientID = uniqueClientID;
            this.UniqueChatID = uniqueChatID;
            this.EncryptedMessage = encryptedMessage;
        }

    }
}
