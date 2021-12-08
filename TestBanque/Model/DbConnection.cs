using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TestBanque.Vue;
using MySql.Data.MySqlClient;

namespace TestBanque.Model
{
    internal class DbConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DbConnection()
        {
            InitializeDb();
        }

        //Initialize values
        private void InitializeDb()
        {
            server = "localhost";
            database = "Banque";
            uid = "efrei";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO Client (nom, prenom, adresse) VALUES('John Smith', '33', '')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void UpdateCompte(int id_compte, bool debiter, bool crediter, double montant=0.0)
        {
            string query = "";

            if (debiter == true)
            {
                /*query = "SELECT solde from Compte where id='" + id_compte + "'";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    var cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        double solde = dataReader.GetDouble(0);

                    }
                }*/

                if (Settings.Lstcpt[id_compte-1].debiter(montant))
                {
                    double solde_compte = 0.0;
                    solde_compte = Settings.Lstcpt[id_compte-1].getSolde();
                    double montant_debit = 0.0;
                    montant_debit = solde_compte - montant;

                    //query = "UPDATE Compte SET solde='(solde)-("+ montant +")' WHERE id='"+ id_compte +"'";
                    query = "UPDATE Compte SET solde='" + montant_debit + "' WHERE id='" + id_compte + "'";
                }
            }
            else if (crediter == true)
            {
                if(Settings.Lstcpt[id_compte-1].crediter(montant))
                {
                    double solde_compte = 0.0;
                    double montant_credit = 0.0;

                    solde_compte = Settings.Lstcpt[id_compte-1].getSolde();
                    montant_credit = solde_compte + montant;

                    query = "UPDATE Compte SET solde='" + montant_credit + "' WHERE id='" + id_compte + "'";
                }
            }
            else
            {
                query = "UPDATE Compte SET decouvert='"+ montant +"' WHERE id = '"+ id_compte +"'";
            }

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Update statement
        public void UpdateClient(int id_client, string ad)
        {
            string query = "UPDATE Client SET adresse='"+ ad +"' WHERE id='"+ id_client +"'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();

                //Assign the query using CommandText
                cmd.CommandText = query;

                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
                string query = "DELETE FROM tableinfo WHERE name='John Smith'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
        }

        //Select statement
        public List<string>[] SelectClient()
        {
            int i = 0, j = 0;
                string query = "SELECT * FROM Client";

            //Create a list to store the result
            List<string>[] list = new List<string>[100];

            //Open connection
            if (this.OpenConnection() == true)
                {
                    //Create Command
                    var cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) {
                        int id = dataReader.GetInt32(0);
                        string nom = dataReader.GetString(1);
                        string prenom = dataReader.GetString(2);
                        string ad = dataReader.GetString(3);
                        Client client1 = new Client(id, nom, prenom, ad);
                        Settings.LstClt.Add(client1);

                        //Console.WriteLine(" {0} : {1} : {2} : {3} ", dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                        i = i + 1;
                    }
                    

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    this.CloseConnection();
                    return list;
                }
        }
        public bool SelectCompte()
        {
            int i = 0, j = 0;
            string query = "SELECT Compte.id, Client.id, decouvert, solde, nom, prenom, adresse FROM Compte LEFT JOIN Client ON Compte.id_client = Client.id";
            
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                var cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    
                    int id = dataReader.GetInt32(0);
                    int id_client = dataReader.GetInt32(1);
                    double decouvert = dataReader.GetDouble(2);
                    double solde = dataReader.GetDouble(3);
                    string nom = dataReader.GetString(4);
                    string prenom = dataReader.GetString(5);
                    string adresse = dataReader.GetString(6);


                    Client client1 = new Client(id_client, nom, prenom, adresse);
                    Compte c1 = new Compte(id, client1, solde, decouvert);
                    Settings.Lstcpt.Add(c1);

                    //Console.WriteLine(" {0} : {1} : {2} : {3} ", dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                    i = i + 1;
                }


                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return true;
            }
            else
            {
                this.CloseConnection();
                return false;
            }
        }

        //Count statement
        public int Count()
        {
                string query = "SELECT Count(*) FROM tableinfo";
                int Count = -1;

                //Open Connection
                if (this.OpenConnection() == true)
                {
                    //Create Mysql Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //ExecuteScalar will return one value
                    Count = int.Parse(cmd.ExecuteScalar() + "");

                    //close Connection
                    this.CloseConnection();

                    return Count;
                }
                else
                {
                    return Count;
                }
            }

        //Backup
        /*public void Backup()
        {
                try
                {
                    DateTime Time = DateTime.Now;
                    int year = Time.Year;
                    int month = Time.Month;
                    int day = Time.Day;
                    int hour = Time.Hour;
                    int minute = Time.Minute;
                    int second = Time.Second;
                    int millisecond = Time.Millisecond;

                    //Save file to C:\ with the current date as a filename
                    string path;
                    path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
                "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                    StreamWriter file = new StreamWriter(path);


                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "mysqldump";
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;

                    Process process = Process.Start(psi);

                    string output;
                    output = process.StandardOutput.ReadToEnd();
                    file.WriteLine(output);
                    process.WaitForExit();
                    file.Close();
                    process.Close();
                }
                catch (IOException ex)
                {
                    Console.Write("Error , unable to backup!");
                }

            }*/

            //Restore
            /*public void Restore()
            {
                try
                {
                    //Read file from C:\
                    string path;
                    path = "C:\\MySqlBackup.sql";
                    StreamReader file = new StreamReader(path);
                    string input = file.ReadToEnd();
                    file.Close();

                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "mysql";
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardOutput = false;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;


                    Process process = Process.Start(psi);
                    process.StandardInput.WriteLine(input);
                    process.StandardInput.Close();
                    process.WaitForExit();
                    process.Close();
                }
                catch (IOException ex)
                {
                    Console.Write("Error , unable to Restore!");
                }
            }*/
    }
}

