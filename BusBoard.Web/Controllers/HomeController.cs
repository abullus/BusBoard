using System;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    private Error ErrorInfo;
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
      ErrorInfo = new Error();
      try
      {
        Postcode postcode = new Postcode(selection.Postcode);
        NearbyBusStops nearbyBusStops = new NearbyBusStops(postcode.latitude, postcode.longitude);
        UpcomingBuses busStopApi = new UpcomingBuses(nearbyBusStops.BusStopCodes[0].id);
        // Add some properties to the BusInfo view model with the data you want to render on the page.
        // Write code here to populate the view model with info from the APIs.
        // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
        var info = new BusInfo(selection.Postcode, busStopApi);
        return View(info);
      }
      catch (Exception ex)
      {
        ErrorInfo.Message = "works?1111";
        return Redirect("/Home/ErrorMessage");
      }
    }

    public ActionResult ErrorMessage()
    {
      ViewBag.Message = "When an error occurs.";
      Error localError = ErrorInfo;
      return View(localError);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}