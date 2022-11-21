using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urun_Ad,
                                               Value = x.Urun_ID.ToString(),
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Cari_Ad + " " + x.Cari_Soyad,
                                               Value = x.Cari_ID.ToString(),
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personel_Ad + " " + x.Personel_Soyad,
                                               Value = x.Personel_ID.ToString(),
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.SatisHareket_Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urun_Ad,
                                               Value = x.Urun_ID.ToString(),
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Cari_Ad + " " + x.Cari_Soyad,
                                               Value = x.Cari_ID.ToString(),
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personel_Ad + " " + x.Personel_Soyad,
                                               Value = x.Personel_ID.ToString(),
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = c.SatisHarekets.Find(s.SatisHareket_ID);
            deger.Cari_ID = s.Cari_ID;
            deger.SatisHareket_Adet = s.SatisHareket_Adet;
            deger.SatisHareket_Fiyat = s.SatisHareket_Fiyat;
            deger.Personel_ID = s.Personel_ID;
            deger.SatisHareket_Tarih = s.SatisHareket_Tarih;
            deger.SatisHareket_ToplamTutar = s.SatisHareket_ToplamTutar;
            deger.Urun_ID = s.Urun_ID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisHareket_ID == id).ToList();
            return View(degerler);
        }
      
    }
}