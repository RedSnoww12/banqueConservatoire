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
        private List<Inscription> lstInscriptionFromStudent = new List<Inscription>();
        public Form1()
        {
            InitializeComponent();


        }

        private void ComboBox_Load(object sender, List<Adherent> lstAdherent)
        {
            var combo = sender as ComboBox;

            foreach (var adherent in lstAdherent)
            {
                combo.Items.Add(adherent);
            }
            //combo.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstAdherent = monManager.listAdherent();

            this.ComboBox_Load(comboBox1, lstAdherent);
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
            var selectAdherent = comboBox1.SelectedItem as Adherent;
            Debug.WriteLine(selectAdherent);
            lstInscriptionFromStudent = monManager.getInscriptionFromStudent(selectAdherent);
            lb.Items.Clear();
            foreach(var inscri in lstInscriptionFromStudent)
            {
                lb.Items.Add(inscri);
            }
        }
    }
}
