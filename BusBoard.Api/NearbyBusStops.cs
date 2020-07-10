using System.Collections.Generic;

namespace BusBoard.Api
{
    public class NearbyBusStops
    {
        public List<StopPoint> stopPoints;

        public class StopPoint
        {
            public string id;
        }
    }
}