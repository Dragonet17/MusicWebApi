using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetApi()
        {

            return View();
        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult Songs()
        {

            return View();
        }

        public ActionResult Artists()
        {

            return View();
        }

        public ActionResult PlayerSong()
        {

            return View();
        }

        public ActionResult PlayerAlbumSong()
        {

            return View();
        }
    }
}