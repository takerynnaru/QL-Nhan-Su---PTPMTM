using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLPhanCong
    {
        DALPhanCong pc = new DALPhanCong();

        public BLLPhanCong()
        { }

        //Them phan cong
        public int ThemPhanCongBLL(string mapc, string nguoitao, string mapb, string nguoiduyet, DateTime ngaytao, DateTime tungay, DateTime denngay, string tieude, string GhiChu)
        {
            int kt = pc.ThemPhanCongDAL( mapc,  nguoitao, mapb, nguoiduyet, ngaytao,  tungay,  denngay,  tieude,  GhiChu);
            if (kt == 1)
                return 1;
            else
                return 0;

        }
        //THEM CHI TIET PHAN CONG
        public int ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
        {
            int kt = pc.ThemCTPhanCongDAL( mapc,  manv,  day, maca);
            if (kt == 1)
                return 1;
            else
                return 0;

        }


    }
}
