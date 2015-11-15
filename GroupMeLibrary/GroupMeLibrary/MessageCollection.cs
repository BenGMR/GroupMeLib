using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    //todo: turn this into an actual collection
    [JsonObject]
    public class MessageCollection
    {
        [JsonProperty(PropertyName = "count")]
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        [JsonProperty(PropertyName ="messages")]
        private List<Message> _messages;

        public List<Message> Messages
        {
            get { return _messages; }
        }
    }
}
