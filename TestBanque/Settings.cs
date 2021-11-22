using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque
{
    internal class Settings
    {
        private int test = 0;

        private static List<Compte> lstcpt = new List<Compte>();

        private static Client Sacha = new Client(123, "AMARA", "Sacha", "ZBI");
        private static Client Lea = new Client(123, "LSJDFL", "Lea", "SBI");

        static private Compte c1 = new Compte(123, Sacha);
        static private Compte c2 = new Compte(1234, Lea);
        static private Compte c3 = new Compte(12345, Lea);

        internal static List<Compte> Lstcpt { get => lstcpt; set => lstcpt = value; }
        internal static Compte C1 { get => c1; set => c1 = value; }
        internal static Compte C2 { get => c2; set => c2 = value; }
        internal static Compte C3 { get => c3; set => c3 = value; }
    }
}
