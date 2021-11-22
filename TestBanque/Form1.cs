﻿using System;
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
        private bool client = false;
        private bool decouvert = false;
        private string montantString = null;
        private double montant = 0;
        private int numList = 0;

        public Form1()
        {
            InitializeComponent();

            Settings.clientSort(Settings.Sacha, Settings.Lea);

            Settings.Lstcpt.Add(Settings.C1);
            Settings.Lstcpt.Add(Settings.C2);
            Settings.Lstcpt.Add(Settings.C3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test();
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

            Form1_Load(sender, e);
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
                Settings.Lstcpt[numList].debiter(montant);
            }

            if (crediter == true)
            {
                Settings.Lstcpt[numList].crediter(montant);
            }

            if (decouvert == true)
            {
                Settings.Lstcpt[numList].Decouvert = montant;
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
            }

            button1.Visible = true;

            Form1_Load(sender,e);
        }

        private void test()
        {
            Console.WriteLine("Test");
        }

    }
}
