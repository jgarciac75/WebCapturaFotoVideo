using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCapturaFotoVideo.Models;

namespace WebCapturaFotoVideo.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Video()
    {
      return View();
    }

    public ActionResult VideoScreenShop()
    {
      return View();
    }

    [HttpPost]
    public ActionResult GetImage(GetImageInputModel model)
    {
      var err = 0;
      var msgErr = "";
      if (model == null || string.IsNullOrEmpty(model.Image))
      {
        err = 1;
        msgErr = "No Hay Datos para la Imagen";
      }
      else
      {
        var imageData = model.Image.Replace("data:image/png;base64,", "");
        var fec = DateTime.Now;
        var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(imageData)));
        image.Save(Server.MapPath($"~/Fotos/foto-{fec.Year}-{fec.Month.ToString().PadLeft(2, '0')}-{fec.Day.ToString().PadLeft(2, '0')}-{fec.Hour.ToString().PadLeft(2, '0')}-{fec.Minute.ToString().PadLeft(2, '0')}-{fec.Second.ToString().PadLeft(2, '0')}.png"), ImageFormat.Png);
      }
      return Json(new
      {
        err,
        msgErr
      });
    }
  }
}