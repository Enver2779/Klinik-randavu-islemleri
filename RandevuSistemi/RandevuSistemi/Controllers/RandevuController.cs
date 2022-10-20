using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandevuSistemi.Controllers
{
    public class RandevuController : Controller
    {
        // GET: Randevu
        public ActionResult Index()
        {
            return View();
        }
    }
}