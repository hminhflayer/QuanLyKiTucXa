using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class PhanLoai
    {

        #region Properties

        private string maPhanLoai;
        private string tenPhanLoai;

        public string MaPhanLoai { get => maPhanLoai; set => maPhanLoai = value; }
        public string TenPhanLoai { get => tenPhanLoai; set => tenPhanLoai = value; }

        #endregion

        #region Methods

        public PhanLoai(string maPhanLoai, string tenPhanLoai)
        {
            this.MaPhanLoai = maPhanLoai;
            this.TenPhanLoai = tenPhanLoai;
        }

        public PhanLoai(DataRow row)
        {
            this.MaPhanLoai = row["MAPHANLOAI"].ToString();
            this.TenPhanLoai = row["TENPHANLOAI"].ToString();
        }

        #endregion
    }
}
