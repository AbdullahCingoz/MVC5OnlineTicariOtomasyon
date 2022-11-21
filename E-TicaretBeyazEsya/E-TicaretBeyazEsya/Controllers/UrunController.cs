using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretBeyazEsya.Models.Tablolar;

namespace E_TicaretBeyazEsya.Controllers
{
    public class UrunController : Controller
    {
        Context c=new Context();
            
        // GET: Urun
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler=urunler.Where(y=>y.Urun_Ad.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList() select new SelectListItem
            {
                Text=x.Kategori_Ad,
                Value=x.Kategori_ID.ToString()
            }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        } 
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
           
               
                Urun u = c.Uruns.Find(id);
                u.Urun_Durum = false;//Soft Delete
                                 //db.Categories.Remove(c);//Hard Delete
                c.SaveChanges();
                return RedirectToAction("Index");
            
        }
       public ActionResult UrunGetir(int id)
       {

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Kategori_Ad,
                                               Value = x.Kategori_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
       }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn=c.Uruns.Find(u.Urun_ID);
            urn.Urun_ID = u.Urun_ID;
            urn.Urun_Ad = u.Urun_Ad;
            urn.Urun_AlisFiyati = u.Urun_AlisFiyati;
            urn.Urun_Durum = u.Urun_Durum;
            urn.Urun_Gorsel = u.Urun_Gorsel;
            urn.Urun_Marka = u.Urun_Marka;
            urn.Urun_SatisFiyati = u.Urun_SatisFiyati;
            urn.Urun_Stok=u.Urun_Stok;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personel_Ad + " " + x.Personel_Soyad,
                                               Value = x.Personel_ID.ToString(),
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.Urun_ID;
            ViewBag.dgr2 = deger1.Urun_SatisFiyati;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.SatisHareket_Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");


        }

    }
}