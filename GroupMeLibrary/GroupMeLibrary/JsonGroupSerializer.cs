using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [JsonObject]
    class JsonGroupSerializer
    {
        public JsonGroupSerializer(string Name, string Description = "", string ImageURL="", bool OfficeMode=false, bool Share = false)
        {
            name = Name;
            description = Description;
            share = Share;
        }
        [JsonProperty(PropertyName ="name")]
        string name;
        [JsonProperty(PropertyName = "description")]
        string description;
        [JsonProperty(PropertyName = "share")]
        bool share;
    }
}
