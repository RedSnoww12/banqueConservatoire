using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque
{
    internal class Settings
    {
        public static List<Compte> lstcpt = new List<Compte>();
        public static Client Sacha = new Client(123, "AMARA", "Sacha", "ZBI");
        public static Client Lea = new Client(123, "LSJDFL", "Lea", "SBI");

        public static Compte c1 = new Compte(123, Sacha);
        public static Compte c2 = new Compte(1234, Lea);
        public static Compte c3 = new Compte(12345, Lea);

    }
}
