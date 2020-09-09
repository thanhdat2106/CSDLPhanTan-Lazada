using Lazada.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web;
using System.Net;

namespace Lazada.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        QL_LAZADA_MIENNAM dbmn = new QL_LAZADA_MIENNAM();
        QL_LAZADA_MIENTRUNG dbmt = new QL_LAZADA_MIENTRUNG();
        QL_LAZADA_MIENBAC1 dbmb = new QL_LAZADA_MIENBAC1();
        public ActionResult TrangAdmin()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("DangNhap", "DangKy_DangNhap");
            }

        }
        public ActionResult Quanlysanpham(string id)
        {
            if (id == "KV001")
            {
                return View(dbmn.SANPHAMs.ToList());
            }
            else if (id == "KV002")
            {
                return View(dbmt.SANPHAMs.ToList());
            }
            else if (id == "KV003")
            {
                return View(dbmb.SANPHAMs.ToList());
            }
            else
            {
                if (Session["makv"].ToString() == "Miền Nam")
                {
                    return View(dbmn.SANPHAMs.Where(sp => sp.MANCC == id).ToList());
                }
                else if (Session["makv"].ToString() == "Miền Trung")
                {
                    return View(dbmt.SANPHAMs.Where(sp => sp.MANCC == id).ToList());
                }
                else
                {
                    return View(dbmb.SANPHAMs.Where(sp => sp.MANCC == id).ToList());
                }
            }
        }

        public ActionResult CreateSP()
        {
            ViewBag.MALOAI = new SelectList(dbmn.LOAIHANGs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateSP(SANPHAM sp, HttpPostedFileBase file, FormCollection col)
        {
            // try
            //{
            //    if (Session["Admin"] == null)
            //        return RedirectToAction("DangNhap", "DangKy_DangNhap");
            //    else
            //    {
            ViewBag.MALOAI = new SelectList(dbmn.LOAIHANGs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            if (col["picture"] == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {

                var kt = dbmn.SANPHAMs.Find(col["MASP"]);
                var kt1 = dbmt.SANPHAMs.Find(col["MASP"]);
                var kt2 = dbmb.SANPHAMs.Find(col["MASP"]);
                //if (Session["makv"].ToString() == "Miền Nam" || Session["makv"].ToString() == "Miền Trung" || Session["makv"].ToString() == "Miền Bắc")
                //{
                //    if (kt == null && kt1 == null && kt2 == null)
                //    {
                //        string[] a = col["picture"].Split('/');
                //        sp.MASP = col["MASP"];
                //        sp.MANCC = Session["mancc"].ToString().Trim();
                //        sp.TENSP = col["TENSP"];
                //        sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                //        sp.DVT = col["DVT"];
                //        sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                //        sp.MALOAI = col["MALOAI"];
                //        sp.KICHTHUOC = col["KICHTHUOC"];
                //        sp.TRONGLUONG = col["TRONGLUONG"];
                //        sp.MAUSAC = col["MAUSAC"];
                //        sp.ANH = a[3];
                //        sp.rowguid = System.Guid.NewGuid();
                //        dbmn.SANPHAMs.Add(sp);
                //        dbmn.SaveChanges();
                //        return RedirectToAction("Quanlysanpham", "Admin", new { @id = sp.MANCC });
                //    }
                //else
                //{
                if (kt == null && kt1 == null && kt2 == null)
                {
                    if (Session["makv"].ToString() == "Miền Nam")
                    {
                        string[] a = col["picture"].Split('/');
                        sp.MASP = col["MASP"];
                        sp.MANCC = Session["mancc"].ToString().Trim();
                        sp.TENSP = col["TENSP"];
                        sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                        sp.DVT = col["DVT"];
                        sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                        sp.MALOAI = col["MALOAI"];
                        sp.KICHTHUOC = col["KICHTHUOC"];
                        sp.TRONGLUONG = col["TRONGLUONG"];
                        sp.MAUSAC = col["MAUSAC"];
                        sp.ANH = a[3].ToString();
                        sp.rowguid = System.Guid.NewGuid();
                        dbmn.SANPHAMs.Add(sp);
                        dbmn.SaveChanges();
                        return RedirectToAction("Quanlysanpham", "Admin", new { @id = sp.MANCC });
                    }
                    else if (Session["makv"].ToString() == "Miền Trung")
                    {
                        string[] a = col["picture"].Split('/');
                        sp.MASP = col["MASP"];
                        sp.MANCC = Session["mancc"].ToString().Trim();
                        sp.TENSP = col["TENSP"];
                        sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                        sp.DVT = col["DVT"];
                        sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                        sp.MALOAI = col["MALOAI"];
                        sp.KICHTHUOC = col["KICHTHUOC"];
                        sp.TRONGLUONG = col["TRONGLUONG"];
                        sp.MAUSAC = col["MAUSAC"];
                        sp.ANH = a[3].ToString();
                        sp.rowguid = System.Guid.NewGuid();
                        dbmt.SANPHAMs.Add(sp);
                        dbmt.SaveChanges();
                        return RedirectToAction("Quanlysanpham", "Admin", new { @id = sp.MANCC });
                    }
                    else
                    {
                        string[] a = col["picture"].Split('/');
                        sp.MASP = col["MASP"];
                        sp.MANCC = Session["mancc"].ToString().Trim();
                        sp.TENSP = col["TENSP"];
                        sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                        sp.DVT = col["DVT"];
                        sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                        sp.MALOAI = col["MALOAI"];
                        sp.KICHTHUOC = col["KICHTHUOC"];
                        sp.TRONGLUONG = col["TRONGLUONG"];
                        sp.MAUSAC = col["MAUSAC"];
                        sp.ANH = a[3].ToString();
                        sp.rowguid = System.Guid.NewGuid();
                        dbmb.SANPHAMs.Add(sp);
                        dbmb.SaveChanges();
                        return RedirectToAction("Quanlysanpham", "Admin", new { @id = sp.MANCC });
                    }
                }

                return View();
            }
            //}
            //}
            //}
            //catch { }
            //return View();
        }
        public string ProcessCreate(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Content/HinhAnh/" + file.FileName));
            return "/Content/HinhAnh/" + file.FileName;
        }
        public ActionResult khuvuc(string kv)
        {
            try
            {
                if (Session["quyen"].ToString() == "all")
                {
                    Session["makv"] = kv;
                    if (kv == "Miền Nam")
                    {
                        Session["mancc"] = "KV001";
                    }
                    else if (kv == "Miền Trung")
                    {
                        Session["mancc"] = "KV002";
                    }
                    else
                    {
                        Session["mancc"] = "KV003";
                    }
                }
            }
            catch { }
            return RedirectToAction("TrangAdmin", "Admin");
        }
        public ActionResult loadkv()
        {
            return PartialView();

        }
        public ActionResult QLtaikhoan()
        {
            return PartialView();

        }
        public ActionResult Delete(string masp)
        {
            if (masp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sp = new SANPHAM();
            if (Session["makv"].ToString() == "Miền Nam")
            {
                 sp = dbmn.SANPHAMs.Find(masp);
                if (sp == null)
                {
                    return HttpNotFound();
                }
               
            }
            else if (Session["makv"].ToString() == "Miền Trung")
            {
                 sp = dbmt.SANPHAMs.Find(masp);
                if (sp == null)
                {
                    return HttpNotFound();
                }
                
            }
            else if (Session["makv"].ToString() == "Miền Bắc")
            {
                 sp = dbmb.SANPHAMs.Find(masp);
                if (sp == null)
                {
                    return HttpNotFound();
                }
               
            }
            return View(sp);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string masp)
        {
           
                if (Session["Admin"] == null)
                    return RedirectToAction("DangNhap", "DangKy_DangNhap");
                else 
                {
                    if(Session["makv"].ToString()=="Miền Nam")
                    {
                        SANPHAM sp = dbmn.SANPHAMs.Find(masp);
                        dbmn.SANPHAMs.Remove(sp);
                        dbmn.SaveChanges();
                        return RedirectToAction("Quanlysanpham","Admin",new {@id = Session["mancc"].ToString().Trim() });
                    }  
                    else if(Session["makv"].ToString() == "Miền Trung")
                    {
                        var sp = dbmt.SANPHAMs.SingleOrDefault(s => s.MASP == masp);
                        dbmt.SANPHAMs.Remove(sp);
                        dbmt.SaveChanges();
                        return RedirectToAction("Quanlysanpham", "Admin", new { @id = Session["mancc"].ToString().Trim() });
                    }
                    else if(Session["makv"].ToString() == "Miền Bắc")
                    {
                        var sp = dbmb.SANPHAMs.SingleOrDefault(s => s.MASP == masp);
                        dbmb.SANPHAMs.Remove(sp);
                        dbmb.SaveChanges();
                        return RedirectToAction("Quanlysanpham", "Admin", new { @id = Session["mancc"].ToString().Trim() });
                    }    
                   
                }              
            
            return RedirectToAction("TrangAdmin", "Admin");
        }
        [HttpGet]
        public ActionResult Edit(string masp)
        {
            if (masp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sp = new SANPHAM();
            if (Session["makv"].ToString() == "Miền Nam")
            {
                sp = dbmn.SANPHAMs.Find(masp);
                ViewBag.MALOAI = new SelectList(dbmn.LOAIHANGs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
                if (sp == null)
                {
                    return HttpNotFound();
                }

            }
            else if (Session["makv"].ToString() == "Miền Trung")
            {
                sp = dbmt.SANPHAMs.Find(masp);
                ViewBag.MALOAI = new SelectList(dbmt.LOAIHANGs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
                if (sp == null)
                {
                    return HttpNotFound();
                }

            }
            else if (Session["makv"].ToString() == "Miền Bắc")
            {
                sp = dbmb.SANPHAMs.Find(masp);
                ViewBag.MALOAI = new SelectList(dbmb.LOAIHANGs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
                if (sp == null)
                {
                    return HttpNotFound();
                }

            }
            return View(sp);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult updateEdit(SANPHAM sp, HttpPostedFileBase file, FormCollection col)
        {
            
            if (file == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {
                if (Session["makv"].ToString() == "Miền Nam")
                {
                    string[] a = col["picture"].Split('/');
                    sp.MASP = col["MASP"];
                    sp.MANCC = Session["mancc"].ToString().Trim();
                    sp.TENSP = col["TENSP"];
                    sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                    sp.DVT = col["DVT"];
                    sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                    sp.MALOAI = col["MALOAI"];
                    sp.KICHTHUOC = col["KICHTHUOC"];
                    sp.TRONGLUONG = col["TRONGLUONG"];
                    sp.MAUSAC = col["MAUSAC"];
                    sp.ANH = a[3].ToString();
                    sp.rowguid = System.Guid.Parse(col["rowguid"]);
                    UpdateModel(sp);
                    dbmn.SaveChanges();
                    return RedirectToAction("Quanlysanpham", "Admin", new { @id = Session["mancc"].ToString().Trim() });
                }
                else if (Session["makv"].ToString() == "Miền Trung")
                {
                    string[] a = col["picture"].Split('/');
                    sp.MASP = col["MASP"];
                    sp.MANCC = Session["mancc"].ToString().Trim();
                    sp.TENSP = col["TENSP"];
                    sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                    sp.DVT = col["DVT"];
                    sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                    sp.MALOAI = col["MALOAI"];
                    sp.KICHTHUOC = col["KICHTHUOC"];
                    sp.TRONGLUONG = col["TRONGLUONG"];
                    sp.MAUSAC = col["MAUSAC"];
                    sp.ANH = a[3].ToString();
                    sp.rowguid = System.Guid.Parse(col["rowguid"]);
                    UpdateModel(sp);
                    dbmt.SaveChanges();
                    return RedirectToAction("Quanlysanpham", "Admin", new { @id = Session["mancc"].ToString().Trim() });
                }
                else if(Session["makv"].ToString() == "Miền Bắc")
                {
                    string[] a = col["picture"].Split('/');
                    sp.MASP = col["MASP"];
                    sp.MANCC = Session["mancc"].ToString().Trim();
                    sp.TENSP = col["TENSP"];
                    sp.DONGIA = int.Parse(col["DONGIA"].ToString());
                    sp.DVT = col["DVT"];
                    sp.SOLUONG = int.Parse(col["SOLUONG"].ToString());
                    sp.MALOAI = col["MALOAI"];
                    sp.KICHTHUOC = col["KICHTHUOC"];
                    sp.TRONGLUONG = col["TRONGLUONG"];
                    sp.MAUSAC = col["MAUSAC"];
                    sp.ANH = a[3].ToString();
                    sp.rowguid = System.Guid.Parse(col["rowguid"]);
                    UpdateModel(sp);
                    dbmb.SaveChanges();
                    return RedirectToAction("Quanlysanpham", "Admin", new { @id = Session["mancc"].ToString().Trim() });
                }

                return View();
            }



        }

    }
    

}