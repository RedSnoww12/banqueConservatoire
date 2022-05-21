using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Professeur : Person
    {
        private double salaire;
        private int idProf;

        public Professeur() { }
        public Professeur(int num, string nom, string prenom, string ad, string telephone, string mail, double salaire = 0) : base(num, nom, prenom, ad, telephone, mail)
        {
            this.idProf = num;
            this.salaire = salaire;
        }

    }
}
