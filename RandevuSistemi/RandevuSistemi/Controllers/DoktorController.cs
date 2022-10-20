using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class DoktorController : Controller
    {
        // GET: Doktor
        Context c = new Context();
        public ActionResult Index()
        {
            var doktor = c.Doktors.ToList();
            return View(doktor);
        }
        [HttpGet]
        public ActionResult DoktorEkle()
        {
            List<SelectListItem> departmanlar = (from x in c.Departmen.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.dprtmn = departmanlar;

            return View();
        }
        [HttpPost]
        public ActionResult DoktorEkle(Doktor d)
        {
            c.Doktors.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoktorSil(int id)
        {
            var Dprt = c.Doktors.Find(id);
            c.Doktors.Remove(Dprt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoktorGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var Dprt = c.Doktors.Find(id);
            return View("DoktorGetir", Dprt);
        }
        public ActionResult DoktorGuncelle(Doktor d)
        {
            var Dprt = c.Doktors.Find(d.DoktorId);
            Dprt.DoktorTC = d.DoktorTC;
            Dprt.DoktorAd = d.DoktorAd;
            Dprt.DoktorSoyad = d.DoktorSoyad;
            Dprt.DoktorDogumT = d.DoktorDogumT;
            Dprt.Mail = d.Mail;
            Dprt.Password = d.Password;
            Dprt.DoktorTelefon = d.DoktorTelefon;
            Dprt.DoktorFoto = d.DoktorFoto;
            Dprt.DepartmanId = d.DepartmanId;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IndexList()
        {
            var doktor = c.Doktors.ToList();
            return View(doktor);
        }
    }
}