using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKyTucXa.DataTransferObject;

namespace QuanLyKyTucXa.DataAccessObject
{
    class ThongKeDAO
    {
        #region Properties

        private static ThongKeDAO instance;

        public static ThongKeDAO Instance
        {
            get { if (instance == null) instance = new ThongKeDAO(); return ThongKeDAO.instance; }
            private set { ThongKeDAO.instance = value; }
        }

        #endregion

        #region Methods

        public List<ThongKe> LoadThongKeList()
        {
            List<ThongKe> list = new List<ThongKe>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM THONGKE");

            foreach (DataRow item in data.Rows)
            {
                ThongKe thongKe = new ThongKe(item);

                list.Add(thongKe);
            }

            return list;
        }

        #endregion
    }
}
