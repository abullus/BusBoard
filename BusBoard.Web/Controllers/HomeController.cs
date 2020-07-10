﻿using System;
using System.Collections.Generic;
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
      try
      {
        // Add some properties to the BusInfo view model with the data you want to render on the page.
        // Write code here to populate the view model with info from the APIs.
        // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
        Postcode postcode = new Postcode();
        TfLAPI tflapi = new TfLAPI();
        double[] latLongArray = postcode.GetLatLong(selection.Postcode);
        List<string> nearbyBusStopCodeList = tflapi.NearbyBusStops(latLongArray[0], latLongArray[1]);
        List<BusData> upcomingBusesList1 = tflapi.UpcomingBuses(nearbyBusStopCodeList[0]);
        List<BusData> upcomingBusesList2 = tflapi.UpcomingBuses(nearbyBusStopCodeList[1]);
        var info = new BusInfo(selection.Postcode,upcomingBusesList1, upcomingBusesList2);
        return View(info);
      }
      catch (Exception ex)
      {
        if (ex.StackTrace.Contains("Postcode.cs"))
        {
          TempData["ErrorMessage"] = "Invalid postcode entered.";
          return Redirect("/Home/ErrorMessage");
        }
        else
        {
          TempData["ErrorMessage"] = "Entered postcode not in London. ";
          return Redirect("/Home/ErrorMessage");
        }
      }
    }

    public ActionResult ErrorMessage()
    {
      ViewBag.Message = "When an error occurs.";
      return View();
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