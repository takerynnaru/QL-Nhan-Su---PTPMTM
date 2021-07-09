using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
     public class BLLCaLamViec
    {
         DALCaLamViec clv = new DALCaLamViec();

         public BLLCaLamViec()
         {
            
         }

         public DataTable LoadMaTenCaBLL()
         {
             return clv.LoadMaTenCaDAL();
         }


    }
}
