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
    public partial class ACALAM : UserControl
    {
        private string maca;

        public string Maca
        {
            get { return maca; }
            set { maca = value; }
        }

        public ACALAM(string mc)
        {
            InitializeComponent();
            this.Maca = mc;
            //this.Ca = caitem;CaItem caitem
            ShowInfor(Maca);
        }

        public void MACALAM(string mc)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void ShowInfor(string maca )
        {
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
                                SO_CONG = CALAMVIEC.SOCONG,

                            };


                foreach (var cl in calam)
                {
                    giobd = (DateTime)cl.GIO_BD;
                    giokt = (DateTime)cl.GIO_KT;
                    if (cl.SO_GIO == 8)
                    {
                        string nd = "Ca 2 buổi " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                        string tg = giobd.Hour.ToString() + ":" + giobd.Minute.ToString() + " - " + giokt.Hour.ToString() + ":" + giokt.Minute.ToString();
                        labelGioLam.Text = tg;
                        labelSCT.Text = nd;
                        SoGio.Text = cl.SO_GIO.ToString();
                        SoCong.Text = cl.SO_CONG.ToString();

                    }
                    else if (cl.SO_GIO != 8)
                    {
                        if (Convert.ToInt32(giokt.Hour.ToString()) <= 12)
                        {
                            string nd = "Ca Sáng: " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                            labelSCT.Text = nd;

                        }
                        else
                        {
                            string nd = "Ca Chiều: " + giobd.Hour.ToString() + "h - " + giokt.Hour.ToString() + "h";
                            labelSCT.Text = nd;

                        }
                        string tg = giobd.Hour.ToString() + ":" + giobd.Minute.ToString() + " - " + giokt.Hour.ToString() + ":" + giokt.Minute.ToString();
                        labelGioLam.Text = tg;
                        SoGio.Text = cl.SO_GIO.ToString();
                        SoCong.Text = cl.SO_CONG.ToString();
                       
                    }


                }
            }
        }

    }
}
