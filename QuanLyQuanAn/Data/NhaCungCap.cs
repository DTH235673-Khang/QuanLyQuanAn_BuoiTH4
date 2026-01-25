using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace QuanLyQuanAn.Data
{
    public class NhaCungCap
    {
        public int ID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ObservableCollectionListSource<PhieuNhapKho> PhieuNhapKho { get; } = new();
    }
}
