using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLFireBase
    {
        FireBase FB = new FireBase();

        public BLLFireBase()
        { }

        public int ConectFireBase()
        {
            if (FB.CreateFirebaseClient() == null)
            {               
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
