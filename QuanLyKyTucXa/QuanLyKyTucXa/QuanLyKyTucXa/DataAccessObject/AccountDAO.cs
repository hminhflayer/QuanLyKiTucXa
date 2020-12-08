using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class AccountDAO
    {
        #region Properties

        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        #endregion

        #region Methods

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE USERNAME = @userName and PASS = @pass";

            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        #endregion

    }
}
