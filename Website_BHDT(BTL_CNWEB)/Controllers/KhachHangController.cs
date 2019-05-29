using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BHDT_BTL_CNWEB_.Models.Functions;
using Website_BHDT_BTL_CNWEB_.Models.MD_Entities;
using System.Data;
using System.Data.SqlClient;
namespace Website_BHDT_BTL_CNWEB_.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            var model = new KhachHangF().KhachHangs.ToList();
            return View(model);
        }
        public ActionResult ThongTin_KH(string IDKhachHang)
        {
            var model = new KhachHangF().FindEntity(IDKhachHang);
            return View(model);
        }
        public ActionResult Xoa_KH(string IDKhachHang)
        {
            KhachHangF khf = new KhachHangF();
            if (khf.Delete_KhachHang(IDKhachHang) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Sua_KhacHang(string IDKhacHang)
        {

            var model = new KhachHangF().FindEntity(IDKhacHang);
            return View(model);

        }

        [HttpPost]
        public ActionResult Sua_KhacHang(KhachHang kh)
        {
            KhachHangF khf = new KhachHangF();
            if(khf.Update(kh)==true)
            {
                return View(kh.IDKhachHang);
            }
            else
            {
                ViewBag.BaoLoiSua = "Sửa Không Thành Công";
                return View(kh.IDKhachHang);
            }
        }

        [HttpPost]
        public ActionResult DoiMatKhau(string IDKhachHang,string MatKhau,string MK1,string MK2)
            {
            KhachHangF khf = new KhachHangF();
            KhachHang kh = khf.FindEntity(IDKhachHang);
            if(kh.MatKhau!=MatKhau)
            {
                TempData["msg7"] = "Mật khẩu không đúng mới mật khẩu cũ";
                return View("NguoiDung", IDKhachHang);
            }
            else
            {
                if(MK1!=MK2)
                {
                    kh.IDKhachHang = IDKhachHang;
                    TempData["msg8"] = "Mật khẩu lần 2 không đúng mới mật khẩu lần 1";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    kh.IDKhachHang = IDKhachHang;
                    kh.MatKhau = MK1;
                    if(khf.Update(kh)==true)
                    {
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                    return View("NguoiDung", "My", kh);

                }
            }

            // tìm kiếm KH theo ID

        }
        [HttpPost]
        public ActionResult CapNhatKH(KhachHang kh)
        {
            KhachHangF khf = new KhachHangF();
            if(khf.UpdateTT(kh)== true)
            {
                return RedirectToAction("NguoiDung","My",kh);
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}