using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataQuanLyNhanSuTableAdapters;

namespace DAL
{
    public class DALNhanVien
    {
        NHANVIENTableAdapter nhanvien = new NHANVIENTableAdapter();

        public string DALtenNV;
        public string DALmaNV;
        public string DALchucvu;
        public string DALgioitinh;
        public string DALngaysinh;
        public string DALsdt;
        public string DALphongban;
        public string DALmaluong;
        public string DALngayvaolam;
        public string DALtinhtrang;
        public string DALchedolamviec;
        public string DALmahd;
        public string DALhinh;
        public string machucvu;
        public DALNhanVien()
        { 
        
        }

        public void loadThongTinNV(string ma)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            { 
                
                NHANVIEN thongtin = db.NHANVIENs.SingleOrDefault(NV => NV.MANV.Equals(ma));
                DALtenNV = thongtin.TENNV;
                DALmaNV = thongtin.MANV;
                machucvu = thongtin.MACHUCVU;
                DALgioitinh =thongtin.GIOITINH;
                DALngaysinh = thongtin.NGAYSINH.ToString();
                DALsdt = thongtin.SDT;
                //DALphongban = thongtin;
                string mapb = thongtin.MAPH;
                //DALmaluong;
                string maluong = thongtin.MALUONG;
                DALngayvaolam = thongtin.NGAYVAOLAN.ToString();
                DALtinhtrang = thongtin.TINHTRANG;
                DALchedolamviec = thongtin.CHEDOLV;
                DALmahd = thongtin.MAHD;
                DALhinh = thongtin.HINHANH;

                CHUCVU ttChucVu = db.CHUCVUs.SingleOrDefault(NV => NV.MACHUCVU.Equals(machucvu));
                DALchucvu = ttChucVu.TENCHUVU;

                PHONGBAN ttPHONGBAN = db.PHONGBANs.SingleOrDefault(NV => NV.MAPH.Equals(mapb));
                DALphongban = ttPHONGBAN.TENPH;


                //var bangluong = db.QUATRINHLUONGs.OrderByDescending(m => m.MANV.Equals(DALmaNV)).First();

                //string luong = bangluong.LUONGCB.ToString();
                                
                                
                                
            }
        }

        public string DALTenNhanVien(string ma)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    NHANVIEN thongtin = db.NHANVIENs.SingleOrDefault(NV => NV.MANV.Equals(ma));
                    return thongtin.TENNV;
                }
                catch
                {
                    return "";
                }
            }
        }

        public string DALHinhNhanVien(string ma)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    NHANVIEN thongtin = db.NHANVIENs.SingleOrDefault(NV => NV.MANV.Equals(ma));
                    return thongtin.HINHANH;
                }
                catch
                {
                    return "avartar.png";
                }
            }
        }

        public DataTable LoadMaTenNVDAL()
        {
            return nhanvien.GetMATENNV();
        }

        public int ThemNhanVienDAL(string ma, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    NHANVIEN NV = new NHANVIEN
                    {
                        MANV = ma,
                        TENNV = ten,
                        GIOITINH = gt,
                        NGAYSINH = ngaysinh,
                        SDT = sdt,
                        MAPH = maph,
                        MALUONG = maluong,
                        NGAYVAOLAN = ngayvl,
                        TINHTRANG = tinhtrang,
                        CHEDOLV = cdlamviec,
                        MAHD = mahd,
                        HINHANH = hinhanh,
                        MACHUCVU = macv,
                    };

                    db.NHANVIENs.InsertOnSubmit(NV);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }
        }
        public int ThemTaiKhoanDAL(string manv, string pass, int trangthai)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    TAIKHOAN NV = new TAIKHOAN
                    {
                       MANV = manv,
                       MAKHAU = pass,
                       TRANGTHAI = trangthai,
                    };

                    db.TAIKHOANs.InsertOnSubmit(NV);
                    db.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;

                }

            }
        }

        ///XOA
        public int XoaNhanVienDAL(string manv)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                try
                {
                    NHANVIEN NVmoi = db.NHANVIENs
                        .Where(r => r.MANV == manv)
                        .First();
                    db.NHANVIENs.DeleteOnSubmit(NVmoi);

                    TAIKHOAN CTmoi = db.TAIKHOANs
                    .Where(r => r.MANV == manv)
                    .First();
                    db.TAIKHOANs.DeleteOnSubmit(CTmoi);
                    db.SubmitChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }

        }

        //sua
        ////SUA return 0 that bai / return 1 thanh cong
        public int SuaNhanVienDAL( string manv, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            try
            {

                using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
                {

                    NHANVIEN NVmoi = db.NHANVIENs
                        .Where(r => r.MANV == manv)
                        .First();

                    //DTmoi.GHICHU = tieude;
                    NVmoi.TENNV = ten;
                    NVmoi.GIOITINH = gt;
                    NVmoi.NGAYSINH = (DateTime)ngaysinh;
                    NVmoi.SDT = sdt;
                    NVmoi.MAPH = maph;
                    NVmoi.MACHUCVU = macv;
                    
                    NVmoi.NGAYVAOLAN = (DateTime)ngayvl;
                    NVmoi.TINHTRANG = tinhtrang;
                    NVmoi.CHEDOLV = cdlamviec;
                    db.SubmitChanges();

                    NVmoi.MALUONG = maluong;
                    NVmoi.MAHD = mahd;
                    NVmoi.HINHANH = hinhanh;


                    db.SubmitChanges();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
            

           
        }

        
    }//////////////////////////////
}
