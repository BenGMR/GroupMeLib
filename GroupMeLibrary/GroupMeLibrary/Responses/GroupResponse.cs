using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GroupMeLibrary
{
    [JsonObject]
    public class GroupResponse
    {
        [JsonProperty("response")]
        [JsonConverter(typeof(SingleVsArrayJsonConversion<Group>))]
        private List<Group> _groups;
        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
        }

        [JsonProperty("meta")]
        private Meta _meta;

        public Meta MetaData
        {
            get { return _meta; }
        }

    }
}
