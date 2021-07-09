using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataQuanLyNhanSuTableAdapters;
using System.Data;

namespace DAL
{
    public class DALCaLamViec
    {
        DataQuanLyNhanSu qlns = new DataQuanLyNhanSu();
        CALAMVIECTableAdapter calam = new CALAMVIECTableAdapter();

        public DALCaLamViec()
        { 
        
        }

        public DataTable LoadMaTenCaDAL()
        {
            return calam.GetDataMaTenCa();
        }
    }
}
