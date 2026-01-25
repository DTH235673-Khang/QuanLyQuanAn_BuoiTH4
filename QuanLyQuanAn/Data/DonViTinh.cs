using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class DonViTinh
    {
        public int Id { get; set; }
        public string TenDonViTinh { get; set; }
        public virtual ObservableCollectionListSource<ThucAn> ThucAn { get; } = new();
    }
}
