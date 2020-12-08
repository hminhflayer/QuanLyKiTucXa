using QuanLyKyTucXa.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessObject
{
    class KhuDAO
    {

        #region Properties

        private static KhuDAO instance;

        public static KhuDAO Instance
        {
            get { if (instance == null) instance = new KhuDAO(); return KhuDAO.instance; }
            private set { KhuDAO.instance = value; }
        }

        #endregion


        #region Methods

        
        private KhuDAO() { }

        public List<Khu> GetListKhu()
        {
            List<Khu> list = new List<Khu>();

            string query = "SELECT * FROM KHU";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Khu khu = new Khu(item);

                list.Add(khu);
            }

            return list;
        }

        #endregion
    }
}
