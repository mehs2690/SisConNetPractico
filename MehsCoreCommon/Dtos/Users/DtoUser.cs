using MehsCoreCommon.Data.Core.Enums;
using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Users
{
    public class DtoUser : AJsonString
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Estatus { get; set; }
        public DateTime SignUpDate { get; set; }

        public DtoUser()
        {
            Id = Guid.NewGuid();
            SignUpDate = DateTime.Now;
            Estatus = EnmEstatusEntity.A.ToString();
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
