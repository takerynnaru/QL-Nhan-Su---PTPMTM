using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{

    public class BLLQLNhanVien
    {
        DALQLNhanVien nv = new DALQLNhanVien();
        public BLLQLNhanVien()
        { }
        public string taoMaTD()
        {
            return nv.taoMaNVTDDAL();
        }
        public DataTable loadDSNV()
        {
            return nv.getDataNhanVien();
        }
        public DataTable loadDSNVTheoMa(string ma)
        {
            return nv.getDaTaNhanVienTheoMa(ma);
        }
        public DataTable loadCBBPhongban()
        {
            return nv.getDataPhongBan();
        }
        public DataTable loadDSNVTheoMaPH(string ma)
        {
            return nv.getDataNhanVienTheoMaPH(ma);
        }
        public DataTable loadCBBPBTheoMaPH(string ma)
        {
            return nv.getDataPhongBanTheoMaPB(ma);
        }
        public DataTable loadCBBCVTheoMaCV(string ma)
        {
            return nv.getDataChucVuTheoMaCV(ma);
        }
        public DataTable loadCBBChucVu()
        {
            return nv.getDataChucVu();
        }
        public int themNV(string ma, string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh)
        {
            return nv.themNVDAL(ma, ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh);
        }
        public int xoaNV(string ma)
        {
            return nv.xoaNVDAL(ma);
        }
        public int suaNV(string ten, string gt, DateTime ngaysinh, string sdt, string maph, string macv, string maluong, DateTime ngayvl, string tinhtrang, string cdlamviec, string mahd, string hinhanh, string ma)
        {
            return nv.suaNhanVienDAL(ten, gt, ngaysinh, sdt, maph, macv, maluong, ngayvl, tinhtrang, cdlamviec, mahd, hinhanh, ma);
        }
    }
}
