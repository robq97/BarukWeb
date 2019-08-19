using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baruk.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult InformationForm()
        {
            return View();
        }

        // GET: Information
        public ActionResult Gallery()
        {
            return View();
        }

        // GET: Information
        public ActionResult WhoAreWe()
        {
            return View();
        }

        // GET: Information
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult _Denied()
        {
            return View();
        }
    }
}