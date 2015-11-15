using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [DataContract]
    public class BaseResponse
    {
        public BaseResponse()
        {

        }

        [DataMember(Name ="response")]
        private List<Group> _groups;
        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
        }
    }
}
