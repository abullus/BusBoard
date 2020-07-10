using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode,UpcomingBuses busStopApi)
    {
      PostCode = postCode;
      UpcomingBuses = busStopApi;
    }

    public UpcomingBuses UpcomingBuses;
    public string PostCode { get; set; }
    


  }
}