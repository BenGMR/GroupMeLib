using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    [JsonObject]
    class JsonGroupSerializer
    {
        public JsonGroupSerializer(string Name, string Description = "", string ImageURL="", bool OfficeMode=false, bool Share = false)
        {
            name = Name;
            description = Description;
            share = Share;
            imageURL = ImageURL;
            officeMode = OfficeMode;
        }
        [JsonProperty(PropertyName ="name")]
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        [JsonProperty(PropertyName = "description")]
        string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        [JsonProperty(PropertyName = "image_url")]
        string imageURL;
        public string ImageURL
        {
            get
            {
                return imageURL;
            }
            set
            {
                imageURL = value;
            }
        }
        [JsonProperty(PropertyName = "office_mode")]
        bool officeMode;
        public bool OfficeMode
        {
            get
            {
                return officeMode;
            }
            set
            {
                officeMode = value;
            }
        }
        [JsonProperty(PropertyName = "share")]
        bool share;
        public bool Share
        {
            get
            {
                return share;
            }
            set
            {
                share = value;
            }
        }
    }
}
