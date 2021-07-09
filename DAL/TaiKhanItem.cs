using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhanItem
    {

        private string madn;

        public string Madn
        {
            get { return madn; }
            set { madn = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private int hoatdong;

        public int Hoatdong
        {
            get { return hoatdong; }
            set { hoatdong = value; }
        }

        public TaiKhanItem()
        { }

        public TaiKhanItem(string madn, string pass, int hoatdong)
        {
            Madn = madn;
            Pass = pass;
            Hoatdong = hoatdong;
        }
    }
}
