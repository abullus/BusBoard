using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode,List<BusData> upcomingBusesList)
    {
      PostCode = postCode;
      UpcomingBusesList = upcomingBusesList;
    }

    public List<BusData> UpcomingBusesList;
    public string PostCode { get; set; }
    


  }
}