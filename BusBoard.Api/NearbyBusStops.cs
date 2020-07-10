using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
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
            NearbyBusStopData nearbyBusStopData = JsonConvert.DeserializeObject<NearbyBusStopData>(response.Content);
            BusStopCodes = nearbyBusStopData.stopPoints;
        }
        
        public class NearbyBusStopData    {
            public List<StopPoint> stopPoints; 

        }
        public class StopPoint
        {
            public string id;
        }
        


    }
}