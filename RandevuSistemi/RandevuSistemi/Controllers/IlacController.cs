using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class IlacController : Controller
    {
        // GET: Ilac
       Context c = new Context();
        public ActionResult Index()
        {
            var ilac = c.Ilacs.ToList();
            return View(ilac);
        }
        [HttpGet]
        public ActionResult IlacEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IlacEkle(Ilac k)
        {
            c.Ilacs.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IlacSil(int id)
        {
            var Ilc = c.Ilacs.Find(id);
            c.Ilacs.Remove(Ilc);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IlacGetir(int id)
        {

            var Ilc = c.Ilacs.Find(id);
            return View("IlacGetir", Ilc);
        }
        public ActionResult IlacGuncelle(Ilac I)
        {
            var Dprt = c.Ilacs.Find(I.IlacId);
            Dprt.IlacAd = I.IlacAd;
            Dprt.PartiNo = I.PartiNo;
            Dprt.IlacKT = I.IlacKT;
            Dprt.SonKullanmaTarih = I.SonKullanmaTarih;
            Dprt.Stok = I.Stok;
            Dprt.RuhsatNo = I.RuhsatNo;
            Dprt.IlacKUB = I.IlacKUB;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IndexList()
        {
            var ilac = c.Ilacs.ToList();
            return View(ilac);
        }
    }
}