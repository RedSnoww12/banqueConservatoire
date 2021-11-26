using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanque.Model
{
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

		public void crediter(double mont)
		{
			this.solde = this.solde + mont;
		}

		public bool debiter(double mont)
		{
			if (solde - mont < -decouvert)
			{
				return false;
			}
			else
			{
				this.solde = this.solde - mont;
				return true;
			}
		}
	}
}
