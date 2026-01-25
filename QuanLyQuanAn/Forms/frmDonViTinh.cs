using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmDonViTinh : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmDonViTinh()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenDonViTinh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<DonViTinh> dvt = new List<DonViTinh>();
            dvt = context.DonViTinh.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dvt;
            txtTenDonViTinh.DataBindings.Clear();
            txtTenDonViTinh.DataBindings.Add("Text", bindingSource, "TenDonViTinh", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenDonViTinh.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa đơn vị tính?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                DonViTinh dvt = context.DonViTinh.Find(id);
                if (dvt != null)
                {
                    context.DonViTinh.Remove(dvt);
                }
                context.SaveChanges();
                frmDonViTinh_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDonViTinh.Text))
                MessageBox.Show("Vui lòng nhập tên đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    DonViTinh dvt=new DonViTinh();
                    dvt.TenDonViTinh = txtTenDonViTinh.Text;
                    context.DonViTinh.Add(dvt);
                    context.SaveChanges();
                }
                else
                {
                    DonViTinh dvt = context.DonViTinh.Find(id);
                    if (dvt != null)
                    {
                        dvt.TenDonViTinh = txtTenDonViTinh.Text;
                        context.DonViTinh.Update(dvt);
                        context.SaveChanges();
                    }
                }
                frmDonViTinh_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmDonViTinh_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
