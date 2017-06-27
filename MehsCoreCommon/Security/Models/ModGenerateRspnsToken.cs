using MehsCoreCommon.Serialization;
using Newtonsoft.Json;

namespace MehsCoreCommon.Security.Models
{
    public class ModGenerateRspnsToken : AJsonString
    {
        public string Token { get; set; }
        public string Message { get; set; }

        public ModGenerateRspnsToken()
        {

        }

        protected override string SerializeJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override string ToString()
        {
            return SerializeJsonString();
        }
    }
}
