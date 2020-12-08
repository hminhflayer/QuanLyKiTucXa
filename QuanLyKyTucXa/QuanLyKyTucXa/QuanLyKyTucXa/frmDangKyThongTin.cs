using QuanLyKyTucXa.DataAccessObject;
using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyKyTucXa
{
    public partial class frmDangKyThongTin : Form
    {
        public frmDangKyThongTin()
        {
            InitializeComponent();
        }

        private void frmHoSoSinhVien_Load(object sender, EventArgs e)
        {

            LoadKhu();
            LoadHopDong();
            LoadPhanLoai();
            LoadThongTinList();
            SettingThongTin();

        }



        #region Methods
        public void SettingThongTin()
        {
            dgvThongTin.Columns["MASO"].HeaderText = "Mã Số";

            dgvThongTin.Columns["HOTEN"].HeaderText = "Họ Tên";
            dgvThongTin.Columns["NAMSINH"].HeaderText = "Năm Sinh";
            dgvThongTin.Columns["GIOITINH"].HeaderText = "Giới Tính";
            dgvThongTin.Columns["CMND"].HeaderText = "CMND";
            dgvThongTin.Columns["NGUYENQUAN"].Visible =false;
            dgvThongTin.Columns["DIENTHOAI"].HeaderText = "SĐT";
            dgvThongTin.Columns["MAKHU"].Visible = false;
            dgvThongTin.Columns["MAPHONG"].HeaderText = "Phòng";
            dgvThongTin.Columns["MAHOPDONG"].Visible = false;
            dgvThongTin.Columns["MAPHANLOAI"].Visible = false;
            dgvThongTin.Columns["TENPHANLOAI"].HeaderText = "Đang là";

        }

        public void LoadThongTinList()
        {
            dgvThongTin.DataSource = ThongTinDAO.Instance.LoadThongTinList();
            LoadPhongbyKhu(cmbKhu.SelectedValue.ToString());
        }

        public void LoadThongTinTimKiemList(string maSo)
        {
            dgvThongTin.DataSource = ThongTinDAO.Instance.LoadThongTinList(maSo);
        }

        public void LoadHopDong()
        {
            List<HopDong> listHopDong = HopDongDAO.Instance.LoadHopDongList();
            cmbHopDong.DataSource = listHopDong;
            cmbHopDong.DisplayMember = "HANHOPDONG";
            cmbHopDong.ValueMember = "MAHOPDONG";
        }

        public void LoadPhanLoai()
        {
            List<PhanLoai> list = PhanLoaiDAO.Instance.LoadPhanLoaiList();
            cmbPhanLoai.DataSource = list;
            cmbPhanLoai.DisplayMember = "TENPHANLOAI";
            cmbPhanLoai.ValueMember = "MAPHANLOAI";
        }

        public void LoadKhu()
        {
            List<Khu> list = KhuDAO.Instance.GetListKhu();
            cmbKhu.DataSource = list;
            cmbKhu.DisplayMember = "TENKHU";
            cmbKhu.ValueMember = "MAKHU";
        }

        public void LoadPhongbyKhu(string maKhu)
        {
            List<Phong> list = PhongDAO.Instance.GetListPhongByKhuOfThongTin(maKhu);
            cmbPhong.DataSource = list;
            cmbPhong.DisplayMember = "MAPHONG";
        }

        public string GetValueKhu()
        {
            string maKhu;

            Khu khu = cmbKhu.SelectedItem as Khu;
            maKhu = khu.MaKhu;

            return maKhu;
        }

        public string GetValuePhanLoai()
        {
            PhanLoai phanLoai = cmbPhanLoai.SelectedItem as PhanLoai;

            return phanLoai.MaPhanLoai;
        }

        public string GetValuePhong()
        {
            string maPhong;

            Phong phong = cmbPhong.SelectedItem as Phong;
            maPhong = phong.MaPhong;

            return maPhong;
        }

        public string GetValueHopDong()
        {
            string mahopDong;

            HopDong hopDong = cmbHopDong.SelectedItem as HopDong;
            mahopDong = hopDong.MaHopDong;

            return mahopDong;
        }

        public void ClearTextThongTin()
        {
            txtMaSo.Clear();
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtCMND.Clear();
            txtNguyenQuan.Clear();
            txtSdt.Clear();
            txtMaSo.Focus();
        }

        public int Ktra()
        {
            for (int i = 0; i < dgvThongTin.RowCount - 1; i++)
            {
                if (txtMaSo.Text.ToUpper() == dgvThongTin.Rows[i].Cells["MASO"].Value.ToString())
                {
                    return 0;
                }
            }
            return 1;
        }

        #endregion

        #region Events

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextThongTin();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(Ktra() == 1)
            {
                if (txtMaSo.Text != "" && txtCMND.Text != "" & txtHoTen.Text != "" && txtNamSinh.Text != "" && txtNguyenQuan.Text != "" && txtSdt.Text != "")
                {
                    string query = "EXEC USP_ADDTHONGTIN_AND_UPDATEPHONG @MASO , @HOTEN , @NAMSINH , @GIOITINH , @CMND , @NGUYENQUAN , @DIENTHOAI , @MAKHU , @MAPHONG , @MAHOPDONG , @MAPHANLOAI ";

                    int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtMaSo.Text, txtHoTen.Text, int.Parse(txtNamSinh.Text), rdbNam.Checked ? "Nam" : "Nữ", txtCMND.Text, txtNguyenQuan.Text, txtSdt.Text, GetValueKhu(), GetValuePhong(), GetValueHopDong(), GetValuePhanLoai() });

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông Báo");
                        LoadThongTinList();
                    }
                }

                ClearTextThongTin();
            }
            else
            {
                MessageBox.Show("Mã Số đã có trong danh sách!");
                txtMaSo.Clear();
                txtMaSo.Focus();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Ktra() == 1)
            {
                string maSoBackup = dgvThongTin.SelectedRows[0].Cells["MASO"].Value.ToString();
                string query = "EXEC USP_UPDATETHONGTIN @MASO , @HOTEN , @NAMSINH , @GIOITINH , @CMND , @NGUYENQUAN , @DIENTHOAI , @MAHOPDONG , @MAPHANLOAI , @MASOBACKUP ";

                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtMaSo.Text, txtHoTen.Text, int.Parse(txtNamSinh.Text), rdbNam.Checked ? "Nam" : "Nữ", txtCMND.Text, txtNguyenQuan.Text, txtSdt.Text, GetValueHopDong(), GetValuePhanLoai(), maSoBackup });

                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Thông Báo");
                    LoadThongTinList();
                }

                ClearTextThongTin();
            }
            else
            {
                MessageBox.Show("Mã số đã có trong danh sách.");
            }    
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "EXEC USP_DELETETHONGTIN_AND_UPDATEPHONG @MASO , @MAPHONG";
            string maSo;
            string maPhong;

            if (dgvThongTin.SelectedRows.Count > 0)
            {
                maSo = dgvThongTin.SelectedRows[0].Cells["MASO"].Value.ToString();
                maPhong = dgvThongTin.SelectedRows[0].Cells["MAPHONG"].Value.ToString();
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSo , maPhong });
                if(result > 0)
                {
                    MessageBox.Show("Xoá thành công!");
                    LoadThongTinList();
                }
            }
        }

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

        }

        private void dgvThongTin_Click(object sender, EventArgs e)
        {
            if (dgvThongTin.SelectedRows.Count > 0)
            {
                txtMaSo.Text = dgvThongTin.SelectedRows[0].Cells["MASO"].Value.ToString();
                txtHoTen.Text = dgvThongTin.SelectedRows[0].Cells["HOTEN"].Value.ToString();
                txtNamSinh.Text = dgvThongTin.SelectedRows[0].Cells["NAMSINH"].Value.ToString();

                if (dgvThongTin.SelectedRows[0].Cells["GIOITINH"].Value.ToString() == "NAM" || dgvThongTin.SelectedRows[0].Cells["GIOITINH"].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }

                txtCMND.Text = dgvThongTin.SelectedRows[0].Cells["CMND"].Value.ToString();
                txtNguyenQuan.Text = dgvThongTin.SelectedRows[0].Cells["NGUYENQUAN"].Value.ToString();
                txtSdt.Text = dgvThongTin.SelectedRows[0].Cells["DIENTHOAI"].Value.ToString();
                cmbKhu.SelectedValue = dgvThongTin.SelectedRows[0].Cells["MAKHU"].Value.ToString();
                cmbPhong.Text = dgvThongTin.SelectedRows[0].Cells["MAPHONG"].Value.ToString();
                cmbHopDong.SelectedValue = dgvThongTin.SelectedRows[0].Cells["MAHOPDONG"].Value.ToString();
                cmbPhanLoai.SelectedValue = dgvThongTin.SelectedRows[0].Cells["MAPHANLOAI"].Value.ToString();
            }
        }
        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadThongTinTimKiemList(txtMaSoTim.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadThongTinList();
        }
    }
}
