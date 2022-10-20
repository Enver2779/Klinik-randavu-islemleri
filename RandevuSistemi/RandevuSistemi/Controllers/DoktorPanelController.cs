using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class DoktorPanelController : Controller
    {
        // GET: DoktorPanel
        Context _context = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var degerler = _context.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            ViewBag.m = mail;
            var mailid = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorId).FirstOrDefault();
            ViewBag.mid = mailid;
            var adsoyad = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var gorsel = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorFoto).FirstOrDefault();
            ViewBag.gorsel = gorsel;
            var meslek = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.Departmen).FirstOrDefault();
            ViewBag.meslek = meslek;
            var telefon = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorTelefon).FirstOrDefault();
            ViewBag.telefon = telefon;
            return View(degerler);
          
        }
        public ActionResult DoktorBilgiGuncelle(Doktor doktor)
        {
            var cariler = _context.Doktors.Find(doktor.DoktorId);
            cariler.DoktorAd = doktor.DoktorAd;
            cariler.DoktorSoyad = doktor.DoktorSoyad;
            cariler.Password = doktor.Password;
            cariler.Mail = doktor.Mail;
            cariler.DoktorTelefon = doktor.DoktorTelefon;
            cariler.Departmen = doktor.Departmen;
            cariler.DoktorFoto = doktor.DoktorFoto;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GelenMesajlar()
        {
            string mail = (string)Session["Mail"];
            var adsoyad = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var mesajlar = _context.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            string mail = (string)Session["Mail"];
            var adsoyad = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var mesajlar = _context.Mesajs.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            string mail = (string)Session["Mail"];
            var adsoyad = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var detay = _context.Mesajs.Where(x => x.MesajID == id).ToList();
            return View(detay);
        }
        public PartialViewResult SolMenu()
        {
            string p = (string)Session["Mail"];
            var mail = _context.Doktors.Where(x => x.Mail == p).Select(y => y.DoktorId).FirstOrDefault();

            var alc = _context.Mesajs.Count(m => m.Alici == p).ToString();
            ViewBag.alici = alc;

            var gndrci = _context.Mesajs.Count(m => m.Gonderici == p).ToString();
            ViewBag.gndrn = gndrci;

            return PartialView();
        }
        public PartialViewResult Partial()
        {
            var mail = (string)Session["Mail"];
            var id = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorId).FirstOrDefault();
            var crbl = _context.Doktors.Find(id);
            return PartialView("Partial", crbl);
        }
        public PartialViewResult Partial2()
        {
            var veriler = _context.Mesajs.Where(x => x.Gonderici == "Admin").ToList();
            return PartialView(veriler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            string mail = (string)Session["Mail"];
            var adsoyad = _context.Doktors.Where(x => x.Mail == mail).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            string mail = (string)Session["Mail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = mail;
            _context.Mesajs.Add(mesaj);
            _context.SaveChanges();
            return RedirectToAction("GidenMesajlar", "CariPanel");
        }
    }
}