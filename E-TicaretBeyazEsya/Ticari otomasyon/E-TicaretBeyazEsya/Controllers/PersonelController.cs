using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class PersonelController : Controller
    {
        Context c=new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Departman_Ad,
                                               Value = x.Departman_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi=Path.GetFileName(Request.Files[0].FileName);
                string uzanti=Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Personel_Gorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Departman_Ad,
                                               Value = x.Departman_ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Personel_Gorsel = "/Image/" + dosyaadi + uzanti;
            }
            var prsn=c.Personels.Find(p.Personel_ID);
            prsn.Personel_Ad = p.Personel_Ad;
            prsn.Personel_Soyad = p.Personel_Soyad;
            prsn.Personel_Gorsel = p.Personel_Gorsel;
            prsn.Departman_ID = p.Departman_ID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
        public ActionResult PersonelSil(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Personel p = c.Personels.Find(id);
            c.Personels.Remove(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}