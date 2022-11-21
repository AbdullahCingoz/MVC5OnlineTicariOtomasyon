using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretBeyazEsya.Models.Tablolar;

namespace E_TicaretBeyazEsya.Controllers
{

    public class DepartmanController : Controller
    {
        Context c = new Context();
        // GET: Departman

        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
      
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir",dpt);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept = c.Departmans.Find(d.Departman_ID); 
            dept.Departman_Ad = d.Departman_Ad;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departman_ID == id).ToList();
            var dpt = c.Departmans.Where(x => x.Departman_ID == id).Select(y => y.Departman_Ad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personel_ID == id).ToList();
            var per = c.Personels.Where(x => x.Personel_ID == id).Select(y => y.Personel_Ad +" "+ y.Personel_Soyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(degerler);
        }
      

    }
}