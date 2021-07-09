using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChamCongItem
    {
        private string manvi;

        public string Manvi
        {
            get { return manvi; }
            set { manvi = value; }
        }
        private DateTime ngaycci;

        public DateTime Ngaycci
        {
            get { return ngaycci; }
            set { ngaycci = value; }
        }
        private DateTime giockini;

        public DateTime Giockini
        {
            get { return giockini; }
            set { giockini = value; }
        }
        private DateTime giochouti;

        public DateTime Giochouti
        {
            get { return giochouti; }
            set { giochouti = value; }
        }
        private int solani;

        public int Solani
        {
            get { return solani; }
            set { solani = value; }
        }

        public ChamCongItem(string manv, DateTime ngaycc, DateTime giovao, DateTime giora, int solan)
        {
            Manvi = manv;
            Ngaycci = ngaycc;
            Giockini = giovao;
            Giochouti = giora;
            Solani = solan;
        }
    }
}
