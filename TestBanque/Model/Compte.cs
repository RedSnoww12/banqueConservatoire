using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TestBanque.Model
{
	[Serializable]
	public class Compte
	{
		private int num;
		private Client proprio;
		private double solde;
		private double decouvert;


		public Compte()
		{

		}

		public Compte(int n, Client proprio)
		{
			num = n;
			solde = 0;
			this.proprio = proprio;
		}


		public int Numero
		{
			get
			{ return num; }
		}

		public double getSolde()
		{
			return this.solde;
		}


		public string Description
		{
			get
			{ return num + " " + proprio + " " + solde + " €"; }
		}


		public double Decouvert { get => decouvert; set => decouvert = value; }
        public Client Proprio { get => proprio; }

        public void crediter(double mont)
		{
			if(mont > 0)
            {
				this.solde = this.solde + mont;
			}
            else
            {
				throw (new Exception("Erreur montant négatif ou nul"));
            }
			
		}

		public void debiter(double mont)
		{
			if(mont > 0)
            {

				if (solde - mont < -decouvert)
				{
					throw (new Exception("Erreur découvert trop faible"));

				}
				else
				{
					this.solde = this.solde - mont;

				}
			}
            else
            {
				
				throw (new Exception("Montant négatif ou nul"));

				
			}
			
		}
	}
}
