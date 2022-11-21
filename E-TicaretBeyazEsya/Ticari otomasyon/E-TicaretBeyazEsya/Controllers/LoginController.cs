using E_TicaretBeyazEsya.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_TicaretBeyazEsya.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cari p)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.Cari_Mail == p.Cari_Mail && x.Cari_Sifre == p.Cari_Sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Cari_Mail, false);
                Session["Cari_Mail"] = bilgiler.Cari_Mail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Admin_KullaniciAd == p.Admin_KullaniciAd && x.Admin_Sifre == p.Admin_Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Admin_KullaniciAd, false);
                Session["Admin_KullaniciAd"] = bilgiler.Admin_KullaniciAd.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}