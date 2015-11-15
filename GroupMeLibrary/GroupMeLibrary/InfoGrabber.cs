using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GroupMeLibrary
{
    public class InfoGrabber
    {
        WebClient webClient;

        private string _apiKey;

        DataContractJsonSerializer jSerializer;

        public InfoGrabber(string APIKey)
        {
            _apiKey = "?token=" + APIKey;
            webClient = new WebClient();
        }
        
        /// <summary>
        /// Grabs all groups a person is involved with
        /// </summary>
        /// <returns>An array of groups</returns>
        public Group[] GetGroups()
        {
            jSerializer = new DataContractJsonSerializer(typeof(BaseResponse));
            

            string urlToCheck = string.Format(Statics.BaseURL + "/groups" + _apiKey);

            BaseResponse blah;
            try
            {
                blah = (BaseResponse)jSerializer.ReadObject(webClient.OpenRead(string.Format(urlToCheck)));
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Failed to pull groups. Reason: {0}", ex.Message));
            }

            return blah.Groups.ToArray();
        }

        /// <summary>
        /// Grabs a particular group
        /// </summary>
        /// <returns>A Groups</returns>
        public Group GetGroupByID(int ID)
        {
            jSerializer = new DataContractJsonSerializer(typeof(BaseResponse));
            
            string urlToCheck = string.Format(Statics.BaseURL + "/groups/"+ ID + _apiKey);

            BaseResponse blah;

            //this works when baseresponse has a single group object
            try
            {
                blah = (BaseResponse)jSerializer.ReadObject(webClient.OpenRead(string.Format(urlToCheck)));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to pull groups. Reason: {0}", ex.Message));
            }

            return blah.Groups[0];
        }
    }
}
