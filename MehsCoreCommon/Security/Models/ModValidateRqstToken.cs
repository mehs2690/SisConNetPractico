namespace MehsCoreCommon.Security.Models
{
    public class ModValidateRqstToken
    {
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public long Ticks { get; set; }
        public string Token { get; set; }
        public string AppId { get; set; }

        public ModValidateRqstToken()
        {

        }
    }
}
