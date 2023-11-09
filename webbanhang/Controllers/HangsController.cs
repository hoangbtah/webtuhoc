using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webbanhang.Models;
using PagedList;
using System.IO;

namespace webbanhang.Controllers
{
    public class HangsController : Controller
    {
        private FShopDB db = new FShopDB();

        // GET: Hangs
        public ActionResult Index( string searchstring,string currentFilter,int? page)
        {
            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentFilter;
            }
            ViewBag.CurrentFilter = searchstring;

            var hangs = db.Hangs.Select(h => h);
            hangs = hangs.OrderBy(s => s.MaHang);
            if (!String.IsNullOrEmpty(searchstring))
            {
                hangs = hangs.Where(m => m.TenHang.Contains(searchstring));
            }
          
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(hangs.ToPagedList(pageNumber,pageSize));
        }

        // GET: Hangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Hangs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    hang.HinhAnh = "";
                    var f = Request.Files["imagefile"];
                    if(f!= null&& f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string Uploadpath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(Uploadpath);
                        hang.HinhAnh = FileName;
                    }
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = "Lỗi nhập dữ liệu" + ex.Message;
                ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
                return View(hang);
            }

            
        }

        // GET: Hangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hang.HinhAnh = "";
                    var f = Request.Files["imagefile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string Uploadpath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(Uploadpath);
                        hang.HinhAnh = FileName;
                    }
                    db.Entry(hang).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
           catch(Exception ex)
            {
                ViewBag.error = "Lỗi sửa dữ liệu" + ex.Message;
                ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
                return View(hang);
            }
           
        }

        // GET: Hangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hang hang = db.Hangs.Find(id);
            db.Hangs.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
