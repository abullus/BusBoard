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
      List<MyArray> request = GetRequest(input);
      PrintStationInfo(request);
    }

    private static void PrintStationInfo(List<MyArray> request)
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine(request[i].lineName);
        Console.WriteLine(request[i].towards);
        Console.WriteLine(request[i].timeToLive.AddHours(1));
        Console.WriteLine();
      }
    }

    private static List<MyArray> GetRequest(string input)
    {
      var client = new RestClient();
      client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
      var request = new RestRequest();
      request.Resource = "StopPoint/"+input+"/Arrivals";
      IRestResponse response = client.Execute(request);
      List<MyArray> myDeserializedClass = JsonConvert.DeserializeObject<List<MyArray>>(response.Content);
      return myDeserializedClass;
    }
  }
}
