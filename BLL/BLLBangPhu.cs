using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLLBangPhu
    {
        DALBangPhu BP = new DALBangPhu();
       public string ma;
       public string so;

       public BLLBangPhu()
       { 
       
       }
       public int MaxMaBLL(string mama)
       {
           return BP.MaxMaDAL(mama); 
       }

        ////them 1
       public void TangMaBangPhuBLL(string mama)
       {
           BP.TangMaBangPhu(mama);
       }


    }
}
