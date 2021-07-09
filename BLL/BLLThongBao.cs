using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{   
    public class BLLThongBao
    {
        public string Bmatb; //MATB CHAR(6),
        public string Bnguoitao;//NGUOITAO CHAR(6),
        public DateTime Bngaytao;//NGAYTAO DATETIME,
        public int Bdoituong;//DOITUONGNHAN INT,
        public string Bmapb;//MAPB CHAR(6),
        public string Bmanv;//MANV CHAR(6),
        public string Btieude;//TIEUDE NVARCHAR(100),
        public string Bnoidung;//NOIDUNG NVARCHAR(300),
        public string Bmanvchitiet;//MANVchitiet CHAR(6),

        DALThongBao TB = new DALThongBao();

        private List<ThongBaoItem> dsthongbaoB = new List<ThongBaoItem>();

        public List<ThongBaoItem> DsthongbaoB
        {
            get { return dsthongbaoB; }
            set { dsthongbaoB = value; }
        }

        private List<ChiTietThongBaoItem> dsCTthongbaoB = new List<ChiTietThongBaoItem>();

        public List<ChiTietThongBaoItem> DsCTthongbaoB
        {
            get { return dsCTthongbaoB; }
            set { dsCTthongbaoB = value; }
        }



        /// <summary>
        /// /////////
        /// </summary>

        //list thong bao
        public void ListThongBaoBLL()
        {
            dsthongbaoB = new List<ThongBaoItem>();
            TB.ListThongBaoDAL();
            int i = 0;
            foreach (var chitiet in TB.Dsthongbao)
            {
                ThongBaoItem item = new ThongBaoItem(chitiet.Imatb1, chitiet.Inguoitao1, (DateTime)chitiet.Ingaytao1, Convert.ToInt32(chitiet.Idoituong1), chitiet.Imapb1, chitiet.Imanv1, chitiet.Itieude1, chitiet.Inoidung1);
                dsthongbaoB.Add(item);
            }

        }

        //list thong bao theo ma thong bao
        public void ListChiTietThongBaoByMATBBBL(string matb)
        {
            dsCTthongbaoB = new List<ChiTietThongBaoItem>();
            TB.ListChiTietThongBaoByMATBDAL(matb);
            int i = 0;
            foreach (var chitiet in TB.DsCTthongbao)
            {
                ChiTietThongBaoItem item = new ChiTietThongBaoItem(chitiet.ICTmatb1, chitiet.ICTmanv1); 
                dsCTthongbaoB.Add(item);
            }

        }
        //list thong bao theo ma nhaan vien

        public void ListChiTietThongBaoByMANVBBL(string manv)
        {
            dsCTthongbaoB = new List<ChiTietThongBaoItem>();
            TB.ListChiTietThongBaoByMANVDAL(manv);
            int i = 0;
            foreach (var chitiet in TB.DsCTthongbao)
            {
                ChiTietThongBaoItem item = new ChiTietThongBaoItem(chitiet.ICTmatb1, chitiet.ICTmanv1);
                dsCTthongbaoB.Add(item);
            }

        }

        //loat thong tin 1 thong bao

        public void LoadThongTinThongBaoBLL(string matb)
        {
            TB.LoadThongTinThongBaoDAL(matb);
            Bmatb = TB.Dmatb;   //Dmatb = thongtin.MATB; //public string Dmatb; //MATB CHAR(6),
            Bnguoitao = TB.Dnguoitao;    //Dnguoitao = thongtin.NGUOITAO;//public string Dnguoitao;//NGUOITAO CHAR(6),
            Bngaytao = (DateTime)TB.Dngaytao;    //Dngaytao = (DateTime)thongtin.NGAYTAO;//public DateTime Dngaytao;//NGAYTAO DATETIME,
            Bdoituong = Convert.ToInt32(TB.Ddoituong);    //Ddoituong = Convert.ToInt32(thongtin.DOITUONGNHAN);//public int Ddoituong;//DOITUONGNHAN INT,
            Bmapb = TB.Dmapb;    //Dmapb = thongtin.MAPB;//public string Dmapb;//MAPB CHAR(6),
            Bmanv = TB.Dmanv;    //Dmanv = thongtin.MANV;//public string Dmanv;//MANV CHAR(6),
            Btieude = TB.Dtieude;    //Dtieude = thongtin.TIEUDE;//public string Dtieude;//TIEUDE NVARCHAR(100),
            Bnoidung = TB.Dnoidung;    //Dnoidung = thongtin.NOIDUNG;//public string Dnoidung;//NOIDUNG NVARCHAR(300),
                ////public string Dmanvchitiet;//MANVchitiet CHAR(6),

        }

        //Them thong bao
        public int ThemThongBaoBLL(string matb, string nguoitao, DateTime ngaytao, int doituong, string mapb, string manv, string tieude, string noidung)
        {
            int kt = TB.ThemThongBaoDAL(matb, nguoitao,  ngaytao,  doituong,  mapb,  manv, tieude,  noidung);
            if (kt == 1)
                return 1;
            else
                return 0;

        }
        //THEM CHI TIET DON TU
        public int ThemChiTietThongBaoBLL(string matb, string manv)
        {
            int kt = TB.ThemChiTietThongBaoDAL(matb, manv);
            if (kt == 1)
                return 1;
            else
                return 0;

        }




    }/////////////////////////////////////////
}
