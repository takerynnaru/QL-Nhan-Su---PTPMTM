using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataQuanLyNhanSuTableAdapters;
using System.Data.Linq.SqlClient;

namespace DAL
{
    public class DALChamCong
    {
        public string manv;
        public DateTime ngaycc;
        public DateTime checkin;
        public DateTime checkout;
        public int solan;

        public DALChamCong()
        {

        }

        public int NhapCheckin(string MaNV, DateTime Ngaytao, int gio, int phut)
        {
            DateTime date = new DateTime(2000, 1, 1, gio, phut, 0);
            int solan = 1;

            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                CHAMCONG CHEKCIN = new CHAMCONG();
                {
                    CHEKCIN.MANV = MaNV;
                    CHEKCIN.NGAYCC = Ngaytao;
                    CHEKCIN.CHECKIN = date;
                    //CHEKCIN.CHECKOUT = null;
                    CHEKCIN.SOLAN = solan;

                }
                try
                {
                    db.CHAMCONGs.InsertOnSubmit(CHEKCIN);
                    db.SubmitChanges();

                }
                catch
                {
                    return 0;
                }
            }
            return 1;
        }


        public int checkChamCong(string MaNV, DateTime Ngaytao) //return 0/ chua check in / return 1 đã checkin / return 2 đã checkout
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                // int kt = isEqualDate((DateTime)r.NGAYCC, Ngaytao);
                CHAMCONG CC = db.CHAMCONGs.FirstOrDefault(r => r.MANV == MaNV && (r.NGAYCC.Day == Ngaytao.Day && r.NGAYCC.Month == Ngaytao.Month));


                if (CC == null)
                {
                    return 0;
                }
                else if (CC.SOLAN == 1)
                    return 1;
            }
            return 2;
        }

        public int CheckOut(string MaNV, DateTime Ngaytao, int gio, int phut)
        {
            DateTime date = new DateTime(2000, 1, 1, gio, phut, 0);
            int solan = 2;
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                CHAMCONG cc = (from r in db.CHAMCONGs
                               where r.MANV == MaNV && (r.NGAYCC.Day == Ngaytao.Day && r.NGAYCC.Month == Ngaytao.Month)
                               select r).FirstOrDefault();
                if (cc == null)
                {
                    return 0;
                }


                cc.CHECKOUT = date;
                cc.SOLAN = solan;
                //db.DANGNHAPs.InsertOnSubmit(dn);
                db.SubmitChanges();
                return 1;
            }
        }


        //////////////////////So sách datetime////////////////////////
        public int isEqualDate(DateTime dateA, DateTime dateB)
        {
            if (dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day)
                return 1;
            return 0;
        }

        bool nhoHonDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year <= dateB.Year && dateA.Month <= dateB.Month && dateA.Day <= dateB.Day;
        }

        bool lonHonDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year >= dateB.Year && dateA.Month >= dateB.Month && dateA.Day >= dateB.Day;
        }
        private List<ChamCongItem> dschamcong = new List<ChamCongItem>();

        public List<ChamCongItem> Dschamcong
        {
            get { return dschamcong; }
            set { dschamcong = value; }
        }

        /// list don tu theo manv
        /// 
        public void ListchamCongAllDAL()
        {
            dschamcong = new List<ChamCongItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var chamcong = from CHAMCONG in db.CHAMCONGs
                            select new
                            {
                                MA_NV = CHAMCONG.MANV,
                                NGAY_CC = CHAMCONG.NGAYCC,
                                CHECK_IN = CHAMCONG.CHECKIN,
                                CHECK_OUT = CHAMCONG.CHECKOUT,
                                SO_LAN = CHAMCONG.SOLAN,
                            };

                int i = 0;
                foreach (var chitiet in chamcong)
                {
              
                    //CaItem itemCa = new CaItem();
                    ChamCongItem item = new ChamCongItem(chitiet.MA_NV,(DateTime) chitiet.NGAY_CC, (DateTime)chitiet.CHECK_IN, (DateTime) chitiet.CHECK_OUT, Convert.ToInt32(chitiet.SO_LAN));
                    dschamcong.Add(item);
                }
            }

        }
        /// list don tu theo manv
        /// 
        public void ListchamCongByMANVDAL(string manv)
        {
            dschamcong = new List<ChamCongItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var chamcong = from CHAMCONG in db.CHAMCONGs
                               //.Where(M => M.MANV.Equals(manv))
                               where SqlMethods.Like(CHAMCONG.MANV, "%" + manv + "%")
                               select new
                               {
                                   MA_NV = CHAMCONG.MANV,
                                   NGAY_CC = CHAMCONG.NGAYCC,
                                   CHECK_IN = CHAMCONG.CHECKIN,
                                   CHECK_OUT = CHAMCONG.CHECKOUT,
                                   SO_LAN = CHAMCONG.SOLAN,
                               };

                int i = 0;
                foreach (var chitiet in chamcong)
                {

                    //CaItem itemCa = new CaItem();
                    ChamCongItem item = new ChamCongItem(chitiet.MA_NV, chitiet.NGAY_CC, (DateTime)chitiet.CHECK_IN, (DateTime)chitiet.CHECK_OUT, Convert.ToInt32(chitiet.SO_LAN));
                    dschamcong.Add(item);
                }
            }

        }
        /// list don tu theo NGAY
        /// 
        public void ListchamCongByDayDAL(DateTime day)
        {
            dschamcong = new List<ChamCongItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var chamcong = from CHAMCONG in db.CHAMCONGs
                               .Where(M => ((DateTime)M.NGAYCC).Day.Equals(day.Day) && ((DateTime)M.NGAYCC).Month.Equals(day.Month))
                               select new
                               {
                                   MA_NV = CHAMCONG.MANV,
                                   NGAY_CC = CHAMCONG.NGAYCC,
                                   CHECK_IN = CHAMCONG.CHECKIN,
                                   CHECK_OUT = CHAMCONG.CHECKOUT,
                                   SO_LAN = CHAMCONG.SOLAN,
                               };

                int i = 0;
                foreach (var chitiet in chamcong)
                {

                    //CaItem itemCa = new CaItem();
                    ChamCongItem item = new ChamCongItem(chitiet.MA_NV, chitiet.NGAY_CC, (DateTime)chitiet.CHECK_IN, (DateTime)chitiet.CHECK_OUT, Convert.ToInt32(chitiet.SO_LAN));
                    dschamcong.Add(item);
                }
            }

        }

    }
}
