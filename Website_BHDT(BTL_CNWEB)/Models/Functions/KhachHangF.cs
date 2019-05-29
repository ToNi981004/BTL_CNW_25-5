﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_BHDT_BTL_CNWEB_.Models.MD_Entities;
namespace Website_BHDT_BTL_CNWEB_.Models.Functions
{
    public class KhachHangF
    {

        DBContext_Entities context;
        public KhachHangF()
        {
            context = new DBContext_Entities();
        }

        /// <summary>
        /// Trả về list nhà cung cấp
        /// </summary>
        public IQueryable<KhachHang> KhachHangs
        {

            get { return context.KhachHangs; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(KhachHang model)
        {
            KhachHang dbEntry = context.KhachHangs.Find(model.IDKhachHang);

            if (dbEntry != null)
            {
                return false;

            }
            else
            {
                context.KhachHangs.Add(model);

                context.SaveChanges();

                return true;
            }
           
       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(KhachHang model)
        {
            KhachHang dbEntry = context.KhachHangs.Find(model.IDKhachHang);

            if (dbEntry == null)
            {
                return false;
            }
            else
            {
                dbEntry.Ho = model.Ho;
                dbEntry.Ten = model.Ten;
                dbEntry.GioiTinh_KH = model.GioiTinh_KH;
                dbEntry.TenCongTy = model.TenCongTy;
                dbEntry.SDT_KH = model.SDT_KH;
                dbEntry.DiaChi_KH = model.DiaChi_KH;
                dbEntry.ThanhPho = model.ThanhPho;
                dbEntry.Quan = model.Quan;
                dbEntry.MaBuuDien = model.MaBuuDien;
                dbEntry.DiaChiEmail = model.DiaChiEmail;
                dbEntry.TongTienMua = model.TongTienMua;
                dbEntry.MatKhau = model.MatKhau;
                context.SaveChanges();
                return true;
            }
            
        }
        public bool UpdateTT(KhachHang model)
        {
            KhachHang dbEntry = context.KhachHangs.Find(model.IDKhachHang);

            if (dbEntry == null)
            {
                return false;
            }
            else
            {
                dbEntry.Ho = model.Ho;
                dbEntry.Ten = model.Ten;
                dbEntry.GioiTinh_KH = model.GioiTinh_KH;
                dbEntry.TenCongTy = model.TenCongTy;
                dbEntry.SDT_KH = model.SDT_KH;
                dbEntry.DiaChi_KH = model.DiaChi_KH;
                dbEntry.ThanhPho = model.ThanhPho;
                dbEntry.Quan = model.Quan;
                dbEntry.MaBuuDien = model.MaBuuDien;
                dbEntry.DiaChiEmail = model.DiaChiEmail;
                context.SaveChanges();
                return true;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MaSP"></param>
        /// <returns></returns>
        public bool Delete_KhachHang(string IDKhachHang)
        {
            KhachHang dbEntry = context.KhachHangs.Find(IDKhachHang);
            if (dbEntry == null)
            {
                return false;
            }
            else
            {
                context.KhachHangs.Remove(dbEntry);
                context.SaveChanges();
                return true;
            }
           
        }
        public KhachHang FindEntity(string MaKH)
        {
            KhachHang dbEntry = context.KhachHangs.Find(MaKH);
            return dbEntry;
        }




    }
}