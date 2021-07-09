using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace GUI
{
    public partial class MainForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BLLNhanVien NV = new BLLNhanVien();
        DangNhapBLL DN = new DangNhapBLL();
        BLLDonTu DT = new BLLDonTu();
        BLLChucVu cv = new BLLChucVu();
        BLLHopDong hd = new BLLHopDong();
        BLLQLNhanVien nv = new BLLQLNhanVien();
        BLLPhongBan pb = new BLLPhongBan();
        BLLBangPhu BP = new BLLBangPhu();
        BLLThongBao TB = new BLLThongBao();
        BLLCaLamViec CLV = new BLLCaLamViec();
        BLLPhanCong PC = new BLLPhanCong();
        BLLChamCong CC = new BLLChamCong();

        string manvdn;
        string chondon;
        protected string fileName = "null";
        public MainForm1(string ma)
        {
            manvdn = ma;
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrameMain.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            //navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];

            navigationFrameMain.SelectedPage = NavigationPageTaiKhoan;
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void officeNavigationBar_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItemNhanSu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageNhanSu;
        }

        private void barButtonItem2_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItemPhBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPagePhongBan;
            dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
        }

        private void barButtonItemChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            navigationFrameMain.SelectedPage = navigationPageChucVu;
            dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            navigationFrameMain.SelectedPage = navigationPageDonTu;
           // DataTable datadon
            dataGridViewDonTu_DonTuView.DataSource = DT.loadDonTuByMANVofBLL(manvdn);

            loadDonTuView();
           
            
        }

        public void loadDonTuView()
        {
            listViewDEMO.Items.Clear();
            DT.ListDonTuOfManvBLL(manvdn);

            foreach (var demo in DT.dsdontu)
            {
                listViewDEMO.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
            ////////////
            ClearThongTinDonTuView();
            panelSuaThongTinDonTu_DonTu_View.Hide();
            /////////////
            //comboBoxNguoiDuyet_Sua_DonTu_View
            comboBoxNguoiDuyet_Sua_DonTu_View.DisplayMember = "TENNV";
            comboBoxNguoiDuyet_Sua_DonTu_View.ValueMember = "MANV";
            comboBoxNguoiDuyet_Sua_DonTu_View.DataSource = NV.LoadMaTenNVBLL();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /////// đơn xin nghỉ

            chondon = "DTXN  ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = false;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = false;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = false;
            panelEditGio_TaoDon_DonTu_View.Enabled = false;
            ///////
            navigationFrameMain.SelectedPage = navigationPageDonXinNghi;
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /////// đơn vắng mặt
            chondon = "DTVM  ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = false;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = false;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = false;
            panelEditGio_TaoDon_DonTu_View.Enabled = true;
            ///////
            navigationFrameMain.SelectedPage = navigationPageDonXinNghi;
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /////// đơn check in out
            chondon = "DTCIO ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = false;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = false;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = false;
            panelEditGio_TaoDon_DonTu_View.Enabled = true;
            ///////
            //navigationFrameMain.SelectedPage = navigationPageDonCheckInOut;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /////// tao ho đơn xin nghỉ
            chondon = "DTXN  ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = true;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = true;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = true;
            panelEditGio_TaoDon_DonTu_View.Enabled = false;
            ///////
            navigationFrameMain.SelectedPage = navigationPageDonXinNghi;
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /////// tạo ho don vang mat
            chondon = "DTVM  ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = true;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = true;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = true;
            panelEditGio_TaoDon_DonTu_View.Enabled = true;
            ///////
            navigationFrameMain.SelectedPage = navigationPageDonXinNghi;
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ///////tao ho chekc in out
            chondon = "DTCIO ";
            loadThongTinTaoDon();
            checkBoxTaoHo_TaoDon_DonTu_View.Checked = true;
            textBoxMaNV_TaoDon_DonTu_View.Enabled = true;
            comboBoxTenNV_TaoDon_DonTu_View.Enabled = true;
            panelEditGio_TaoDon_DonTu_View.Enabled = true;
            ///////
            navigationFrameMain.SelectedPage = navigationPageDonXinNghi;
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           //C:\Users\Admin\AppData\Local\GitHubDesktop\app-2.8.2\QuanLyNhanSu\QuanLyNhanSu\GUI\Resources\LOGO (1)1.png
           
            barButtonItemThongBao.Caption = "Thông Báo Mới";
            barButtonItemThongBao.ImageOptions.ImageUri.Uri = "language";
            //------------------------------------------------------------------------------
            //CÁCH ĐỔI HÌNH BẰNG LINK DẪN FOLDER :
            //barButtonItemThongBao.ImageUri.Uri = "C:/Users/Admin/AppData/Local/GitHubDesktop/app-2.8.2/QuanLyNhanSu/QuanLyNhanSu/GUI/Resources/LOGO (1)1.png";
        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void lb_ChucVu_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        ///================================================================================================================================
        ///                       Tài khoản                      
        ///================================================================================================================================

        public void LoadThongTAIKHOAN(string ma)
        {
            NV.LoadThongTinNhanVien(ma);
            lb_TenNV_pageTAIKHOAN.Text = NV.BLLtenNV;
            lb_ChucVu_pageTAIKHOAN.Text = NV.BLLchucvu;
            lb_NgaySinh.Text = NV.BLLngaysinh;
            lbSDT_TaiKhoan.Text = NV.BLLsdt;
            labelTaikhoan_TaiKhoan.Text = NV.BLLmaNV;
            lbPhongBan_TaiKhoan.Text = NV.BLLphongban;
            lbNgayVaoLam_TaiKhoan.Text = NV.BLLngayvaolam;
            string hinh;
            hinh = NV.BLLhinh;

            if (NV.machuvu.Equals("MAR003") || NV.machuvu.Equals("MAR004"))
            {
                barButtonItemTaoBangLuong.Enabled = true;
                barButtonItemQLngaynghi_hr.Enabled = true;
                barButtonItemPhanCa_HR.Enabled = true;
                barButtonItemDuyetPhieuChi.Enabled = true;
                barButtonItemDuyetPhieuThu.Enabled = true;
                barButtonItemDuyetDonTu.Enabled = true;
                barButtonItemNhanSu_HR.Enabled = true;
                barButtonItemThietLapCa.Enabled = true;
                barButtonItemTaiKhoan_HRM.Enabled = true;
            }
            else
            {

                barButtonItemTaoBangLuong.Enabled = false;
                barButtonItemQLngaynghi_hr.Enabled = false;
                barButtonItemPhanCa_HR.Enabled = false;
                barButtonItemDuyetPhieuChi.Enabled = false;
                barButtonItemDuyetPhieuThu.Enabled = false;
                barButtonItemDuyetDonTu.Enabled = false;
                barButtonItemNhanSu_HR.Enabled = false;
                barButtonItemThietLapCa.Enabled = false;
                barButtonItemTaiKhoan_HRM.Enabled = false;
            }

//C:\Users\Admin\AppData\Local\GitHubDesktop\app-2.8.2\QuanLyNhanSu\QuanLyNhanSu\GUI\HINH\avatar\avartar.png
//C:\Users\Admin\AppData\Local\GitHubDesktop\app-2.8.2\QuanLyNhanSu\QuanLyNhanSu\GUI\Resources\son1.png
            try
            {
                pictureBox1.Image = Image.FromFile("C:/Users/Admin/AppData/Local/GitHubDesktop/app-2.8.2/QuanLyNhanSu/QuanLyNhanSu/GUI/Resources/" + hinh);
            }
            catch
            {
               //pictureBox1.Image = Image.FromFile("C:/Users/Admin/AppData/Local/GitHubDesktop/app-2.8.2/QuanLyNhanSu/QuanLyNhanSu/GUI/HINH/avatar/avartar.png");
            }



        }

        public void LoadTenTK(string ma)
        {
           
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // LoadThongTAIKHOAN(manvdn);
        }

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItemTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadThongTAIKHOAN(manvdn);

            navigationFrameMain.SelectedPage = NavigationPageTaiKhoan;
        }

        ///================================================================================================================================
        ///                       LICH - CHẤM CÔNG                      
        ///================================================================================================================================

        ////----------------------------------------------khai báo

        #region Peoperties
       
        private List<List<ADAY>> matrix1;

        public List<List<ADAY>> Matrix1
        {
            get { return matrix1; }
            set { matrix1 = value; }
        }

        //--------------- CHUYỀN DATA
        private CaData ca;

        public CaData Ca
        {
            get { return ca; }
            set { ca = value; }
        }

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        #endregion

        // ////----------------------------------------------hàm phụ

        void LoadMatrix()
        {
            Matrix1 = new List<List<ADAY>>();

            ADAY olbaday = new ADAY() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix1.Add(new List<ADAY>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    ADAY btn = new ADAY() { Width = Cons.dateButtomWidth, Height = Cons.dateButtomHeight };
                    btn.Location = new Point(olbaday.Location.X + olbaday.Width + Cons.margin, olbaday.Location.Y);

                    //0--------Click----------------
                    //btn.Click += btn_Click;
                    //btn.Viewbtn += btn_Viewbtn;
                    btn.Viewpanel += btn_Viewpanel;

                    pnlMatrix.Controls.Add(btn);
                    Matrix1[i].Add(btn);

                    olbaday = btn;
                }
                olbaday = new ADAY() { Width = -Cons.margin, Height = 0, Location = new Point(0, olbaday.Location.Y + Cons.dateButtomHeight + Cons.margin) };
            }
            SetDefaultDate();
        }

        void btn_Viewpanel(object sender, EventArgs e)
        {
            //////////////SỰ KIỆN MỞ FORM///////////////////
            //if (string.IsNullOrEmpty((sender as ADAY).Textday1))
            //    return;
            //DailyPlan daily = new DailyPlan(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32((sender as ADAY).Textday1)));
            //daily.Show();
            /////////////////////////////////////////////////
        }

        void btn_Viewbtn(object sender, EventArgs e)
        {
            //////////////SỰ KIỆN MỞ FORM///////////////////
            //if (string.IsNullOrEmpty((sender as ADAY).Textday1))
            //    return;
            //DailyCa daily = new DailyCa(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32((sender as ADAY).Textday1)), manvdn, "CA001");
            //daily.Show();
            /////////////////////////////////////////////////

            if (string.IsNullOrEmpty((sender as ADAY).Textday1))
                return;
            DailyCa daily = new DailyCa(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32((sender as ADAY).Textday1)), manvdn, (sender as ADAY).Macaa1);
            daily.Show();

        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                    return 31;
                case 3:
                    return 31;
                case 5:
                    return 31;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 10:
                    return 31;
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;

                default:
                    return 30;
            }

        }
        //sửa cái này nữa nhá
        void AddNumberInMatrixByDate(DateTime date)
        {
            //ClearMatrix();
            //DateTime useDate = new DateTime(date.Year, date.Month, 1);

            //int line = 0;
            
            //for (int i = 1; i <= DayOfMonth(date); i++)
            //{
            //    int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
            //    ADAY btn = Matrix1[line][column];
            //    btn.numberDay(i.ToString());

            //    if (isEqualDate(useDate, DateTime.Now))
            //    {
            //        btn.BackColor = Color.Yellow;
            //    }

            //    if (isEqualDate(useDate, date))
            //    {
            //        btn.BackColor = Color.Aqua;
            //    }

            //    if (column >= 6)
            //        line++;

            //    useDate = useDate.AddDays(1);

            //}
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            /////////////////////////////////
            Ca = new CaData();
            //Ca.Ca = new List<CaItem>();
            Ca.ListCa(manvdn);




            int line = 0;

            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                ADAY btn = Matrix1[line][column];

                btn.numberDay(i.ToString());

                foreach (var cahomnay in Ca.Ca)
                {
                    //if ((cahomnay.DayOfTuan-1) == column && date.Month >= cahomnay.DateBD.Month && date.Day >= cahomnay.DateBD.Day ) ///the nha them nha!!!
                    //{
                    //    btn.calamDay(cahomnay.Maca);
                    //    btn.BackColor = Color.Pink;
                    //}
                    if ((cahomnay.DayOfTuan - 1) == column && lonHonDate(useDate, cahomnay.DateBD) && nhoHonDate(useDate, cahomnay.DateKT)) ///the nha them nha!!!
                    {
                        btn.calamDay(cahomnay.Maca);
                        btn.BackColor = Color.Pink;
                        btn.Viewbtn +=btn_Viewbtn;
                    }
                    else
                    {
                        //btn.removeLableAday();
                    }
                }


                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }

                if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Aqua;
                }

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);


            }


        }


        bool isEqualDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        bool nhoHonDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year <= dateB.Year && dateA.Month <= dateB.Month && dateA.Day <= dateB.Day;
        }

        bool lonHonDate(DateTime dateA, DateTime dateB)
        {

            return dateA.Year >= dateB.Year && dateA.Month >= dateB.Month && dateA.Day >= dateB.Day;
        }

        void ClearMatrix()
        {

            for (int i = 0; i < Matrix1.Count; i++)
            {
                for (int j = 0; j < Matrix1[i].Count; j++)
                {
                    ADAY btn = Matrix1[i][j];
                    btn.numberDay("");
                    btn.removeLableAday();
                    btn.BackColor = Color.White;
                }
            }
        }

        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;

        }

        // ////----------------------------------------------Load lịch làm

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           // LoadMatrix();
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberInMatrixByDate((sender as DateTimePicker).Value);
            //btnMonDay.Text = "MonDay";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnPreviours_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnToDay_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            LoadThongTAIKHOAN(manvdn);
            LoadMatrix();
            panelEditMK_TaiKhoan.Hide();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đăng xuất không?", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs.Equals(DialogResult.Yes))
            {
                this.Visible = false;
                FormDangNhap f = new FormDangNhap();
                f.Show();
                //this.Close();
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
           

        }

        ///================================================================================================================================
        ///                       ĐỔI MẬT KHẨU                      
        ///================================================================================================================================


        private void labelXacNhan_MK_TaiKhoan_Click(object sender, EventArgs e)
        {
            if (TB_NEWMK_TaiKhoan.Text == null || TB_OLDMK_TaiKhoan.Text == null || TB_REMK_TaiKhoan.Text == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }

            if (TB_NEWMK_TaiKhoan.Text != TB_REMK_TaiKhoan.Text)
                MessageBox.Show("Nhập lại mật khẩu mới, hai mật khẩu không giống nhau!");

            int kt = DN.DangNhap(manvdn, TB_OLDMK_TaiKhoan.Text);

            if (kt == 1)
            {
                int i = DN.BLLDoiMK(manvdn, TB_NEWMK_TaiKhoan.Text);
                if (i == 1)
                {

                    DialogResult rs = MessageBox.Show("Vui lòng đăng xuất để sử dụng mật khẩu mới?", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs.Equals(DialogResult.Yes))
                    {
                        this.Visible = false;
                        FormDangNhap f = new FormDangNhap();
                        f.Show();
                        //this.Close();
                    }
                }
                else
                    MessageBox.Show("Đổi mật khẩu thấy bại!");
            }
            else
                MessageBox.Show("Mật khẩu sai, vui lòng nhập lại!");
        }

        private void label_Huy_MK_TaiKhoan_Click(object sender, EventArgs e)
        {
            panelEditMK_TaiKhoan.Hide();
            TB_NEWMK_TaiKhoan.Text = ""; TB_OLDMK_TaiKhoan.Text = ""; TB_REMK_TaiKhoan.Text = "";
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            panelEditMK_TaiKhoan.Hide();
            TB_NEWMK_TaiKhoan.Text = ""; TB_OLDMK_TaiKhoan.Text = ""; TB_REMK_TaiKhoan.Text = "";
        }

        private void btn_DoiMK_TaiKhoan_Click(object sender, EventArgs e)
        {
            panelEditMK_TaiKhoan.Show();
        }


        ///================================================================================================================================
        ///                       CHỨC VỤ                     
        ///================================================================================================================================


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataGridViewChuVu.DataSource = cv.loaddgvDSCVTheoMa(txtTK.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm chức vụ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string ma = "CV00" + BP.MaxMaBLL("MACV  ").ToString();
                if (cv.themCV(ma, txtTen.Text) == 1)
                {
                    MessageBox.Show("Thêm thành công!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                    txtMa.Text = "";
                    txtTen.Text = "";
                    BP.TangMaBangPhuBLL("MACV  ");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa chức vụ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (cv.suaCV(txtTen.Text, txtMa.Text) == 1)
                {
                    MessageBox.Show("Sửa thành công!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                    txtMa.Text = "";
                    txtTen.Text = "";

                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa chức vụ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (cv.xoaCV(dataGridViewChuVu.CurrentRow.Cells[0].Value.ToString()) == 1)
                {
                    MessageBox.Show("Xóa thành công!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                    txtMa.Text = "";
                    txtTen.Text = "";

                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                    dataGridViewChuVu.DataSource = cv.loaddgvDSCV();
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
        }

        private void simpleButtonSEARCH_HD_Click(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = hd.loadDGVDSHDTheoMa(txtTK_HD.Text);
        }

        private void barButtonItemHopDong_HR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageHopDong_HR;
            dgvDSHD.DataSource = hd.loadDGVDSHD();

        }

        private void navigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        ///================================================================================================================================
        ///                       HỢP ĐỒNG                    
        ///================================================================================================================================


        private void simpleButtonXEMTATCA_HD_Click(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = hd.loadDGVDSHD();

        }

        private void btnThem_HD_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm hợp đồng?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DateTime dtBD = dtpNgayBD_HD.Value;
                DateTime dtKT = dtpNgayKT_HD.Value;
                DateTime dtNK = dtpNK_HD.Value;
                if (hd.ThemHD(hd.taoMaHDTDBLL(), txtTen_HD.Text, dtBD, dtKT, dtNK, "Còn hiệu lực", txtND_HD.Text).ToString() == "1")
                {
                    MessageBox.Show("Thêm thành công!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                    txtMa_HD.Text = "";
                    txtTen_HD.Text = "";
                    dtpNgayBD_HD.Value = DateTime.Now;
                    dtpNgayKT_HD.Value = DateTime.Now;
                    dtpNK_HD.Value = DateTime.Now;
                    txtND_HD.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void simpleButtonCLEAR_HD_Click(object sender, EventArgs e)
        {
            txtMa_HD.Text = "";
            txtTen_HD.Text = "";
            dtpNgayBD_HD.Value = DateTime.Now;
            dtpNgayKT_HD.Value = DateTime.Now;
            dtpNK_HD.Value = DateTime.Now;
            txtND_HD.Text = "";
        }

        private void simpleButtonSUA_HD_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa hợp đồng?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DateTime dtBD = dtpNgayBD_HD.Value;
                DateTime dtKT = dtpNgayKT_HD.Value;
                DateTime dtNK = dtpNK_HD.Value;
                if (hd.SuaHD(txtTen_HD.Text, dtBD, dtKT, dtNK, "Còn hiệu lực", txtND_HD.Text, txtMa_HD.Text) == 1)
                {
                    MessageBox.Show("Sửa thành công!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                    txtMa_HD.Text = "";
                    txtTen_HD.Text = "";
                    dtpNgayBD_HD.Value = DateTime.Now;
                    dtpNgayKT_HD.Value = DateTime.Now;
                    dtpNK_HD.Value = DateTime.Now;
                    txtND_HD.Text = "";
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void simpleButton_XOA_HD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa hợp đồng?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (hd.XoaHD(dgvDSHD.CurrentRow.Cells[0].Value.ToString()) == 1)
                {
                    MessageBox.Show("Xóa thành công!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                    txtMa_HD.Text = "";
                    txtTen_HD.Text = "";
                    dtpNgayBD_HD.Value = DateTime.Now;
                    dtpNgayKT_HD.Value = DateTime.Now;
                    dtpNK_HD.Value = DateTime.Now;
                    txtND_HD.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                    dgvDSHD.DataSource = hd.loadDGVDSHD();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        ///================================================================================================================================
        ///                       NHÂN VIÊN - NHÂN SỰ                     
        ///================================================================================================================================


        private void navigationPageNhanSu_Paint(object sender, PaintEventArgs e)
        {

             navigationFrameMain.SelectedPage = navigationPageNhanSu;

        }

        private void btnShowAll_QLNV_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.DataSource = nv.loadDSNV();

        }

        private void btnTimKiem_QLNV_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.DataSource = nv.loadDSNVTheoMa(txtTimKiem_QLNV.Text);
        }

        private void barButtonItemNhanSu_HR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageNhanSu;

            dataGridViewNhanSu.DataSource = nv.loadDSNV();
            
            cbbPhongBan_QLNV.DisplayMember = "TENPH";
            cbbPhongBan_QLNV.ValueMember = "MAPH";
            cbbPhongBan_QLNV.DataSource = nv.loadCBBPhongban();
        }

        private void bnbrowse_QLNV_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {


                fileName = dlg.FileName;

            }
        }

        private void btnThem_QLNV_Click(object sender, EventArgs e)
        {
            if (txtTen_QLNV.Text.Trim().Length == 0 || txtSDT_QLNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập dầy đủ thông tin");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DateTime dtpNS = dtpNgaySinh_QLNV.Value;
                DateTime dtpNVL = dtpNgayVL_QLNV.Value;
                string manv = "NV00" + BP.MaxMaBLL("MANV  ");
                if (NV.ThemNhanVienBLL(manv, txtTen_QLNV.Text, cbbGioiTinh_QLNV.Text, dtpNS, txtSDT_QLNV.Text, cbbPB_QLNV.SelectedValue.ToString(), cbbChucVu_QLNV.SelectedValue.ToString(), null, dtpNVL, txtTinhTrang_QLNV.Text, cbbChedolam_QLNV.Text, null, null) == 1)
                {
                    MessageBox.Show("Thêm thành công!");
                    dataGridViewNhanSu.DataSource = nv.loadDSNV();
                    btnThem_QLNV.Enabled = false;
                    txtMa_QLNV.Text = "";
                    txtTen_QLNV.Text = "";
                    dtpNgaySinh_QLNV.Value = DateTime.Now;
                    txtSDT_QLNV.Text = "";
                    txtMaLuong_QLNV.Text = "";
                    txtTinhTrang_QLNV.Text = "";
                    txtMaHD_QLNV.Text = "";
                    dtpNgayVL_QLNV.Value = DateTime.Now;

                    BP.TangMaBangPhuBLL("MANV  ");

                    if (NV.ThemTaiKhoanBLL(manv, "1234", 1) == 1)
                    {
                        MessageBox.Show("Đã thêm một tài khoản mới có mã đăng nhập: " + manv + " , mật khẩu : 1234!, vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        MessageBox.Show("TK.Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                    dataGridViewChuVu.DataSource = nv.loadDSNV();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnSua_QLNV_Click(object sender, EventArgs e)
        {
            if (txtMa_QLNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DateTime dtpNS = dtpNgaySinh_QLNV.Value;
                DateTime dtpNVL = dtpNgayVL_QLNV.Value;

                if (NV.SuaNhanVienBLL(txtMa_QLNV.Text, txtTen_QLNV.Text, cbbGioiTinh_QLNV.Text, dtpNS, txtSDT_QLNV.Text, cbbPB_QLNV.SelectedValue.ToString(), cbbChucVu_QLNV.SelectedValue.ToString(), txtMaLuong_QLNV.Text, dtpNVL, txtTinhTrang_QLNV.Text, cbbChedolam_QLNV.Text, txtMaHD_QLNV.Text, fileName) == 1)
                {
                    MessageBox.Show("Sửa thành công!");
                    dataGridViewNhanSu.DataSource = nv.loadDSNV();
                    btnThem_QLNV.Enabled = false;
                    txtMa_QLNV.Text = "";
                    txtTen_QLNV.Text = "";
                    dtpNgaySinh_QLNV.Value = DateTime.Now;
                    txtSDT_QLNV.Text = "";
                    txtMaLuong_QLNV.Text = "";
                    txtTinhTrang_QLNV.Text = "";
                    txtMaHD_QLNV.Text = "";
                    dtpNgayVL_QLNV.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                    dataGridViewChuVu.DataSource = nv.loadDSNV();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnXoa_QLNV_Click(object sender, EventArgs e)
        {
            if (txtMa_QLNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (NV.XoaNhanVienBLL(txtMa_QLNV.Text) == 1)
                {
                    MessageBox.Show("Xóa thành công!");
                    dataGridViewNhanSu.DataSource = nv.loadDSNV();
                    btnThem_QLNV.Enabled = false;
                    txtMa_QLNV.Text = "";
                    txtTen_QLNV.Text = "";
                    dtpNgaySinh_QLNV.Value = DateTime.Now;
                    txtSDT_QLNV.Text = "";
                    txtMaLuong_QLNV.Text = "";
                    txtTinhTrang_QLNV.Text = "";
                    txtMaHD_QLNV.Text = "";
                    dtpNgayVL_QLNV.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                    dataGridViewChuVu.DataSource = nv.loadDSNV();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnClear_QLNV_Click(object sender, EventArgs e)
        {
            btnThem_QLNV.Enabled = true;
            txtMa_QLNV.Text = "";
            txtTen_QLNV.Text = "";
            dtpNgaySinh_QLNV.Value = DateTime.Now;
            txtSDT_QLNV.Text = "";
            txtMaLuong_QLNV.Text = "";
            txtTinhTrang_QLNV.Text = "";
            txtMaHD_QLNV.Text = "";
            dtpNgayVL_QLNV.Value = DateTime.Now;
        }

        ///================================================================================================================================
        ///                       PHÒNG BAN                      
        ///================================================================================================================================


        private void simpleButtonTim__PB_Click(object sender, EventArgs e)
        {
            dataGridViewPHONGBAN.DataSource = pb.loadDGVTheoMa(txtTK_PB.Text);
        }

        private void simpleButtonThem_PB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm phòng ban?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string ma = "PB00" + BP.MaxMaBLL("MAPB  ").ToString();
                if (pb.themPB(ma, txtTen_PB.Text, txtTruongPhong_PB.Text) == 1)
                {
                    MessageBox.Show("Thêm thành công!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                    txtMa_PB.Text = "";
                    txtTen_PB.Text = "";
                    txtTruongPhong_PB.Text = "";
                    BP.TangMaBangPhuBLL("MAPB  ");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                }
            }
        }

        private void simpleButtonSua_PB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa phòng ban?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (pb.suaPB(txtTen_PB.Text, txtTruongPhong_PB.Text, txtMa_PB.Text) == 1)
                {
                    MessageBox.Show("Sửa thành công!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                    txtMa_PB.Text = "";
                    txtTen_PB.Text = "";
                    txtTruongPhong_PB.Text = "";
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                }
            }
        }

        private void simpleButtonXoa_PB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa phòng ban?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (pb.xoaPB(dataGridViewPHONGBAN.CurrentRow.Cells[0].Value.ToString()) == 1)
                {
                    MessageBox.Show("Xóa thành công!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                    txtMa_PB.Text = "";
                    txtTen_PB.Text = "";
                    txtTruongPhong_PB.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                    dataGridViewPHONGBAN.DataSource = pb.loadDGVDSPB();
                }
            }
        }

        private void simpleButtonClear_PB_Click(object sender, EventArgs e)
        {
            txtMa_PB.Text = "";
            txtTen_PB.Text = "";
            txtTruongPhong_PB.Text = "";
        }

        private void cbbPB_QLNV_DropDown(object sender, EventArgs e)
        {
            cbbPB_QLNV.DataSource = nv.loadCBBPhongban();
            cbbPB_QLNV.DisplayMember = "TENPH";
            cbbPB_QLNV.ValueMember = "MAPH";
        }

        private void cbbChucVu_QLNV_DropDown(object sender, EventArgs e)
        {
            cbbChucVu_QLNV.DataSource = nv.loadCBBChucVu();
            cbbChucVu_QLNV.DisplayMember = "TENCHUVU";
            cbbChucVu_QLNV.ValueMember = "MACHUCVU";
        }

        private void dataGridViewNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[0].Value.ToString();
            txtTen_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[1].Value.ToString();
            cbbGioiTinh_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[2].Value.ToString();
            dtpNgaySinh_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[3].Value.ToString();
            txtSDT_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[4].Value.ToString();
            cbbPB_QLNV.DataSource = nv.loadCBBPBTheoMaPH(dataGridViewNhanSu.CurrentRow.Cells[5].Value.ToString());
            cbbPB_QLNV.DisplayMember = "TENPH";
            cbbPB_QLNV.ValueMember = "MAPH";
            cbbChucVu_QLNV.DataSource = nv.loadCBBCVTheoMaCV(dataGridViewNhanSu.CurrentRow.Cells[6].Value.ToString());
            cbbChucVu_QLNV.DisplayMember = "TENCHUVU";
            cbbChucVu_QLNV.ValueMember = "MACHUCVU";
            txtMaLuong_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[7].Value.ToString();
            dtpNgayVL_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[8].Value.ToString();
            txtTinhTrang_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[9].Value.ToString();
            cbbChedolam_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[10].Value.ToString();
            txtMaHD_QLNV.Text = dataGridViewNhanSu.CurrentRow.Cells[11].Value.ToString();
        }

        private void dataGridViewPHONGBAN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa_PB.Text = dataGridViewPHONGBAN.CurrentRow.Cells[0].Value.ToString();
            txtTen_PB.Text = dataGridViewPHONGBAN.CurrentRow.Cells[1].Value.ToString();
            txtTruongPhong_PB.Text = dataGridViewPHONGBAN.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridViewChuVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridViewChuVu.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dataGridViewChuVu.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridViewNhanSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        ///================================================================================================================================
        ///                       DON TỪ                      
        ///================================================================================================================================


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listViewDEMO.Items.Clear();
            DateTime date = new DateTime(dateTimePicker_DonTu_View.Value.Year, dateTimePicker_DonTu_View.Value.Month, dateTimePicker_DonTu_View.Value.Day);

            dataGridViewDonTu_DonTuView.DataSource = DT.loadDonTuByNGAYTAOofBLL(date);

            DT.ListDonTuOfDayBLL(date, manvdn);

            foreach (var demo in DT.dsdontu)
            {
                listViewDEMO.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonViewAll_DonTu_View_Click(object sender, EventArgs e)
        {
            dataGridViewDonTu_DonTuView.DataSource = DT.loadDonTuByMANVofBLL(manvdn);
            //loadDonTuByNGAYTAOofBLL

            listViewDEMO.Items.Clear();

            DT.ListDonTuOfManvBLL(manvdn);

            foreach (var demo in DT.dsdontu)
            {
                listViewDEMO.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
        }

        private void dataGridViewDonTu_DonTuView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void listViewDEMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string madon = null;

            if (listViewDEMO.SelectedItems.Count > 0)
            {
                madon = listViewDEMO.SelectedItems[0].SubItems[0].Text;
                try
                {
                    DT.ChiTietDonTuBLL(madon);
                    DT.ThongTinDonTuBLL(madon);
                    //TieuDe
                    labelGhiChu_TieuDe_DonTu_View.Text = DT.Bghichu;
                    textBoxTieuDe_Sua_DonTu_View.Text = DT.Bghichu;
                    //MaDon
                    labelMaDon_DonTu_View.Text = DT.Bmadon;
                    labelMaDon_Sua_DonTu_View.Text = DT.Bmadon;
                    //MaLoai
                    labelLoaiDon_DonTu_View.Text = DT.tenloaidon;
                    labelLoaiDon_Sua_DonTu_View.Text = DT.tenloaidon;
                    //ngaytao
                    labelNgayTao_Sua_DonTu_View.Text = DT.Bngaytao.Day.ToString() + "/" + DT.Bngaytao.Month.ToString() + "/" + DT.Bngaytao.Year.ToString();
                    labelNgayTao_DonTu_View.Text = DT.Bngaytao.Day.ToString() + "/" + DT.Bngaytao.Month.ToString() + "/" + DT.Bngaytao.Year.ToString();
                    //taoho
                    if(DT.Btaoho == 1)
                    {
                        labelTaoHo_DonTu_View.Text = "Tạo hộ";
                        labelTaoHo_Sua_DonTu_View.Text = "Tạo hộ";
                    }
                    else
                    {
                        labelTaoHo_DonTu_View.Text = "Tạo cho mình";
                        labelTaoHo_Sua_DonTu_View.Text = "Tạo cho mình";
                    }
                    //mã nhân viên
                    labelMaNV_DonTu_View.Text = DT.Bmanv;
                    labelMaNV_Sua_DonTu_View.Text = DT.Bmanv;
                    //tên nhân viên
                    labelTenNV_DonTu_View.Text = DT.tennhanvien;
                    labelTenNV_Sua_DonTu_View.Text = DT.tennhanvien;
                    ///Tên Người Tạo
                    labelTenNguoiTao_DonTu_View.Text = DT.tennguoilap;
                    labelTenNguoiTao_Sua_DonTu_View.Text = DT.tennguoilap;
                    //lydo
                    labelLyDo_DonTu_View.Text = DT.Blydo;
                    comboBoxLyDo_Sua_DonTu_View.Text = DT.Blydo;

                    //NguoiDuyet
                    labelNguoiDuyet_DonTu_View.Text = DT.tennguoiduyet;
                    //tý làm nhaaaa
                    comboBoxNguoiDuyet_Sua_DonTu_View.SelectedIndex = comboBoxNguoiDuyet_Sua_DonTu_View.FindStringExact(DT.tennguoiduyet);
                    //Ngaybd
                    dateTimePickerNgayBD_Sua_DonTu_View.Value = DT.Bngaybd;
                    labelNgayBD_DonTu_View.Text = DT.Bngaybd.Day.ToString() + "/" + DT.Bngaybd.Month.ToString() + "/" + DT.Bngaybd.Year.ToString();
                    //NgayKT
                    dateTimePickerNgayKT_Sua_DonTu_View.Value = DT.Bngaykt;
                    labelNgayKT_DonTu_View.Text = DT.Bngaykt.Day.ToString() + "/" + DT.Bngaykt.Month.ToString() + "/" + DT.Bngaykt.Year.ToString();
                    //
                    if (DT.Bloaidon == "DTXN  ")
                    {
                        labelGioBD_DonTu_View.Text = "";
                        labelGioKT_DonTu_View.Text = "";
                        
                    }
                    else
                    {
                        labelGioBD_DonTu_View.Text = DT.Bgiobd.Hour.ToString() + ":" + DT.Bgiobd.Minute.ToString();
                        labelGioKT_DonTu_View.Text = DT.Bgiokt.Hour.ToString() + ":" + DT.Bgiokt.Minute.ToString();
                    }
                   
                    if (DT.Btinhcong == 1)
                    {
                        labelTinhCong_DonTu_View.Text = "Có tính công";
                        labelTinhCong_Sua_DonTu_View.Text = "Có tính công";
                    }
                    else
                    {
                        labelTinhCong_DonTu_View.Text = "Không tính công";
                        labelTinhCong_Sua_DonTu_View.Text = "Không tính công";
                    }
                    labelTrangThai_DonTu_View.Text = DT.Btrangthai;
                    labelTrangThai_Sua_DonTu_View.Text = DT.Btrangthai;
                    //MOTA
                    labelMoTa_DonTu_View.Text = DT.Bmota;
                    textBoxMoTa_Sua_DonTu_View.Text = DT.Bmota;
                    if (labelTrangThai_DonTu_View.Text.Equals("Đã Duyệt") || labelTrangThai_DonTu_View.Text.Equals("Từ Chối"))
                    {
                        buttonSua_DonTu_View.Enabled = false;
                        buttonXoa_DonTu_View.Enabled = false;
                    }
                    else
                    {
                        buttonSua_DonTu_View.Enabled = true;
                        buttonXoa_DonTu_View.Enabled = true;
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Lỗi truy xuất!");
                }
                
            }
        }

        public void ClearThongTinDonTuView()
        {
            labelGhiChu_TieuDe_DonTu_View.Text = "";
            labelMaDon_DonTu_View.Text = "";
            labelLoaiDon_DonTu_View.Text = "";
            labelNgayTao_DonTu_View.Text = "";
            labelTaoHo_DonTu_View.Text = "";
            labelMaNV_DonTu_View.Text = "";
            labelTenNV_DonTu_View.Text = "";
            labelTenNguoiTao_DonTu_View.Text = "";
            labelLyDo_DonTu_View.Text = "";
            labelNguoiDuyet_DonTu_View.Text = "";
            labelNgayBD_DonTu_View.Text = "";
            labelNgayKT_DonTu_View.Text = "";
            labelGioBD_DonTu_View.Text = "";
            labelGioKT_DonTu_View.Text = "";
            labelTinhCong_DonTu_View.Text = "";
            labelTrangThai_DonTu_View.Text = "";
            labelMoTa_DonTu_View.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelSuaThongTinDonTu_DonTu_View.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelSuaThongTinDonTu_DonTu_View.Hide();
        }

        ///================================================================================================================================
        ///                       TẠO ĐƠN TỪ                      
        ///================================================================================================================================


        private void buttonLuu_Sua_DonTu_View_Click(object sender, EventArgs e)
        {
            DateTime giobd = new DateTime();
            DateTime giokt = new DateTime();
            if (DT.Bloaidon == "DTXN  ")
            {

                giobd = new DateTime(2000, 1, 1, 0, 0, 0);
                giokt = new DateTime(2000, 1, 1, 0, 0, 0);

            }
            else
            {
                giobd = new DateTime(2000, 1, 1, Convert.ToInt32(comboBoxGioBD_Sua_DonTu_View.Text), Convert.ToInt32(comboBoxPhutBD_Sua_DonTu_View.Text), 0);
                giokt = new DateTime(2000, 1, 1, Convert.ToInt32(comboBoxGioKT_Sua_DonTu_View.Text), Convert.ToInt32(comboBoxPhutKT_Sua_DonTu_View.Text), 0);
            }
            
            try
            {
                int kt = DT.SuaDonTuBLL(labelMaDon_Sua_DonTu_View.Text, textBoxTieuDe_Sua_DonTu_View.Text, comboBoxNguoiDuyet_Sua_DonTu_View.SelectedValue.ToString(), (DateTime)dateTimePickerNgayBD_Sua_DonTu_View.Value, dateTimePickerNgayKT_Sua_DonTu_View.Value, giobd, giokt, textBoxMoTa_Sua_DonTu_View.Text, comboBoxLyDo_Sua_DonTu_View.Text);
                if (kt == 1)
                {
                    MessageBox.Show("Đã Sửa Thành Công");
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại!");
                }
            
            }
            catch
            {
                MessageBox.Show("Lỗi truy xuất!");
            }
            loadDonTuView();
            panelSuaThongTinDonTu_DonTu_View.Hide();
        }

        ///xoa don tu
        private void buttonXoa_DonTu_View_Click(object sender, EventArgs e)
        {
            if (labelMaDon_DonTu_View.Text == "")
            {
                MessageBox.Show("chọn một đơn cần xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn xóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int kt = DT.XoaDonTuBLL(labelMaDon_Sua_DonTu_View.Text);
                    if (kt == 1)
                    {
                        MessageBox.Show("Đã Xóa Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại!");
                    }

                }
                catch
                {
                    MessageBox.Show("Lỗi truy xuất!");
                }
                loadDonTuView();
            }
        }

        public void loadThongTinTaoDon()
        {
            //comboBoxNguoiDuyet_Sua_DonTu_View
            comboBoxTenNV_TaoDon_DonTu_View.DisplayMember = "TENNV";
            comboBoxTenNV_TaoDon_DonTu_View.ValueMember = "MANV";
            comboBoxTenNV_TaoDon_DonTu_View.DataSource = NV.LoadMaTenNVBLL();

            //comboBoxNguoiDuyet_Sua_DonTu_View
            comboBoxNguoiDuyet_TaoDon_DonTu_View.DisplayMember = "TENNV";
            comboBoxNguoiDuyet_TaoDon_DonTu_View.ValueMember = "MANV";
            comboBoxNguoiDuyet_TaoDon_DonTu_View.DataSource = NV.LoadMaTenNVBLL();

            string matamdt = "DT0" + BP.MaxMaBLL("MADON").ToString();
            labelMaDon_TaoDon_DonTu_View.Text = matamdt;

            labelTenLoaiDon_TaoDon_DonTu_View.Text = DT.BLLTenLoaiDon(chondon);

            DateTime date = new DateTime();
            date = DateTime.Now;
            labelNgayTao_TaoDon_DonTu_View.Text = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();

            textBoxMaNV_TaoDon_DonTu_View.Text = manvdn;
            labelTenNguoiTao_TaoDon_DonTu_View.Text = NV.BLLTenNhanVien(manvdn);

        }

        private void checkBoxTaoHo_TaoDon_DonTu_View_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaoHo_TaoDon_DonTu_View.Checked == true)
            {
                textBoxMaNV_TaoDon_DonTu_View.Enabled = true;
                comboBoxTenNV_TaoDon_DonTu_View.Enabled = true;
            }
            else
            {
                textBoxMaNV_TaoDon_DonTu_View.Enabled = false;
                comboBoxTenNV_TaoDon_DonTu_View.Enabled = false;
            }
        }

        private void textBoxMaNV_TaoDon_DonTu_View_TextChanged(object sender, EventArgs e)
        {
            
            comboBoxTenNV_TaoDon_DonTu_View.Text = NV.BLLTenNhanVien(textBoxMaNV_TaoDon_DonTu_View.Text);
        }

        private void comboBoxTenNV_TaoDon_DonTu_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxMaNV_TaoDon_DonTu_View.Text = comboBoxTenNV_TaoDon_DonTu_View.SelectedValue.ToString();
        }

        ///HỦY BỎ LẬP ĐƠN
        private void buttonHuyBo_TaoDon_DonTu_View_Click(object sender, EventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageDonTu;
            // DataTable datadon
            dataGridViewDonTu_DonTuView.DataSource = DT.loadDonTuByMANVofBLL(manvdn);
            loadDonTuView();
        }


        ///CẬP NHẬT ĐƠN TỪ
        private void buttonCapNhat_TaoDon_DonTu_View_Click(object sender, EventArgs e)
        {
            //tao đơn
            DateTime giobdtd = new DateTime();
            DateTime giokttd = new DateTime();
            DateTime ngaytaotd = new DateTime();

            string manvtd = textBoxMaNV_TaoDon_DonTu_View.Text;
            string madontd = labelMaDon_TaoDon_DonTu_View.Text;
            string maloaitd = chondon;
            string nguoilaptd = manvdn;
            int taohotd;
            if (checkBoxTaoHo_TaoDon_DonTu_View.Checked == true)
            {
                taohotd = 1;
            }
            else
            {
                taohotd = 0;
            }
            string nguoiduyettd = comboBoxNguoiDuyet_TaoDon_DonTu_View.SelectedValue.ToString();
            ngaytaotd = DateTime.Now;
            string trangthaitd = "Chờ Duyệt";
            string tieudetd = textBoxTieuDe_TaoDon_DonTu_View.Text;
            
            //tao chi tiết đơn
            if (chondon == "DTXN  ")
            {

                giobdtd = new DateTime(2000, 1, 1, 0, 0, 0);
                giokttd = new DateTime(2000, 1, 1, 0, 0, 0);

            }
            else
            {
                giobdtd = new DateTime(2000, 1, 1, Convert.ToInt32(comboBoxGioBD_TaoDon_DonTu_View.Text), Convert.ToInt32(comboBoxPhutBD_TaoDon_DonTu_View.Text), 0);
                giokttd = new DateTime(2000, 1, 1, Convert.ToInt32(comboBoxGioKT_TaoDon_DonTu_View.Text), Convert.ToInt32(comboBoxPhutKT_TaoDon_DonTu_View.Text), 0);
            }
            string lydotd = comboBoxLyDo_TaoDon_DonTu_View.Text;
            DateTime ngaybdtd = dateTimePickerNgayBD_TaoDon_DonTu_View.Value;
            DateTime ngaykttd = dateTimePickerNgayKT_TaoDon_DonTu_View.Value;
            int tinhcongtd = 0;
            string motatd = textBoxMoTa_TaoDon_DonTu_View.Text;

            ///////gọi bll
            //gọi bll
            int kt1 = DT.ThemDonTuBLL(manvtd, madontd, maloaitd, nguoilaptd, taohotd, nguoiduyettd, ngaytaotd, trangthaitd, tieudetd);
            if (kt1 == 1)
            {
                int kt2 = DT.ThemChiTietDonTuBLL(madontd, lydotd, ngaybdtd, ngaykttd, giobdtd, giokttd, tinhcongtd, motatd);
                if (kt2 == 1)
                {
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết đơn Thất Bại!");
                }
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            ////////////////////////////////////
            ////////////////////////////////////
            //tăng mã đơn
            BP.TangMaBangPhuBLL("MADON ");

        }

        ///================================================================================================================================
        ///                       thông báo                     
        ///================================================================================================================================

        FlowLayoutPanel fpanelLoadThongBao_ThongBao_view = new FlowLayoutPanel();
        private void barButtonItemThongBao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //navigationPageThongBao
            navigationFrameMain.SelectedPage = navigationPageThongBao;

            fpanelLoadThongBao_ThongBao_view.Width = panelLoadThongBao_ThongBao_View.Width;
            fpanelLoadThongBao_ThongBao_view.Height = panelLoadThongBao_ThongBao_View.Width;
            panelLoadThongBao_ThongBao_View.Controls.Add(fpanelLoadThongBao_ThongBao_view);


            ShowListThongBaoByMaNV(manvdn);

        }

        void ShowListThongBaoByMaNV(string manv)
        {
            fpanelLoadThongBao_ThongBao_view.Controls.Clear();
            //////////////////////////////////////
            TB.ListChiTietThongBaoByMANVBBL(manv);

            foreach (var demo in TB.DsCTthongbaoB)
            {
                string matb = demo.ICTmatb1;/////////////////////
                AThongBao ATB = new AThongBao(matb);
                fpanelLoadThongBao_ThongBao_view.Controls.Add(ATB);
            }
            ////////////////////////

            
        }

        private void navigationPageDonTu_Paint(object sender, PaintEventArgs e)
        {

        }

        ///================================================================================================================================
        ///                       Duyệt Đơn                     
        ///================================================================================================================================

        private void barButtonItemDuyetDonTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageDuyetDon_hr;

            loadDuyetDonTuView();
        }

        public void loadDuyetDonTuView()
        {
            listViewDuyetDon_DonTu_HR.Items.Clear();
            DT.ListDonTuAllDAL();

            foreach (var demo in DT.dsdontu)
            {
                listViewDuyetDon_DonTu_HR.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
            ////////////

            /////////////

        }

        private void listViewDuyetDon_DonTu_HR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string madon = null;

            if (listViewDuyetDon_DonTu_HR.SelectedItems.Count > 0)
            {
                madon = listViewDuyetDon_DonTu_HR.SelectedItems[0].SubItems[0].Text;
                try
                {
                    DT.ChiTietDonTuBLL(madon);
                    DT.ThongTinDonTuBLL(madon);
                    //TieuDe
                    labelTieuDe_DonTu_HR.Text = DT.Bghichu;
                    //MaDon
                    labelMaDon_DonTu_HR.Text = DT.Bmadon;
                    //MaLoai
                    labelLoaiDon_DonTu_HR.Text = DT.tenloaidon;
                    //ngaytao
                    labelNgayTao_DonTu_HR.Text = DT.Bngaytao.Day.ToString() + "/" + DT.Bngaytao.Month.ToString() + "/" + DT.Bngaytao.Year.ToString();

                    //taoho
                    if (DT.Btaoho == 1)
                    {
                        labelTaoHo_DonTu_HR.Text = "Tạo hộ";
                    }
                    else
                    {
                        labelTaoHo_DonTu_HR.Text = "Tạo cho mình";
                    }
                    //mã nhân viên
                    labelMaNV_DonTu_HR.Text = DT.Bmanv;
                    //tên nhân viên
                    labelTenNV_DonTu_HR.Text = DT.tennhanvien;
                    ///Tên Người Tạo
                    labelNguoiTao_DonTu_HR.Text = DT.tennguoilap;
                    //lydo
                    labelLyDo_DonTu_HR.Text = DT.Blydo;

                    //NguoiDuyet
                    labelNguoiDuyet_DonTu_HR.Text = DT.tennguoiduyet;
                    //tý làm nhaaaa
                    //comboBoxNguoiDuyet_Sua_DonTu_View.SelectedIndex = comboBoxNguoiDuyet_Sua_DonTu_View.FindStringExact(DT.tennguoiduyet);
                    //Ngaybd
                    //dateTimePickerNgayBD_Sua_DonTu_View.Value = DT.Bngaybd;
                    label1NgayBD_DonTu_HR.Text = DT.Bngaybd.Day.ToString() + "/" + DT.Bngaybd.Month.ToString() + "/" + DT.Bngaybd.Year.ToString();
                    //NgayKT
                    //dateTimePickerNgayKT_Sua_DonTu_View.Value = DT.Bngaykt;
                    labelNgayKT_DonTu_HR.Text = DT.Bngaykt.Day.ToString() + "/" + DT.Bngaykt.Month.ToString() + "/" + DT.Bngaykt.Year.ToString();
                    //
                    if (DT.Bloaidon == "DTXN  ")
                    {
                        label1GioBD_DonTu_HR.Text = "";
                        labelGioKT_DonTu_HR.Text = "";

                    }
                    else
                    {
                        label1GioBD_DonTu_HR.Text = DT.Bgiobd.Hour.ToString() + ":" + DT.Bgiobd.Minute.ToString();
                        labelGioKT_DonTu_HR.Text = DT.Bgiokt.Hour.ToString() + ":" + DT.Bgiokt.Minute.ToString();
                    }

                    if (DT.Btinhcong == 1)
                    {
                        labelTinhCong_DonTu_HR.Text = "Có tính công";
                    }
                    else
                    {
                        labelTinhCong_DonTu_HR.Text = "Không tính công";
                    }
                    comboBoxTrangThai_DonTu_HR.Text = DT.Btrangthai;
                    //MOTA
                    labelMoTa_DuyetDon_HR.Text = DT.Bmota;
                }
                catch
                {
                    MessageBox.Show("Lỗi truy xuất!");
                }

            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (labelMaDon_DonTu_HR.Text.Equals("") == false)
            {
                string madon = labelMaDon_DonTu_HR.Text;
                string trangthai = "Đã Duyệt";
                int kt2 = DT.DuyetDonTuBLL(madon, trangthai);
                if (kt2 == 1)
                {
                    MessageBox.Show("Đã Duyệt Đơn");
                    TaoThongBaoDuyetDon(madon, manvdn, labelMaNV_DonTu_HR.Text, labelLoaiDon_DonTu_HR.Text, trangthai);
                }
                else
                {
                    MessageBox.Show("Duyệt Đơn thất bại!");
                }
                loadDuyetDonTuView();
                ClearThongTinDuyetDon();
            }
            else
            {
                MessageBox.Show("chọn đơn cần duyệt !");
            }
        }

        public void ClearThongTinDuyetDon()
        {
            //TieuDe
            labelTieuDe_DonTu_HR.Text = "";
            //MaDon
            labelMaDon_DonTu_HR.Text = "";
            //MaLoai
            labelLoaiDon_DonTu_HR.Text = "";
            //ngaytao
            labelNgayTao_DonTu_HR.Text = "";

            //taoho
                labelTaoHo_DonTu_HR.Text = "";

            //mã nhân viên
            labelMaNV_DonTu_HR.Text = "";
            //tên nhân viên
            labelTenNV_DonTu_HR.Text = "";
            ///Tên Người Tạo
            labelNguoiTao_DonTu_HR.Text = "";
            //lydo
            labelLyDo_DonTu_HR.Text ="";

            //NguoiDuyet
            labelNguoiDuyet_DonTu_HR.Text = "";
            //tý làm nhaaaa
            //comboBoxNguoiDuyet_Sua_DonTu_View.SelectedIndex = comboBoxNguoiDuyet_Sua_DonTu_View.FindStringExact(DT.tennguoiduyet);
            //Ngaybd
            //dateTimePickerNgayBD_Sua_DonTu_View.Value = DT.Bngaybd;
            label1NgayBD_DonTu_HR.Text = "";
            //NgayKT
            //dateTimePickerNgayKT_Sua_DonTu_View.Value = DT.Bngaykt;
            labelNgayKT_DonTu_HR.Text = "";
            //

                label1GioBD_DonTu_HR.Text = "";
                labelGioKT_DonTu_HR.Text = "";


                labelTinhCong_DonTu_HR.Text = "";

            comboBoxTrangThai_DonTu_HR.Text = "";
            //MOTA
            labelMoTa_DuyetDon_HR.Text = "";
        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClearThongTinDuyetDon();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (labelMaDon_DonTu_HR.Text.Equals("") == false)
            {
                string madon = labelMaDon_DonTu_HR.Text;
                string trangthai = comboBoxTrangThai_DonTu_HR.Text;
                int kt2 = DT.DuyetDonTuBLL(madon, trangthai);
                if (kt2 == 1)
                {
                    MessageBox.Show("Đã Duyệt Đơn");
                    TaoThongBaoDuyetDon(madon, manvdn, labelMaNV_DonTu_HR.Text, labelLoaiDon_DonTu_HR.Text, trangthai);
                }
                else
                {
                    MessageBox.Show("Duyệt Đơn thất bại!");
                }
                loadDuyetDonTuView();
                ClearThongTinDuyetDon();
            }
            else
            {
                MessageBox.Show("chọn đơn cần duyệt !");
            }
        }

        public void TaoThongBaoDuyetDon(string madon, string nguoiduyet, string manv, string loaidon, string trangthai)
        { 
            DateTime ngaytaotb = new DateTime();
            string matb;
            int ma = BP.MaxMaBLL("MATB  ");
            matb = "TB00" + ma.ToString();
            string nguoitao = nguoiduyet;
            int doituong = 1;
            string mapb = null;
            string manvtb = manv;
            string tieudetb = trangthai + " " + loaidon +" - mã đơn: " + madon;
            string tennvd = NV.BLLTenNhanVien(nguoiduyet);
            string noidung = tennvd + " đã " + trangthai + " " + loaidon +" của bạn!, vui lòng kiểm tra lại đơn từ nhé! cám ơn.";
            ngaytaotb = DateTime.Now;

            int kt = TB.ThemThongBaoBLL( matb, nguoitao,  ngaytaotb, doituong, mapb , manv,  tieudetb, noidung);
            //int kt = TB.ThemThongBaoBLL("DEMO3", "DEMO", ngaytaotb, 1, null , "NV0050", "DEMO03", "DEMOO3");
            if (kt == 1)
            {
                int kt2 = TB.ThemChiTietThongBaoBLL(matb, manv);
                if (kt2 == 1)
                {
                    MessageBox.Show("đã thông báo đến nhân viên!");
                    BP.TangMaBangPhuBLL("MATB  ");
                }
                else
                {
                    MessageBox.Show("2.chưa tạo thông báo!");
                }
            }
            else
            {
                MessageBox.Show("1.chưa tạo thông báo!");
            }

        }

        private void buttonViewAll_DonTu_HR_Click(object sender, EventArgs e)
        {
            loadDuyetDonTuView();
        }

        private void dateTimePickerDuyetDon_DonTu_HR_ValueChanged(object sender, EventArgs e)
        {
            listViewDuyetDon_DonTu_HR.Items.Clear();
            DateTime date = new DateTime(dateTimePickerDuyetDon_DonTu_HR.Value.Year, dateTimePickerDuyetDon_DonTu_HR.Value.Month, dateTimePickerDuyetDon_DonTu_HR.Value.Day);
            DT.ListDonTuOfDayAllBLL(date);

            foreach (var demo in DT.dsdontu)
            {
                listViewDuyetDon_DonTu_HR.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
        }

        private void buttonHomNay_DonTu_HR_Click(object sender, EventArgs e)
        {
            listViewDuyetDon_DonTu_HR.Items.Clear();
            DateTime date = new DateTime();
            date = DateTime.Now;

            DT.ListDonTuOfDayAllBLL(date);

            foreach (var demo in DT.dsdontu)
            {
                listViewDuyetDon_DonTu_HR.Items.Add(new ListViewItem(new string[] { demo.Madon1, demo.Tennv1.ToString(), demo.Loaidon1, demo.Ngaytao1.ToString(), demo.Nguoiduyet1, demo.Trangthai1.ToString() }));
            }
        }

        ///================================================================================================================================
        ///                       Duyệt Đơn                     
        ///================================================================================================================================


        private void barButtonItemTaiKhoan_HRM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageTaiKhoan_HRM;
            loadTaiKhoanHRM();
            panelSuaTrangThai_TaiKhoan_HR.Hide();
        }

        public void loadTaiKhoanHRM()
        {
            listViewTaiKhoan_HRM.Items.Clear();
            DN.ListTaiKhoanBLL();
            foreach (var TK in DN.Dstaikhoan)
            {
                string tenNV = NV.BLLTenNhanVien(TK.Madn);
                string trangthai;
                if (TK.Hoatdong == 1)
                {
                    trangthai = "Hoạt động";
                }
                else
                {
                    trangthai = "Đã khóa";
                }

                listViewTaiKhoan_HRM.Items.Add(new ListViewItem(new string[] { TK.Madn, tenNV, trangthai }));
            }
            ////////////

            /////////////

        }

        private void textBoxSearch_TaiKhoan_HR_TextChanged(object sender, EventArgs e)
        {
            listViewTaiKhoan_HRM.Items.Clear();
            DN.ListTaiKhoanByMaDNBLL(textBoxSearch_TaiKhoan_HR.Text);
            foreach (var TK in DN.Dstaikhoan)
            {
                string tenNV = NV.BLLTenNhanVien(TK.Madn);
                string trangthai;
                if (TK.Hoatdong == 1)
                {
                    trangthai = "Hoạt động";
                }
                else
                {
                    trangthai = "Đã khóa";
                }

                listViewTaiKhoan_HRM.Items.Add(new ListViewItem(new string[] { TK.Madn, tenNV, trangthai }));
            }
        }

        private void buttonSearch_TaiKhoan_HR_Click(object sender, EventArgs e)
        {
            listViewTaiKhoan_HRM.Items.Clear();
            DN.ListTaiKhoanByMaDNBLL(textBoxSearch_TaiKhoan_HR.Text);
            foreach (var TK in DN.Dstaikhoan)
            {
                string tenNV = NV.BLLTenNhanVien(TK.Madn);
                string trangthai;
                if (TK.Hoatdong == 1)
                {
                    trangthai = "Hoạt động";
                }
                else
                {
                    trangthai = "Đã khóa";
                }

                listViewTaiKhoan_HRM.Items.Add(new ListViewItem(new string[] { TK.Madn, tenNV, trangthai }));
            }
        }

        private void label106_Click(object sender, EventArgs e)
        {

        }

        private void listViewTaiKhoan_HRM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //madon = listViewDuyetDon_DonTu_HR.SelectedItems[0].SubItems[0].Text;

            string madn = null;

            if (listViewTaiKhoan_HRM.SelectedItems.Count > 0)
            {
                madn = listViewTaiKhoan_HRM.SelectedItems[0].SubItems[0].Text;
                try
                {

                    DN.LoadThongTinTaiKhoanBLL(madn);

                    labelMaDN_TaiKhoan_HR.Text = madn;
                    labelTenNV_TaiKhoan_HR.Text = NV.BLLTenNhanVien(madn);
                    string trangthai;
                    if (DN.hoatdongB == 1)
                    {
                        trangthai = "Hoạt Động";
                    }
                    else
                    {
                        trangthai = "Đã Khóa";
                    }
                    labelTrangThai_TaiKhoan_HR.Text = trangthai;
                    comboBoxTrangThai_TaiKhoan_HR.Text = trangthai;
                }
                catch { }
            } 
        }

        private void buttonCapNhat_TaiKhoan_HR_Click(object sender, EventArgs e)
        {
            panelSuaTrangThai_TaiKhoan_HR.Show();
        }

        private void buttonHuy_TaiKhoan_HR_Click(object sender, EventArgs e)
        {
            panelSuaTrangThai_TaiKhoan_HR.Hide();
            labelMaDN_TaiKhoan_HR.Text = "";
            labelTenNV_TaiKhoan_HR.Text = "";
            labelTrangThai_TaiKhoan_HR.Text = "";
        }

        private void buttonLuu_TaiKhoan_HR_Click(object sender, EventArgs e)
        {
            if (labelMaDN_TaiKhoan_HR.Text != "")
            {
                int trangthai;
                if (comboBoxTrangThai_TaiKhoan_HR.Text.Equals("Hoạt Động"))
                {
                    trangthai = 1;
                }

                else
                {
                    trangthai = 0;
                }

                int kt = DN.SuaTaiKhoanBLL(labelMaDN_TaiKhoan_HR.Text, trangthai);
                //////////////////////////////
                if (kt == 1)
                {
                    MessageBox.Show("Sửa thành công");
                    panelSuaTrangThai_TaiKhoan_HR.Hide();
                    labelMaDN_TaiKhoan_HR.Text = "";
                    labelTenNV_TaiKhoan_HR.Text = "";
                    labelTrangThai_TaiKhoan_HR.Text = "";
                    loadTaiKhoanHRM();
                }
                else
                    MessageBox.Show("2.Lỗi Sửa!!!!!!");
            }
            else
            {
                MessageBox.Show("1.Lỗi Sửa!!!!!!");
            }
        }

        ///================================================================================================================================
        ///                       Phan Cong                     
        ///================================================================================================================================


        private void barButtonItem18_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             navigationFrameMain.SelectedPage = navigationPagePhanCong_HRM;
             LoadThongTinPhanCongHR();

        }


        public void LoadThongTinPhanCongHR()
        {
            string mapc = "PC00" + BP.MaxMaBLL("MAPC  ").ToString();
            labelMaPhanCong_PhanCong_HR.Text = mapc;
            //THONG TIN CHUNG
            //NGAYTAO
            DateTime date = new DateTime();
            date = DateTime.Now;
            labelNgayTao_PhanCong_HR.Text = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
            labelNguoiLap_PhanCong_HR.Text = NV.BLLTenNhanVien(manvdn);
            //comboBoxNguoiDuyet_PhanCong_HR
            comboBoxNguoiDuyet_PhanCong_HR.DisplayMember = "TENNV";
            comboBoxNguoiDuyet_PhanCong_HR.ValueMember = "MANV";
            comboBoxNguoiDuyet_PhanCong_HR.DataSource = NV.LoadMaTenNVBLL();
            //comboBoxTenNV_PhanCong_HR
            comboBoxTenNV_PhanCong_HR.DisplayMember = "TENNV";
            comboBoxTenNV_PhanCong_HR.ValueMember = "MANV";
            comboBoxTenNV_PhanCong_HR.DataSource = NV.LoadMaTenNVBLL();
            //comboBoxPhongBan_PhanCong_HR
            comboBoxPhongBan_PhanCong_HR.DataSource = nv.loadCBBPhongban();
            comboBoxPhongBan_PhanCong_HR.DisplayMember = "TENPH";
            comboBoxPhongBan_PhanCong_HR.ValueMember = "MAPH";
            comboBoxPhongBan_PhanCong_HR.Enabled = false;

            //CHI TIET CA

            //comboBoxCaThu2_PhanCong_HR
            comboBoxCaThu2_PhanCong_HR.Enabled = false;
            comboBoxCaThu2_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu2_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu2_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaThu3_PhanCong_HR
            comboBoxCaThu3_PhanCong_HR.Enabled = false;
            comboBoxCaThu3_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu3_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu3_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaThu4_PhanCong_HR
            comboBoxCaThu4_PhanCong_HR.Enabled = false;
            comboBoxCaThu4_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu4_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu4_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaThu5_PhanCong_HR
            comboBoxCaThu5_PhanCong_HR.Enabled = false;
            comboBoxCaThu5_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu5_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu5_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaThu6_PhanCong_HR
            comboBoxCaThu6_PhanCong_HR.Enabled = false;
            comboBoxCaThu6_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu6_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu6_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaThu7_PhanCong_HR
            comboBoxCaThu7_PhanCong_HR.Enabled = false;
            comboBoxCaThu7_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaThu7_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaThu7_PhanCong_HR.ValueMember = "MACA";
            //comboBoxCaChuNhat_PhanCong_HR
            comboBoxCaChuNhat_PhanCong_HR.Enabled = false;
            comboBoxCaChuNhat_PhanCong_HR.DataSource = CLV.LoadMaTenCaBLL();
            comboBoxCaChuNhat_PhanCong_HR.DisplayMember = "TENCA";
            comboBoxCaChuNhat_PhanCong_HR.ValueMember = "MACA";


            //comboBoxTenNV_TaoDon_DonTu_View.DisplayMember = "TENNV";
            //comboBoxTenNV_TaoDon_DonTu_View.ValueMember = "MANV";
            //comboBoxTenNV_TaoDon_DonTu_View.DataSource = NV.LoadMaTenNVBLL();
        }

        private void checkBoxThu2_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu2_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu2_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu2_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxThu3_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu3_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu3_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu3_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxThu4_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu4_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu4_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu4_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxThu5_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu5_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu5_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu5_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxThu6_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu6_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu6_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu6_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxThu7_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThu7_PhanCong_HR.Checked == true)
            {
                comboBoxCaThu7_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaThu7_PhanCong_HR.Enabled = false;
            }
        }

        private void checkBoxChuNhat_PhanCong_HR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChuNhat_PhanCong_HR.Checked == true)
            {
                comboBoxCaChuNhat_PhanCong_HR.Enabled = true;
            }
            else
            {
                comboBoxCaChuNhat_PhanCong_HR.Enabled = false;
            }
        }

        private void comboBoxTenNV_PhanCong_HR_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxMaNV_PhanCong_HR.Text = comboBoxTenNV_PhanCong_HR.SelectedValue.ToString();
        }

        private void textBoxMaNV_PhanCong_HR_TextChanged(object sender, EventArgs e)
        {
            comboBoxTenNV_PhanCong_HR.Text = NV.BLLTenNhanVien(textBoxMaNV_PhanCong_HR.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime datenow = new DateTime();
            datenow = DateTime.Now;
            if (nhoHonDate(dateTimePickerTuNgay_PhanCong_HR.Value, datenow))
            {
                MessageBox.Show("Lỗi, ngày bắt đầu phải lớn hơn ngày hiện tại nha!");
                return;
            }

            if (nhoHonDate(dateTimePickerDenNgay_PhanCong_HR.Value, datenow))
            {
                MessageBox.Show("Lỗi, ngày kết thúc phải lớn hơn ngày hiện tại nha!");
                return;
            }

            ///CAP NHAT PHAN CONG -----------------------------------------
            //ThemPhanCongBLL(string mapc, string nguoitao, string mapb, string nguoiduyet, DateTime ngaytao, DateTime tungay, DateTime denngay, string tieude, string GhiChu)
            string mapc = "PC00" + BP.MaxMaBLL("MAPC  ").ToString();
            
            string nguoitao = manvdn;
            string mapb = comboBoxPhongBan_PhanCong_HR.SelectedValue.ToString();
            string nguoiduyet = comboBoxNguoiDuyet_PhanCong_HR.SelectedValue.ToString();
            DateTime ngaytao = new DateTime();
            ngaytao = DateTime.Now;
            DateTime tungay = dateTimePickerTuNgay_PhanCong_HR.Value;
            DateTime denngay = dateTimePickerDenNgay_PhanCong_HR.Value;
            string tieude = textBoxTieuDe_PhanCong_HR.Text;
            string GhiChu = textBoxGhiChu_PhanCong_HR.Text;

            int kt1 = PC.ThemPhanCongBLL(mapc, nguoitao, mapb, nguoiduyet, ngaytao, tungay, denngay, tieude, GhiChu);
            if (kt1 == 1)
            {
                //thu 2
                if (checkBoxThu2_PhanCong_HR.Checked == true)
                { 
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 1;
                    string maca = comboBoxCaThu2_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu 3
                if (checkBoxThu3_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 2;
                    string maca = comboBoxCaThu3_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu 4
                if (checkBoxThu4_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 3;
                    string maca = comboBoxCaThu4_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu 5
                if (checkBoxThu5_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 4;
                    string maca = comboBoxCaThu5_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu 6
                if (checkBoxThu6_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 5;
                    string maca = comboBoxCaThu6_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu 7
                if (checkBoxThu7_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 6;
                    string maca = comboBoxCaThu7_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }
                //thu chu nhat
                if (checkBoxChuNhat_PhanCong_HR.Checked == true)
                {
                    //ThemCTPhanCongBLL(string mapc, string manv, int day, string maca)
                    int day = 7;
                    string maca = comboBoxCaChuNhat_PhanCong_HR.SelectedValue.ToString();
                    string manv = textBoxMaNV_PhanCong_HR.Text;
                    int kt2 = PC.ThemCTPhanCongBLL(mapc, manv, day, maca);
                    if (kt2 != 1)
                    {
                        MessageBox.Show("2.Lỗi Thêm!!!!!!");
                    }
                }

                MessageBox.Show("Đã Tạo Phiếu Phân Công");
                BP.TangMaBangPhuBLL("MAPC  ");
            }
            else
            {
                MessageBox.Show("1.Lỗi Thêm!!!!!!");
            }


        }

        ///================================================================================================================================
        ///                       DS CHAM CONG                    
        ///================================================================================================================================


        private void barButtonItemChamCong_HR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrameMain.SelectedPage = navigationPageDSChamCong;
            loadDSChamCong();
        }

        public void loadDSChamCong()
        {
            listViewdsChamCong_hr.Items.Clear();
            CC.ListchamCongAllBLL();
            foreach (var c in CC.Dschamcong)
            {
                string tenNV = NV.BLLTenNhanVien(c.Manvi);
                string ngaycc = c.Ngaycci.Day.ToString() + "/" + c.Ngaycci.Month.ToString() + "/" + c.Ngaycci.Year.ToString();
                string checkin = c.Giockini.Hour.ToString() + ":" + c.Giockini.Minute.ToString();
                string checkout = c.Giochouti.Hour.ToString() + ":" + c.Giochouti.Minute.ToString();

                listViewdsChamCong_hr.Items.Add(new ListViewItem(new string[] { c.Manvi, tenNV, ngaycc, checkin, checkout }));
            }
            ////////////

            /////////////

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listViewdsChamCong_hr.Items.Clear();
                CC.ListchamCongByMANVBLL(textBoxSearch_MANV_CHAMCONG.Text);
                foreach (var c in CC.Dschamcong)
                {
                    string tenNV = NV.BLLTenNhanVien(c.Manvi);
                    string ngaycc = c.Ngaycci.Day.ToString() + "/" + c.Ngaycci.Month.ToString() + "/" + c.Ngaycci.Year.ToString();
                    string checkin = c.Giockini.Hour.ToString() + ":" + c.Giockini.Minute.ToString();
                    string checkout = c.Giochouti.Hour.ToString() + ":" + c.Giochouti.Minute.ToString();

                    listViewdsChamCong_hr.Items.Add(new ListViewItem(new string[] { c.Manvi, tenNV, ngaycc, checkin, checkout }));
                }
            }
            catch { }
        }

        private void buttonViewALL_ChamCong_HR_Click(object sender, EventArgs e)
        {
            loadDSChamCong();
        }

        private void buttonToDay_ChamCong_HR_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            try
            {
                listViewdsChamCong_hr.Items.Clear();
                CC.ListchamCongByDayDAL(date);
                foreach (var c in CC.Dschamcong)
                {
                    string tenNV = NV.BLLTenNhanVien(c.Manvi);
                    string ngaycc = c.Ngaycci.Day.ToString() + "/" + c.Ngaycci.Month.ToString() + "/" + c.Ngaycci.Year.ToString();
                    string checkin = c.Giockini.Hour.ToString() + ":" + c.Giockini.Minute.ToString();
                    string checkout = c.Giochouti.Hour.ToString() + ":" + c.Giochouti.Minute.ToString();

                    listViewdsChamCong_hr.Items.Add(new ListViewItem(new string[] { c.Manvi, tenNV, ngaycc, checkin, checkout }));
                }
            }
            catch { }
        }

        private void dateTimePickerChamCong_hr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                listViewdsChamCong_hr.Items.Clear();
                CC.ListchamCongByDayDAL(dateTimePickerChamCong_hr.Value);
                foreach (var c in CC.Dschamcong)
                {
                    string tenNV = NV.BLLTenNhanVien(c.Manvi);
                    string ngaycc = c.Ngaycci.Day.ToString() + "/" + c.Ngaycci.Month.ToString() + "/" + c.Ngaycci.Year.ToString();
                    string checkin = c.Giockini.Hour.ToString() + ":" + c.Giockini.Minute.ToString();
                    string checkout = c.Giochouti.Hour.ToString() + ":" + c.Giochouti.Minute.ToString();

                    listViewdsChamCong_hr.Items.Add(new ListViewItem(new string[] { c.Manvi, tenNV, ngaycc, checkin, checkout }));
                }
            }
            catch { }
        }

        private void labelTrangThai_DonTu_View_TextChanged(object sender, EventArgs e)
        {
            //labelTrangThai_DonTu_View
            if (labelTrangThai_DonTu_View.Text.Equals("Đã Duyệt") || labelTrangThai_DonTu_View.Text.Equals("Từ Chối"))
                    {
                        buttonSua_DonTu_View.Enabled = false;
                        buttonXoa_DonTu_View.Enabled = false;
                    }
                    else
                    {
                        buttonSua_DonTu_View.Enabled = true;
                        buttonXoa_DonTu_View.Enabled = true;
                    }
        }














    }///////////////////////////////////
}