using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Person
    {
        protected int idP;
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string tel;
        protected string mail;

        Person(int idP, string nom, string prenom, string adresse, string tel, string mail)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.tel = tel;
            this.mail = mail;
            this.idP = idP;
        }
    }
}
