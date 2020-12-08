using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessObject
{
    class HopDongDAO
    {

        #region Properties

        private static HopDongDAO instance;

        public static HopDongDAO Instance
        {
            get { if (instance == null) instance = new HopDongDAO(); return HopDongDAO.instance; }
            private set { HopDongDAO.instance = value; }
        }


        #endregion

        #region Methods

        private HopDongDAO() { }

        public List<HopDong> LoadHopDongList()
        {
            List<HopDong> listHopDong = new List<HopDong>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HOPDONG");

            foreach (DataRow item in data.Rows)
            {
                HopDong hopDong = new HopDong(item);

                listHopDong.Add(hopDong);
            }

            return listHopDong;
        }

        #endregion
    }
}
