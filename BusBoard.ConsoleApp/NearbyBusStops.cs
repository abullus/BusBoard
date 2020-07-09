using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class NearbyBusStops
    {
        public List<StopPoint> BusStopCodes;

        public NearbyBusStops(double latitude, double longitude)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint?stopTypes=NaptanPublicBusCoachTram&radius=500&lat="
                               + latitude+ "&lon="+longitude;
            IRestResponse response = client.Execute(request);
            Root busStopData = JsonConvert.DeserializeObject<Root>(response.Content);
            BusStopCodes = busStopData.stopPoints;
        }
        
        public class StopPoint    {
            public string id;
        }

        public class Root    {
            public List<StopPoint> stopPoints;
        }


    }
}