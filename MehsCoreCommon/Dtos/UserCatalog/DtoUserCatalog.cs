using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.UserCatalog
{
    public class DtoUserCatalog : AJsonString
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }

        public DtoUserCatalog()
        {
            CreateDate = DateTime.Now;
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
