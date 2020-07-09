using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class MyArray    {
        public string vehicleId { get; set; } 
        public string stationName { get; set; } 
        public string lineName { get; set; } 
        public string destinationName { get; set; } 
        public int timeToStation { get; set; } 
        public string currentLocation { get; set; } 
        public string towards { get; set; } 
        public DateTime expectedArrival { get; set; } 
        public DateTime timeToLive { get; set; } 
    }
}