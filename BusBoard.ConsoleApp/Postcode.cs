using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class Postcode
    {
        public Root postcodeLocation;
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        public class Result    {
            public double longitude; 
            public double latitude;
        }

        public class Root    {
            public Result result; 

        }


        public Postcode(string inputPostcode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.postcodes.io/");
            var request = new RestRequest();
            request.Resource = "/postcodes/" + inputPostcode;
            IRestResponse response = client.Execute(request);
            postcodeLocation = JsonConvert.DeserializeObject<Root>(response.Content);
        }
        
    }
}