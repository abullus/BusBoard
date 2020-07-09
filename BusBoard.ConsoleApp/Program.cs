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
      Console.WriteLine("Please enter a bus stop code: ");
      string input = Console.ReadLine();
      BusStopAPI busStopApi = new BusStopAPI(input);
      PrintStationInfo(busStopApi.BusStopData);
    }

    private static void PrintStationInfo(List<BusData> request)
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine(request[i].LineName);
        Console.WriteLine(request[i].Towards);
        Console.WriteLine(request[i].TimeToLive.AddHours(1));
        Console.WriteLine();
      }
    }


  }
}
