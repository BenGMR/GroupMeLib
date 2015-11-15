using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [JsonObject]
    public class Member
    {
        [JsonProperty(PropertyName = "user_id")]
        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }
        }

        [JsonProperty(PropertyName = "nickname")]
        private string _nickName;
        public string NickName
        {
            get
            {
                return _nickName;
            }
        }

        [JsonProperty(PropertyName = "muted")]
        private bool _muted;
        public bool Muted
        {
            get
            {
                return _muted;
            }
        }

        [JsonProperty(PropertyName = "image_url")]
        private string _imageURL;
        public string ImageURL
        {
            get
            {
                return _imageURL;
            }
        }
    }
}
