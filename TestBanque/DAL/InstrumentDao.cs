using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TestBanque.Model;

namespace TestBanque.DAL
{
    class InstrumentDao
    {
        private ConnectionSql maConnectionSql;


        private MySqlCommand Ocom;

        public Instrument getOneInstrument(int id)
        {
            Instrument instru = new Instrument();
            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();

                Ocom = maConnectionSql.reqExec("Select id, nom from instrument where instrument.id=" + id + ";");

                MySqlDataReader reader = Ocom.ExecuteReader();



                while (reader.Read())
                {

                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);

                    instru = new Instrument(num, nom);

                }
                reader.Close();
                maConnectionSql.closeConnection();
            }
            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return instru;
        }

        public List<Instrument> getInstruments()
        {
            List<Instrument> lstInstrument = new List<Instrument>();

            try
            {
               

                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnectionSql.openConnection();

                Ocom = maConnectionSql.reqExec("Select id, nom from instrument;");

                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {

                    int num = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);

                    Instrument instru = new Instrument(num, nom);

                    lstInstrument.Add(instru);

                }

                reader.Close();
                maConnectionSql.closeConnection();
            }

            catch (Exception err)
            {
                throw (new Exception("" + err));
            }

            return lstInstrument;
        }
    }
}
