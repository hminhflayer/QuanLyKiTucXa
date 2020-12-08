using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessObject
{
    class PhanLoaiDAO
    {
        #region Properties

        private static PhanLoaiDAO instance;

        public static PhanLoaiDAO Instance
        {
            get { if (instance == null) instance = new PhanLoaiDAO(); return PhanLoaiDAO.instance; }
            private set { PhanLoaiDAO.instance = value; }
        }


        #endregion

        #region Methods

        private PhanLoaiDAO() { }

        public List<PhanLoai> LoadPhanLoaiList()
        {
            List<PhanLoai> list = new List<PhanLoai>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM PHANLOAI");

            foreach (DataRow item in data.Rows)
            {
                PhanLoai phanLoai = new PhanLoai(item);

                list.Add(phanLoai);
            }

            return list;
        }

        #endregion
    }
}
