using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLNhanVien
    {
        DALNhanVien NV = new DALNhanVien();
        public string BLLtenNV;
        public string BLLmaNV;
        public string BLLchucvu;
        public string BLLgioitinh;
        public string BLLngaysinh;
        public string BLLsdt;
        public string BLLphongban;
        public string BLLmaluong;
        public string BLLngayvaolam;
        public string BLLtinhtrang;
        public string BLLchedolamviec;
        public string BLLmahd;
        public string BLLhinh;
        public string machuvu;

        public BLLNhanVien()
        { 

        }

        public void LoadThongTinNhanVien(string ma)
        {
            NV.loadThongTinNV(ma);
            BLLtenNV = NV.DALtenNV;
            BLLmaNV = NV.DALmaNV;
            BLLchucvu = NV.DALchucvu;
            BLLgioitinh = NV.DALgioitinh;
            BLLngaysinh = NV.DALngaysinh;
            BLLsdt = NV.DALsdt;
            BLLphongban = NV.DALphongban;
            //BLLmaluong =  NV.;
            BLLngayvaolam = NV.DALngayvaolam;
            BLLtinhtrang = NV.DALtinhtrang;
            BLLchedolamviec = NV.DALtinhtrang;
            BLLmahd = NV.DALmahd;
            BLLhinh = NV.DALhinh;
            machuvu = NV.machucvu;

        }

        public DataTable LoadMaTenNVBLL()
        {
            return NV.LoadMaTenNVDAL();
        }


        public string BLLTenNhanVien(string ma)
        {
            return NV.DALTenNhanVien(ma);
        }

        public string BLLHinhNhanVien(string ma)
        {
            return NV.DALHinhNhanVien(ma);
        }

        public int ThemNhanVienBLL(string ma, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            int kt = NV.ThemNhanVienDAL(ma, ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh);
            if (kt == 1)
                return 1;
            else
                return 0;
        }


        //xoa
        public int XoaNhanVienBLL(string manv)
        {
            int kt = NV.XoaNhanVienDAL(manv);
            if (kt == 1)
                return 1;
            else
                return 0;
        }
                //sua
        ////SUA return 0 that bai / return 1 thanh cong
        public int SuaNhanVienBLL(string manv, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            int kt = NV.SuaNhanVienDAL(manv, ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh);
            if (kt == 1)
                return 1;
            else
                return 0;
        }

        //them tai khoan moi
        public int ThemTaiKhoanBLL(string manv, string pass, int trangthai)
        {
            int kt = NV.ThemTaiKhoanDAL(manv, pass, trangthai);
            if (kt == 1)
                return 1;
            else
                return 0;
        }

    }////
}
