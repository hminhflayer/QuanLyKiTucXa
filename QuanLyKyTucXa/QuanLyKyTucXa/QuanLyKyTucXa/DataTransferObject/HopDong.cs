using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataTransferObject
{
    class HopDong
    {
        #region Properties

        private string maHopDong;
        private string hanHopDong;

        public string MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string HanHopDong { get => hanHopDong; set => hanHopDong = value; }

        #endregion

        #region Methods

        public HopDong(string maHopDong,string hanHopDong)
        {
            this.MaHopDong = maHopDong;
            this.HanHopDong = hanHopDong;
        }

        public HopDong(DataRow row)
        {
            this.MaHopDong = row["MAHOPDONG"].ToString();
            this.HanHopDong = row["HANHOPDONG"].ToString();
        }

        #endregion
    }
}
