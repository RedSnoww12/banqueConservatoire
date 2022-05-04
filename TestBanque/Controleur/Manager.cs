using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBanque.DAL;
using TestBanque.Model;

namespace TestBanque.Controleur
{
    class Manager
    {
        private AdherentDao adao = new AdherentDao();

        public List<Adherent> listAdherent()
        {
            return (adao.getAdherents());
        }
    }
}
