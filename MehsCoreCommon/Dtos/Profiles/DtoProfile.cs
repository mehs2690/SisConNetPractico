using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Profiles
{
    public class DtoProfile : AJsonString
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Estatus { get; set; }
        public int Range { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? ApplicationRefId { get; set; }

        public DtoProfile()
        {
            Id = Guid.NewGuid();
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
