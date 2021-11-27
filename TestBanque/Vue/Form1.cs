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
    public partial class Form1 : Form
    {
        private bool crediter = false;
        private bool debiter = false;
        private bool client = false;
        private bool decouvert = false;
        private string montantString = null;
        private double montant = 0.0;
        private int numList = 0;

        public Form1()
        {
            InitializeComponent();

            Settings.clientSort();

            Settings.compteSort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lb.Items.Clear();
            //button1.Visible = false;
            
            if (client == false)
            {
                foreach (var compte in Settings.Lstcpt)
                {
                    lb.Items.Add(compte.Description);
                }
            }
            else
            {
                foreach (var client in Settings.LstClt)
                {
                    lb.Items.Add(client);
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
                montant = Convert.ToDouble(montantString);
            }

            if (debiter == true && montant != 0.0)
            {
                Settings.Lstcpt[numList].debiter(montant);
            }

            if (crediter == true && montant != 0.0)
            {
                Settings.Lstcpt[numList].crediter(montant);
            }

            if (decouvert == true && montant != 0.0)
            {
                Settings.Lstcpt[numList].Decouvert = montant;
            }

            if(client == true)
            {
                Client c = (Client)lb.SelectedItem;
                //numList = lb.SelectedIndex;
                if (c != null)
                {
                    FormClient fc = new FormClient(c);
                    fc.ShowDialog();
                }
            }

            Console.WriteLine(Settings.Lstcpt[numList].Description);
            textBox1.Text = "";
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

    }
}
