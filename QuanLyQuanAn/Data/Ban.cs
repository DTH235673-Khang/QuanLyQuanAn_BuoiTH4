using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class Ban
    {
        public int ID { get; set; }
        public string TenBan { get; set; }
        public int SucChua { get; set; }
        public string TrangThai { get; set; }

        public virtual ObservableCollectionListSource<HoaDon> HoaDon{ get; } = new();
    }
}
