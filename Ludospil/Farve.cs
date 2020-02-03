using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    class Farve
    {
        private const string gul = "gul";
        private const string groen = "grøn";
        private const string roed = "rød";
        private const string blaa = "blå";
        private bool gulTaken = false;
        private bool groenTaken = false;
        private bool roedTaken = false;
        private bool blaaTaken = false;
        public string gulGet()
        {
            gulTaken = true;
            return gul;
        }
        public string groenGet()
        {
            groenTaken = true;
            return groen;
        }
        public string roedGet()
        {
            roedTaken = true;
            return roed;
        }
        public string blaaGet()
        {
            blaaTaken = true;
            return blaa;
        }
        public bool getGulTaken
        {
            get
            {
                return gulTaken;
            }
        }
        public bool getGroenTaken
        {
            get
            {
                return groenTaken;
            }
        }
        public bool getRoedTaken
        {
            get
            {
                return roedTaken;
            }
        }
        public bool getBlaaTaken
        {
            get
            {
                return blaaTaken;
            }
        }
    }
}
