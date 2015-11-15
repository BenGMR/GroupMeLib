using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    public class Statics
    {
        static string _apiKey;
        public static string APIKey
        {
            get
            {
                return _apiKey;
            }
            set
            {
                _apiKey = "?token=" + value;
            }
        }
        public static string BaseURL = "https://api.groupme.com/v3";
    }
}
