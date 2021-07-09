using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataQuanLyNhanSuTableAdapters;

namespace DAL
{

    public class DALChucVu
    {
        CHUCVUTableAdapter daChucVu = new CHUCVUTableAdapter();
        public DALChucVu()
        { }
        public DataTable getDataChucVu()
        {
            return daChucVu.GetData();
        }
        public DataTable getDaTaChucVuTheoMa(string ma)
        {
            return daChucVu.GetDataByMACV(ma);
        }
        public string taoMaPBTDDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daChucVu.GetData().Rows.Count);
            foreach (DataRow row in daChucVu.GetData().Rows)
            {
                str.Add((string)row["MACHUCVU"]);
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
        public int themCVDAL(string ma, string ten)
        {
            return daChucVu.InsertQuery(ma, ten);
        }
        public int xoaCVDAL(string ma)
        {
            return daChucVu.DeleteQuery(ma);
        }
        public int suaCVDAL(string ten, string ma)
        {
            return daChucVu.UpdateQuery(ten, ma);
        }
    }
}
