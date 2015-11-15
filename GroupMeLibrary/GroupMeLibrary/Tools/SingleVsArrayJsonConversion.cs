using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    class SingleVsArrayJsonConversion<T> : JsonConverter
    {
        //Thanks to http://stackoverflow.com/questions/18994685/how-to-handle-both-a-single-item-and-an-array-for-the-same-property-using-json-n
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            //if the object happens to be an array
            if (token.Type == JTokenType.Array)
            {
                //return as a list of stuff!
                return token.ToObject<List<T>>();
            }
            //otherwise just return a single object as a list
            return new List<T>
            {
                token.ToObject<T>()
            };
        }

        public override bool CanWrite
        {
            get
            {//can't write
                return false;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //no need to write...yet?
            throw new NotImplementedException();
        }
    }
}
