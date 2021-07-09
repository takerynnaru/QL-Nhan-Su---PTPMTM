using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLChucVu
    {
        DALChucVu cv = new DALChucVu();
        public BLLChucVu()
        { }
        public DataTable loaddgvDSCV()
        {
            return cv.getDataChucVu();
        }
        public DataTable loaddgvDSCVTheoMa(string ma)
        {
            return cv.getDaTaChucVuTheoMa(ma);
        }
        public string taoMaTD()
        {
            return cv.taoMaPBTDDAL();
        }
        public int themCV(string ma, string ten)
        {
            return cv.themCVDAL(ma, ten);
        }
        public int xoaCV(string ma)
        {
            return cv.xoaCVDAL(ma);
        }
        public int suaCV(string ten, string ma)
        {
            return cv.suaCVDAL(ten, ma);
        }
    }
}
