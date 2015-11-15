using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

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

        public static DateTime UnixToDateTime(long epoch)
        {
            DateTime t = new DateTime(1970, 1, 1, 0, 0, 0);
            return t.AddSeconds(epoch);
        }

        /// <summary>
        /// Grabs all groups a person is involved with
        /// </summary>
        /// <returns>An array of groups</returns>
        public GroupResponse GetGroups()
        {
            string urlToCheck = string.Format(Statics.BaseURL + "/groups" + _apiKey);

            GroupResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<GroupResponse>(webClient.DownloadString(string.Format(urlToCheck)));
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Failed to pull groups. Reason: {0}", ex.Message));
            }

            return response;
        }

        /// <summary>
        /// Grabs a particular group
        /// </summary>
        /// <returns>A Groups</returns>
        public GroupResponse GetGroupByID(int groupID)
        {
            string urlToCheck = string.Format(Statics.BaseURL + "/groups/"+ groupID + _apiKey);

            GroupResponse response;
            
            try
            {
                response = JsonConvert.DeserializeObject<GroupResponse>(webClient.DownloadString(string.Format(urlToCheck)));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to pull group. Reason: {0}", ex.Message));
            }

            return response;
        }

        public MessageResponse GetGroupMessages(int groupID)
        {
            string urlToCheck = string.Format(Statics.BaseURL + "/groups/" + groupID + "/messages"+ _apiKey);

            MessageResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<MessageResponse>(webClient.DownloadString(string.Format(urlToCheck)));
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Failed get messages. Reason: {0}", ex.Message));
            }
            return response;
        }
    }
}
