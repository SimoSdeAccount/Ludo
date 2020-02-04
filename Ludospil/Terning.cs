using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    class Terning
    {
        public int TerningKast()
        {
            Random RanGen = new Random();
            return RanGen.Next(5, 7);
        }
    }
}
