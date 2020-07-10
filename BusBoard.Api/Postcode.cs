using System;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class Postcode
    {
        public double longitude;
        public double latitude;
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
            Root postcodeData = JsonConvert.DeserializeObject<Root>(response.Content);
            longitude = postcodeData.result.longitude;
            latitude = postcodeData.result.latitude;
        }
        
    }
}