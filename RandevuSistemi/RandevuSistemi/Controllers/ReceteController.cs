using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class ReceteController : Controller
    {
        // GET: Recete
        Context c = new Context();
        public ActionResult Index()
        {
            var recete = c.Recetes.ToList();
            return View(recete);
        }
        [HttpGet]
        public ActionResult YeniRecete()
        {
            List<SelectListItem> deger1 = (from x in c.Ilacs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.IlacAd,
                                               Value = x.IlacId.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Hastas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.HastaName + " " + x.HastaSurName+""+x.HastaTc,
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
        public ActionResult YeniRecete(Recete recete)
        {
            recete.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Recetes.Add(recete);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReceteSil(int id)
        {
            var rec = c.Recetes.Find(id);
            c.Recetes.Remove(rec);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReceteGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Ilacs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.IlacAd,
                                               Value = x.IlacId.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Hastas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.HastaName + " " + x.HastaSurName + "" + x.HastaTc,
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


            var rect = c.Recetes.Find(id);
            return View("ReceteGetir", rect);
        }
        public ActionResult ReceteGuncelle(Recete s)
        {
            var sts = c.Recetes.Find(s.ReceteId);
            sts.HastaId = s.HastaId;
            sts.ProtokolNo = s.ProtokolNo;
            sts.Tanı = s.Tanı;
            sts.DoktorId = s.DoktorId;
            sts.Tarih = s.Tarih;
            sts.Aciklama = s.Aciklama;
            sts.IlacId = s.IlacId;
            sts.Tarih = s.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IndexList()
        {
            var recete = c.Recetes.ToList();
            return View(recete);
        }
    }
}