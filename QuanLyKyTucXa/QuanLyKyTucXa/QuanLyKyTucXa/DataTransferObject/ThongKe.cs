using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class ThongKe
    {
        #region Properties

        private string  maHoaDon;
        private string     maPhong;
        private int soLuongDien;
        private int soLuongNuoc;
        private int tienDien;
        private int tienNuoc;
        private int tienPhong;
        private int thanhTien;
        private string trangThai;

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public int SoLuongDien { get => soLuongDien; set => soLuongDien = value; }
        public int SoLuongNuoc { get => soLuongNuoc; set => soLuongNuoc = value; }
        public int TienDien { get => tienDien; set => tienDien = value; }
        public int TienNuoc { get => tienNuoc; set => tienNuoc = value; }
        public int TienPhong { get => tienPhong; set => tienPhong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        #endregion

        #region Methods

        public ThongKe() { }

        public ThongKe(string maHoaDon, string maPhong, int soLuongDien, int soLuongNuoc, int tienDien, int tienNuoc, int tienPhong, int thanhTien, string trangThai)
        {
            this.MaHoaDon = maHoaDon;
            this.MaPhong = maPhong;
            this.SoLuongDien = soLuongDien;
            this.SoLuongNuoc = soLuongNuoc;
            this.TienDien = tienDien;
            this.TienNuoc = tienNuoc;
            this.TienPhong = tienPhong;
            this.ThanhTien = thanhTien;
            this.TrangThai = trangThai;
        }

        public ThongKe(DataRow row)
        {
            this.MaHoaDon = row["maHoaDon"].ToString();
            this.MaPhong = row["maPhong"].ToString();
            this.SoLuongDien = (int)row["soLuongDien"];
            this.SoLuongNuoc = (int)row["soLuongNuoc"];
            this.TienDien = (int)row["tienDien"];
            this.TienNuoc = (int)row["tienNuoc"];
            this.TienPhong = (int)row["tienPhong"];
            this.ThanhTien = (int)row["thanhTien"];
            this.TrangThai = row["trangThai"].ToString();
        }

        #endregion
    }
}
