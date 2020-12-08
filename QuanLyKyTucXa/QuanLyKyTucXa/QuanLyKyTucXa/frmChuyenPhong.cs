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
    public partial class frmChuyenPhong : Form
    {
        public frmChuyenPhong()
        {
            InitializeComponent();
        }

        public void LoadThongTinInPhong()
        {
            if (cmbPhong1.Text != "")
            {
                dtgvThongTin1.DataSource = ThongTinDAO.Instance.GetThongTinByPhong(cmbPhong1.Text);

            }

            if (cmbPhong2.Text != "")
            {
                dtgvThongTin2.DataSource = ThongTinDAO.Instance.GetThongTinByPhong(cmbPhong2.Text);
            }

            if(cmbPhong1.Text == "" || cmbPhong2.Text == "")
            {
                btn2Chuyen1.Enabled = false;
                btn1Chuyen2.Enabled = false;
                
            }    
            else
            {
                btn2Chuyen1.Enabled = true;
                btn1Chuyen2.Enabled = true;
            }    

            SettingThongTin();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1Chuyen2_Click(object sender, EventArgs e)
        {
            if(dtgvThongTin1.SelectedRows.Count > 0)
            {
                string maSo = dtgvThongTin1.SelectedRows[0].Cells["MASO"].Value.ToString();
                string maPhongCanChuyen = cmbPhong2.Text;
                string maPhongCu = cmbPhong1.Text;

                int result = ThongTinDAO.Instance.ChuyenPhong(maSo, maPhongCanChuyen,maPhongCu);

                if(result > 0 )
                {
                    MessageBox.Show("Chuyển phòng thành công!");
                    LoadThongTinInPhong();
                }
            }
            
        }

        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            LoadKhu1();
            LoadKhu2();
            LoadThongTinInPhong();
        }

        public void SettingThongTin()
        {
            if(dtgvThongTin1.DataSource != null)
            {
                dtgvThongTin1.Columns["MASO"].HeaderText = "Mã Số";

                dtgvThongTin1.Columns["HOTEN"].HeaderText = "Họ Tên";
                dtgvThongTin1.Columns["NAMSINH"].Visible = false;
                dtgvThongTin1.Columns["GIOITINH"].HeaderText = "Giới Tính";
                dtgvThongTin1.Columns["CMND"].Visible = false;
                dtgvThongTin1.Columns["NGUYENQUAN"].Visible = false;
                dtgvThongTin1.Columns["DIENTHOAI"].Visible = false;
                dtgvThongTin1.Columns["MAKHU"].Visible = false;
                dtgvThongTin1.Columns["MAPHONG"].HeaderText = "Phòng";
                dtgvThongTin1.Columns["MAHOPDONG"].Visible = false;
                dtgvThongTin1.Columns["MAPHANLOAI"].Visible = false;
                dtgvThongTin1.Columns["TENPHANLOAI"].Visible = false;

            }    
            
            if(dtgvThongTin2.DataSource != null)
            {
                dtgvThongTin2.Columns["MASO"].HeaderText = "Mã Số";

                dtgvThongTin2.Columns["HOTEN"].HeaderText = "Họ Tên";
                dtgvThongTin2.Columns["NAMSINH"].Visible = false;
                dtgvThongTin2.Columns["GIOITINH"].HeaderText = "Giới Tính";
                dtgvThongTin2.Columns["CMND"].Visible = false;
                dtgvThongTin2.Columns["NGUYENQUAN"].Visible = false;
                dtgvThongTin2.Columns["DIENTHOAI"].Visible = false;
                dtgvThongTin2.Columns["MAKHU"].Visible = false;
                dtgvThongTin2.Columns["MAPHONG"].HeaderText = "Phòng";
                dtgvThongTin2.Columns["MAHOPDONG"].Visible = false;
                dtgvThongTin2.Columns["MAPHANLOAI"].Visible = false;
                dtgvThongTin2.Columns["TENPHANLOAI"].Visible = false;
            }    

        }

        public void LoadKhu1()
        {
            List<Khu> list = KhuDAO.Instance.GetListKhu();
            cmbKhu1.DataSource = list;
            cmbKhu1.DisplayMember = "TENKHU";
            cmbKhu1.ValueMember = "MAKHU";

        }


        public void LoadKhu2()
        {
            List<Khu> list = KhuDAO.Instance.GetListKhu();

            cmbKhu2.DataSource = list;
            cmbKhu2.DisplayMember = "TENKHU";
            cmbKhu2.ValueMember = "MAKHU";
        }

        public List<Phong> LoadPhongbyKhu(string maKhu)
        {
            List<Phong> list = PhongDAO.Instance.GetListPhongByKhuOfPhong(maKhu);
            return list;
        }

        private void cmbKhu1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKhu;

            ComboBox cmb = sender as ComboBox;

            if (cmb.SelectedItem == null)
            {
                return;
            }

            Khu khu = cmb.SelectedItem as Khu;

            maKhu = khu.MaKhu;

            cmbPhong1.DataSource = LoadPhongbyKhu(maKhu);
            cmbPhong1.DisplayMember = "MAPHONG";
            cmbPhong1.ValueMember = "MAPHONG";

            LoadThongTinInPhong();
        }

        private void cmbKhu2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKhu;

            ComboBox cmb = sender as ComboBox;

            if (cmb.SelectedItem == null)
            {
                return;
            }

            Khu khu = cmb.SelectedItem as Khu;

            maKhu = khu.MaKhu;

            cmbPhong2.DataSource = LoadPhongbyKhu(maKhu);
            cmbPhong2.DisplayMember = "MAPHONG";

            LoadThongTinInPhong();
        }


        private void cmbPhong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongTinInPhong();
        }

        private void cmbPhong1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongTinInPhong();
        }

        private void btn2Chuyen1_Click(object sender, EventArgs e)
        {
            if (dtgvThongTin2.SelectedRows.Count > 0)
            {
                string maSo = dtgvThongTin2.SelectedRows[0].Cells["MASO"].Value.ToString();
                string maPhongCanChuyen = cmbPhong1.Text;
                string maphongCu = cmbPhong2.Text;

                int result = ThongTinDAO.Instance.ChuyenPhong(maSo, maPhongCanChuyen,maphongCu);

                if (result > 0)
                {
                    MessageBox.Show("Chuyển phòng thành công!");
                    LoadThongTinInPhong();
                }
            }
        }

    }
}
