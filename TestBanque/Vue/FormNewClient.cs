using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBanque.Model;

namespace TestBanque.Vue
{
    public partial class FormNewClient : Form
    {
        private DbConnection mysql = new DbConnection();
        public FormNewClient()
        {
            InitializeComponent();
        }

        private void FormNewClient_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string adresse = textBox3.Text;

            if(nom != "" && prenom != "" && adresse != "")
            {
                try
                {
                    mysql.InsertClient(nom, prenom, adresse);
                    Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

        }
    }
}
