using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Cours
    {
        private int num;
        private Professeur unProf;
        private Instrument unInstru;
        private string date;
        private int nbPlace;

        public Cours() { }

        public Cours(int num, Professeur unProf, Instrument unInstru, string date, int nbPlace)
        {
            this.num = num;
            this.unProf = unProf;
            this.unInstru = unInstru;
            this.date = date;
            this.nbPlace = nbPlace;
        }

        public int getNum()
        {
            return this.num;
        }
        public Professeur getUnProf()
        {
            return this.unProf;
        }
        public Instrument getUnInstru()
        {
            return this.unInstru;
        }
        public string getDate()
        {
            return this.date;
        }
        public int getNbPlace()
        {
            return this.nbPlace;
        }

        public int Num { get => num; }
    }
}
