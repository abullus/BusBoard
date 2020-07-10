using System;

namespace BusBoard.Api
{
    public class BusData
    {
        public string VehicleId { get; set; }
        public string StationName { get; set; }
        public string LineName { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }
        public string CurrentLocation { get; set; }
        public string Towards { get; set; }
        public DateTime ExpectedArrival { get; set; }
        public DateTime TimeToLive { get; set; }
    }
}