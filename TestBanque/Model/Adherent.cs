using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TestBanque.Model
{
	[Serializable]
	public class Adherent
	{
		private string adresse;
		private List<Inscritption> Inscription;
		private int num;
		private string nom;
		private string prenom;

		public Adherent(int num, string nom, string prenom, string ad)
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
			set { nom = value; }
		}
		public string Prenom
		{
			get { return prenom; }
			set { prenom = value; }
		}
		public string Adresse
		{
			get { return adresse; }
			set { adresse = value; }
		}

		public override string ToString()
		{
			return (this.nom + " ; " + this.prenom + " ; " + this.adresse);
		}
	}
}
