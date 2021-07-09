using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CaItem
    {
        private DateTime dateBD;

        public DateTime DateBD
        {
            get { return dateBD; }
            set { dateBD = value; }
        }

        private DateTime dateKT;

        public DateTime DateKT
        {
            get { return dateKT; }
            set { dateKT = value; }
        }

        private string mapc;

        public string Mapc
        {
            get { return mapc; }
            set { mapc = value; }
        }

        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private string maca;

        public string Maca
        {
            get { return maca; }
            set { maca = value; }
        }

        private int dayOfTuan;

        public int DayOfTuan
        {
            get { return dayOfTuan; }
            set { dayOfTuan = value; }
        }

        public CaItem()
        {

        }

        public CaItem(DateTime NBD, DateTime NKT, string MAPC, string MANV, string MACA, int DAYOFWEEK)
        {
            DateBD = NBD;
            DateKT = NKT;
            Mapc = MAPC;
            Manv = MANV;
            Maca = MACA;
            DayOfTuan = DAYOFWEEK;
        }

    }
}
