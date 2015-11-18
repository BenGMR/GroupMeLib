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
        /// Grabs a particular group
        /// </summary>
        /// <returns></returns>
        public GroupResponse GetGroup(int groupID)
        {
            string urlToCheck = string.Format(Statics.BaseURL + "/groups/" + groupID + _apiKey);

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
        /// Creates a new group. Returns the created group
        /// </summary>
        /// <returns></returns>
        public GroupResponse CreateGroup(string name, string description="", string imageURL="", bool share=false)
        {
            //Thanks to http://stackoverflow.com/questions/25306570/convert-curl-to-c-sharp

            string urlToCall = string.Format(Statics.BaseURL + "/groups" +_apiKey);

            JsonGroupSerializer grpToCreate = new JsonGroupSerializer(name, description, imageURL, false, share);
            string jsonString = JsonConvert.SerializeObject(grpToCreate);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToCall);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }
            GroupResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<GroupResponse>(new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd());
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Failed to create group. Reason: {0}", ex.Message));
            }
           
            return response;
        }

        /// <summary>
        /// Updates a group. Returns the updated group
        /// </summary>
        /// <returns></returns>
        public GroupResponse UpdateGroup(int id, string name = "", string description = "", string imageURL = "", bool toggleOfficeMode = false, bool toggleShare = false)
        {
            string urlToCall = string.Format(string.Format("{0}/groups/{1}/update{2}", Statics.BaseURL, id,_apiKey));

            JsonGroupSerializer grpToUpdate = new JsonGroupSerializer(name, description, imageURL, toggleOfficeMode, toggleShare);

            //idea to prevent 2 web calls per function call:
            //1) Pull all groups when InfoGrabber is created, store them in an array.
            //2) When updating a group or pulling a group by ID, we simply look through the array. If not in the array, throw an exception.
            //so yes, I know 2 web calls per function call isn't good.


            //pull the group before we update it.
            try
            {
                //if nothing was plugged into description, for example, we need to keep it the same as before.
                Group groupToBeUpdated = GetGroup(id).Groups[0];

                if (string.IsNullOrWhiteSpace(name))
                {
                    grpToUpdate.Name = groupToBeUpdated.Name;
                }

                if (string.IsNullOrWhiteSpace(description))
                {
                    grpToUpdate.Description = groupToBeUpdated.Description;
                }

                if (string.IsNullOrWhiteSpace(imageURL))
                {
                    grpToUpdate.ImageURL = groupToBeUpdated.ImageURL;
                }

                //how do we check if the function caller plugged in false or used false by default and therefore doesn't want to change it?
                //(bool?) object that's null by default?
                //solution: named the variables "toggleOfficeMode" and "toggleShare" for simplicity
                if(toggleOfficeMode)
                {
                    grpToUpdate.OfficeMode = !groupToBeUpdated.OfficeMode;
                }

                if (toggleShare)
                {
                    grpToUpdate.Share = !groupToBeUpdated.Share;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Failed to pull group. Reason: {0}", ex.Message));
            }

            string jsonString = JsonConvert.SerializeObject(grpToUpdate);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToCall);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }
            GroupResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<GroupResponse>(new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to update group. Reason: {0}", ex.Message));
            }

            return response;
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
