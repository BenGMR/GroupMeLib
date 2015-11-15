using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [JsonObject]
    public class MessageResponse
    {
        [JsonProperty("response")]
        [JsonConverter(typeof(SingleVsArrayJsonConversion<MessageCollection>))]
        private List<MessageCollection> _messages;
        public List<MessageCollection> Messages
        {
            get
            {
                return _messages;
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
