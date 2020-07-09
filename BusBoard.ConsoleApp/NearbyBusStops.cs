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
            BusStopCodes = JsonConvert.DeserializeObject<List<StopPoint>>(response.Content);
        }
        public class StopPoint
        {
            public string id;
        }
    }
}