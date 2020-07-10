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

      while (true)
      {
        Console.WriteLine("Please enter a postcode: (Or Exit)");

        string inputPostcode = Console.ReadLine();

        if (inputPostcode == "Exit")
        {
          break;
        }

        try
        {
          Postcode postcode = new Postcode(inputPostcode);
          NearbyBusStops nearbyBusStops = new NearbyBusStops(postcode.latitude, postcode.longitude);
          UpcomingBuses busStopApi = new UpcomingBuses(nearbyBusStops.BusStopCodes[0].id);
          PrintStationInfo(busStopApi.BusStopData);
        }
        catch (Exception ex)
        {
          if (ex.StackTrace.Contains("Postcode.cs"))
          {
            Console.WriteLine("Postcode invalid.");
          }
          else
          {
            Console.WriteLine("Postcode error: not in London.");
          }
          
        }
      }

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
