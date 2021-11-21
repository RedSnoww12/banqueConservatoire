using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanque
{
	class Compte
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

		public void crediter(double mont)
		{
			solde = solde + mont;
		}

		public bool debiter(double mont)
		{
			if (solde - mont < -decouvert)
			{
				return false;
			}
			else
			{
				solde = solde - mont;
				return true;
			}
		}
	}
}
