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
		private int id;
		private Client proprio;
		private int id_client;
		private double solde;
		private double decouvert;


		public Compte()
		{

		}

		public Compte(int n, Client proprio)
		{
			id = n;
			solde = 0;
			this.proprio = proprio;
		}

		public Compte(int n, Client proprio, double solde, double decouvert)
		{
			id = n;
			this.solde = solde;
			this.proprio = proprio;
			this.decouvert = decouvert;
		}

		public Compte(int n, int id_client, double solde, double decouvert)
		{
			id = n;
			this.solde = solde;
			this.id_client = id_client;
			this.decouvert = decouvert;
		}


		public int Id
		{
			get
			{ return id; }
		}

		public double getSolde()
		{
			return this.solde;
		}


		public string Description
		{
			get
			{ return id + " " + proprio + " " + solde + " €"; }
		}


		public double Decouvert { get => decouvert; set => decouvert = value; }
        public Client Proprio { get => proprio; }

        public bool crediter(double mont)
		{
			if(mont > 0)
            {
				this.solde = this.solde + mont;
				return true;
			}
            else
            {
				throw (new Exception("Erreur montant négatif ou nul"));
            }
			
		}

		public bool debiter(double mont)
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

					return true;
				}
			}
            else
            {
				
				throw (new Exception("Montant négatif ou nul"));

				
			}
			
		}
	}
}
