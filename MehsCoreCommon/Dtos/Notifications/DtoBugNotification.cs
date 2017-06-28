using MehsCoreCommon.Serialization;
using Newtonsoft.Json;
using System;

namespace MehsCoreCommon.Dtos.Notifications
{
    public class DtoBugNotification : AJsonString
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public string Status { get; set; }

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
