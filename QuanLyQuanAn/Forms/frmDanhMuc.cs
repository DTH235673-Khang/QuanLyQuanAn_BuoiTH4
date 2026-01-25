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
    public partial class frmDanhMuc : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenDanhMuc.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<DanhMuc> lsp = new List<DanhMuc>();
            lsp = context.DanhMuc.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;
            txtTenDanhMuc.DataBindings.Clear();
            txtTenDanhMuc.DataBindings.Add("Text", bindingSource, "TenDanhMuc", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenDanhMuc.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    DanhMuc dam = new DanhMuc();
                    dam.TenDanhMuc = txtTenDanhMuc.Text;
                    context.DanhMuc.Add(dam);
                    context.SaveChanges();
                }
                else
                {
                    DanhMuc dam = context.DanhMuc.Find(id);
                    if (dam != null)
                    {
                        dam.TenDanhMuc = txtTenDanhMuc.Text;
                        context.DanhMuc.Update(dam);
                        context.SaveChanges();
                    }
                }
                frmDanhMuc_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa danh mục?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                DanhMuc dam = context.DanhMuc.Find(id);
                if (dam != null)
                {
                    context.DanhMuc.Remove(dam);
                }
                context.SaveChanges();
                frmDanhMuc_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmDanhMuc_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
