using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Appareil
    {
        private string id;
        private bool actif;
        private int valeurMin;
        private int valeur;
        private int valeurMax;
        public string Id { get { return id; } }
        public bool Actif { get; set; }
        public int Valeur { get; set; }

        public int GetValeurMin()
        {
            return 0;
        }
        public int GetValeurMax()
        {
            return 0;
        }
        protected Appareil(string idAppareil, int valeurMin, int valeurMax)
        {
            id = idAppareil;
            this.valeurMin = valeurMin;
            this.valeurMax = valeurMax;
        }
    }
}
