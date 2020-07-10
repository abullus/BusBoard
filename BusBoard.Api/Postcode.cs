using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class Postcode
    {
        public class Result
        {
            public double longitude;
            public double latitude;
        }

        public class PostcodeData
        {
            public Result result;
        }


        public double[] GetLatLong(string inputPostcode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.postcodes.io/");
            var request = new RestRequest();
            request.Resource = "/postcodes/" + inputPostcode;
            IRestResponse response = client.Execute(request);
            PostcodeData postcodeData = JsonConvert.DeserializeObject<PostcodeData>(response.Content);
            double[] LatLongArray = {postcodeData.result.latitude, postcodeData.result.longitude};
            return LatLongArray;
        }
    }
}