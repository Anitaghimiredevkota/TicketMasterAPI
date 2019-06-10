using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace TicketMasterApiApp.Models
{
    public class TicketMasterApiAppDAL
    {
        private static readonly string ApiKey = "apikey=" + ConfigurationManager.AppSettings["TicketMasterApi"];

        
        public static JObject GetData(string url)
        {
            
            HttpWebRequest request = WebRequest.CreateHttp(url + ApiKey);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return JObject.Parse(reader.ReadToEnd());
            }
            return null;
        }

        public static JObject GetEventById(string id)
        {
            return GetData($"https://app.ticketmaster.com/discovery/v2/events/{id}.json?");
        }
    }    
}