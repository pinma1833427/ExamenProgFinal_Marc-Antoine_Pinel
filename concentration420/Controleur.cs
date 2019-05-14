using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Controleur : Appareil
    {
        public Controleur(string idControleur) : base(idControleur, 0, 100)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
