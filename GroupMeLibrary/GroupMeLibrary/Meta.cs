using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [JsonObject]
    public class Meta
    {
        public Meta()
        {
            _code = 0;
            _errors = null;
        }
        [JsonProperty(PropertyName ="code")]
        private int _code;

        public int Code
        {
            get { return _code; }
        }

        [JsonProperty(PropertyName = "errors")]
        private string[] _errors;

        public string[] Errors
        {
            get { return _errors; }
        }


    }
}
