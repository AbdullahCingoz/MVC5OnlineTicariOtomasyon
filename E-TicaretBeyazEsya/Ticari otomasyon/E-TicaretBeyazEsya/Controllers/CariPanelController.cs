using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_TicaretBeyazEsya.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Cari_Mail"];
            var degerler = c.Mesajlars.Where(x=>x.Alici==mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Caris.Where(x => x.Cari_Mail == mail).Select(y => y.Cari_ID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cari_ID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
         
            var toplamtutar = c.SatisHarekets.Where(x => x.Cari_ID == mailid).Sum(y => y.SatisHareket_ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
          
            var toplamurunsayisi = c.SatisHarekets.Where(x => x.Cari_ID == mailid).Sum(y => y.SatisHareket_Adet);
            ViewBag.toplamurun = toplamurunsayisi;
           
            var adsoyad = c.Caris.Where(x => x.Cari_Mail == mail).Select(y => y.Cari_Ad + " " + y.Cari_Soyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var sehir = c.Caris.Where(x => x.Cari_Mail == mail).Select(y => y.Cari_Sehir).FirstOrDefault();
            ViewBag.sehir = sehir;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["Cari_Mail"];
            var id=c.Caris.Where(x=>x.Cari_Mail==mail.ToString()).Select(y=>y.Cari_ID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cari_ID == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Cari_Mail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alici==mail).OrderByDescending(x => x.Mesaj_ID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string) Session["Cari_Mail"];
        var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z=>z.Mesaj_ID).ToList();
        var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.Mesaj_ID == id).ToList();
            var mail = (string)Session["Cari_Mail"];
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;

            return View(degerler);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["Cari_Mail"];
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;

            return View();
        }
        [Authorize] 
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["Cari_Mail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.kargoDetays select x;
           
                k = k.Where(y => y.TakipKodu.Contains(p));
            
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();

            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Cari_Mail"];
            var id =c.Caris.Where(x=>x.Cari_Mail==mail).Select(y=>y.Cari_ID).FirstOrDefault();
            var caribul = c.Caris.Find(id);
            return PartialView("Partial1", caribul);
            
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cari cr)
        {
            var cari = c.Caris.Find(cr.Cari_ID);
            cari.Cari_Ad = cr.Cari_Ad;
            cari.Cari_Soyad = cr.Cari_Soyad;
            cari.Cari_Sifre = cr.Cari_Sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}