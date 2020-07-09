using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
  partial class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

      Console.WriteLine("Please enter a postcode: ");
      
      string input = Console.ReadLine();

      Postcode postcode = new Postcode(input);
      NearbyBusStops nearbyBusStops = new NearbyBusStops(postcode.latitude, postcode.longitude);
      
      BusStopAPI busStopApi = new BusStopAPI(nearbyBusStops.BusStopCodes[0].id);
      PrintStationInfo(busStopApi.BusStopData);
      
    }

    private static void PrintStationInfo(List<BusData> busDataList)
    {
      Console.WriteLine("Nearest bus stop: {0}\n", busDataList[0].StationName);
      foreach (var bus in busDataList)
      {
        Console.WriteLine("Line: "+bus.LineName);
        Console.WriteLine("Destination: "+bus.DestinationName);
        Console.WriteLine("Scheduled Arrival: "+ bus.ExpectedArrival.AddHours(1));
        Console.WriteLine("Expected Arrival: "+bus.TimeToLive.AddHours(1));
        Console.WriteLine();
      }
    }


  }
}
