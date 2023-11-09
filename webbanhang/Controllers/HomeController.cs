using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbanhang.Models;

namespace webbanhang.Controllers
{
    public class HomeController : Controller
    {
        private FShopDB db = new FShopDB();
        public ActionResult Index()
        {
            if(Session["IdUser"]!=null)
            {
                return RedirectToAction("Index", "Hangs");
            }    
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "manguoidung,hoten,matkhau,email")] nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.nguoidungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(nguoidung);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string matkhau)
        {
            if (ModelState.IsValid)
            {
                var user = db.nguoidungs.Where(m => m.email.Equals(email) &&
                  m.matkhau.Equals(matkhau)).ToList();
                if(user.Count()>0)
                {
                    Session["HoTen"] = user.FirstOrDefault().hoten;
                    Session["Email"] = user.FirstOrDefault().email;
                    Session["IdUser"] = user.FirstOrDefault().manguoidung;
                    return RedirectToAction("Index","Hangs");
                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công,sai tên đăng nhập hoặc mật khẩu";
                }
                
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");

        }

    }
}