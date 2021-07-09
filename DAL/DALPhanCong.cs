using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataQuanLyNhanSuTableAdapters;
using System.Data;

namespace DAL
{
    public class DALPhanCong
    {

        public DALPhanCong()
        { }

        //tao phancong

        public int ThemPhanCongDAL(string mapc, string nguoitao, string mapb, string nguoiduyet, DateTime ngaytao, DateTime tungay, DateTime denngay, string tieude, string GhiChu)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    PHANCONG pc = new PHANCONG
                    {
                        MAPC = mapc,
                        MANVTAO = nguoitao,
                        MAPH = mapb,
                        NGUOIDUYET = nguoiduyet,
                        NGAYTAO = (DateTime) ngaytao,
                        TUNGAY = tungay,
                        DENNGAY = denngay,
                        TIEUDE =  tieude,
                        GHICHU = GhiChu

                    };

                    db.PHANCONGs.InsertOnSubmit(pc);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }

        }

        //them chi tiet phan cong
        public int ThemCTPhanCongDAL(string mapc, string manv, int day, string maca)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    CHITIETPHANCONG ctpc = new CHITIETPHANCONG
                    {
                        MAPC = mapc,
                        MANV = manv,
                        DAYOFTUAN = Convert.ToInt32(day),
                        MACA = maca,

                    };

                    db.CHITIETPHANCONGs.InsertOnSubmit(ctpc);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }

        }

    }//////////////////////////////
}
