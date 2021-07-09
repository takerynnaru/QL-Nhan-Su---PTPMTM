using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALThongBao
    {
        public string Dmatb; //MATB CHAR(6),
        public string Dnguoitao;//NGUOITAO CHAR(6),
        public DateTime Dngaytao;//NGAYTAO DATETIME,
        public int Ddoituong;//DOITUONGNHAN INT,
        public string Dmapb;//MAPB CHAR(6),
        public string Dmanv;//MANV CHAR(6),
        public string Dtieude;//TIEUDE NVARCHAR(100),
        public string Dnoidung;//NOIDUNG NVARCHAR(300),
        public string Dmanvchitiet;//MANVchitiet CHAR(6),

        public DALThongBao()
        { }

        private List<ThongBaoItem> dsthongbao = new List<ThongBaoItem>();

        public List<ThongBaoItem> Dsthongbao
        {
            get { return dsthongbao; }
            set { dsthongbao = value; }
        }
        //////////////////////////

        private List<ChiTietThongBaoItem> dsCTthongbao = new List<ChiTietThongBaoItem>();

        public List<ChiTietThongBaoItem> DsCTthongbao
        {
            get { return dsCTthongbao; }
            set { dsCTthongbao = value; }
        }

        //////////////////load thong tin thong bao

        public void LoadThongTinThongBaoDAL(string matb)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                THONGBAO thongtin = db.THONGBAOs.SingleOrDefault(NV => NV.MATB.Equals(matb));
                Dmatb = thongtin.MATB; //public string Dmatb; //MATB CHAR(6),
                Dnguoitao = thongtin.NGUOITAO;//public string Dnguoitao;//NGUOITAO CHAR(6),
                Dngaytao = (DateTime)thongtin.NGAYTAO;//public DateTime Dngaytao;//NGAYTAO DATETIME,
                Ddoituong = Convert.ToInt32(thongtin.DOITUONGNHAN);//public int Ddoituong;//DOITUONGNHAN INT,
                Dmapb = thongtin.MAPB;//public string Dmapb;//MAPB CHAR(6),
                Dmanv = thongtin.MANV;//public string Dmanv;//MANV CHAR(6),
                Dtieude = thongtin.TIEUDE;//public string Dtieude;//TIEUDE NVARCHAR(100),
                Dnoidung = thongtin.NOIDUNG;//public string Dnoidung;//NOIDUNG NVARCHAR(300),
                //public string Dmanvchitiet;//MANVchitiet CHAR(6),
            }

        }

        /// <summary>
        /// /////////////////////////////list danh sach thong bao////////////////////////////////////////////////////////////////////
        /// </summary>
        public void ListThongBaoDAL()
        {
            dsthongbao = new List<ThongBaoItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var thongbao = from THONGBAO in db.THONGBAOs
                            //.Where(M => M.NGUOILAP.Equals(manv))
                            select new
                            {
                                MA_TB = THONGBAO.MATB,
                                NGUOI_TAO = THONGBAO.NGUOITAO,
                                NGAY_TAO = THONGBAO.NGAYTAO,
                                DOI_TUONG = THONGBAO.DOITUONGNHAN,
                                MA_PB = THONGBAO.MAPB,
                                MA_NV = THONGBAO.MANV,
                                TIEU_DE = THONGBAO.TIEUDE,
                                NOI_DUNG = THONGBAO.NOIDUNG,
                            };

                int i = 0;
                foreach (var chitiet in thongbao)
                {
                    //CaItem itemCa = new CaItem();
                    ThongBaoItem item = new ThongBaoItem(chitiet.MA_TB, chitiet.NGUOI_TAO, (DateTime)chitiet.NGAY_TAO, Convert.ToInt32(chitiet.DOI_TUONG), chitiet.MA_PB, chitiet.MA_NV, chitiet.TIEU_DE, chitiet.NOI_DUNG);
                    dsthongbao.Add(item);
                }
            }

        }



        // TIMF CHI TIET THOE MA THONG BAO
        public void ListChiTietThongBaoByMATBDAL(string matb)
        {
            dsCTthongbao = new List<ChiTietThongBaoItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var ctthongbao = from CHITIETTHONGBAO in db.CHITIETTHONGBAOs
                               .Where(M => M.MATB.Equals(matb))
                               .Reverse()
                               select new
                               {
                                   MA_TB = CHITIETTHONGBAO.MATB,
                                   MA_NV = CHITIETTHONGBAO.MANV,
                               };

                int i = 0;
                foreach (var chitiet in ctthongbao)
                {
                    //CaItem itemCa = new CaItem();
                    ChiTietThongBaoItem item = new ChiTietThongBaoItem(chitiet.MA_TB, chitiet.MA_NV);
                    dsCTthongbao.Add(item);
                }
            }

        }

        ///  TIM CHI TIET THEO MA NHAN VIEN
        public void ListChiTietThongBaoByMANVDAL(string manv)
        {
            dsCTthongbao = new List<ChiTietThongBaoItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var ctthongbao = from CHITIETTHONGBAO in db.CHITIETTHONGBAOs
                               .Where(M => M.MANV.Equals(manv))
                                 select new
                                 {
                                     MA_TB = CHITIETTHONGBAO.MATB,
                                     MA_NV = CHITIETTHONGBAO.MANV,
                                 };

                int i = 0;
                foreach (var chitiet in ctthongbao)
                {
                    //CaItem itemCa = new CaItem();
                    ChiTietThongBaoItem item = new ChiTietThongBaoItem(chitiet.MA_TB, chitiet.MA_NV);
                    dsCTthongbao.Add(item);
                }
            }

        }

        //tao thong bao

        public int ThemThongBaoDAL(string matb, string nguoitao, DateTime ngaytao, int doituong, string mapb, string manv, string tieude, string noidung)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    THONGBAO tb = new THONGBAO
                    {
                       MATB = matb,
                       NGUOITAO = nguoitao,
                       NGAYTAO = (DateTime)ngaytao,
                       DOITUONGNHAN = Convert.ToInt32(doituong),
                       MAPB = mapb,
                       MANV = manv,
                       TIEUDE = tieude,
                       NOIDUNG = noidung,
                    };

                    db.THONGBAOs.InsertOnSubmit(tb);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }

        }


        public int ThemChiTietThongBaoDAL(string matb, string manv)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    CHITIETTHONGBAO dt = new CHITIETTHONGBAO
                    {
                       MATB = matb,
                       MANV = manv
                    };

                    db.CHITIETTHONGBAOs.InsertOnSubmit(dt);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }
        }

    }/////////////////////////////////////////////////
}
