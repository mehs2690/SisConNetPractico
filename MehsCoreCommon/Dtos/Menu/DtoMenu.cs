using MehsCoreCommon.Serialization;
using Newtonsoft.Json;

namespace MehsCoreCommon.Dtos.Menu
{
    public class DtoMenu : AJsonString
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Icon { get; set; }
        public string StyleClass { get; set; }
        public string EventOn { get; set; }
        public string Estatus { get; set; }
        public string OptionType { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public int? ParentId { get; set; }
        public int? UserTypeRefId { get; set; }

        public DtoMenu()
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
