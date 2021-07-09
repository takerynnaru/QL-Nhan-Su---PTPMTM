using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class AThongBao : UserControl
    {
        BLLThongBao TB = new BLLThongBao();
        BLLNhanVien NV = new BLLNhanVien();
        public AThongBao(string matb)
        {
            InitializeComponent();
            ShowThongBao(matb);
        }



        void ShowThongBao(string matb)
        {
            TB.LoadThongTinThongBaoBLL(matb);
            string hinh = NV.BLLHinhNhanVien(TB.Bnguoitao);
            string tennv = NV.BLLTenNhanVien(TB.Bnguoitao);
            pictureBoxNguoiDang.Image = Image.FromFile("C:/Users/Admin/AppData/Local/GitHubDesktop/app-2.8.2/QuanLyNhanSu/QuanLyNhanSu/GUI/Resources/" + hinh);
            //pictureBox1.Image = Image.FromFile("C:/Users/Admin/AppData/Local/GitHubDesktop/app-2.8.2/QuanLyNhanSu/QuanLyNhanSu/GUI/Resources/" + hinh);
            labelTenNguoiDang.Text = tennv;
            labelTieuDe.Text = TB.Btieude;
            labelMaTB.Text = matb;
            labelNọiDung.Text = TB.Bnoidung;
            labelNgayDang.Text = TB.Bngaytao.Day.ToString() + "/" + TB.Bngaytao.Month.ToString() + "/" + TB.Bngaytao.Year.ToString();
        }

    }
}
