using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ADAY : UserControl
    {
        private string Textday;
        private string Macaa;

        public string Macaa1
        {
            get { return Macaa; }
            set { Macaa = value; }
        }

        public string Textday1
        {
            get { return Textday; }
            set { Textday = value; }
        }

        public ADAY()
        {
            InitializeComponent();
        }
        public void numberDay(string ngay)
        {
            labelADAY.Text = ngay;
            Textday = ngay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewbtn != null)
            {
                viewbtn(this, new EventArgs());
            }
        }

        public void removeLableAday()
        {
            //labelADAY.Text = "";
            labelCaChieu.Text = "";
            labelCaSang.Text = "";
            button1.Hide();
        }

        public void calamDay(string maca)
        {
            Macaa = maca;
            string tenca;
            DateTime giobd;
            DateTime giokt;
            int sogio;
            using (DataNhanSuDataContext db = new DataNhanSuDataContext())
            {

                var calam = from CALAMVIEC in db.CALAMVIECs
                                .Where(M => M.MACA.Equals(maca))
                            select new
                            {
                                TEN_CA = CALAMVIEC.TENCA,
                                GIO_BD = CALAMVIEC.GIOBD,
                                GIO_KT = CALAMVIEC.GIOKT,
                                SO_GIO = CALAMVIEC.SOGIO,

                            };


                foreach (var cl in calam)
                {
                    giobd = (DateTime)cl.GIO_BD;
                    giokt = (DateTime)cl.GIO_KT;
                    if (cl.SO_GIO == 8)
                    {
                        string nd = "Ca 2 buổi " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                        labelCaChieu.Text = nd;
                        //labelCaChieu.Text = "";
                        //Button BtnView = new Button() { Width = 75, Height = 23, Location = new Point(34, 70) };
                        //BtnView.Text = "Xem Thêm";
                        //panelADAY.Controls.Add(BtnView);
                        button1.Show();

                    }
                    else if (cl.SO_GIO != 8)
                    {
                        if (Convert.ToInt32(giokt.Hour.ToString()) <= 12)
                        {
                            string nd = "Ca Sáng: " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                            labelCaChieu.Text = nd;

                        }
                        else
                        {
                            string nd = "Ca Chiều: " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                            labelCaChieu.Text = nd;

                        }

                        button1.Show();
                    }


                }
            }

        }
        ///////////////////////////////////////////
        private event EventHandler viewpanel;
        public event EventHandler Viewpanel
        {
            add { viewpanel += value; }
            remove { viewpanel += value; }
        }

        private void panelADAY_Click(object sender, EventArgs e)
        {
            if (viewpanel != null)
            {
                viewpanel(this, new EventArgs());
            }
        }
        /////////////////////////////////////////
        private event EventHandler viewbtn;
        public event EventHandler Viewbtn
        {
            add { viewbtn += value; }
            remove { viewbtn += value; }
        }





    }
}
