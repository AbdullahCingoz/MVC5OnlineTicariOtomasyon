using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretBeyazEsya.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler=c.Uruns.Where(x=>x.Urun_ID==1).ToList(); 
            cs.Deger1 = c.Uruns.Where(x => x.Urun_ID == 1).ToList(); 
            cs.Deger2=c.Detays.Where(y=>y.Detay_ID==1).ToList();
            return View(cs);
        }
    }
}