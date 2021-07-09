using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DangNhapBLL
    {
        public string madnB;
        public string passB;
        public int hoatdongB;
        DALDangNhap DN = new DALDangNhap();


        private List<TaiKhanItem> dstaikhoan = new List<TaiKhanItem>();

        public List<TaiKhanItem> Dstaikhoan
        {
            get { return dstaikhoan; }
            set { dstaikhoan = value; }
        }

        public DangNhapBLL()
        {
            
        }

        public int DangNhap(string ma, string pass)
        {
            int kt = 3;
            kt = DN.DangNhap(ma, pass);
            
            if (kt == 0) // nhap không đầy đủ
            {
                return 0;
            }
            else if (kt == 1) // đăng nhập thành công
            {
                madnB = DN.madn;
                return 1;
            }
            else if (kt == 2) //tk bị khóa
            {
                return 2;
            }
            else // đăng nhập thất bại!
            {
                return 3;
            }
            return 3;
        }

        public int BLLDoiMK(string manv, string mk)
        {
            int i = DN.DoiMK(manv, mk);
            if (i == 1)
                return 1;
            return 0;
        }

        public void ListTaiKhoanBLL()
        {
            dstaikhoan = new List<TaiKhanItem>();
            DN.ListTaiKhoanDAL();
            int i = 0;
            foreach (var chitiet in DN.Dstaikhoan)
            {
                TaiKhanItem item = new TaiKhanItem(chitiet.Madn, chitiet.Pass, Convert.ToInt32(chitiet.Hoatdong));
                dstaikhoan.Add(item);
            }

        }

        //ListTaiKhoanByMaDNDAL(string madn)
        public void ListTaiKhoanByMaDNBLL(string madn)
        {
            dstaikhoan = new List<TaiKhanItem>();
            DN.ListTaiKhoanByMaDNDAL(madn);
            int i = 0;
            foreach (var chitiet in DN.Dstaikhoan)
            {
                TaiKhanItem item = new TaiKhanItem(chitiet.Madn, chitiet.Pass, Convert.ToInt32(chitiet.Hoatdong));
                dstaikhoan.Add(item);
            }

        }

        ///load thong tin mot taikhoan
        ///Chi tiet đơn từ nè!!!
        public void LoadThongTinTaiKhoanBLL(string madn)
        {
            DN.LoadThongTinTaiKhoanDAL(madn);
            madnB = DN.madn;
            passB = DN.pass;
            hoatdongB = DN.hoatdong;
        }

        ///SUA
        ///
        public int SuaTaiKhoanBLL(string madn, int trangthai)
        {
            int kt = DN.SuaTaiKhoanDAL(madn, trangthai);
            if (kt == 1)
                return 1;
            else
                return 0;
        }

    }////////////////////////
}
