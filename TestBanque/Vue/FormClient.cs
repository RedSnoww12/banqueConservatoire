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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TestBanque.Vue
{ 

    [Serializable]
    public partial class FormClient : Form
    {
        private Adherent client;
        public FormClient(Adherent client)
        {
            this.client = client;
            InitializeComponent();
        }


        private void FormClient_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = client.Numero.ToString();
            textBox2.Text = client.Nom;
            textBox3.Text = client.Prenom;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                MessageBox.Show("Modification succed");
                Close();
            }
            
        }
    }
}
