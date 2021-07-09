using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALLoaiDonTu
    {
        public string DMaLoaiDon;
        public string DTenLoaiDon;

        public string DALTenLoaiDon(string maloai)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                LOAIDONTU thongtin = db.LOAIDONTUs.SingleOrDefault(NV => NV.MALOAIDON.Equals(maloai));
                return thongtin.TENLOAIDONTU;

            }
        }

    }
}
