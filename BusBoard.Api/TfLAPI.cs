using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class TfLAPI
    {
        public List<string> NearbyBusStops(double latitude, double longitude)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint?stopTypes=NaptanPublicBusCoachTram&radius=500&lat="
                               + latitude + "&lon=" + longitude;
            IRestResponse response = client.Execute(request);
            NearbyBusStops nearbyBusStopsDataList = JsonConvert.DeserializeObject<NearbyBusStops>(response.Content);
            return DataToList(nearbyBusStopsDataList);
        }

        private List<string> DataToList(NearbyBusStops nearbyBusStopsDataList)
        {
            List<string> nearbyBusStopCodeList = new List<string>();
            foreach (var busStop in nearbyBusStopsDataList.stopPoints)
            {
                nearbyBusStopCodeList.Add(busStop.id);
            }

            return nearbyBusStopCodeList;
        }

        public List<BusData> UpcomingBuses(string busStopCode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint/" + busStopCode + "/Arrivals";
            IRestResponse response = client.Execute(request);
            List<BusData> test =  JsonConvert.DeserializeObject<List<BusData>>(response.Content);
            test.Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
            return test.Take(5).ToList();
        }
    }
}