using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLDonTu
    {
        DALDonTu dt = new DALDonTu();
        DALLoaiDonTu loaidon = new DALLoaiDonTu();
        DALNhanVien nv = new DALNhanVien();

        public string Bmanv;    //MANV CHAR(6),
        public string Bmadon;    //MADON CHAR(6),
        public string Bloaidon;    //MALOAIDON CHAR(6),
        public string Bnguoilap;    //NGUOILAP CHAR(6),
        public int Btaoho;    //TAOHO INT,
        public string Bnguoiduyet;    //NGUOIDUYET CHAR(6),
        public DateTime Bngaytao;    //NGAYTAO DATETIME,
        public string Btrangthai;    //TRANGTHAI NVARCHAR(30),
        public string Bghichu;    //GHICHU NVARCHAR(50),

        //public string Dmadt    //MADON CHAR(6),
        public string Blydo;    //LYDO NVARCHAR(60),
        public DateTime Bngaybd;        //NGAYBD DATETIME,
        public DateTime Bngaykt;        //NGAYKT DATETIME,
        public DateTime Bgiobd;        //GIOBD DATETIME,
        public DateTime Bgiokt;        //GIOKT DATETIME,
        public int Btinhcong;        //TINHCONG INT,
        public string Bmota;        //MOTA NVARCHAR(200),
        public int Bphat;        //PHAT INT,

        /// <summary>
        /// thong tin them
        public string tenloaidon;
        public string tennhanvien;
        public string tennguoilap;
        public string tennguoiduyet;
        /// </summary>

        public BLLDonTu()
        {
        
        
        }
               ////load loai 
        public DataTable loadLoaiDon()
        {
            return dt.loadLoaiDonDAL();
        }
        //load don tu theo ma nhan vien
        public DataTable loadDonTuByMANVofBLL(string manv)
        {
            return dt.loadDonTuByMANVofDAL(manv);
        }
        //load don tu theo ngay
        public DataTable loadDonTuByNGAYTAOofBLL(DateTime ngaytao)
        {
            return dt.loadDonTuByNGAYTAOofDAL(ngaytao);
        }

        public List<DonTuItem> dsdontu = new List<DonTuItem>();

        public List<DonTuItem> Dsdontu
        {
            get { return dsdontu; }
            set { dsdontu = value; }
        }

        public void ListDonTuAllDAL()
        {
            dsdontu = new List<DonTuItem>();
            dt.ListDonTuAllDAL();
            int i = 0;
            foreach (var chitiet in dt.dsdontu)
            {
                DonTuItem item = new DonTuItem(chitiet.Madon1, chitiet.Manv1, chitiet.Tennv1, chitiet.Loaidon1, chitiet.Nguoilap1, Convert.ToInt32(chitiet.Taoho1), chitiet.Nguoiduyet1, (DateTime)chitiet.Ngaytao1, chitiet.Trangthai1, chitiet.Ghichu1);
                dsdontu.Add(item);
            }
        }

        public void ListDonTuOfManvBLL(string manv)
        {
            dsdontu = new List<DonTuItem>();
            dt.ListDonTuOfManvDAL(manv);
            int i = 0;
            foreach (var chitiet in dt.dsdontu)
            {               
                DonTuItem item = new DonTuItem(chitiet.Madon1, chitiet.Manv1, chitiet.Tennv1, chitiet.Loaidon1, chitiet.Nguoilap1, Convert.ToInt32(chitiet.Taoho1), chitiet.Nguoiduyet1, (DateTime)chitiet.Ngaytao1, chitiet.Trangthai1, chitiet.Ghichu1);
                dsdontu.Add(item);
            }
            
        }

        public void ListDonTuOfDayBLL(DateTime ngaytao, string manv)
        {
            dsdontu = new List<DonTuItem>();
            dt.ListDonTuOfDayDAL(ngaytao, manv);
            int i = 0;
            foreach (var chitiet in dt.dsdontu)
            {
                DonTuItem item = new DonTuItem(chitiet.Madon1, chitiet.Manv1, chitiet.Tennv1, chitiet.Loaidon1, chitiet.Nguoilap1, Convert.ToInt32(chitiet.Taoho1), chitiet.Nguoiduyet1, (DateTime)chitiet.Ngaytao1, chitiet.Trangthai1, chitiet.Ghichu1);
                dsdontu.Add(item);
            }

        }

        public void ListDonTuOfDayAllBLL(DateTime ngaytao)
        {
            dsdontu = new List<DonTuItem>();
            dt.ListDonTuOfDayAllDAL(ngaytao);
            int i = 0;
            foreach (var chitiet in dt.dsdontu)
            {
                DonTuItem item = new DonTuItem(chitiet.Madon1, chitiet.Manv1, chitiet.Tennv1, chitiet.Loaidon1, chitiet.Nguoilap1, Convert.ToInt32(chitiet.Taoho1), chitiet.Nguoiduyet1, (DateTime)chitiet.Ngaytao1, chitiet.Trangthai1, chitiet.Ghichu1);
                dsdontu.Add(item);
            }

        }

        ///Chi tiet đơn từ nè!!!
        public void ChiTietDonTuBLL(string madon)
        {
            dt.ChiTietDonTuDAL(madon);
                Bmadon = dt.Dmadon;                //public string Dmadt    //MADON CHAR(6),
                Blydo = dt.Dlydo;    //LYDO NVARCHAR(60),
                Bngaybd = (DateTime)dt.Dngaybd;        //NGAYBD DATETIME,
                Bngaykt = (DateTime)dt.Dngaykt;        //NGAYKT DATETIME,
                Bgiobd = (DateTime)dt.Dgiobd;        //GIOBD DATETIME,
                Bgiokt = (DateTime)dt.Dgiokt;        //GIOKT DATETIME,
                Btinhcong = Convert.ToInt32(dt.Dtinhcong);        //TINHCONG INT,
                Bmota = dt.Dmota;        //MOTA NVARCHAR(200),
                Bphat = Convert.ToInt32(dt.Dphat);        //PHAT INT,

        }

        /// THONG TIN CHUNG DO TU
        public void ThongTinDonTuBLL(string madon)
        {
            dt.ThongTinDonTuDAL(madon);
                Bmanv =  dt.Dmanv;    //MANV CHAR(6),
                Bmadon = dt.Dmadon;    //MADON CHAR(6),
                Bloaidon = dt.Dloaidon;    //MALOAIDON CHAR(6),
                Bnguoilap = dt.Dnguoilap;    //NGUOILAP CHAR(6),
                Btaoho = Convert.ToInt32(dt.Dtaoho);    //TAOHO INT,
                Bnguoiduyet = dt.Dnguoiduyet;    //NGUOIDUYET CHAR(6),
                Bngaytao = (DateTime)dt.Dngaytao;    //NGAYTAO DATETIME,
                Btrangthai = dt.Dtrangthai;    //TRANGTHAI NVARCHAR(30),
                Bghichu = dt.Dghichu;    //GHICHU NVARCHAR(50)
                /////
                tenloaidon = loaidon.DALTenLoaiDon(dt.Dloaidon);
                tennhanvien = nv.DALTenNhanVien(dt.Dmanv);
                tennguoilap = nv.DALTenNhanVien(dt.Dnguoilap);
                tennguoiduyet = nv.DALTenNhanVien(dt.Dnguoiduyet);

        }

        ///SUA
        ///
        public int SuaDonTuBLL(string madon, string tieude, string nguoiduyet, DateTime ngaybd, DateTime ngaykt, DateTime giobd, DateTime giokt, string mota, string lydo)
        {
            int kt = dt.SuaDonTuDAL(madon, tieude,  nguoiduyet,  ngaybd,  ngaykt,  giobd,  giokt,  mota, lydo );
            if (kt == 1)
                return 1;
            else
                return 0;
        }


        public int DuyetDonTuBLL(string madon,  string trangthai)
        {
            int kt = dt.DuyetDonTuDAL(madon, trangthai);
            if (kt == 1)
                return 1;
            else
                return 0;
        }

        //xoa

        public int XoaDonTuBLL(string madon)
        {
            int kt = dt.XoaDonTuDAL(madon);
            if (kt == 1)
                return 1;
            else
                return 0;
        }

        //Themdontu
        public int ThemDonTuBLL(string manv, string madon, string maloai, string nguoilap, int taoho, string nguoiduyet, DateTime ngaytao, string trangthai, string tieude)
        {
            int kt = dt.ThemDonTuDAL( manv, madon,  maloai,  nguoilap, taoho, nguoiduyet,  ngaytao,  trangthai, tieude);
            if (kt == 1)
                return 1;
            else
                return 0;

        }
        //THEM CHI TIET DON TU
        public int ThemChiTietDonTuBLL(string madon, string lydo, DateTime ngaybd, DateTime ngaykt, DateTime giobd, DateTime giokt, int tinhcong, string mota)
        {
            int kt = dt.ThemChiTietDonTuDAL(madon,  lydo,  ngaybd,  ngaykt, giobd,  giokt,  tinhcong, mota);
            if (kt == 1)
                return 1;
            else
                return 0;
        
        }

        public string BLLTenLoaiDon(string maloai)
        {
            return loaidon.DALTenLoaiDon(maloai);
        }

    }///////////////////////
}
