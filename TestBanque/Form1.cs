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
        private int numList = 0;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lb.Items.Clear();
            button1.Visible = false;
            Settings.lstcpt.Add(Settings.c1);
            Settings.lstcpt.Add(Settings.c2);
            Settings.lstcpt.Add(Settings.c3);

            foreach (var compte in Settings.lstcpt)
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
            button1.Visible = true;
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            numList = lb.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            montantString = textBox1.Text;
            montant = Convert.ToDouble(montantString);

            if (debiter == true)
            {
                Settings.lstcpt[numList].debiter(montant);
            }

            if (crediter == true)
            {
                Settings.lstcpt[numList].crediter(montant);
            }
            Console.WriteLine(Settings.lstcpt[numList].Description);
            Form1_Load(sender,e);

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
            button1.Visible = true;
        }

    }
}
