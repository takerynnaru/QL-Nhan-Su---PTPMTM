using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class DALBangPhu
    {
       public string ma;
       public string so;

       public DALBangPhu()
       { 
       
       }

       public int MaxMaDAL(string mama)
       {
           using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
           {
               try
               {
                   BANGPHU thongtin = db.BANGPHUs.SingleOrDefault(NV => NV.TENMA.Equals(mama));
                   return Convert.ToInt32(thongtin.MA);    

               }
               catch
               {
                   return 0;
               }
                              
           }
       }


       public void TangMaBangPhu(string mama)
       {
           using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
           {
               try
               {
                   BANGPHU thongtin = db.BANGPHUs.SingleOrDefault(NV => NV.TENMA.Equals(mama));
                   thongtin.MA = thongtin.MA + 1;
                   db.SubmitChanges();

               }
               catch
               {
                   return;
               }

           }
       }


    }
}
