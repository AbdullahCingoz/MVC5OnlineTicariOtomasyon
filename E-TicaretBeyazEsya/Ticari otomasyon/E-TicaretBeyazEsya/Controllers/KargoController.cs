using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karaketler = { "A", "B", "C", "D","E","F","G","H"};
            int k1, k2, k3;
            k1 = rnd.Next(0, karaketler.Length);
            k2 = rnd.Next(0, karaketler.Length);
            k3 = rnd.Next(0, karaketler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karaketler[k1] + s2 + karaketler[k2] + s3 + karaketler[k3];
            ViewBag.takipkod = kod;

            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay k)
        {
            c.kargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
          
            return View(degerler);
        }
    }
}