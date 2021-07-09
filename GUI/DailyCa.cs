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
    public partial class DailyCa : Form
    {
        BLLChamCong CC = new BLLChamCong();
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private CaData ca;

        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        string Maca;
        public DailyCa(DateTime date, string manv, string maca)
        {
            InitializeComponent();
            this.Date = date;
            this.Manv = manv;
            fPanel.Width = panel2.Width;
            fPanel.Height = panel2.Width;
            panel2.Controls.Add(fPanel);
            Maca = maca;

            string ND = "Chấm công ngày " + Date.Day.ToString() + "/" + Date.Month.ToString() + "/" + Date.Year.ToString();
            labelNgay.Text = ND;

            ShowJobByDate(Maca);

            var datenow = DateTime.Now;

            if (isEqualDate(datenow, Date))
            { buttonChamCong.Show(); }
            else buttonChamCong.Hide();
        }

        void ShowJobByDate(string maca)
        {
            fPanel.Controls.Clear();

            ACALAM ACA = new ACALAM(Maca);
            fPanel.Controls.Add(ACA);           
        }


        //////////////////////So sách datetime////////////////////////
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

        private void buttonChamCong_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            int gio = Convert.ToInt32( date.Hour.ToString());
            int phut = Convert.ToInt32( date.Minute.ToString());

            /////////////CheckIn- checkout//////////////////////////
            int kt = CC.BLLcheckChamCong(manv, date);//return 0/ chua check in / return 1 đã checkin / return 2 đã checkout
            if (kt == 0)
            {
                int i = CC.BLLCheckin(manv, date, gio, phut); ///check in/////////////////////////
                if (i == 1)
                {
                    string nd = "Bạn đã check in lúc " + gio.ToString() + "h" + phut.ToString() + "' ngày " + date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
                    MessageBox.Show(nd);
                }
                else
                {
                    MessageBox.Show("Chấm công thất bại, vui lòng chấm lại nha!");
                }
                /////////////////
            }
            else if (kt == 1) ///CheckOut/////////////////////////
            {
                int o = CC.BLLCheckOut(manv, date, gio, phut);
                if (o == 1)
                {
                    string nd = "Bạn đã check out lúc " + gio.ToString() + "h" + phut.ToString() + "' ngày " + date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
                    MessageBox.Show(nd);
                }
                else
                {
                    MessageBox.Show("Check Out thất bại, vui lòng chấm lại nha!");
                }
            }
            else
            {
                int o = CC.BLLCheckOut(manv, date, gio, phut);
                if (o == 1)
                {
                    string nd = "Bạn đã check out lúc " + gio.ToString() + "h" + phut.ToString() + "' ngày " + date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
                    MessageBox.Show(nd);
                }
                else
                {
                    MessageBox.Show("Check Out thất bại, vui lòng chấm lại nha!");
                }
            }
           
            
        }
        /////////////////////////////////////////////




    }
}
