using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode,List<BusData> upcomingBusesList1, List<BusData> upcomingBusesList2)
    {
      PostCode = postCode;
      UpcomingBusesList1 = upcomingBusesList1;
      UpcomingBusesList2 = upcomingBusesList2;
    }

    public List<BusData> UpcomingBusesList1;
    public List<BusData> UpcomingBusesList2;
    public string PostCode { get; set; }
    


  }
}