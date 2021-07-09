using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDangNhap
    {
        public string madn;
        public string pass;
        public int hoatdong;
        public DALDangNhap()
        { 
        }

        private List<TaiKhanItem> dstaikhoan = new List<TaiKhanItem>();

        public List<TaiKhanItem> Dstaikhoan
        {
            get { return dstaikhoan; }
            set { dstaikhoan = value; }
        }

        public int DangNhap(string manv, string makhau) // return 0: chua nhap text ; return 1: Dang nhap thanh cong; return 2: tk bi khoa; return 3: user mat khau sai
        {
            string user = manv;
            string pass = makhau;
            string TinhTrang;
            if (user.Equals("") || pass.Equals(""))
            {
                //MessageBox.Show("Vui lòng nhập Username và Password");
                return 0;
            }            
            TAIKHOAN insertDN = new TAIKHOAN { MANV = user, MAKHAU = pass };
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                //TAIKHOAN checkUSER = db.TAIKHOANs.FirstOrDefault(sv => insertDN.MANV.Equals(sv.MANV));
               // TAIKHOAN checkPASS = db.TAIKHOANs.FirstOrDefault(sv => insertDN.MAKHAU.Equals(sv.MAKHAU));
                TAIKHOAN checkTK = db.TAIKHOANs.FirstOrDefault(x => x.MANV == user && x.MAKHAU == pass);

                if (checkTK == null)//checkUSER == null || checkPASS == null
                {
                    //MessageBox.Show("Mật khẩu hoặc tên đăng nhập không tồn tại");
                    return 3;
                }
                else
                {
                    using (LINQquanLyNhanSuDataContext dbm = new LINQquanLyNhanSuDataContext())
                    {
                        TAIKHOAN layma = dbm.TAIKHOANs.FirstOrDefault(x => x.MANV == user);
                        {
                            madn = layma.MANV;
                            TinhTrang = layma.TRANGTHAI.ToString();
                        }
                    }
                    if (TinhTrang == "1")
                    {

                        //DialogResult rs = MessageBox.Show("Đăng Nhập Thành Công!!", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (rs.Equals(DialogResult.Yes))
                        //{
                        //    ma = manv;
                        //}
                        return 1;
                    }
                    else
                    {
                        //DialogResult rs = MessageBox.Show("Tài khoản đã bị khóa, liên hệ phòng nhân sự để mở lại!!", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        return 2;
                    }
                }
            }

            //return 3;
        }

        public int DoiMK (string manv, string mk)
        {
        
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                TAIKHOAN TK = (from r in db.TAIKHOANs
                               where r.MANV == manv 
                                      select r).FirstOrDefault();
                if (TK == null)
                {
                    return 0;
                }


                TK.MAKHAU = mk;
                //db.DANGNHAPs.InsertOnSubmit(dn);
                db.SubmitChanges();
                return 1;
            }
        }


        public void ListTaiKhoanDAL()
        {
            dstaikhoan = new List<TaiKhanItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var tk = from TAIKHOAN in db.TAIKHOANs

                            select new
                            {
                                MA_NV = TAIKHOAN.MANV,
                                PAS_S = TAIKHOAN.MAKHAU,
                                H_DONG = TAIKHOAN.TRANGTHAI,
                               
                            };

                int i = 0;
                foreach (var chitiet in tk)
                {
                    //CaItem itemCa = new CaItem();
                    TaiKhanItem item = new TaiKhanItem(chitiet.MA_NV, chitiet.PAS_S, Convert.ToInt32(chitiet.H_DONG));
                    dstaikhoan.Add(item);
                }
            }
        }
        //tìm theo ma dang nhap
        public void ListTaiKhoanByMaDNDAL(string madn)
        {
            dstaikhoan = new List<TaiKhanItem>();
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                var tk = from TAIKHOAN in db.TAIKHOANs
                         where SqlMethods.Like(TAIKHOAN.MANV, "%" + madn + "%")
                         select new
                         {
                             MA_NV = TAIKHOAN.MANV,
                             PAS_S = TAIKHOAN.MAKHAU,
                             H_DONG = TAIKHOAN.TRANGTHAI,

                         };

                int i = 0;
                foreach (var chitiet in tk)
                {
                    //CaItem itemCa = new CaItem();
                    TaiKhanItem item = new TaiKhanItem(chitiet.MA_NV, chitiet.PAS_S, Convert.ToInt32(chitiet.H_DONG));
                    dstaikhoan.Add(item);
                }
            }
        }

        ///load thong tin mot taikhoan
        ///Chi tiet đơn từ nè!!!
        public void LoadThongTinTaiKhoanDAL(string madn)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {
                TAIKHOAN thongtin = db.TAIKHOANs.SingleOrDefault(NV => NV.MANV.Equals(madn));
                madn = thongtin.MANV;
                pass = thongtin.MAKHAU;
                hoatdong = Convert.ToInt32(thongtin.TRANGTHAI);

            }

        }

        ////SUA return 0 that bai / return 1 thanh cong
        public int SuaTaiKhoanDAL(string madn, int trangthai)
        {
            using (LINQquanLyNhanSuDataContext db = new LINQquanLyNhanSuDataContext())
            {

                TAIKHOAN TKmoi = db.TAIKHOANs
                    .Where(r => r.MANV == madn)
                    .First();

                TKmoi.TRANGTHAI = trangthai;
               

                db.SubmitChanges();
                return 1;
            }

            return 0;
        }














    }///////////////////////////////////////////
}
