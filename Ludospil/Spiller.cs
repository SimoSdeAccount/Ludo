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
        public Spiller() {
            //Spilleren modtager sine brikker ved instanciering
            for (int i = 0; i< brikker.Length; i++)
			{
                brikker[i] = new Brik();
			}
        }
        //Valider om spiller er i mål
        public bool Finish()
        {
            for (int i = 0; i < brikker.Length; i++)
            {
                if(brikker[i].GetSetFelt < 52)
                {
                    finished = false;
                    return finished;
                }
            }
            finished = true;
            return finished;
        }
        //Modtag brikstatus for brik
        public bool GetBrikStatus(int index)
        {
            return brikker[index].GetSetPaaBraet;
        }
        //Set brætstatus for brik
        public void SetBrikStatus(int index, bool status)
        {
            brikker[index].GetSetPaaBraet = status;
        }
        //Ryk Brik
        public void RykBrikker(int index, int antalryk)
        {
            brikker[index].GetSetFelt += antalryk;
        }
        //Få felt på en brik
        public int BrikFelt(int index)
        {
            return brikker[index].GetSetFelt;
        }
        //Få spillerens brikker
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
    }
}
