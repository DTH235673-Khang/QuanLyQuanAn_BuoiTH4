using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    public class PhieuNhapKho_ChiTiet
    {
        public int ID { get; set; }
        public int PhieuNhapKhoID { get; set; }
        public int NguyenLieuID { get; set; }
        public int SoLuongNhap { get; set; }
        public int GiaNhap { get; set; }
        public virtual PhieuNhapKho PhieuNhapKho { get; set; } = null!;
        public virtual NguyenLieu NguyenLieu { get; set; } = null!;
    }
}
