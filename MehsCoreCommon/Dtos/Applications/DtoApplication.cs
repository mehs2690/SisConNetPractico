using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Applications
{
    public class DtoApplication : AJsonString
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activate { get; set; }
        public string Estatus { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }

        public DtoApplication()
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
