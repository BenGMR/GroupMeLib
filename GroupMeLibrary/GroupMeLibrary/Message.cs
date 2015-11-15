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
    public class Message
    {
        [JsonProperty(PropertyName ="id")]
        private long _messageId;

        public long MessageID
        {
            get { return _messageId; }
        }

        [JsonProperty(PropertyName = "source_guid")]
        private string _sourceGUID;

        public string SourceGUID
        {
            get { return _sourceGUID; }
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

        [JsonProperty(PropertyName = "user_id")]
        private long _userID;

        public long UserID
        {
            get { return _userID; }
        }

        [JsonProperty(PropertyName = "group_id")]
        private long _groupdID;

        public long GroupID
        {
            get { return _groupdID; }
        }

        [JsonProperty(PropertyName = "name")]
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        [JsonProperty(PropertyName = "avatar_url")]
        private string _avatarURL;

        public string AvatarURL
        {
            get { return _avatarURL; }
        }

        [JsonProperty(PropertyName = "text")]
        private string _text;

        public string Text
        {
            get { return _text; }
        }

        [JsonProperty(PropertyName = "system")]
        private bool _system;

        public bool System
        {
            get { return _system; }
        }

        [JsonProperty(PropertyName = "favorited_by")]
        private long[] _favoritedBy;

        public long[] FavoritedBy
        {
            get { return _favoritedBy; }
        }

        [JsonProperty(PropertyName = "attachments")]
        private Attachment[] _attachments;

        public Attachment[] Attachments
        {
            get { return _attachments; }
        }
    }
}
