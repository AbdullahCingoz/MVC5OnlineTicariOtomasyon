using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_TicaretBeyazEsya.Controllers
{
    public class CariController : Controller
    {
        Context c =new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var degerler=c.Caris.Where(x=>x.Cari_Durum==true).ToList();
            return View(degerler);
        }
        public ActionResult CariDetay(int? id)
        {
            var dgr = c.SatisHarekets.Where(x => x.Cari_ID == id).ToList();
            var degerler = c.Caris.Where(x => x.Cari_ID == id).Select(y => y.Cari_Ad + y.Cari_Soyad).FirstOrDefault();
            ViewBag.cr = degerler;
            return View(dgr);
        }
        public ActionResult CariSil(int? id)
        {
            var car = c.Caris.Find(id);
            car.Cari_Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cr)
        {
            cr.Cari_Durum = true;
            c.Caris.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = c.Caris.Find(id);
            return View("CariGetir", cr);
        }
        public ActionResult CariGüncelle(Cari cr)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var crs = c.Caris.Find(cr.Cari_ID);
            crs.Cari_Ad = cr.Cari_Ad;
            crs.Cari_Soyad = cr.Cari_Soyad;
            crs.Cari_Sehir = cr.Cari_Sehir;
            crs.Cari_Mail = cr.Cari_Mail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}