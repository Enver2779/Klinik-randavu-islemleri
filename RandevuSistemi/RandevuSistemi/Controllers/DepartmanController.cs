using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departman = c.Departmen.ToList();
            return View(departman);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman k)
        {
            c.Departmen.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var Dprt = c.Departmen.Find(id);
            c.Departmen.Remove(Dprt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {

            var Dprt = c.Departmen.Find(id);
            return View("DepartmanGetir", Dprt);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var Dprt = c.Departmen.Find(d.DepartmanId);
            Dprt.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var doktorlar = c.Doktors.Where(x => x.DepartmanId == id).ToList();
            var dprtmn = c.Departmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departman = dprtmn;
            return View(doktorlar);
        }
    }
}