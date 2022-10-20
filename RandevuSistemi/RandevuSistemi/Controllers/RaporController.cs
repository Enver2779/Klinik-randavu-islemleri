using RandevuSistemi.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandevuSistemi.Controllers
{
    public class RaporController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var rapor = c.Rapors.ToList();
            return View(rapor);
        }
        
        [HttpGet]
        public ActionResult RaporEkle()
        {
            List<SelectListItem> deger1 = (from x in c.RaporDurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.RaporDurumu,
                                               Value = x.RaporDurumId.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Hastas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.HastaName + " " + x.HastaSurName + " " + x.HastaTc,
                                               Value = x.HastaId.ToString()
                                           }).ToList();


            List<SelectListItem> deger3 = (from x in c.Doktors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd + " " + x.DoktorSoyad,
                                               Value = x.DoktorId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult RaporEkle(Rapor ro)
        {
            c.Rapors.Add(ro);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}