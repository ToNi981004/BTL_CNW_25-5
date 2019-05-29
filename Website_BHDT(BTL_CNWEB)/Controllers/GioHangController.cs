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
    public class GioHangController : Controller
    {
        DBContext_Entities db = new DBContext_Entities();
        // GET: GioHang
        public ActionResult Index()
        {
            if(Session["giohang"]==null)
            {
                TempData["msg4"] = "Giỏ Hàng Của Bạn Rỗng!";
                ViewBag.TenTK = Session["TenTK"];
                return RedirectToAction("Index", "My");
            }
            else
            {
                ViewBag.TenTK = Session["TenTK"];
                List<CartItem> giohang = Session["giohang"] as List<CartItem>;
                return View(giohang);
            }
            
        }
        public ActionResult ThemVaoGio(string IDSanPham)
        {

            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.IDSanPham==IDSanPham) == null)
            {
                SanPham sp = db.SanPhams.Find(IDSanPham);  // tim sp theo sanPhamID

                CartItem newItem = new CartItem()
                {
                    IDSanPham = IDSanPham,
                    TenSanPham = sp.TenSanPham,
                    Anh = sp.Anh,
                    SoLuong = 1,
                    DonGiaB = sp.DonGiaB

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.IDSanPham == IDSanPham);
                cardItem.SoLuong++;
                return Redirect(Request.UrlReferrer.ToString());
            }

            

        }
        public RedirectToRouteResult XoaKhoiGio(string IDSanPham)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.IDSanPham == IDSanPham);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
        //public ActionResult ThanhToan(string IDSanPham,int SoLuong)
        //{
        //    ChiTietHoaDonF ctf = new ChiTietHoaDonF();
        //    ChiTietHoaDon ct = new ChiTietHoaDon();

        //    ct.IDSanPham = IDSanPham;
        //    ct.SoLuong = SoLuong;
        //    if(ctf.Insert_ChiTietHD(ct)==true)
        //    {
        //        return Redirect(Request.UrlReferrer.ToString());
        //    }
        //    return Redirect(Request.UrlReferrer.ToString());
        //}
        //public ActionResult SuLiThanhToan(string IDSanPham, int SoLuong)
        //{
        //    ChiTietHoaDonF ctf = new ChiTietHoaDonF();
        //    ChiTietHoaDon ct = new ChiTietHoaDon();

        //    ct.IDSanPham = IDSanPham;
        //    ct.SoLuong = SoLuong;
        //    if (ctf.Insert_ChiTietHD(ct) == true)
        //    {
        //        return Redirect(Request.UrlReferrer.ToString());
        //    }
        //    return Redirect(Request.UrlReferrer.ToString());
        //}

        //public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        //{
        //    // tìm carditem muon sua
        //    List<CartItem> giohang = Session["giohang"] as List<CartItem>;
        //    CartItem itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
        //    if (itemSua != null)
        //    {
        //        itemSua.SoLuong = soluongmoi;
        //    }
        //    return RedirectToAction("Index");

        //}


    }
}