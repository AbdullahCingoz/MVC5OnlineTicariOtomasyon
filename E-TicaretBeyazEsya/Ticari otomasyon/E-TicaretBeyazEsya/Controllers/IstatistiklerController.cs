using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class IstatistiklerController : Controller
    {
        Context c = new Context();
        // GET: Istatistikler
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1=deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2=deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x=>x.Urun_Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.Urun_Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.Urun_Stok<=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.Urun_SatisFiyati descending select x.Urun_Ad).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.Urun_SatisFiyati ascending select x.Urun_Ad).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.Urun_Ad=="Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.Urun_Ad == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12=c.Uruns.GroupBy(x=>x.Urun_Marka).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 =c.Uruns.Where(u=>u.Urun_ID==( c.SatisHarekets.GroupBy(x => x.Urun_ID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.Urun_Ad).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14=c.SatisHarekets.Sum(x=>x.SatisHareket_ToplamTutar).ToString();
            ViewBag.d14= deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.SatisHareket_Tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SatisHarekets.Where(x => x.SatisHareket_Tarih == bugun).Sum(y => (decimal?)y.SatisHareket_ToplamTutar).ToString(); 
            ViewBag.d16 = deger16;




            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.Cari_Sehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.Departman_Ad into g
                         select new SinifGrup2
                         {
                             Departman_ID = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Caris.ToList();
            return PartialView(sorgu); 
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                         group x by x.Urun_Marka into g
                         select new SinifGrup3
                         {
                              Marka= g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }

    }
}