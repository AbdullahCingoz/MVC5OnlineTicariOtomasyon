using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.Fatura_ID);
            fatura.Fatura_SeriNo = f.Fatura_SeriNo;
            fatura.Fatura_SıraNo = f.Fatura_SıraNo;
            fatura.Fatura_Saat = f.Fatura_Saat;
            fatura.Fatura_Tarih = f.Fatura_Tarih;
            fatura.Fatura_TeslimAlan = f.Fatura_TeslimAlan;
            fatura.Fatura_TeslimEden = f.Fatura_TeslimEden;
            fatura.Fatura_VergiDairesi = f.Fatura_VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Fatura_ID == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}