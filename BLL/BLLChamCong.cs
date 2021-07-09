using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLLChamCong
    {
        DALChamCong cc = new DALChamCong();

        public string manv;
        public DateTime ngaycc;
        public DateTime checkin;
        public DateTime checkout;
        public int solan;

        public BLLChamCong()
        { 
            
        }

        public int BLLCheckin(string MaNV, DateTime Ngaytao, int gio, int phut)
        {
            int i = cc.NhapCheckin(MaNV, Ngaytao, gio, phut);
            if (i == 1)
                return 1;
            return 0;

        }

        public int BLLcheckChamCong(string MaNV, DateTime Ngaytao)
        {
            int i = cc.checkChamCong(MaNV, Ngaytao);

            return i;
        }

        public int BLLCheckOut(string MaNV, DateTime Ngaytao, int gio, int phut)
        {
            int i = cc.CheckOut(MaNV, Ngaytao, gio, phut);
            if (i == 1)
                return 1;
            return 0;
        }

        private List<ChamCongItem> dschamcong = new List<ChamCongItem>();

        public List<ChamCongItem> Dschamcong
        {
            get { return dschamcong; }
            set { dschamcong = value; }
        }

        public void ListchamCongAllBLL()
        {
            dschamcong = new List<ChamCongItem>();
            cc.ListchamCongAllDAL();
            int i = 0;
            foreach (var chitiet in cc.Dschamcong)
            {
                ChamCongItem item = new ChamCongItem(chitiet.Manvi, (DateTime) chitiet.Ngaycci, (DateTime)chitiet.Giockini, (DateTime)chitiet.Giochouti, Convert.ToInt32(chitiet.Solani));
                dschamcong.Add(item);
            }
        }

        /// list don tu theo manv
        /// 
        public void ListchamCongByMANVBLL(string manv)
        {
            dschamcong = new List<ChamCongItem>();
            cc.ListchamCongByMANVDAL(manv);
            int i = 0;
            foreach (var chitiet in cc.Dschamcong)
            {
                ChamCongItem item = new ChamCongItem(chitiet.Manvi, (DateTime)chitiet.Ngaycci, (DateTime)chitiet.Giockini, (DateTime)chitiet.Giochouti, Convert.ToInt32(chitiet.Solani));
                dschamcong.Add(item);
            }
        }
              
       /// list don tu theo NGAY
        /// 
        public void ListchamCongByDayDAL(DateTime day)
        {
            dschamcong = new List<ChamCongItem>();
            cc.ListchamCongByDayDAL(day);
            int i = 0;
            foreach (var chitiet in cc.Dschamcong)
            {
                ChamCongItem item = new ChamCongItem(chitiet.Manvi, (DateTime)chitiet.Ngaycci, (DateTime)chitiet.Giockini, (DateTime)chitiet.Giochouti, Convert.ToInt32(chitiet.Solani));
                dschamcong.Add(item);
            }
        }

    }///////////////////
}
