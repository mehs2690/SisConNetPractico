using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Bugs
{
    public class DtoBug : AJsonString
    {
        public Guid Id { get; set; }
        public Guid? AppId { get; set; }
        public Guid? UserRegId { get; set; }
        public Guid? UserSolId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime BugRegistredDate { get; set; }
        public DateTime? BugClosedDate { get; set; }

        public DtoBug()
        {
            Id = Guid.NewGuid();
            BugRegistredDate = DateTime.Now;
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
