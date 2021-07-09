using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataQuanLyNhanSuTableAdapters;
using System.Data;


namespace DAL
{
    public class DALDonTu
    {
        DataQuanLyNhanSu qlns = new DataQuanLyNhanSu();
        LOAIDONTUTableAdapter loaidontu = new LOAIDONTUTableAdapter();
        DONTUTableAdapter dontuadapter = new DONTUTableAdapter();
        DALLoaiDonTu loaidon = new DALLoaiDonTu();
        DALNhanVien nv = new DALNhanVien();

        public string Dmanv;    //MANV CHAR(6),
        public string Dmadon;    //MADON CHAR(6),
        public string Dloaidon;    //MALOAIDON CHAR(6),
        public string Dnguoilap;    //NGUOILAP CHAR(6),
        public int Dtaoho;    //TAOHO INT,
        public string Dnguoiduyet;    //NGUOIDUYET CHAR(6),
        public DateTime Dngaytao;    //NGAYTAO DATETIME,
        public string Dtrangthai;    //TRANGTHAI NVARCHAR(30),
        public string Dghichu;    //GHICHU NVARCHAR(50),
        //public string Dmadt    //MADON CHAR(6),
        public string Dlydo;    //LYDO NVARCHAR(60),
        public DateTime Dngaybd;        //NGAYBD DATETIME,
        public DateTime Dngaykt;        //NGAYKT DATETIME,
        public DateTime Dgiobd;        //GIOBD DATETIME,
        public DateTime Dgiokt;        //GIOKT DATETIME,
        public int Dtinhcong;        //TINHCONG INT,
        public string Dmota;        //MOTA NVARCHAR(200),
        public int Dphat;        //PHAT INT,
        /// <summary>
        /// thong tin them
        public string tenloaidon;
        public string tennhanvien;
        public string tennguoilap;
        public string tennguoiduyet;
        /// </summary>


        public List<DonTuItem> dsdontu = new List<DonTuItem>();

        public List<DonTuItem> Dsdontu
        {
            get { return dsdontu; }
            set { dsdontu = value; }
        }


        public DALDonTu()
        { 
        
        }

        ////load loai 
        public DataTable loadLoaiDonDAL()
        {
            return loaidontu.GetData();
        }

        //loadDONTU thoe ma nhan vien

        public DataTable loadDonTuByMANVofDAL(string manv)
        {
            return dontuadapter.GetDataDonTuByManv(manv);
        }

        // load don tu theo ngay ta

        public DataTable loadDonTuByNGAYTAOofDAL(DateTime ngaytao)
        {
            return dontuadapter.GetDataDoTuByNGAYTAO(ngaytao);
        }


        //TaoDonTu
        //public int 
        ///
        ///

        /// list don tu theo manv
        /// 
        public void ListDonTuOfManvDAL(string manv)
        {
            dsdontu = new List<DonTuItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                    var dontu = from DONTU in db.DONTUs
                                .Where(M => M.NGUOILAP.Equals(manv))
                                    select new
                                    {
                                        MA_NV = DONTU.MANV,
                                        MA_DON = DONTU.MADON,
                                        LOAI_DON = DONTU.MALOAIDON,
                                        NGUOI_LAP = DONTU.NGUOILAP,
                                        TAO_HO  = DONTU.TAOHO,
                                        NGUOI_DUYET = DONTU.NGUOIDUYET,
                                        NGAY_TAO = DONTU.NGAYTAO,
                                        TRANG_THAI = DONTU.TRANGTHAI,
                                        GHI_CHU = DONTU.GHICHU,
                                    };

                    int i = 0;
                    foreach (var chitiet in dontu)
                    {
                        //CaItem itemCa = new CaItem();

                        string tendon = loaidon.DALTenLoaiDon(chitiet.LOAI_DON);
                        string tennv = nv.DALTenNhanVien(chitiet.MA_NV);
                        string tennvLap = nv.DALTenNhanVien(chitiet.NGUOI_LAP);
                        string tennvDuyet = nv.DALTenNhanVien(chitiet.NGUOI_DUYET);
                        //CaItem itemCa = new CaItem();
                        DonTuItem item = new DonTuItem(chitiet.MA_DON, chitiet.MA_NV, tennv, tendon, tennvLap, Convert.ToInt32(chitiet.TAO_HO), tennvDuyet, (DateTime)chitiet.NGAY_TAO, chitiet.TRANG_THAI, chitiet.GHI_CHU);
                        dsdontu.Add(item);
                    }
            } 

        }

        /// list don tu all
        /// 
        public void ListDonTuAllDAL()
        {
            dsdontu = new List<DonTuItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var dontu = from DONTU in db.DONTUs
                            orderby DONTU.NGAYTAO descending
                            select new
                            {
                                MA_NV = DONTU.MANV,
                                MA_DON = DONTU.MADON,
                                LOAI_DON = DONTU.MALOAIDON,
                                NGUOI_LAP = DONTU.NGUOILAP,
                                TAO_HO = DONTU.TAOHO,
                                NGUOI_DUYET = DONTU.NGUOIDUYET,
                                NGAY_TAO = DONTU.NGAYTAO,
                                TRANG_THAI = DONTU.TRANGTHAI,
                                GHI_CHU = DONTU.GHICHU,
                            };

                int i = 0;
                foreach (var chitiet in dontu)
                {
                    //CaItem itemCa = new CaItem();

                    string tendon = loaidon.DALTenLoaiDon(chitiet.LOAI_DON);
                    string tennv = nv.DALTenNhanVien(chitiet.MA_NV);
                    string tennvLap = nv.DALTenNhanVien(chitiet.NGUOI_LAP);
                    string tennvDuyet = nv.DALTenNhanVien(chitiet.NGUOI_DUYET);
                    //CaItem itemCa = new CaItem();
                    DonTuItem item = new DonTuItem(chitiet.MA_DON, chitiet.MA_NV, tennv, tendon, tennvLap, Convert.ToInt32(chitiet.TAO_HO), tennvDuyet, (DateTime)chitiet.NGAY_TAO, chitiet.TRANG_THAI, chitiet.GHI_CHU);
                    dsdontu.Add(item);
                }
            }

        }


        // list dontu theo ngay 
        public bool isEqualDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        public void ListDonTuOfDayDAL(DateTime ngaytao, string manv)
        {
            try
            {
                dsdontu = new List<DonTuItem>();
                using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
                {

                    var dontu = from DONTU in db.DONTUs
                                //.Where(M => M.NGAYTAO.Equals(ngaytao))
                                .Where(M => ((DateTime)M.NGAYTAO).Day.Equals(ngaytao.Day) && ((DateTime)M.NGAYTAO).Month.Equals(ngaytao.Month) && M.NGUOILAP.Equals(manv))
                                select new
                                {
                                    MA_NV = DONTU.MANV,
                                    MA_DON = DONTU.MADON,
                                    LOAI_DON = DONTU.MALOAIDON,
                                    NGUOI_LAP = DONTU.NGUOILAP,
                                    TAO_HO = DONTU.TAOHO,
                                    NGUOI_DUYET = DONTU.NGUOIDUYET,
                                    NGAY_TAO = DONTU.NGAYTAO,
                                    TRANG_THAI = DONTU.TRANGTHAI,
                                    GHI_CHU = DONTU.GHICHU,
                                };

                    int i = 0;
                    foreach (var chitiet in dontu)
                    {
                        //CaItem itemCa = new CaItem();

                        string tendon = loaidon.DALTenLoaiDon(chitiet.LOAI_DON);
                        string tennv = nv.DALTenNhanVien(chitiet.MA_NV);
                        string tennvLap = nv.DALTenNhanVien(chitiet.NGUOI_LAP);
                        string tennvDuyet = nv.DALTenNhanVien(chitiet.NGUOI_DUYET);
                        //CaItem itemCa = new CaItem();
                        DonTuItem item = new DonTuItem(chitiet.MA_DON, chitiet.MA_NV, tennv, tendon, tennvLap, Convert.ToInt32(chitiet.TAO_HO), tennvDuyet, (DateTime)chitiet.NGAY_TAO, chitiet.TRANG_THAI, chitiet.GHI_CHU);
                        dsdontu.Add(item);
                    }
                }
            }
            catch { }
            

        }

        ///list don by day all
        public void ListDonTuOfDayAllDAL(DateTime ngaytao)
        {
            try
            {
                dsdontu = new List<DonTuItem>();
                using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
                {

                    var dontu = from DONTU in db.DONTUs
                                    //.Where(M => M.NGAYTAO.Equals(ngaytao))
                                .Where(M => ((DateTime)M.NGAYTAO).Day.Equals(ngaytao.Day) && ((DateTime)M.NGAYTAO).Month.Equals(ngaytao.Month))
                                select new
                                {
                                    MA_NV = DONTU.MANV,
                                    MA_DON = DONTU.MADON,
                                    LOAI_DON = DONTU.MALOAIDON,
                                    NGUOI_LAP = DONTU.NGUOILAP,
                                    TAO_HO = DONTU.TAOHO,
                                    NGUOI_DUYET = DONTU.NGUOIDUYET,
                                    NGAY_TAO = DONTU.NGAYTAO,
                                    TRANG_THAI = DONTU.TRANGTHAI,
                                    GHI_CHU = DONTU.GHICHU,
                                };

                    int i = 0;
                    foreach (var chitiet in dontu)
                    {
                        //CaItem itemCa = new CaItem();

                        string tendon = loaidon.DALTenLoaiDon(chitiet.LOAI_DON);
                        string tennv = nv.DALTenNhanVien(chitiet.MA_NV);
                        string tennvLap = nv.DALTenNhanVien(chitiet.NGUOI_LAP);
                        string tennvDuyet = nv.DALTenNhanVien(chitiet.NGUOI_DUYET);
                        //CaItem itemCa = new CaItem();
                        DonTuItem item = new DonTuItem(chitiet.MA_DON, chitiet.MA_NV, tennv, tendon, tennvLap, Convert.ToInt32(chitiet.TAO_HO), tennvDuyet, (DateTime)chitiet.NGAY_TAO, chitiet.TRANG_THAI, chitiet.GHI_CHU);
                        dsdontu.Add(item);
                    }
                }
            }
            catch { }


        }
        
        ///Chi tiet đơn từ nè!!!
        public void ChiTietDonTuDAL(string madon)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

               
                CHITIETDONTU thongtin = db.CHITIETDONTUs.SingleOrDefault(NV => NV.MADON.Equals(madon));
                Dmadon = thongtin.MADON;                //public string Dmadt    //MADON CHAR(6),
                Dlydo = thongtin.LYDO;                  //public string Dlydo;    //LYDO NVARCHAR(60),
                Dngaybd = (DateTime)thongtin.NGAYBD;    //public DateTime Dngaybd;        //NGAYBD DATETIME,
                Dngaykt = (DateTime)thongtin.NGAYKT;    //public DateTime Dngaykt;        //NGAYKT DATETIME,
                    Dgiobd = (DateTime)thongtin.GIOBD;      //public DateTime Dgiobd;        //GIOBD DATETIME,
                    Dgiokt = (DateTime)thongtin.GIOKT;      //public DateTime Dgiokt;        //GIOKT DATETIME,
                Dtinhcong =Convert.ToInt32( thongtin.TINHCONG);          //public int Dtinhcong;        //TINHCONG INT,
                Dmota = thongtin.MOTA;                   //public string Dmota;        //MOTA NVARCHAR(200),
                Dphat = Convert.ToInt32(thongtin.PHAT);  //public int Dphat;        //PHAT INT,
              
            }

        }

        /// THONG TIN CHUNG DO TU
        public void ThongTinDonTuDAL(string madon)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                DONTU thongtin = db.DONTUs.SingleOrDefault(NV => NV.MADON.Equals(madon));
                Dmanv = thongtin.MANV;                //public string Dmanv;    //MANV CHAR(6),
                Dmadon = thongtin.MADON;                //public string Dmadon;    //MADON CHAR(6),
                Dloaidon = thongtin.MALOAIDON;                //public string Dloaidon;    //MALOAIDON CHAR(6),
                Dnguoilap = thongtin.NGUOILAP;                //public string Dnguoilap;    //NGUOILAP CHAR(6),
                Dtaoho = Convert.ToInt32(thongtin.TAOHO);                //public int Dtaoho;    //TAOHO INT,
                Dnguoiduyet = thongtin.NGUOIDUYET;                //public string Dnguoiduyet;    //NGUOIDUYET CHAR(6),
                Dngaytao = (DateTime)thongtin.NGAYTAO;                 //public DateTime Dngaytao;    //NGAYTAO DATETIME,
                Dtrangthai = thongtin.TRANGTHAI;                //public string Dtrangthai;    //TRANGTHAI NVARCHAR(30),
                Dghichu = thongtin.GHICHU;                //public string Dghichu;    //GHICHU NVARCHAR(50)
                /////
                tenloaidon = loaidon.DALTenLoaiDon(thongtin.MALOAIDON);
                tennhanvien = nv.DALTenNhanVien(thongtin.MANV);
                tennguoilap = nv.DALTenNhanVien(thongtin.NGUOILAP);
                tennguoiduyet = nv.DALTenNhanVien(thongtin.NGUOIDUYET);
            }

        }

        ////SUA return 0 that bai / return 1 thanh cong
        public int SuaDonTuDAL(string madon ,string tieude, string nguoiduyet, DateTime ngaybd, DateTime ngaykt, DateTime giobd, DateTime giokt, string mota, string lydo)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                
                DONTU DTmoi = db.DONTUs
                    .Where(r => r.MADON == madon)
                    .First();

                DTmoi.GHICHU = tieude;
                DTmoi.NGUOIDUYET = nguoiduyet;

                db.SubmitChanges();

                CHITIETDONTU CTmoi = db.CHITIETDONTUs
                    .Where(r => r.MADON == madon)
                    .First();

                CTmoi.NGAYBD = ngaybd;
                CTmoi.NGAYKT =ngaykt;
                CTmoi.GIOBD = giobd;
                CTmoi.GIOKT = giokt;
                CTmoi.MOTA = mota;
                CTmoi.LYDO = lydo;

                db.SubmitChanges();
                return 1;
            }

            return 0;
        }



        ///XOA
        public int XoaDonTuDAL(string madon)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    DONTU DTmoi = db.DONTUs
                        .Where(r => r.MADON == madon)
                        .First();
                    db.DONTUs.DeleteOnSubmit(DTmoi);

                    CHITIETDONTU CTmoi = db.CHITIETDONTUs
                    .Where(r => r.MADON == madon)
                    .First();
                    db.CHITIETDONTUs.DeleteOnSubmit(CTmoi);
                    db.SubmitChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            
        }

        //tao don

        public int ThemDonTuDAL(string manv, string madon, string maloai, string nguoilap, int taoho, string nguoiduyet, DateTime ngaytao, string trangthai, string tieude)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    DONTU dt = new DONTU
                    {
                        MANV = manv,
                        MADON = madon,
                        MALOAIDON = maloai,
                        NGUOILAP = nguoilap,
                        TAOHO = taoho,
                        NGUOIDUYET = nguoiduyet,
                        NGAYTAO = (DateTime)ngaytao,
                        TRANGTHAI = trangthai,
                        GHICHU = tieude,
                        
                    };

                    db.DONTUs.InsertOnSubmit(dt);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }
        
        }


        public int ThemChiTietDonTuDAL(string madon, string lydo, DateTime ngaybd, DateTime ngaykt, DateTime giobd, DateTime giokt, int tinhcong, string mota)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    CHITIETDONTU dt = new CHITIETDONTU
                    {
                        MADON = madon,
                        LYDO = lydo,
                        NGAYBD = ngaybd,
                        NGAYKT = ngaykt,
                        GIOBD = giobd,
                        GIOKT = giokt,
                        TINHCONG = tinhcong,
                        MOTA = mota,
                    };

                    db.CHITIETDONTUs.InsertOnSubmit(dt);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }
        }
        //////dUYET dON
        ////SUA return 0 that bai / return 1 thanh cong
        public int DuyetDonTuDAL(string madon, string trangthai)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    DONTU DTmoi = db.DONTUs
                    .Where(r => r.MADON == madon)
                    .First();

                    DTmoi.TRANGTHAI = trangthai;

                    db.SubmitChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
                
            }

           
        }


    }////////////////////////////////////////
}
