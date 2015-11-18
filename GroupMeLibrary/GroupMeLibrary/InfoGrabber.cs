using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Http;

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
        /// <returns></returns>
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
        /// Grabs the groups you have left but can rejoin.
        /// </summary>
        /// <returns></returns>
        public GroupResponse GetFormerGroups()
        {
            string urlToCheck = string.Format(Statics.BaseURL + "/groups/former" + _apiKey);

            GroupResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<GroupResponse>(webClient.DownloadString(string.Format(urlToCheck)));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to pull groups. Reason: {0}", ex.Message));
            }

            return response;
        }

        /// <summary>
        /// Grabs a particular group
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new group
        /// </summary>
        /// <returns></returns>
        public void CreateGroup(string name, string description="", string imageURL="", bool share=false)
        {
            //Thanks to http://stackoverflow.com/questions/25306570/convert-curl-to-c-sharp

            string urlToCall = string.Format(Statics.BaseURL + "/groups" +_apiKey);

            JsonGroupSerializer grpToCreate = new JsonGroupSerializer(name);
            string jsonString = JsonConvert.SerializeObject(grpToCreate);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToCall);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }

            WebResponse response = request.GetResponse();
            string text;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Pulls the last 20 messages from a group chat
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
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
