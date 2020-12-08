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
    public partial class frmQuanLyPhong : Form
    {
        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        #region Properties



        #endregion

        #region Methods

        public void LoadKhu()
        {
            List<Khu> list = KhuDAO.Instance.GetListKhu();

            cmbKhu.DataSource = list;
            cmbKhu.DisplayMember = "tenKhu";
            cmbKhu.ValueMember = "maKhu";
        }

        public void LoadPhongbyKhu(string maKhu)
        {
            flpDanhSachPhong.Controls.Clear();
            List<Phong> listPhong = PhongDAO.Instance.GetListPhongByKhuOfPhong(maKhu);

            foreach (Phong item in listPhong)
            {
                Button btn = new Button()
                {
                    Size = new Size(Width = PhongDAO.PhongWeidth, Height = PhongDAO.PhongHeight),
                    Text = item.MaPhong.ToString(),
                    BackColor = Color.Yellow,
                    Tag = item
                };

                if(item.SoLuong >= item.SoLuongToiDa)
                {
                    btn.BackColor = Color.Red;
                }

                btn.Click += Btn_Click;
                flpDanhSachPhong.Controls.Add(btn);
            }
        }

        public void loadThongTin(string maPhong)
        {

            dgvThongTin.DataSource = ThongTinDAO.Instance.GetThongTinByPhong(maPhong);
            
        }

        public void ClearTextPhong()
        {
            txtMaPhong.Clear();
            txtSoLuong.Text = "0";
            txtSoLuongMax.Clear();

            txtMaPhong.Focus();
        }

        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string maphong = btn.Text;

            Phong phong = btn.Tag as Phong;

            txtMaKhu.Text = phong.MaKhu;
            txtMaPhong.Text = phong.MaPhong.ToString();
            txtSoLuong.Text = phong.SoLuong.ToString();
            txtSoLuongMax.Text = phong.SoLuongToiDa.ToString();

            loadThongTin(maphong);

            if(phong.SoLuong > 0)
            {
                btnXoa.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
            }    

        }

        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            frmChuyenPhong cp = new frmChuyenPhong();
            cp.ShowDialog();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpDanhSachPhong.Controls.Clear();
            txtMaKhu.Text = cmbKhu.SelectedValue.ToString();
            ClearTextPhong();
            dgvThongTin.DataSource = ThongTinDAO.Instance.GetThongTinByKhu(cmbKhu.SelectedValue.ToString());

            ComboBox cmb = sender as ComboBox;

            string maKhu = "";

            if (cmb.SelectedItem == null)
            {
                return;
            }

            Khu khu = cmb.SelectedItem as Khu;

            maKhu = khu.MaKhu;

            LoadPhongbyKhu(maKhu);
            
        }

        public int Ktra()
        {
            foreach (Button item in flpDanhSachPhong.Controls)
            {
                if (txtMaPhong.Text.ToUpper() == item.Text)
                {
                    return 0;
                }
            }
            return 1;
        }

        #endregion

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if(Ktra() == 1)
            {
                if (txtMaPhong.Text != "" && txtSoLuongMax.Text != "" && txtSoLuongMax.Text != "" && int.Parse(txtSoLuong.Text) == 0)
                {
                    int result = PhongDAO.Instance.InsertPhong(txtMaPhong.Text, txtMaKhu.Text, int.Parse(txtSoLuongMax.Text), int.Parse(txtSoLuong.Text));
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm phòng thành công!");
                        ClearTextPhong();
                        LoadPhongbyKhu(txtMaKhu.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ !");
                }
            }
            else
            {
                MessageBox.Show("Mã phòng đã có trong danh sách");
                txtMaPhong.Clear();
                txtMaPhong.Focus();
            }    
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            ClearTextPhong();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadKhu();
            txtMaKhu.Text = cmbKhu.SelectedValue.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaPhong.Text != "")
            {
                int result = PhongDAO.Instance.DeletePhong(txtMaPhong.Text);

                if(result > 0)
                {
                    MessageBox.Show("Xoá Phòng thành công!");
                    LoadPhongbyKhu(txtMaKhu.Text);
                }    
            }    
        }
    }
}
