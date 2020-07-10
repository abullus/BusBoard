using System.Collections;
using System.Collections.Generic;

namespace BusBoard.Api
{
    public class NearbyBusStops
    {
        public List<StopPoint> stopPoints;

        public class StopPoint
        {
            public List<children> children;
            public string commonName;
        }
        
        public class children
        {
            public string id;
        }
    }
}