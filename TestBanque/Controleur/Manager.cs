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
        private ProfesseurDao pdao = new ProfesseurDao();
        private InstrumentDao idao = new InstrumentDao();
        private CoursDao cdao = new CoursDao();
        private InscriptionDao inscrdao = new InscriptionDao();

        public List<Adherent> listAdherent()
        {
            return (adao.getAdherents());
        }

        public List<Professeur> listProfesseurs()
        {
            return (pdao.getProfesseurs());
        }

        public Professeur OneProfesseur(int id)
        {
            return (pdao.getOneProfesseur(id));
        }

        public Adherent OneAdherent(int id)
        {
            return (adao.getOneAdherents(id));
        }

        public List<Instrument> getInstruments()
        {
            return (idao.getInstruments());
        }

        public Instrument getOneInstrument(int id)
        {
            return (idao.getOneInstrument(id));
        }

        public List<Cours> getCours()
        {
            return cdao.getCours();
        }
        public Cours getOneCours(int id)
        {
            return (cdao.getOneCours(id));
        }
        public List<Inscription> getInscriptions()
        {
            return (inscrdao.getInscriptions());
        }
        public List<Inscription> getInscriptionFromStudent(Adherent student)
        {
            return (inscrdao.getInscriptionFromStudent(student));
        }
        public void validateInscription(Inscription inscription)
        {
            inscrdao.validateInscription(inscription);
        }
        public void supp_Inscription(Inscription inscription)
        {
            inscrdao.supp_Inscription(inscription);
        }

    }
}
