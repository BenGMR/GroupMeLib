using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [DataContract]
    public class Member
    {
        [DataMember(Name = "user_id")]
        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }
        }

        [DataMember(Name = "nickname")]
        private string _nickName;
        public string NickName
        {
            get
            {
                return _nickName;
            }
        }

        [DataMember(Name = "muted")]
        private bool _muted;
        public bool Muted
        {
            get
            {
                return _muted;
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
    }
}
