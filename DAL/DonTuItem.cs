using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonTuItem
    {
        private string Manv;    //MANV CHAR(6),

        public string Manv1
        {
            get { return Manv; }
            set { Manv = value; }
        }

        private string Tennv;  //tennv

        public string Tennv1
        {
            get { return Tennv; }
            set { Tennv = value; }
        }

        private string Madon;    //MADON CHAR(6),

        public string Madon1
        {
            get { return Madon; }
            set { Madon = value; }
        }


        private string Loaidon;    //MALOAIDON CHAR(6),

        public string Loaidon1
        {
            get { return Loaidon; }
            set { Loaidon = value; }
        }
        private string Nguoilap;    //NGUOILAP CHAR(6),

        public string Nguoilap1
        {
            get { return Nguoilap; }
            set { Nguoilap = value; }
        }
        private int Taoho;    //TAOHO INT,

        public int Taoho1
        {
            get { return Taoho; }
            set { Taoho = value; }
        }
        private string Nguoiduyet;    //NGUOIDUYET CHAR(6),

        public string Nguoiduyet1
        {
            get { return Nguoiduyet; }
            set { Nguoiduyet = value; }
        }
        private DateTime Ngaytao;    //NGAYTAO DATETIME,

        public DateTime Ngaytao1
        {
            get { return Ngaytao; }
            set { Ngaytao = value; }
        }
        private string Trangthai;    //TRANGTHAI NVARCHAR(30),

        public string Trangthai1
        {
            get { return Trangthai; }
            set { Trangthai = value; }
        }
        private string Ghichu;    //GHICHU NVARCHAR(50),

        public string Ghichu1
        {
            get { return Ghichu; }
            set { Ghichu = value; }
        }
        //public string Dmadt    //MADON CHAR(6)

        // public CaItem(DateTime NBD, DateTime NKT, string MAPC, string MANV, string MACA, int DAYOFWEEK)
        //{
        //    DateBD = NBD;
        //    DateKT = NKT;
        //    Mapc = MAPC;
        //    Manv = MANV;
        //    Maca = MACA;
        //    DayOfTuan = DAYOFWEEK;
        //}

        public DonTuItem()
        {

        }

        public DonTuItem(string madon, string manv, string tennv, string tendon, string nguoilap, int taoho, string nguouduyet, DateTime ngaytao, string trangthai, string ghichu)
        {
            Madon1 = madon;
            Manv1 = manv;
            Tennv1 = tennv;
            Loaidon1 = tendon;
            Nguoilap1 = nguoilap;
            Taoho1 = taoho;
            Nguoiduyet1 = nguouduyet;
            Ngaytao1 = ngaytao;
            Trangthai1 = trangthai;
            Ghichu1 = ghichu;

        }
    }
}
