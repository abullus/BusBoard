using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class UpcomingBuses
    {
        public List<BusData> BusStopData;
        
        public class BusData    {
            public string VehicleId { get; set; } 
            public string StationName { get; set; } 
            public string LineName { get; set; } 
            public string DestinationName { get; set; } 
            public int TimeToStation { get; set; } 
            public string CurrentLocation { get; set; } 
            public string Towards { get; set; } 
            public DateTime ExpectedArrival { get; set; } 
            public DateTime TimeToLive { get; set; }
        }
        public UpcomingBuses (string busStopCode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint/"+busStopCode+"/Arrivals";
            IRestResponse response = client.Execute(request);
            BusStopData = JsonConvert.DeserializeObject<List<BusData>>(response.Content);
        }
    }
}