using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBanque.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TestBanque.Vue
{
    public partial class Form1 : Form
    {
        private bool crediter = false;
        private bool debiter = false;
        private bool client = false;
        private bool decouvert = false;
        private string montantString = null;
        private double montant = 0.0;
        private int numList = 0;

        //private List<Compte> lstcompte = new List<Compte>();
        private DbConnection mySql = new DbConnection();

        public Form1()
        {
            InitializeComponent();

            //Settings.clientSort();

            //Settings.compteSort();
            //chargement();
        }

        private void sauvegarde()
        {
            FileStream stream = new FileStream("data", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, Settings.Lstcpt);
            serializer.Serialize(stream, Settings.LstClt);
            stream.Close();
        }

        private void chargement()
        {
            if (File.Exists("data"))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                FileStream stream = new FileStream("data", FileMode.Open);
                Settings.Lstcpt = (List<Compte>)deserializer.Deserialize(stream);
                stream.Close();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        { 

            lb.Items.Clear();
            Settings.LstClt.Clear();
            Settings.Lstcpt.Clear();
            
            //button1.Visible = false;

            mySql.SelectClient();
            mySql.SelectCompte();
            
            if(client == true)
            {
                foreach (var client in Settings.LstClt)
                {
                    lb.Items.Add(client.ToString());
                }
            }
            else
            {
                foreach (var compte in Settings.Lstcpt)
                {
                    lb.Items.Add(compte.Description);
                }
            }
            
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void créditerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debiter = false;
            crediter = true;
            client = false;
            decouvert = false;

            if (crediter == true)
            {
                button1.Text = "Créditer";
            }
            button1.Location = new Point(378, 317);
            button1.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;

            Form1_Load(sender, e);
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            numList = lb.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            montantString = textBox1.Text;

            if(montantString != "")
            {
                try
                {
                    montant = Convert.ToDouble(montantString);
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                
            }

            if (debiter == true && montant != 0.0)
            {
                try
                {
                    mySql.UpdateCompte(Settings.LstClt[numList].Numero, debiter, crediter, montant);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            if (crediter == true && montant != 0.0)
            {
                try
                {
                    mySql.UpdateCompte(Settings.LstClt[numList].Numero, debiter, crediter, montant);
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                
            }

            if (decouvert == true && montant != 0.0)
            {
                mySql.UpdateCompte(Settings.LstClt[numList].Numero, debiter, crediter, montant);
            }

            if(client == true)
            {
                Client c = Settings.LstClt[numList];
                //numList = lb.SelectedIndex;
                if (c != null)
                {
                    FormClient fc = new FormClient(c);
                    fc.ShowDialog();
                }
            }

            textBox1.Text = "";
            montant = 0.0;
            Form1_Load(sender,e);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void débiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            debiter = true;
            crediter = false;
            client = false;
            decouvert = false;

            if (debiter == true)
            {
                button1.Text = "Débiter";
            }
            button1.Location = new Point(378, 317);
            button1.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;

            Form1_Load(sender, e);
        }

        private void découvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debiter = false;
            crediter = false;
            client = false;
            decouvert = true;

            if (decouvert == true)
            {
                button1.Text = "Valider";
            }
            button1.Location = new Point(378, 317);
            button1.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;

            Form1_Load(sender, e);
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            debiter = false;
            crediter = false;
            client = true;
            decouvert = false;

            if (client == true)
            {
                button1.Text = "Valider";
                button1.Location = new Point(246, 316);
                textBox1.Visible = false;
                label1.Visible=false;
            }

            button1.Visible = true;

            Form1_Load(sender,e);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //sauvegarde();
        }
    }
}
