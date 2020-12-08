using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class ThongTin
    {
        #region Properties

        private string  maSo;
        private string  hoTen;
        private int     namSinh;
        private string  gioiTinh;
        private string  cMND;
        private string  nguyenQuan;
        private string  dienThoai;
        private string  maKhu;
        private string  maPhong;
        private string  maHopDong;
        private string  maPhanLoai;
        private string tenPhanloai;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string NguyenQuan { get => nguyenQuan; set => nguyenQuan = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string MaKhu { get => maKhu; set => maKhu = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaPhanLoai { get => maPhanLoai; set => maPhanLoai = value; }
        public string MaSo { get => maSo; set => maSo = value; }
        public string TenPhanloai { get => tenPhanloai; set => tenPhanloai = value; }

        #endregion

        #region Methods

        public ThongTin()
        {

        }

        public ThongTin(string maSo, string hoTen, int namSinh, string gioiTinh, string cMND, string nguyenQuan, string sDT, string maKhu, string maPhong, string maHopDong, string maPhanLoai, string tenPhanLoai)
        {
            this.MaSo = maSo;
            this.HoTen = hoTen;
            this.NamSinh = namSinh;
            this.GioiTinh = gioiTinh;
            this.CMND = cMND;
            this.NguyenQuan = nguyenQuan;
            this.DienThoai = dienThoai;
            this.MaKhu = maKhu;
            this.MaPhong = maPhong;
            this.MaHopDong = maHopDong;
            this.MaPhanLoai = maPhanLoai;
            this.TenPhanloai = tenPhanLoai;
        }

        public ThongTin(DataRow row , bool phanLoai)
        {
            this.MaSo = row["maSo"].ToString();
            this.HoTen = row["hoTen"].ToString();
            this.NamSinh = (int)row["namSinh"];
            this.GioiTinh = row["gioiTinh"].ToString();
            this.CMND = row["cMND"].ToString();
            this.NguyenQuan = row["nguyenQuan"].ToString();
            this.DienThoai = row["dienThoai"].ToString();
            this.MaKhu = row["maKhu"].ToString();
            this.MaPhong = row["maPhong"].ToString();
            this.MaHopDong = row["maHopDong"].ToString();
            this.MaPhanLoai = row["maPhanLoai"].ToString();
            if(phanLoai == true)
            {
                this.TenPhanloai = row["tenPhanLoai"].ToString();
            }    

        }

        #endregion
    }
}
