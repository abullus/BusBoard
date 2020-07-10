using System;
using System.Collections.Generic;
using System.Net;
using BusBoard.Api;

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
                    Postcode postcode = new Postcode();
                    TfLAPI tflapi = new TfLAPI();
                    double[] latLongArray = postcode.GetLatLong(inputPostcode);
                    NearbyBusStops nearbyBusStops = tflapi.NearbyBusStops(latLongArray[0], latLongArray[1]);
                    Dictionary<string, List<BusData>> upcomingBusesDict = tflapi.UpcomingBuses(nearbyBusStops);
                    PrintStationInfo(upcomingBusesDict);
                }
                catch (Exception ex)
                {
                    if (ex.StackTrace.Contains("Postcode.cs"))
                    {
                        Console.WriteLine("Postcode invalid.");
                    }
                    else
                    {
                        Console.WriteLine("Postcode error: not in London." + ex.Message);
                    }
                }
            }
        }

        private static void PrintStationInfo(Dictionary<string, List<BusData>> upcomingBusesDict)
        {
            int count = 0;
            Console.WriteLine("These are the bus stops within 500m of your postcode");
            foreach (var busStop in upcomingBusesDict)
            {
                count++;
                Console.WriteLine($"Bus Stop No. {count}: {busStop.Key}\n");
                foreach (var bus in busStop.Value)
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
}