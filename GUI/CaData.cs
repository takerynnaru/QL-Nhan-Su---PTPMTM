using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CaData
    {

        private List<CaItem> ca = new List<CaItem>();

        public List<CaItem> Ca
        {
            get { return ca; }
            set { ca = value; }
        }

        private List<PhanCongItem> phancong = new List<PhanCongItem>();

        public List<PhanCongItem> Phancong
        {
            get { return phancong; }
            set { phancong = value; }
        }

        public void ListCa(string manv)
        {
            string mapc;
            DateTime DateBD;
            DateTime DateKT;
            using (DataNhanSuDataContext db = new DataNhanSuDataContext())
            {

                var phancailist = from PHANCONG in db.PHANCONGs
                                  select new
                                  {
                                      MA_PC = PHANCONG.MAPC,
                                      DAY_BD = PHANCONG.TUNGAY,
                                      DAY_KT = PHANCONG.DENNGAY,

                                  };

                foreach (var pcitem in phancailist)
                {
                    //CaItem itemCa = new CaItem();
                    PhanCongItem item = new PhanCongItem((DateTime)pcitem.DAY_BD, (DateTime)pcitem.DAY_KT, pcitem.MA_PC);
                    phancong.Add(item);
                }


                foreach (var chitietpc in phancong)
                {

                    var chitietca = from CHITIETPHANCONG in db.CHITIETPHANCONGs
                                .Where(M => M.MAPC.Equals(chitietpc.Mapc) && M.MANV.Equals(manv))
                                    select new
                                    {
                                        MA_PC = CHITIETPHANCONG.MAPC,
                                        MA_NV = CHITIETPHANCONG.MANV,
                                        MA_CA = CHITIETPHANCONG.MACA,
                                        NGAY_OF_TUAN = CHITIETPHANCONG.DAYOFTUAN,
                                    };

                    //public CaItem(DateTime NBD, DateTime NKT, string MAPC, string MANV, string MACA, int DAYOFWEEK)
                    //var bangluong = db.QUATRINHLUONGs.OrderByDescending(m => m.MANV.Equals(DALmaNV)).First();

                    //string luong = bangluong.LUONGCB.ToString();

                    int i = 0;
                    foreach (var chitiet in chitietca)
                    {
                        //CaItem itemCa = new CaItem();
                        CaItem item = new CaItem((DateTime)chitietpc.DateBD, (DateTime)chitietpc.DateKT, chitiet.MA_PC, chitiet.MA_NV, chitiet.MA_CA, chitiet.NGAY_OF_TUAN);
                        ca.Add(item);
                    }

                }


            }
        }

    }
}
