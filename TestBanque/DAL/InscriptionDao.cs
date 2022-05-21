using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TestBanque.Model;

namespace TestBanque.DAL
{
    class InscriptionDao
    {
        private ConnectionSql maConnexionSql;
        private ConnectionSql maConnexionSql2;
        private ConnectionSql maConnexionSql3;

        private AdherentDao adao = new AdherentDao();
        private CoursDao cdao = new CoursDao();

        private MySqlCommand Ocom;

        public List<Inscription> getInscriptions()
        {
            List<Inscription> lstInsci = new List<Inscription>();

            try
            {
                maConnexionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnexionSql.openConnection();



                Ocom = maConnexionSql.reqExec("Select insription.idStudent, insription.Cours, paye from inscription inner join person on insription.idStudent = person.id inner join students on person.id = students.id;");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int numCours = (int)reader.GetValue(0);
                    int numStudent = (int)reader.GetValue(1);
                    int paye = (int)reader.GetValue(2);

                    Adherent student = adao.getOneAdherents(numStudent);

                    Cours cours = cdao.getOneCours(numCours);

                    Inscription inscri = new Inscription(student, cours, paye);

                    lstInsci.Add(inscri);

                }

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstInsci;

        }

        public List<Inscription> getInscriptionFromStudent(Adherent student)
        {
            List<Inscription> lstInsci = new List<Inscription>();

            try
            {
                maConnexionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnexionSql.openConnection();

                /*maConnexionSql2 = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
                maConnexionSql2.openConnection();

                maConnexionSql3 = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
                maConnexionSql3.openConnection();*/



                Ocom = maConnexionSql.reqExec("Select inscription.idStudent, inscription.idCours, paye from inscription inner join person on inscription.idStudent = person.id inner join students on person.id = students.id where inscription.idStudent=" + student.IdP +"; ");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int numCours = (int)reader.GetValue(0);
                    int numStudent = (int)reader.GetValue(1);
                    int paye = (int)reader.GetValue(2);

                    Adherent student1 = adao.getOneAdherents(numStudent);

                    Cours cours = cdao.getOneCours(numCours);

                    Inscription inscri = new Inscription(student1, cours, paye);

                    lstInsci.Add(inscri);

                }

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstInsci;
        }


    }
}
