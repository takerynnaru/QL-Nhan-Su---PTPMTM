using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLHopDong
    {
        DALHongDong hd = new DALHongDong();
        public BLLHopDong()
        { }
        public DataTable loadDGVDSHD()
        {
            return hd.getDataHopDong();
        }
        public DataTable loadDGVDSHDTheoMa(string pMaHD)
        {
            return hd.getDataHopDongTheoMa(pMaHD);
        }
        public string taoMaHDTDBLL()
        {
            return hd.taoMaHDTDDAL();
        }
        public int ThemHD(string ma, string ten, DateTime ngaybd, DateTime ngaykt, DateTime ngayky, string tinhtrang, string nd)
        {
            return hd.themHDDAL(ma, ten, ngaybd, ngaykt, ngayky, tinhtrang, nd);
        }
        public int XoaHD(string ma)
        {
            return hd.XoaHDDAL(ma);
        }
        public int SuaHD(string ten, DateTime ngaybd, DateTime ngaykt, DateTime ngayky, string tinhtrang, string nd, string ma)
        {
            return hd.SuaHDDAL(ten, ngaybd, ngaykt, ngayky, tinhtrang, nd, ma);
        }
    }
}
