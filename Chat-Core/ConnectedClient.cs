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
}
