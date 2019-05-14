using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Detecteur : Appareil
    {
        public Detecteur(string idDetecteur) : base (idDetecteur, 0, 100)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
