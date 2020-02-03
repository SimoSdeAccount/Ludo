using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    class Spiller
    {
        private string navn;
        private string farve;
        private bool finished = false;
        private Brik[] brikker = new Brik[4];
        private bool HarEnPaaBraet = false;
        public Spiller() {
            for (int i = 0; i< brikker.Length; i++)
			{
                brikker[i] = new Brik();
			}
        }
        public bool ValidateFinish()
        {
            for (int i = 0; i < brikker.Length; i++)
            {
                if(brikker[i].GetSetPaaBraet == false)
                {
                    finished = false;
                    return finished;
                }
            }
            finished = true;
            return finished;
        }
        public Brik[] getBrikker
        {
            get { return brikker; }
        }
        //spiller navn
        public string GetSetNavn
        {
            get { return navn; }
            set { navn = value; }
        }
        //spiller farve
        public string GetSetFarve
        {
            get{ return farve; }
            set{ farve = value; }
        }
        //brik1 vaerdier
        public int Brik1Felt
        {
            get{ return brikker[0].GetSetFelt; }
            set{ brikker[0].GetSetFelt = value; }
        }
        public bool Brik1Braet
        {
            get{ return brikker[0].GetSetPaaBraet; }
            set{ brikker[0].GetSetPaaBraet = value; }
        }
        //brik2 vaerdier
        public int Brik2Felt
        {
            get { return brikker[1].GetSetFelt; }
            set { brikker[1].GetSetFelt = value; }
        }
        public bool Brik2Braet
        {
            get { return brikker[1].GetSetPaaBraet; }
            set { brikker[1].GetSetPaaBraet = value; }
        }
        //brik3 vaerdier
        public int Brik3Felt
        {
            get { return brikker[2].GetSetFelt; }
            set { brikker[2].GetSetFelt = value; }
        }
        public bool Brik3Braet
        {
            get { return brikker[2].GetSetPaaBraet; }
            set { brikker[2].GetSetPaaBraet = value; }
        }
        //brik4 vaerdier
        public int Brik4Felt
        {
            get { return brikker[3].GetSetFelt; }
            set { brikker[3].GetSetFelt = value; }
        }
        public bool Brik4Braet
        {
            get { return brikker[3].GetSetPaaBraet; }
            set { brikker[3].GetSetPaaBraet = value; }
        }
    }
}
