using MehsCoreCommon.Security.Core;
using MehsCoreCommon.Serialization;
using Newtonsoft.Json;

namespace MehsCoreCommon.Security.Models
{
    public class ModGenerateRqstToken : AJsonString
    {
        private string key;
        private string userName;
        private string phaserKey;
        private string idApp;
        private string ip;
        private string userAgent;
        private long ticks;

        public long Ticks
        {
            get { return ticks; }
            set { ticks = value; }
        }

        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public string IdApp
        {
            get { return idApp; }
            set { idApp = value; }
        }

        public string PhaserKey
        {
            get { return phaserKey; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = Crypt(value); }
        }


        public ModGenerateRqstToken()
        {

        }

        public ModGenerateRqstToken(string phaserKey) : this()
        {
            key = phaserKey;
            this.phaserKey = Crypt(phaserKey);
        }

        private string Crypt(string value)
        {
            return ProcessTripleDES.Encrypt(value, key, ProcessHexaDecimal.GenerateHexadecimal(key, true));
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
