using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessObject
{
    class PhongDAO
    {
        #region Properties

        private static PhongDAO instance;
        public static int PhongHeight = 120;
        public static int PhongWeidth = 120;

        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return PhongDAO.instance; }
            private set { PhongDAO.instance = value; }
        }

        #endregion

        #region Methods

        private PhongDAO() { }

        public List<Phong> GetListPhongByKhuOfThongTin(String maKhu)
        {
            List<Phong> listPhong = new List<Phong>();

            string query = "SELECT * FROM PHONG WHERE MAKHU = '" + maKhu + "' AND SOLUONG < SOLUONGTOIDA ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);

                listPhong.Add(phong);
            }

            return listPhong;
        }


        public List<Phong> GetListPhongByKhuOfPhong(String maKhu)
        {
            List<Phong> listPhong = new List<Phong>();

            string query = "SELECT * FROM PHONG WHERE MAKHU = '" + maKhu + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);

                listPhong.Add(phong);
            }

            return listPhong;
        }

        public int InsertPhong(string maPhong, string maKhu, int soLuongMax, int soLuong)
        {
            string query = "INSERT PHONG VALUES( @MAPHONG , @MAKHU , @SOLUONGTOIDA , @SOLUONG )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maPhong,maKhu,soLuongMax,soLuong});

            return result;
        }

        public int DeletePhong(string maPhong)
        {
            string query = "DELETE PHONG WHERE MAPHONG = @MAPHONG";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maPhong});

            return result;
        }


        #endregion

    }
}
