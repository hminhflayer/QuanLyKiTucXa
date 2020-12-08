using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessObject
{
    class ThongTinDAO
    {
        #region Properties

        private static ThongTinDAO instance;

        public static ThongTinDAO Instance
        {
            get { if (instance == null) instance = new ThongTinDAO(); return instance; }
            private set { instance = value; }
        }

        #endregion

        #region Methods

        private ThongTinDAO() { }

        public List<ThongTin> LoadThongTinList()
        {
            List<ThongTin> list = new List<ThongTin>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT t.* , pl.TENPHANLOAI FROM THONGTIN AS t , PHANLOAI AS pl WHERE t.MAPHANLOAI = pl.MAPHANLOAI");

            foreach (DataRow item in data.Rows)
            {
                ThongTin sv = new ThongTin(item,true);

                list.Add(sv);
            }

            return list;
        }

        public List<ThongTin> LoadThongTinList(string maSo)
        {
            List<ThongTin> list = new List<ThongTin>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT t.* , pl.TENPHANLOAI FROM THONGTIN AS t , PHANLOAI AS pl WHERE t.MAPHANLOAI = pl.MAPHANLOAI AND t.MASO like '"+maSo+"%'");

            foreach (DataRow item in data.Rows)
            {
                ThongTin sv = new ThongTin(item,true);

                list.Add(sv);
            }

            return list;
        }

        public List<ThongTin> GetThongTinByPhong(string maPhong)
        {
            List<ThongTin> list = new List<ThongTin>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM THONGTIN WHERE MAPHONG = @MAPHONG",new object[] { maPhong });

            foreach (DataRow item in data.Rows)
            {
                ThongTin thongTin = new ThongTin(item,false);

                list.Add(thongTin);
            }

            return list;
        }

        public List<ThongTin> GetThongTinByKhu(string maKhu)
        {
            List<ThongTin> list = new List<ThongTin>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM THONGTIN WHERE MAKHU = @MAKHU", new object[] { maKhu });

            foreach (DataRow item in data.Rows)
            {
                ThongTin thongTin = new ThongTin(item,false);

                list.Add(thongTin);
            }

            return list;
        }

        public int ChuyenPhong(string maSo, string maPhongCanChuyen ,string maPhongCu)
        {
            string query = "EXEC USP_CHUYENPHONG @MAPHONGMOI , @MAPHONGCU , @MASO";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {maPhongCanChuyen,maPhongCu,maSo});

            return result;
        }

        #endregion

    }
}
