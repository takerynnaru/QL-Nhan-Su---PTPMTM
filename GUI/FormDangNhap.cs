using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace GUI
{
    public partial class FormDangNhap : Form
    {
        DangNhapBLL dn = new DangNhapBLL();
        public string madnGUI;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void bt_DangNhap_Click(object sender, EventArgs e)
        {
            string ma = textUser.Text;
            string pass = textPass.Text;
            int kt = 3;
            kt = dn.DangNhap(ma, pass);
            if (kt == 0) // nhap không đầy đủ
            {
                MessageBox.Show("Vui lòng nhập Username và Password");
            }
            else if (kt == 1) // đăng nhập thành công
            {
                DialogResult rs = MessageBox.Show("Đăng Nhập Thành Công!!", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs.Equals(DialogResult.Yes))
                {
                    madnGUI = dn.madnB;
                    MainForm1 f = new MainForm1(madnGUI);
                    f.Show();
                    this.Hide();
                }
            }
            else if (kt == 2) //tk bị khóa
            {
                DialogResult rs = MessageBox.Show("Tài khoản đã bị khóa, liên hệ phòng nhân sự để mở lại!!", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            }
            else // đăng nhập thất bại!
            {
                MessageBox.Show("Mật khẩu hoặc tên đăng nhập không tồn tại");
            }
           
        }
    }
}
