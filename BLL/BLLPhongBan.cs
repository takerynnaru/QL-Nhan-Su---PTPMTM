using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLPhongBan
    {
        DALPhongBan pb = new DALPhongBan();
        public BLLPhongBan()
        { }
        public DataTable loadDGVDSPB()
        {
            return pb.getDataPhongBan();
        }
        public DataTable loadDGVTheoMa(string ma)
        {
            return pb.getDataPhongBanTheoMa(ma);
        }
        public string taoMaTD()
        {
            return pb.taoMaPBTDDAL();
        }
        public int themPB(string ma, string ten, string truongphong)
        {
            return pb.themPBDAL(ma, ten, truongphong);
        }
        public int xoaPB(string ma)
        {
            return pb.xoaPBDAL(ma);
        }
        public int suaPB(string ten, string truongphong, string ma)
        {
            return pb.suaPBDAL(ten, truongphong, ma);
        }
    }
}
