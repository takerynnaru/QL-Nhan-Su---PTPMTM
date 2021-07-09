using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataQuanLyNhanSuTableAdapters;

namespace DAL
{
    public class DALPhongBan
    {
        PHONGBANTableAdapter daPhongBan = new PHONGBANTableAdapter();
        public DALPhongBan()
        { }
        public DataTable getDataPhongBan()
        {
            return daPhongBan.GetData();
        }
        public DataTable getDataPhongBanTheoMa(string ma)
        {
            return daPhongBan.GetDataByMaPH(ma);
        }
        public string taoMaPBTDDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daPhongBan.GetData().Rows.Count);
            foreach (DataRow row in daPhongBan.GetData().Rows)
            {
                str.Add((string)row["MAPH"]);
            }
            List<int> lstInt = new List<int>(str.Count);
            for (int i = 0; i < str.Count; i++)
            {
                string s = str[i].Substring(str[i].Length - 3, 3);
                lstInt.Add(int.Parse(s));
            }
            int max = lstInt.Max();
            max++;
            if (max <= 9)
            {
                MaTD = "MAR00" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "MAR0" + max.ToString();
            }
            else
            {
                MaTD = "MAR" + max.ToString();
            }

            return MaTD;
        }
        public int themPBDAL(string ma, string ten, string truongphong)
        {
            return daPhongBan.InsertQuery(ma, ten, null);
        }
        public int xoaPBDAL(string ma)
        {
            return daPhongBan.DeleteQuery(ma);
        }
        public int suaPBDAL(string ten, string truongphong, string ma)
        {
            return daPhongBan.UpdateQuery(ten, truongphong, ma);
        }
    }
}
