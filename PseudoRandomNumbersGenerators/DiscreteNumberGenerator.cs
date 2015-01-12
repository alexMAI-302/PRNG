using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomNumbersGenerators
{
    abstract class DiscreteNumberGenerator : Generator
    {
        public virtual int[] Generate()
        { return null; }
    }
}
