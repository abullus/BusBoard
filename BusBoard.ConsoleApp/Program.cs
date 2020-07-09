using System;
using System.Net;
using RestSharp;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      
      var client = new RestClient();
      client.BaseUrl = new Uri("https://api.tfl.gov.uk/");
      var request = new RestRequest();
      request.Resource = "StopPoint/490008660N/Arrivals";
      IRestResponse response = client.Execute(request);
      Console.WriteLine(response.Content);
      
    }
    
  }
}
