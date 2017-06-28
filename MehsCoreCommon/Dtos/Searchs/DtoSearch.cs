using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Searchs
{
    public class DtoSearch : AJsonString
    {
        public string Systemm { get; set; }
        public string UserRegistered { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string EntityName { get; set; }

        public DtoSearch()
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
