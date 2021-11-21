using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBanque
{
    public partial class Form1 : Form
    {
        private bool crediter = false;
        private bool debiter = false;
        private string montantString = null;
        private double montant = 0;
        static List<Compte> lstcpt = new List<Compte>();
        static Client Sacha = new Client(123, "AMARA", "Sacha", "ZBI");
        static Compte c1 = new Compte(123, Sacha);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Client Sacha = new Client(123, "AMARA", "Sacha", "ZBI");
            Client Lea = new Client(123, "LSJDFL", "Lea", "SBI");
            Compte c1 = new Compte(123, Sacha);
            Compte c2 = new Compte(1234, Lea);
            Compte c3 = new Compte(12345, Lea);

            lstcpt.Add(c1);
            lstcpt.Add(c2);
            lstcpt.Add(c3);


            foreach (var compte in lstcpt)
            {
                lb.Items.Add(compte.Description);
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
            if (crediter == true)
            {
                button1.Text = "Créditer";
            }
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            montantString = textBox1.Text;
            montant = Convert.ToDouble(montantString);

            if (debiter == true)
            {
                lstcpt[0].debiter(montant);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void débiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debiter = true;
            crediter = false;
            if (debiter == true)
            {
                button1.Text = "Débiter";
            }
        }

    }
}
