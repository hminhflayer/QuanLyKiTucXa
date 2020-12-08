using System.Data;

namespace QuanLyKyTucXa.DataTransferObject
{
    public class Phong
    {
        #region Properties 

        private string maPhong;

        private string maKhu;

        private int soLuong;

        private int soLuongToiDa;


        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaKhu { get => maKhu; set => maKhu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int SoLuongToiDa { get => soLuongToiDa; set => soLuongToiDa = value; }


        #endregion

        #region Methods

        public Phong(string maPhong, string maKhu, int soLuong, int soLuongToiDa)
        {
            this.MaPhong = maPhong;
            this.MaKhu = maKhu;
            this.SoLuong = soLuong;
            this.SoLuongToiDa = soLuongToiDa;
        }

        public Phong(DataRow row)
        {
            this.MaPhong = row["maPhong"].ToString();
            this.MaKhu = row["maKhu"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.SoLuongToiDa = (int)row["soLuongToiDa"];
        }
        #endregion
    }
}
