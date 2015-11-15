using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GroupMeLibrary
{
    [JsonObject]
    public class Group
    {
        [JsonProperty(PropertyName = "id")]
        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }
        }

        [JsonProperty(PropertyName = "name")]
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        [JsonProperty(PropertyName = "type")]
        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
        }

        [JsonProperty(PropertyName = "description")]
        private string _description;
        public string Description
        {
            get
            {
                return _description;
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

        [JsonProperty(PropertyName = "creator_user_id")]
        private long _creatorID;
        public long CreatorID
        {
            get
            {
                return _creatorID;
            }
        }
        
        [JsonProperty(PropertyName = "created_at")]
        private long _createdAt;
        public DateTime CreatedAt
        {
            get
            {
                return InfoGrabber.UnixToDateTime(_createdAt);
            }
        }

        [JsonProperty(PropertyName = "updated_at")]
        private long _updatedAt;
        public DateTime UpdatedAt
        {
            get
            {
                return InfoGrabber.UnixToDateTime(_updatedAt);
            }
        }
        
        [JsonProperty(PropertyName = "members")]
        private Member[] _members;
        public Member[] Members
        {
            get
            {
                return _members;
            }
        }

        [JsonProperty(PropertyName = "share_url")]
        private string _shareURL;
        public string ShareURL
        {
            get
            {
                return _shareURL;
            }
        }

        [JsonProperty(PropertyName = "messages")]
        private MessageCollection _messages;
        public MessageCollection Messages
        {
            get
            {
                return _messages;
            }
        }
    }
}
