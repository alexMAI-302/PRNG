using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    abstract class ContiniousNumberGenerator : Generator
    {
        public virtual double[] Generate()
        { return null; }
    }
}
