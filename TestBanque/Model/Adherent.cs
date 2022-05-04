using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TestBanque.Model
{
	[Serializable]
	public class Adherent : Person
	{
		private int niveau;
		private int idStudent;

		public Adherent(int num, string nom, string prenom, string ad, string telephone, string mail, int niveau = 1) : base(num,nom,prenom,ad,telephone,mail)
		{
			this.idStudent = num;
			this.niveau = niveau;
		}



	}
}
