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

        public static List<Event> GetEventsByPrice(double price)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?apikey=Kpj2rgTEX1l8IZ9iae7DASDwI9gz2tCO");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                JObject events = JObject.Parse(reader.ReadToEnd());
                List<Event> foundEvents = new List<Event>();

                foreach (JObject e in events["_embedded"]["events"])
                {
                    if (e["priceRanges"] != null)
                    {
                        double min = (double)e["priceRanges"][0]["min"];
                        double max = (double)e["priceRanges"][0]["max"];

                        if (price >= min && price <= max)
                        {
                            foundEvents.Add(new Event(e));
                        }
                    }
                }

                return foundEvents;
            }
            return null;
        }
    }    
}