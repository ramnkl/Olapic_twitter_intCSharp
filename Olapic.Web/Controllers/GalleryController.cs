using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Olapic.Lib;

namespace Olapic.Web.Controllers
{
    public class GalleryController : AsyncController
    {
        // GET: Gallery
        public ActionResult Index()
        {


            var olapic = new Olapic.Lib.OlapicMgr
            {
                ApiKey = "8eb975f77afdb5309af98507ce52477d137d1445bf1de2d0039deba508b12c51",
                MediaEndpoint = "https://photorankapi-a.akamaihd.net/customers/217064/media/photorank",
                StreamEndpoint = "https://photorankapi-a.akamaihd.net/streams/"
            };
            var list = olapic.GetRecentPhotos();
           // IEnumerable<string> twitts = twitter.GetTwitts("ramnkl16", 10).Result;
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

    }
}