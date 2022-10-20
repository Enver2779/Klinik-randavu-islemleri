using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;
namespace RandevuSistemi.Controllers
{
    public class SekreterController : Controller
    {
        // GET: Sekreter
        Context c = new Context();
        public ActionResult Index()
        {
            var sek = c.Sekreters.ToList();
            return View(sek);
        }
        [HttpGet]
        public ActionResult SekreterEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SekreterEkle(Sekreter s)
        {
            c.Sekreters.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SekreterSil(int id)
        {
            var sekt = c.Sekreters.Find(id);
            c.Sekreters.Remove(sekt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SekreterGetir(int id)
        {

            var sekt = c.Sekreters.Find(id);
            return View("SekreterGetir", sekt);
        }
        public ActionResult SekreterGuncelle(Sekreter d)
        {
            var sekt = c.Sekreters.Find(d.SekreterID);
            sekt.SekreterAdi = d.SekreterAdi;
            sekt.SekreterSoyadi = d.SekreterSoyadi;
            sekt.SekreterMaili = d.SekreterMaili;
            sekt.SekreterSifresi = d.SekreterSifresi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}