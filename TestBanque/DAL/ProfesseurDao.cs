using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBanque.Model;
using MySql.Data.MySqlClient;

namespace TestBanque.DAL
{
    class ProfesseurDao
    {
        private ConnectionSql maConnectionSql;


        private MySqlCommand Ocom;
        public List<Professeur> getProfesseurs()
        {
            List<Professeur> lstProfesseur = new List<Professeur>();

            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();



                Ocom = maConnectionSql.reqExec("Select professeur.id , person.nom, person.prenom, person.telephone, person.adresse, person.mail, professeur.salaire from professeur inner join person on professeur.id = person.id;");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string telephone = (string)reader.GetValue(3);
                    string adresse = (string)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    double salaire = (double)reader.GetValue(6);

                    Professeur a = new Professeur(num, nom, prenom, telephone, adresse, mail, salaire);

                    lstProfesseur.Add(a);
                }

                reader.Close();
                maConnectionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstProfesseur;
        }

        public Professeur getOneProfesseur(int id)
        {
            Professeur prof = new Professeur();
            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();

                Ocom = maConnectionSql.reqExec("Select professeur.id , person.nom, person.prenom, person.telephone, person.adresse, person.mail, professeur.salaire from professeur inner join person on professeur.id = person.id where professeur.id=" + id + ";");

                MySqlDataReader reader = Ocom.ExecuteReader();

                

                while (reader.Read())
                {

                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string telephone = (string)reader.GetValue(3);
                    string adresse = (string)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    double salaire = (double)reader.GetValue(6);

                    prof = new Professeur(num, nom, prenom, telephone, adresse, mail, salaire);

                }
                reader.Close();
                maConnectionSql.closeConnection();
            }
            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return prof;
        }
    }
}
