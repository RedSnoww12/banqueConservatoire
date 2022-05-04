using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Inscritption
    {
        private Adherent unAdherent;
        private Cours unCours;

        bool payee = false;

        public Inscritption()
        {

        }

        public Inscritption(Adherent unAdherent, Cours unCours, bool payee = false)
        {
            this.unAdherent = unAdherent;
            this.unCours = unCours;
            this.Payee = payee;
        }

        public int insciPayee()
        {
            Payee = true;
            return 0;
        }

        public bool Payee { get => payee; set => payee = value; }
    }
}
