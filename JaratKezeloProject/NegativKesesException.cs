using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    internal class NegativKesesException: Exception
    {
        public NegativKesesException(int keses) : base("A kékés nem lehet negatív!")
        {

        }
    }
}
