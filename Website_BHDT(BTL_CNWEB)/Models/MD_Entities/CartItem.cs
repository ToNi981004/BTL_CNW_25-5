using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BHDT_BTL_CNWEB_.Models.MD_Entities
{
    public class CartItem
    {
       
            public string Anh { get; set; }
            public string IDSanPham { get; set; }
            public string TenSanPham { get; set; }
            public double? DonGiaB { get; set; }
            public int SoLuong { get; set; }



    }
}