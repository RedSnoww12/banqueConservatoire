using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TestBanque.Model;

namespace TestBanque.DAL
{
    class AdherentDao
    {
        private ConnectionSql maConnectionSql;


        private MySqlCommand Ocom;

        
        public List<Adherent> getAdherents()
        {
            List<Adherent> lstAdherent = new List<Adherent>();

            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();



                Ocom = maConnectionSql.reqExec("Select students.id , person.nom, person.prenom, person.telephone, person.adresse, person.mail, students.niveau from students inner join person on students.id = person.id;");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int numStudent = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string telephone = (string)reader.GetValue(3);
                    string adresse = (string)reader.GetValue(4);
                    string mail = (string)reader.GetValue(5);
                    int niveau = (int)reader.GetValue(6);

                    Adherent a = new Adherent(numStudent, nom, prenom, telephone, adresse, mail, niveau);

                    lstAdherent.Add(a);
                }

                reader.Close();
                maConnectionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstAdherent;
        }
    }
}
