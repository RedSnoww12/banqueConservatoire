using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Instrument
    {
        private int num;
        private string nom;

        public Instrument() { }

        public Instrument(int num, string nom)
        {
            this.num = num;
            this.nom = nom;
        }

        public int Num { get => num; }
        public string Nom { get => nom; }
    }
}
