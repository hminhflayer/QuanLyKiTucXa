using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class Khu
    {
        #region Properties

        private string maKhu;
        private string tenkhu;
        private int soPhong;

        public string MaKhu { get => maKhu; set => maKhu = value; }
        public string TenKhu { get => tenkhu; set => tenkhu = value; }
        public int SoPhong { get => soPhong; set => soPhong = value; }

        #endregion

        #region Methods

        public Khu() { }

        public Khu(string maKhu, string khu, int soPhong)
        {
            this.MaKhu = maKhu;
            this.TenKhu = khu;
            this.SoPhong = soPhong;
        }

        public Khu(DataRow row)
        {
            this.MaKhu = row["maKhu"].ToString();
            this.TenKhu = row["tenkhu"].ToString();
            this.SoPhong = (int)row["soPhong"];
        }

        #endregion
    }
}
