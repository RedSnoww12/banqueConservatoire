﻿using System;
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
using TestBanque.Controleur;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;


namespace TestBanque.Vue
{
    public partial class Form1 : Form
    {
        private Manager monManager = new Manager();
        private List<Adherent> lstAdherent = new List<Adherent>();
        public Form1()
        {
            InitializeComponent();


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lstAdherent = monManager.listAdherent();

            foreach(var adherent in lstAdherent)
            {
                Debug.WriteLine(adherent.ToString());
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
           
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void débiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
