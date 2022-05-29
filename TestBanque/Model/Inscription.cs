using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Inscription
    {
        private Adherent unAdherent;
        private Cours unCours;

        private int payee;

        public Inscription()
        {

        }

        public Inscription(Adherent unAdherent, Cours unCours, int payee = 1)
        {
            this.unAdherent = unAdherent;
            this.unCours = unCours;
            this.payee = payee;
        }

        public override string ToString()
        {
            return ("Adherent: "+this.unAdherent.ToString()+" ; Numéro du Cours: "+this.unCours.getNum()+" ; Payé : "+ this.payee);
        }

        public int insciPayee()
        {
            this.payee = 0;
            return 0;
        }

        public int Payee { get => payee; }
    }
}
