using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DAL
{
    public class FireBase
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
    }
}
