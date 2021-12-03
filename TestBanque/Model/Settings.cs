using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    [Serializable]
    internal class Settings
    {
        

        private static Client sacha = new Client(123, "AMARA", "Sacha", "ZBI");
        private static Client lea = new Client(123, "LSJDFL", "Lea", "SBI");
        private static List<Client> lstClt = new List<Client>();

        private static List<Compte> lstcpt = new List<Compte>();
        static private Compte c1 = new Compte(123, Sacha);
        static private Compte c2 = new Compte(1234, Lea);
        static private Compte c3 = new Compte(12345, Lea);


        internal static List<Compte> Lstcpt { get => lstcpt; set => lstcpt = value; }
        internal static List<Client> LstClt { get => lstClt; set => lstClt = value; }

        internal static Compte C1 { get => c1; set => c1 = value; }
        internal static Compte C2 { get => c2; set => c2 = value; }
        internal static Compte C3 { get => c3; set => c3 = value; }

        internal static Client Sacha { get => sacha; set => sacha = value; }
        internal static Client Lea { get => lea; set => lea = value; }

        public static void clientSort()
        {
            lstClt.Add(sacha);
            lstClt.Add(lea);
        }

        public static void compteSort()
        {
            lstcpt.Add(c1);
            lstcpt.Add(c2);
            lstcpt.Add(c3);
        }

    }
}
