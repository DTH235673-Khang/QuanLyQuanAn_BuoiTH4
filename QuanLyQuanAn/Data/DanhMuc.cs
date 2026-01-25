using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class DanhMuc
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public virtual ObservableCollectionListSource<ThucAn> ThucAn { get; } = new();
    }
}
