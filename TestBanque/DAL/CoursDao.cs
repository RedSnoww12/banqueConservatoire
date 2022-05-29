using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TestBanque.Model;

namespace TestBanque.DAL
{
    class CoursDao
    {
        private ProfesseurDao pdao = new ProfesseurDao();
        private InstrumentDao idao = new InstrumentDao();

        private ConnectionSql maConnectionSql;


        private MySqlCommand Ocom;

        public List<Cours> getCours()
        {
            List<Cours> lstCours = new List<Cours>();
            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();



                Ocom = maConnectionSql.reqExec("Select cours.id , person.id, instrument.id, jourDate, nbPlace from cours inner join person on cours.idProf = person.id inner join instrument on cours.idInstrument = instrument.id;");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int numCours = (int)reader.GetValue(0);
                    int numPerson = (int)reader.GetValue(1);
                    int numInstrument = (int)reader.GetValue(2);
                    string jourDate = (string)reader.GetValue(3);
                    int nbPlace = (int)reader.GetValue(4);

                    Professeur prof = pdao.getOneProfesseur(numPerson);

                    Instrument intru = idao.getOneInstrument(numInstrument);

                    Cours cours = new Cours(numCours, prof, intru, jourDate, nbPlace);

                    lstCours.Add(cours);
                }

                reader.Close();
                reader.Dispose();
                maConnectionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstCours;
        }

        public Cours getOneCours(int id)
        {
            Cours cours = new Cours();
            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();



                Ocom = maConnectionSql.reqExec("Select cours.id , person.id, instrument.id, jourDate, nbPlace from cours inner join person on cours.idProf = person.id inner join instrument on cours.idInstrument = instrument.id where cours.id=" + id + ";");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int numCours = (int)reader.GetValue(0);
                    int numPerson = (int)reader.GetValue(1);
                    int numInstrument = (int)reader.GetValue(2);
                    string jourDate = (string)reader.GetValue(3);
                    int nbPlace = (int)reader.GetValue(4);

                    Professeur prof = pdao.getOneProfesseur(numPerson);

                    Instrument intru = idao.getOneInstrument(numInstrument);

                    cours = new Cours(numCours, prof, intru, jourDate, nbPlace);

                }

                reader.Close();
                reader.Dispose();
                maConnectionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return cours;
        }
    }

}
