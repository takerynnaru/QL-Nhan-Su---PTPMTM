using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataQuanLyNhanSuTableAdapters;

namespace DAL
{
    public class DALQLNhanVien
    {
        NHANVIENTableAdapter daNhanVien = new NHANVIENTableAdapter();
        PHONGBANTableAdapter daPhongBan = new PHONGBANTableAdapter();
        CHUCVUTableAdapter daChucVu = new CHUCVUTableAdapter();
        DALBangPhu BP = new DALBangPhu();
        public DALQLNhanVien()
        { }
        public string taoMaNVTDDAL()
        {
            string MaTD = "";
            //List<string> str = new List<string>(daNhanVien.GetData().Rows.Count);
            //foreach (DataRow row in daNhanVien.GetData().Rows)
            //{
            //    str.Add((string)row["MaNV"]);
            //}
            //List<int> lstInt = new List<int>(str.Count);
            //for (int i = 0; i < str.Count; i++)
            //{
            //    string s = str[i].Substring(str[i].Length - 4, 4);
            //    lstInt.Add(int.Parse(s));
            //}
            //int max = lstInt.Max();
            //max++;
            //if (max <= 9)
            //{
            //    MaTD = "NV000" + max.ToString();
            //}
            //else if (max <= 99)
            //{
            //    MaTD = "NV00" + max.ToString();
            //}
            //else if (max <= 999)
            //{
            //    MaTD = "NV0" + max.ToString();
            //}
            //else { MaTD = "NV" + max.ToString(); }
            int MA = BP.MaxMaDAL("MANV  ");
            MaTD = "NV0" + MA.ToString();

            return MaTD;
        }
        public DataTable getDataNhanVien()
        {
            return daNhanVien.GetData();
        }
        public DataTable getDaTaNhanVienTheoMa(string ma)
        {
            return daNhanVien.GetDataByMQNV(ma);
        }
        public DataTable getDataPhongBan()
        {
            return daPhongBan.GetData();
        }
        public DataTable getDataNhanVienTheoMaPH(string ma)
        {
            return daNhanVien.GetDataByCBBMAPH(ma);
        }
        public DataTable getDataPhongBanTheoMaPB(string ma)
        {
            return daPhongBan.GetDataByMAPHCBB(ma);
        }
        public DataTable getDataChucVuTheoMaCV(string ma)
        {
            return daChucVu.GetDataByMACV(ma);
        }
        public DataTable getDataChucVu()
        {
            return daChucVu.GetData();
        }
        public int themNVDAL(string ma, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            return daNhanVien.InsertQuery(ma, ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh);
        }
        public int xoaNVDAL(string ma)
        {
            return daNhanVien.DeleteQuery(ma);
        }
        public int suaNhanVienDAL(string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh, string ma)
        {
            return daNhanVien.UpdateQuery(ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh, ma);
        }
    }
}
