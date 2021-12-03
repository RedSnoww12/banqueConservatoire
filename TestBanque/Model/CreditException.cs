using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    public class CreditException : Exception
    {
        public CreditException(string m) : base(m)
        {

        }
    }
}
