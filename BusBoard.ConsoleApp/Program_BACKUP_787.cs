using System;
using System.Collections.Generic;
using System.Net;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

<<<<<<< HEAD
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
=======
            Console.WriteLine("Please enter a postcode: ");

            string inputPostcode = Console.ReadLine();
>>>>>>> 3d5c24549da544805a16c4802bcad35b43e9105a

            Postcode postcode = new Postcode(inputPostcode);
            NearbyBusStops nearbyBusStops = new NearbyBusStops(postcode.latitude, postcode.longitude);

            UpcomingBuses upcomingBuses = new UpcomingBuses(nearbyBusStops.BusStopCodes[0].id);
            PrintStationInfo(upcomingBuses.BusStopData);
        }

        private static void PrintStationInfo(List<BusData> busDataList)
        {
            Console.WriteLine($"\nNearest bus stop: {busDataList[0].StationName}\n");
            foreach (var bus in busDataList)
            {
                Console.WriteLine("Line: " + bus.LineName);
                Console.WriteLine("Destination: " + bus.DestinationName);
                Console.WriteLine("Scheduled Arrival: " + bus.ExpectedArrival.AddHours(1).TimeOfDay);
                Console.WriteLine("Expected Arrival: " + bus.TimeToLive.AddHours(1).TimeOfDay);
                Console.WriteLine();
            }
        }
    }
}