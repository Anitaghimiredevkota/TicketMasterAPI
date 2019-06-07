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
        private static readonly string ApiKey = "?apikey=" + ConfigurationManager.AppSettings["TicketMasterApiKey"];

        public static JObject GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?countryCode=US&apikey=Kpj2rgTEX1l8IZ9iae7DASDwI9gz2tCO");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                JObject rawData = JObject.Parse(reader.ReadToEnd());
                return rawData;
            }
            return null;
        }

        public static JObject GetEventById(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events/vv1AkZA_UGkd6D_vT.json?apikey=Kpj2rgTEX1l8IZ9iae7DASDwI9gz2tCO");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                JObject rawData = JObject.Parse(reader.ReadToEnd());
                return rawData;
            }
            return null;
        }
    }    
}