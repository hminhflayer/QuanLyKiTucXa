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
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDangKyThongTin dk = new frmDangKyThongTin();
            dk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmQuanLyKhu frmQuanLyKhu = new frmQuanLyKhu();
            frmQuanLyKhu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong frmQuanLyPhong = new frmQuanLyPhong();
            frmQuanLyPhong.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            frmThongKe.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình Quản Lý Ký Túc Xá ?","Thông Báo",MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }
    }
}
