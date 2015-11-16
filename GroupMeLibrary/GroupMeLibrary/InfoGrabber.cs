using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

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
            string urlToCall = string.Format(Statics.BaseURL + "/groups" +_apiKey);

            JsonGroupSerializer grpToCreate = new JsonGroupSerializer(name);

            string jsonConversion;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToCall);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            MemoryStream ms = new MemoryStream();
            string json = JsonConvert.SerializeObject(grpToCreate);
            byte[] jsonbytes = GetBytes(json);
            ms.Read(jsonbytes, 0, jsonbytes.Length);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();

            /*try
            {
                
                jsonConversion = JsonConvert.SerializeObject(grpToCreate);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonConversion);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.ContentLength = bytes.Length;
                
                Stream dataStream = request.GetRequestStream();

                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                response.Close();
                //response = JsonConvert.DeserializeObject<GroupResponse>(webClient.DownloadString(string.Format(urlToCheck)));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}", ex.Message));
            }
            */
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
