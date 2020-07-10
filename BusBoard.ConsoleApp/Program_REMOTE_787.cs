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

            Console.WriteLine("Please enter a postcode: ");

            string inputPostcode = Console.ReadLine();

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