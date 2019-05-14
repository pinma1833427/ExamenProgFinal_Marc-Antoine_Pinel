using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Lumiere : Appareil
    {
        public Lumiere(string idLumiere) : base(idLumiere,  0,  255)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
