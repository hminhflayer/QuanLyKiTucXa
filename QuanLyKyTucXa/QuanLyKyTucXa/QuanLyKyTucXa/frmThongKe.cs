using QuanLyKyTucXa.DataAccessObject;
using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKyTucXa
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadKhu();
            LoadThongKeList();
            
        }

        #region Methods

        public void LoadKhu()
        {
            List<Khu> list = KhuDAO.Instance.GetListKhu();
            cmbKhu.DataSource = list;
            cmbKhu.DisplayMember = "TENKHU";
            cmbKhu.ValueMember = "MAKHU";
        }

        public void LoadPhongbyKhu(string maKhu)
        {
            List<Phong> list = PhongDAO.Instance.GetListPhongByKhuOfPhong(maKhu);
            cmbPhong.DataSource = list;
            cmbPhong.DisplayMember = "MAPHONG";
        }

        public void LoadThongKeList()
        {
            dgvThongKe.DataSource = ThongKeDAO.Instance.LoadThongKeList();
        }

        public string GetValuePhong()
        {
            string maPhong;

            Phong phong = cmbPhong.SelectedItem as Phong;
            maPhong = phong.MaPhong;

            return maPhong;
        }

        public int Ktra()
        {
            for (int i = 0; i < dgvThongKe.RowCount - 1; i++)
            {
                if (txtMaHoaDon.Text.ToUpper() == dgvThongKe.Rows[i].Cells["MAHOADON"].Value.ToString())
                {
                    return 0;
                }
            }
            return 1;
        }

        public void ClearTextThongKe()
        {
            txtMaHoaDon.Clear();
            txtSoDien.Clear();
            txtSoNuoc.Clear();
            txtGiaDien.Clear();
            txtGiaNuoc.Clear();
            txtTienPhong.Clear();

            txtMaHoaDon.Focus();
        }
        #endregion

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKhu;

            ComboBox cmb = sender as ComboBox;

            if (cmb.SelectedItem == null)
            {
                return;
            }

            Khu khu = cmb.SelectedItem as Khu;

            maKhu = khu.MaKhu;

            LoadPhongbyKhu(maKhu);

            if (cmbPhong.Text == "")
            {
                btnThanhTien.Enabled = false;
            }
            else
            {
                btnThanhTien.Enabled = true;
            }
        }

        private void btnThanhTien_Click(object sender, EventArgs e)
        {
            if(Ktra() == 1)
            {
                if ((txtMaHoaDon.Text != "") && (txtSoDien.Text != "") && (txtSoNuoc.Text != "") && (txtTienPhong.Text != ""))
                {
                    string maHoaDon = txtMaHoaDon.Text;
                    string maPhong = GetValuePhong();
                    int sodien = Convert.ToInt32(this.txtSoDien.Text);
                    int sonuoc = Convert.ToInt32(this.txtSoNuoc.Text);
                    int tienphong = int.Parse(txtTienPhong.Text);

                    int tiendien = sodien * int.Parse(txtGiaDien.Text);
                    int tiennuoc = sonuoc * int.Parse(txtGiaNuoc.Text);
                    int thanhtien = tiendien + tiennuoc + tienphong;


                    string trangthai;
                    if (chkTrangThai.Checked == true)
                        trangthai = "Đã thanh toán";
                    else trangthai = "Chưa thanh toán";

                    string query = "INSERT THONGKE VALUES( @MAHOADON , @MAPHONG , @SOLUONGDIEN , @SOLUONGNUOC , @TIENDIEN , @TIENNUOC , @TIENPHONG , @THANHTIEN , @TRANGTHAI )";
                    int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHoaDon, maPhong, sodien, sonuoc, tiendien, tiennuoc, tienphong, thanhtien, trangthai });

                    if (result > 0)
                    {
                        MessageBox.Show("Thống kê đã được lưu lại!");
                    }
                    LoadThongKeList();
                    ClearTextThongKe();
                }
                else MessageBox.Show("Hãy nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK);
            }    
            else
            {
                MessageBox.Show("Mã Hoá Đơn đa tồn tại");
                txtMaHoaDon.Clear();
                txtMaHoaDon.Focus();
            }    
        }
    }
}
