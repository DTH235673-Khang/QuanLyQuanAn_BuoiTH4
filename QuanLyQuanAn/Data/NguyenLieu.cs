using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class NguyenLieu
    {
        public int ID { get; set; }
        public string TenNguyenLieu { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public int GiaNhap { get; set; }
        public virtual ObservableCollectionListSource<PhieuNhapKho_ChiTiet> PhieuNhapKho_ChiTiet { get; } = new();

    }
}

