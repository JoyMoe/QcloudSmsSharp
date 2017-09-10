using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QcloudSmsSharp
{
    public class QcloudSmsMessage
    {
        public string Tel { get; set; }

        public int Type { get; set; } = 0;

        public string Msg { get; set; }

        public string Sig { get; set; }

        public long Time { get; set; }

        public string Extend { get; set; } = "";

        public string Ext { get; set; } = "";

        public override string ToString()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
