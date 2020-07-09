using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class BusStopAPI
    {
        public List<BusData> BusStopData;
        
        public BusStopAPI (string input)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint/"+input+"/Arrivals";
            IRestResponse response = client.Execute(request);
            BusStopData = JsonConvert.DeserializeObject<List<BusData>>(response.Content);
        }
    }
}