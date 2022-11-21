using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretBeyazEsya.Models.Tablolar;
using PagedList;
using PagedList.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {

            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Kategori k = c.Kategoris.Find(id);
            c.Kategoris.Remove(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.Kategori_ID);
            ktgr.Kategori_Ad = k.Kategori_Ad;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Deneme()
        {
            Class2 cs = new Class2();
            cs.Kategoriler = new SelectList(c.Kategoris, "Kategori_ID", "Kategori_Ad");
            cs.Urunler = new SelectList(c.Uruns, "Urun_ID", "Urun_Ad");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns
                               join y in c.Kategoris on
                               x.Kategori.Kategori_ID equals y.Kategori_ID
                               where x.Kategori.Kategori_ID == p
                               select new
                               {
                                   Text = x.Urun_Ad,
                                   Value = x.Urun_ID.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}