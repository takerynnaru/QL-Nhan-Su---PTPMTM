using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace BLL
{
    public class BLLFireBase
    {


        public IFirebaseClient CreateFirebaseClient()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "akZMbhafpNSLb4TU8NdovrHLJDkOZlyRndQswuRY",
                BasePath = "https://qlsinhvien-bbfa1-default-rtdb.firebaseio.com"

            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(config);
            return client;
        }
        public async void FirebaseInsertData(IFirebaseClient client, object
                                 data, string rootName)
        {

            if (client != null)
            {

                await client.SetAsync(rootName, data);
            }
        }

        public async void FirebaseDeleteData(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                await client.DeleteAsync(rootName);
            }
        }

        public async void FirebaseUpdateData(IFirebaseClient client, object data, string rootName)
        {
            if (client != null)
            {
                await client.UpdateAsync(rootName, data);
            }
        }

        //FireBase FB = new FireBase();

        //public BLLFireBase()
        //{ }

        //public int ConectFireBase()
        //{
        //    if (FB.CreateFirebaseClient() == null)
        //    {               
        //        return 0;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}

        //public int FireBaseInsertDataBLL(IFirebaseClient client, object data, string rootName)
        //{
        //    try
        //    {

        //        FB.FirebaseInsertData(FB.CreateFirebaseClient(), data, rootName);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        
        //}
    }
}
