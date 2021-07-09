using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongBaoItem
    {
        private string Imatb; //MATB CHAR(6),

        public string Imatb1
        {
            get { return Imatb; }
            set { Imatb = value; }
        }
        private string Inguoitao;//NGUOITAO CHAR(6),

        public string Inguoitao1
        {
            get { return Inguoitao; }
            set { Inguoitao = value; }
        }
        private DateTime Ingaytao;//NGAYTAO DATETIME,

        public DateTime Ingaytao1
        {
            get { return Ingaytao; }
            set { Ingaytao = value; }
        }
        private int Idoituong;//DOITUONGNHAN INT,

        public int Idoituong1
        {
            get { return Idoituong; }
            set { Idoituong = value; }
        }
        private string Imapb;//MAPB CHAR(6),

        public string Imapb1
        {
            get { return Imapb; }
            set { Imapb = value; }
        }
        private string Imanv;//MANV CHAR(6),

        public string Imanv1
        {
            get { return Imanv; }
            set { Imanv = value; }
        }
        private string Itieude;//TIEUDE NVARCHAR(100),

        public string Itieude1
        {
            get { return Itieude; }
            set { Itieude = value; }
        }
        private string Inoidung;//NOIDUNG NVARCHAR(300),

        public string Inoidung1
        {
            get { return Inoidung; }
            set { Inoidung = value; }
        }


        public ThongBaoItem(string matb, string nguoitao, DateTime ngaytao, int doituong, string mapb, string manv, string tieude, string noidung)
        {
            Imatb1 = matb;       ////public string Imatb; //MATB CHAR(6),
            Inguoitao1 = nguoitao;        ////public string Inguoitao;//NGUOITAO CHAR(6),
            Ingaytao1 = ngaytao;        ////public DateTime Ingaytao;//NGAYTAO DATETIME,
            Idoituong1 = doituong;        ////public int Idoituong;//DOITUONGNHAN INT,
            Imapb1 = mapb;        ////public string Imapb;//MAPB CHAR(6),
            Imanv1 = manv;        ////public string Imanv;//MANV CHAR(6),
            Itieude1 = tieude;       ////public string Itieude;//TIEUDE NVARCHAR(100),
            Inoidung1 = noidung;        ////public string Inoidung;//NOIDUNG NVARCHAR(300),
        }


    }////////////////////////////////////////////
}
