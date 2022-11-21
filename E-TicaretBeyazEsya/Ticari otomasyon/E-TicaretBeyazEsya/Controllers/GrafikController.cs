using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c=new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz=new Chart(width:600,height:600);
            grafikciz.AddTitle("Kategori-Ürün Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 100, 250, 230 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.Urun_Ad));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Urun_Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar").AddSeries(chartType:"Column",name:"Stok",xValue:xvalue,yValues:yvalue);//eğer veriler sığmazsa chartType pie yap
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
              
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1>UrunListesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                Stok = 320
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 400
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Telefon",
                Stok = 250
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 650
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf=new List<Sinif2>();
            using(var c=new Context())
            {
                snf = c.Uruns.Select(x => new Sinif2
                {
                    urn = x.Urun_Ad,
                    stk = x.Urun_Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}