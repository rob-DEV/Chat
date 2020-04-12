using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Chat_Core
{
    public class JsonPacket
    {
        private string m_Type;
        public Dictionary<string, string> Data { get; private set; }

        public JsonPacket(string type)
        {
            m_Type = type;
            Data = new Dictionary<string, string>();
        }

        public JsonPacket(string type, Dictionary<string, string> data)
        {
            m_Type = type;
            Data = data;
        }

        public JsonPacket(Dictionary<string, string> data)
        {
            if(data.ContainsKey("TYPE"))
                m_Type = data["TYPE"];

            Data = data;
        }

        public void Add(string key, string value)
        {
            Data[key] = value;
        }

        public string Serialize()
        {
            if (!Data.ContainsKey("TYPE"))
                Data["TYPE"] = m_Type;

            return JsonConvert.SerializeObject(Data);

        }

        public static JsonPacket Deserialize(string json)
        {
            return new JsonPacket(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));

        }

    }
}
