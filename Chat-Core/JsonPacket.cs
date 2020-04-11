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
        public Dictionary<string, string> m_Data { get; private set; }

        public JsonPacket(string type)
        {
            m_Type = type;
            m_Data = new Dictionary<string, string>();
        }

        public JsonPacket(string type, Dictionary<string, string> data)
        {
            m_Type = type;
            m_Data = data;
        }

        public JsonPacket(Dictionary<string, string> data)
        {
            if(data.ContainsKey("TYPE"))
                m_Type = data["TYPE"];

            m_Data = data;
        }

        public void Add(KeyValuePair<string, string> element)
        {
            m_Data[element.Key] = element.Value;
        }


        public string Serialize()
        {
            if (!m_Data.ContainsKey("TYPE"))
                m_Data["TYPE"] = m_Type;

            return JsonConvert.SerializeObject(m_Data);

        }

        public static JsonPacket Deserialize(string json)
        {
            return new JsonPacket(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));

        }

    }
}
