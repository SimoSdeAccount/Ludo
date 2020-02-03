using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    class Brik
    {
        private int Felt = 0;
        private bool PaaBraet = false;
        public int GetSetFelt
        {
            get { return Felt; }
            set { Felt = value; }
        }
        public bool GetSetPaaBraet
        {
            get{ return PaaBraet; }
            set{ PaaBraet = value; }
        }
    }
}
