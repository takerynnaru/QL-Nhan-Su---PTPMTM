using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataQuanLyNhanSuTableAdapters;

namespace DAL
{
    public class DALHongDong
    {
        HOPDONGTableAdapter daHopDong = new HOPDONGTableAdapter();
        public DALHongDong()
        {
        }
        public DataTable getDataHopDong()
        {
            return daHopDong.GetData();
        }
        public DataTable getDataHopDongTheoMa(string pMaHD)
        {
            return daHopDong.GetDataByMAHD(pMaHD);
        }
        public string taoMaHDTDDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daHopDong.GetData().Rows.Count);
            foreach (DataRow row in daHopDong.GetData().Rows)
            {
                str.Add((string)row["MaHD"]);
            }
            List<int> lstInt = new List<int>(str.Count);
            for (int i = 0; i < str.Count; i++)
            {
                string s = str[i].Substring(str[i].Length - 4, 4);
                lstInt.Add(int.Parse(s));
            }
            int max = lstInt.Max();
            max++;
            if (max <= 9)
            {
                MaTD = "HD000" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "HD00" + max.ToString();
            }
            else if (max <= 999)
            {
                MaTD = "HD0" + max.ToString();
            }
            else { MaTD = "HD" + max.ToString(); }
            return MaTD;
        }
        public int themHDDAL(string ma, string ten, DateTime ngaybd, DateTime ngaykt, DateTime ngayky, string tinhtrang, string nd)
        {
            return daHopDong.InsertQuery(ma, ten, ngaybd, ngaykt, ngayky, tinhtrang, nd);
        }
        public int XoaHDDAL(string ma)
        {
            return daHopDong.DeleteQuery(ma);
        }
        public int SuaHDDAL(string ten, DateTime ngaybd, DateTime ngaykt, DateTime ngayky, string tinhtrang, string nd, string ma)
        {
            return daHopDong.UpdateQuery(ten, ngaybd, ngaykt, ngayky, tinhtrang, nd, ma);
        }
    }

}
