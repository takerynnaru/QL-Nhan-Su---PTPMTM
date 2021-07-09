using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class PhanCongItem
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

        public PhanCongItem(DateTime NBD, DateTime NKT, string MAPC)
        {
            DateBD = NBD;
            DateKT = NKT;
            Mapc = MAPC;
        }
    }
}
