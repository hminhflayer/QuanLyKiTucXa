using QuanLyKyTucXa.DataAccessObject;
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
    public partial class frmQuanLyKhu : Form
    {
        public frmQuanLyKhu()
        {
            InitializeComponent();
        }

        #region Methods

        public void ClearText()
        {
            txtMaKhu.Clear();
            txtTenKhu.Clear();
            txtSoLuongPhong.Clear();
            txtMaKhu.Focus();
        }

        public void LoadKhu()
        {
            dtgvKhu.DataSource = KhuDAO.Instance.GetListKhu();
            dtgvKhu.Columns["MAKHU"].HeaderText = "Mã Khu";
            dtgvKhu.Columns["TENKHU"].HeaderText = "Tên Khu";
            dtgvKhu.Columns["SOPHONG"].HeaderText = "Số lượng Phòng";
        }
        public int Ktra()
        {
            for (int i = 0; i < dtgvKhu.RowCount - 1; i++)
            {
                if (txtMaKhu.Text.ToUpper() == dtgvKhu.Rows[i].Cells["MAKHU"].Value.ToString())
                {
                    return 0;
                }
            }
            return 1;
        }

        #endregion

        #region Events

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(Ktra() == 1)
            {
                if (txtMaKhu.Text != "" && txtTenKhu.Text != "" && txtSoLuongPhong.Text != "")
                {
                    int a;
                    if (int.TryParse(txtSoLuongPhong.Text, out a))
                    {
                        string query = "INSERT KHU VALUES( @MAKHU , @TENKHU , @SOPHONG )";
                        int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtMaKhu.Text, txtTenKhu.Text, int.Parse(txtSoLuongPhong.Text) });

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm khu thành công!");
                            ClearText();
                            LoadKhu();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá trị không đúng");
                    }
                }               
            }
            else
            {
                MessageBox.Show("Mã Khu đã tồn tại!");
                txtMaKhu.Clear();
                txtMaKhu.Focus();
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvKhu.SelectedRows.Count > 0)
            {
                string query = "DELETE KHU WHERE MAKHU = @MAKHU ";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { dtgvKhu.SelectedRows[0].Cells["MAKHU"].Value.ToString() });

                if (result > 0)
                {
                    MessageBox.Show("Xoá khu thành công!");
                    LoadKhu();
                }
            }

        }

        private void frmQuanLyKhu_Load(object sender, EventArgs e)
        {
            LoadKhu();
        }

        private void dtgvKhu_Click(object sender, EventArgs e)
        {
            txtMaKhu.Text = dtgvKhu.SelectedRows[0].Cells["MAKHU"].Value.ToString();
            txtTenKhu.Text = dtgvKhu.SelectedRows[0].Cells["TENKHU"].Value.ToString();
            txtSoLuongPhong.Text = dtgvKhu.SelectedRows[0].Cells["SOPHONG"].Value.ToString();
        }

        private void btnXoaChu_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        #endregion


    }
}
