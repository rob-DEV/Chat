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
        private Dictionary<string, string> m_Data;


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

        public void Add(KeyValuePair<string, string> element)
        {
            m_Data[element.Key] = element.Value;
        }


        public string Serialize()
        {
            m_Data["REQUEST_TYPE"] = m_Type;

            return JsonConvert.SerializeObject(m_Data);

        }

    }
}
