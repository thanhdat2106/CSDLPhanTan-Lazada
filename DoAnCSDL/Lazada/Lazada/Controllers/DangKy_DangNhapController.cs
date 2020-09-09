using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lazada.Models;
namespace Lazada.Controllers
{
    public class DangKy_DangNhapController : Controller
    {
        // GET: DangKy_DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TENTK"];
            var matkhau = collection["MATKHAU"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewBag.Loi1 = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewBag.Loi2 = "Phải nhập mật khẩu";
            }
            else
            {
                string datasourcemn = "DESKTOP - 7U6NLFV\\MSSQLSERVER01";
                string datasourcemt = "DESKTOP - 7U6NLFV\\MSSQLSERVER2";
                string datasourcemb = "DESKTOP - 7U6NLFV\\MSSQLSERVER3";
                string database = "QL_LAZADA";
                QL_LAZADA_MIENNAM dbmn = new QL_LAZADA_MIENNAM();
                TK_KHACHHANG kh = dbmn.TK_KHACHHANG.SingleOrDefault(n => n.TENTK_KH.Equals(tendn) && n.MK_KH.Equals(matkhau));
                TK_NCC admn = dbmn.TK_NCC.SingleOrDefault(n => n.TENTK_NCC.Equals(tendn) && n.MK_KH.Equals(matkhau));
                //if (DBSQLServerUtils.GetDBConnection(datasourcemn, database, tendn, matkhau) == true &&
                //    DBSQLServerUtils.GetDBConnection(datasourcemt, database, tendn, matkhau) == true &&
                //    DBSQLServerUtils.GetDBConnection(datasourcemb, database, tendn, matkhau) == true)
                if(tendn=="AD004" && matkhau=="123")
                {                 
                    Session["tenncc"] = tendn;
                    Session["makv"] = "Miền Nam";
                    Session["quyen"] = "all";
                    Session["Admin"] = tendn;
                    Session["mancc"] = "KV001";
                    return RedirectToAction("TrangAdmin", "Admin");
                }
                //else if(DBSQLServerUtils.GetDBConnection(datasourcemn, database, tendn, matkhau) == true)
                else if(tendn == "AD001" && matkhau == "123")
                {                  
                    Session["tenncc"] = tendn;
                    Session["makv"] = "Miền Nam";
                    Session["quyen"] = "miennam";
                    Session["mancc"] = "KV001";
                    return RedirectToAction("TrangAdmin", "Admin");
                }
                //else if (DBSQLServerUtils.GetDBConnection(datasourcemt, database, tendn, matkhau) == true)
                else if (tendn == "AD002" && matkhau == "123")
                {                  
                    Session["tenncc"] = tendn;
                    Session["makv"] = "Miền Trung";
                    Session["quyen"] = "mientrung";
                    Session["Admin"] = tendn;
                    Session["mancc"] = "KV002";
                    return RedirectToAction("TrangAdmin", "Admin");
                }
                //else if (DBSQLServerUtils.GetDBConnection(datasourcemb, database, tendn, matkhau) == true)
                else if (tendn == "AD003" && matkhau == "123")
                {
                    Session["tenncc"] = tendn;
                    Session["makv"] = "Miền Bắc";
                    Session["quyen"] = "mienbac";
                    Session["Admin"] = tendn;
                    Session["mancc"] = "KV003" ;
                    return RedirectToAction("TrangAdmin", "Admin");
                }               
                else if(kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    KHACHHANG username = dbmn.KHACHHANGs.SingleOrDefault(n => n.MATK_KH.Equals(kh.MATK_KH));
                    Session["Tentk"] = username.TENKH;
                    Session["matk"] = kh.MATK_KH;
                    Session["makh"] = username.MAKH;
                    Session["makv"] = "KV001";
                    Session["diachi"] = username.DIACHI;
                    return RedirectToAction("Index", "Home",new {@makv = "KV001" });
                }
                else if (admn != null)
                {
                    ViewBag.Thongbao = "Đăng nhập thành công";
                    Session["Admin"] = admn;
                    NHACUNGCAP ncc = dbmn.NHACUNGCAPs.SingleOrDefault(n => n.MATK_NCC.Equals(admn.MATK_NCC));
                    Session["tenncc"] = ncc.TENNCC;
                    Session["mancc"] = ncc.MANCC;
                    Session["makv"] = "Miền Nam";
                    Session["quyen"] = "miennam";
                    //return RedirectToAction("Home", "Home");
                    return RedirectToAction("TrangAdmin", "Admin");
                }
                else
                {
                    QL_LAZADA_MIENTRUNG dbmt = new QL_LAZADA_MIENTRUNG();
                    TK_KHACHHANG khmt = dbmt.TK_KHACHHANG.SingleOrDefault(n => n.TENTK_KH.Equals(tendn) && n.MK_KH.Equals(matkhau));
                    TK_NCC admt = dbmt.TK_NCC.SingleOrDefault(n => n.TENTK_NCC.Equals(tendn) && n.MK_KH.Equals(matkhau));
                    if(khmt != null)
                    {
                        ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                        Session["Taikhoan"] = khmt;
                        KHACHHANG username = dbmt.KHACHHANGs.SingleOrDefault(n => n.MATK_KH.Equals(khmt.MATK_KH));
                        Session["Tentk"] = username.TENKH;
                        Session["matk"] = khmt.MATK_KH;
                        Session["makh"] = username.MAKH;
                        Session["makv"] = "KV002";
                        Session["diachi"] = username.DIACHI;
                        return RedirectToAction("Index", "Home", new { @makv = "KV002" });
                    }
                    else if (admt != null)
                    {
                        ViewBag.Thongbao = "Đăng nhập thành công";
                        Session["Admin"] = admt;
                        NHACUNGCAP ncc = dbmt.NHACUNGCAPs.SingleOrDefault(n => n.MATK_NCC.Equals(admt.MATK_NCC));
                        Session["tenncc"] = ncc.TENNCC;
                        Session["mancc"] = ncc.MANCC;
                        Session["makv"] = "Miền Trung";
                        Session["quyen"] = "mientrung";
                        //return RedirectToAction("Home", "Home");
                        return RedirectToAction("TrangAdmin", "Admin");
                    }
                    else
                    {
                        QL_LAZADA_MIENBAC1 dbmb = new QL_LAZADA_MIENBAC1();
                        TK_KHACHHANG khmb = dbmb.TK_KHACHHANG.SingleOrDefault(n => n.TENTK_KH.Equals(tendn) && n.MK_KH.Equals(matkhau));
                        TK_NCC admb = dbmb.TK_NCC.SingleOrDefault(n => n.TENTK_NCC.Equals(tendn) && n.MK_KH.Equals(matkhau));
                        if(khmb !=null)
                        {
                            ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                            Session["Taikhoan"] = khmb;
                            KHACHHANG username = dbmb.KHACHHANGs.SingleOrDefault(n => n.MATK_KH.Equals(khmb.MATK_KH));
                            Session["Tentk"] = username.TENKH;
                            Session["matk"] = khmb.MATK_KH;
                            Session["makh"] = username.MAKH;
                            Session["makv"] = "KV003";
                            Session["diachi"] = username.DIACHI;
                            return RedirectToAction("Index", "Home", new { @makv = "KV003" });
                        }
                        else if (admb != null)
                        {
                            ViewBag.Thongbao = "Đăng nhập thành công";
                            Session["Admin"] = admb;
                            NHACUNGCAP ncc = dbmb.NHACUNGCAPs.SingleOrDefault(n => n.MATK_NCC.Equals(admb.MATK_NCC));
                            Session["tenncc"] = ncc.TENNCC;
                            Session["mancc"] = ncc.MANCC;
                            Session["makv"] = "Miền Bắc";
                            Session["quyen"] = "mientrung";
                            //return RedirectToAction("Home", "Home");
                            return RedirectToAction("TrangAdmin", "Admin");
                        }
                        else
                        {
                            ViewBag.Thongbao = "Tên đăng nhập hoặc tài khoản không đúng";
                        }    
                    }
                }
                //if (kh != null || ad != null)
                //{
                //    if (kh != null && ad == null)
                //    {
                //        ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                //        Session["Taikhoan"] = kh;
                //        KHACHHANG username = data.KHACHHANGs.SingleOrDefault(n => n.MATK.Equals(kh.MATK));
                //        Session["Tentk"] = username.TENKH;
                //        Session["matk"] = kh.MATK;
                //        Session["makh"] = username.MAKH;
                //        return RedirectToAction("Home", "Home");

                //    }
                //    if (kh == null && ad != null)
                //    {
                //        ViewBag.Thongbao = "Đăng nhập thành công";
                //        Session["Admin"] = ad;
                //        Session["quyen"] = ad.TENQ;
                //        //return RedirectToAction("Home", "Home");
                //        return RedirectToAction("Homequanly", "Admin");
                //    }
                //}
                //else
                //    ViewBag.Thongbao = "Tên đăng nhập hoặc tài khoản không đúng";
            }

            return View();
        }
        public ActionResult DangXuat()
        {
            if (Session["Taikhoan"] != null)
            {
                Session["Taikhoan"] = null;
                Session["Tentk"] = null;
                Session["Giohang"] = null;
                return RedirectToAction("Index", "Home");
            }
            else if (Session["Admin"] != null)
            {
                Session["Admin"] = null;
                return RedirectToAction("DangNhap", "DangKy_DangNhap");
            }
            else
            {
                return RedirectToAction("DangNhap", "DangKy_DangNhap");
            }
        }
        public PartialViewResult TaiKhoan()
        {
            if (Session["Tenkh"] == null)
                Session["Tenkh"] = " quý khách";
            return PartialView();
        }
        public ActionResult DangKy()
        {
            return RedirectToAction("Admin", "TrangAdmin");
        }
    }
}