﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project3_MainWF.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DMH> DMHs { get; set; }
        public virtual DbSet<DMKH> DMKHs { get; set; }
        public virtual DbSet<HDBH> HDBHs { get; set; }
        public virtual DbSet<HDBHCT> HDBHCTs { get; set; }
        public virtual DbSet<HDNhap> HDNhaps { get; set; }
        public virtual DbSet<HDNhapCT> HDNhapCTs { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
    
        public virtual ObjectResult<BaoCaoChiTietCongNo_Result> BaoCaoChiTietCongNo(Nullable<int> maKH, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maKHParameter = maKH.HasValue ?
                new ObjectParameter("MaKH", maKH) :
                new ObjectParameter("MaKH", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BaoCaoChiTietCongNo_Result>("BaoCaoChiTietCongNo", maKHParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<LayThongTinNhapVoiMhVaDate_Result> LayThongTinNhapVoiMhVaDate(Nullable<int> maHang, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maHangParameter = maHang.HasValue ?
                new ObjectParameter("MaHang", maHang) :
                new ObjectParameter("MaHang", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayThongTinNhapVoiMhVaDate_Result>("LayThongTinNhapVoiMhVaDate", maHangParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<LayThongTinNhapVoiMkhVaDate_Result> LayThongTinNhapVoiMkhVaDate(Nullable<int> maKhachHang, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maKhachHangParameter = maKhachHang.HasValue ?
                new ObjectParameter("MaKhachHang", maKhachHang) :
                new ObjectParameter("MaKhachHang", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayThongTinNhapVoiMkhVaDate_Result>("LayThongTinNhapVoiMkhVaDate", maKhachHangParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<LayThongTinXuatVoiMhVaDate_Result> LayThongTinXuatVoiMhVaDate(Nullable<int> maHang, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maHangParameter = maHang.HasValue ?
                new ObjectParameter("MaHang", maHang) :
                new ObjectParameter("MaHang", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayThongTinXuatVoiMhVaDate_Result>("LayThongTinXuatVoiMhVaDate", maHangParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<LayThongTinXuatVoiMkhVaDate_Result> LayThongTinXuatVoiMkhVaDate(Nullable<int> maKhachHang, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maKhachHangParameter = maKhachHang.HasValue ?
                new ObjectParameter("MaKhachHang", maKhachHang) :
                new ObjectParameter("MaKhachHang", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayThongTinXuatVoiMkhVaDate_Result>("LayThongTinXuatVoiMkhVaDate", maKhachHangParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<thekho_Result> thekho(Nullable<int> mahang, Nullable<System.DateTime> ngaybd, Nullable<System.DateTime> ngaykt)
        {
            var mahangParameter = mahang.HasValue ?
                new ObjectParameter("mahang", mahang) :
                new ObjectParameter("mahang", typeof(int));
    
            var ngaybdParameter = ngaybd.HasValue ?
                new ObjectParameter("ngaybd", ngaybd) :
                new ObjectParameter("ngaybd", typeof(System.DateTime));
    
            var ngayktParameter = ngaykt.HasValue ?
                new ObjectParameter("ngaykt", ngaykt) :
                new ObjectParameter("ngaykt", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<thekho_Result>("thekho", mahangParameter, ngaybdParameter, ngayktParameter);
        }
    
        public virtual ObjectResult<TheKhoHang_Result> TheKhoHang(Nullable<int> maHang, Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var maHangParameter = maHang.HasValue ?
                new ObjectParameter("MaHang", maHang) :
                new ObjectParameter("MaHang", typeof(int));
    
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TheKhoHang_Result>("TheKhoHang", maHangParameter, ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<thongTinBanCTByDate_Result> thongTinBanCTByDate(Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc)
        {
            var ngayBatDauParameter = ngayBatDau.HasValue ?
                new ObjectParameter("ngayBatDau", ngayBatDau) :
                new ObjectParameter("ngayBatDau", typeof(System.DateTime));
    
            var ngayKetThucParameter = ngayKetThuc.HasValue ?
                new ObjectParameter("ngayKetThuc", ngayKetThuc) :
                new ObjectParameter("ngayKetThuc", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<thongTinBanCTByDate_Result>("thongTinBanCTByDate", ngayBatDauParameter, ngayKetThucParameter);
        }
    
        public virtual ObjectResult<thongTinNhapCTByDate_Result> thongTinNhapCTByDate(Nullable<System.DateTime> ngayBatDau, Nullable<System.DateTime> ngayKetThuc)
        {
            var ngayBatDauParameter = ngayBatDau.HasValue ?
                new ObjectParameter("ngayBatDau", ngayBatDau) :
                new ObjectParameter("ngayBatDau", typeof(System.DateTime));
    
            var ngayKetThucParameter = ngayKetThuc.HasValue ?
                new ObjectParameter("ngayKetThuc", ngayKetThuc) :
                new ObjectParameter("ngayKetThuc", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<thongTinNhapCTByDate_Result>("thongTinNhapCTByDate", ngayBatDauParameter, ngayKetThucParameter);
        }
    
        public virtual ObjectResult<TimPhieuThu_Result> TimPhieuThu(Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TimPhieuThu_Result>("TimPhieuThu", ngayBDParameter, ngayKTParameter);
        }
    
        public virtual ObjectResult<TongHopXuatNhapTon_Result> TongHopXuatNhapTon(Nullable<System.DateTime> ngayBD, Nullable<System.DateTime> ngayKT)
        {
            var ngayBDParameter = ngayBD.HasValue ?
                new ObjectParameter("NgayBD", ngayBD) :
                new ObjectParameter("NgayBD", typeof(System.DateTime));
    
            var ngayKTParameter = ngayKT.HasValue ?
                new ObjectParameter("NgayKT", ngayKT) :
                new ObjectParameter("NgayKT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TongHopXuatNhapTon_Result>("TongHopXuatNhapTon", ngayBDParameter, ngayKTParameter);
        }
    }
}