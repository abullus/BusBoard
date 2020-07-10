using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public class TfLAPI
    {
        public NearbyBusStops NearbyBusStops(double latitude, double longitude)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            request.Resource = "StopPoint?stopTypes=NaptanOnstreetBusCoachStopPair&radius=500&lat="
                               + latitude + "&lon=" + longitude;
            IRestResponse response = client.Execute(request);
            NearbyBusStops nearbyBusStopsDataList = JsonConvert.DeserializeObject<NearbyBusStops>(response.Content);
            return nearbyBusStopsDataList;
        }


        public Dictionary<string, List<BusData>> UpcomingBuses(NearbyBusStops busStopData)
        {
            Dictionary<string, List<BusData>> UpcomingBusesDict = new Dictionary<string, List<BusData>>();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
            var request = new RestRequest();
            foreach (var busStopPair in busStopData.stopPoints)
            {
                List<BusData> busStopPairDataList = new List<BusData>();
                foreach (var busStop in busStopPair.children)
                {
                    request.Resource = "StopPoint/" + busStop.id + "/Arrivals";
                    IRestResponse response = client.Execute(request);
                    List<BusData> data = JsonConvert.DeserializeObject<List<BusData>>(response.Content);
                    busStopPairDataList.AddRange(data);
                }

                if (UpcomingBusesDict.ContainsKey(busStopPair.commonName))
                {
                    UpcomingBusesDict[busStopPair.commonName].AddRange(busStopPairDataList);
                }
                else
                {
                    UpcomingBusesDict.Add(busStopPair.commonName, busStopPairDataList);
                }
                UpcomingBusesDict[busStopPair.commonName].Sort((x, y) => x.ExpectedArrival.CompareTo(y.ExpectedArrival));
                UpcomingBusesDict[busStopPair.commonName] = UpcomingBusesDict[busStopPair.commonName].Take(5).ToList();
            }

            return UpcomingBusesDict;
        }
    }
}