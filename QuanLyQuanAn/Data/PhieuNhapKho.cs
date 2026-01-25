using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class PhieuNhapKho
    {
        public int ID { get; set; }
        public DateTime NgayNhap { get; set; }
        public int NhanVienID { get; set; }
        public int NhaCungCapID { get; set; }
       
        public virtual NhanVien NhanVien { get; set; } = null!;
        public virtual NhaCungCap NhaCungCap { get; set; } = null!;

        public virtual ObservableCollectionListSource<PhieuNhapKho_ChiTiet> PhieuNhapKho_ChiTiet { get; } = new();
    }
}

