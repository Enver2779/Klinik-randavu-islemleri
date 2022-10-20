using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandevuSistemi.Models.Sinif;

namespace RandevuSistemi.Controllers
{
    public class HastaController : Controller
    {
        // GET: Hasta
        Context c = new Context();
        public ActionResult Index()
        {
            var hasta = c.Hastas.ToList();
            return View(hasta);
        }
        [HttpGet]
        public ActionResult HastaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaEkle(Hasta k)
        {
            c.Hastas.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaSil(int id)
        {
            var Dprt = c.Hastas.Find(id);
            c.Hastas.Remove(Dprt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaGetir(int id)
        {

            var Dprt = c.Hastas.Find(id);
            return View("HastaGetir", Dprt);
        }
        public ActionResult HastaGuncelle(Hasta d)
        {
            var Dprt = c.Hastas.Find(d.HastaId);
            Dprt.HastaTc = d.HastaTc;
            Dprt.HastaName = d.HastaName;
            Dprt.HastaSurName = d.HastaSurName;
            Dprt.HastaDogumT = d.HastaDogumT;
            Dprt.KanGb = d.KanGb;
            //Dprt.HastaFoto = d.HastaFoto;
            Dprt.HastaTelefon = d.HastaTelefon;
            Dprt.Aciklama = d.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IndexList()
        {
            var hasthaor = c.Hastas.ToList();
            return View(hasthaor);
        }
       
    }
}