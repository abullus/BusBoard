using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode, Dictionary<string, List<BusData>> upcomingBusesDict)
        {
            PostCode = postCode;
            UpcomingBusesDict = upcomingBusesDict;
        }

        public Dictionary<string, List<BusData>> UpcomingBusesDict;
        public string PostCode { get; set; }
    }
}