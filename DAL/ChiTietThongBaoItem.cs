using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietThongBaoItem
    {
        private string ICTmatb; //MATB CHAR(6),

        public string ICTmatb1
        {
            get { return ICTmatb; }
            set { ICTmatb = value; }
        }
        private string ICTmanv; //MANV CHAR(6),

        public string ICTmanv1
        {
            get { return ICTmanv; }
            set { ICTmanv = value; }
        }

        public ChiTietThongBaoItem(string matb, string manv)
        {
            ICTmatb1 = matb;
            ICTmanv1 = manv;
        }

    }
}
