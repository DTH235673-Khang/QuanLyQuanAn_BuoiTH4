using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyQuanAn.Data
{
    public class QLQADbContext: DbContext
    {
        public DbSet<Ban> Ban { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<DonViTinh> DonViTinh { get; set; }
        public DbSet<ThucAn> ThucAn { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<NguyenLieu> NguyenLieu { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKho { get; set; }
        public DbSet<PhieuNhapKho_ChiTiet> PhieuNhapKho_ChiTiet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLQAConnection"].ConnectionString);
        }
    }
}
