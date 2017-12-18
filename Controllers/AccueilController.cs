using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EBibliotheque.Models;

namespace EBibliotheque.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}