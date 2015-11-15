using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GroupMeLibrary
{
    [DataContract]
    public class Group
    {
        public Group()
        {

        }
        [DataMember(Name = "id")]
        private long _id;
        /*public long ID
        {
            get
            {
                return _id;
            }
        }*/

        [DataMember(Name = "name")]
        private string _family;
        public string Family
        {
            get
            {
                return _family;
            }
        }

        [DataMember(Name = "type")]
        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
        }

        [DataMember(Name = "description")]
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
        }

        [DataMember(Name = "image_url")]
        private string _imageURL;
        public string ImageURL
        {
            get
            {
                return _imageURL;
            }
        }

        [DataMember(Name = "creator_user_id")]
        private long _creatorID;
        public long CreatorID
        {
            get
            {
                return _creatorID;
            }
        }
        /*
        [DataMember(Name = "created_at")]
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get
            {
                return _createdAt;
            }
        }

        [DataMember(Name = "updated_at")]
        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get
            {
                return _updatedAt;
            }
        }
        */
        [DataMember(Name = "members")]
        private Member[] _members;
        public Member[] Members
        {
            get
            {
                return _members;
            }
        }

        [DataMember(Name = "share_url")]
        private string _shareURL;
        public string ShareURL
        {
            get
            {
                return _shareURL;
            }
        }

        [DataMember(Name = "messages")]
        private Messages _messages;
        public Messages Messages
        {
            get
            {
                return _messages;
            }
        }
    }
}
