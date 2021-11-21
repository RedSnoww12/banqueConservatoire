using System;
using System.Collections.Generic;
using System.Text;

namespace TestBanque
{
	class Client
	{
		private string adresse;
		private List<Compte> comptes = new List<Compte>();
		private int num;
		private string nom;
		private string prenom;
		private string ad;

		public Client(int num, string nom, string prenom, string ad)
		{
			this.num = num;
			this.nom = nom;
			this.prenom = prenom;
			this.adresse = ad;
		}

		public int Numero
		{
			get { return num; }
		}
		public string Nom
		{
			get { return nom; }
		}
		public string Prenom
		{
			get { return prenom; }
		}
		public string Adresse
		{
			get { return adresse; }
			set { adresse = value; }
		}

		public override string ToString()
		{
			return (this.nom + " " + this.prenom);
		}
	}
}
