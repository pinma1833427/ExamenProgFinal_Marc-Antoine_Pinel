using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    sealed public partial class Concentrateur
    {
        private string id;
        private List<Zone> zones;
        public string Id { get { return id; } }

        public Concentrateur(string id)
        {
            this.id = id;
            zones = new List<Zone>();
        }
        internal void CreerZone(string idZone)
        {
            if (GetZone(idZone) == null)
                zones.Add(new Zone(idZone));
            else
                throw new C420Exception("La zone existe déjà");
        }
        internal void SupprimerZone(string idZone)
        {
            if (GetZone(idZone) != null)
                zones.Remove(GetZone(idZone));
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void ActiverZone(string idZone)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).Activer();
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void EteindreZone(string idZone)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).Eteindre();
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void CreerLumiere(string idZone, string idLumiere)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).CreerLumiere(idLumiere);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void CreerDetecteur(string idZone, string idDetecteur)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).CreerDetecteur(idDetecteur);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void CreerControleur(string idZone, string idControleur)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).CreerControleur(idControleur);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void SupprimerAppareil(string idZone, string idAppareil)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).SupprimerAppareil(idAppareil);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void ActiverAppareil(string idZone, string idAppareil)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).ActiverAppareil(idAppareil);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void EteindreAppareil(string idZone, string idAppareil)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).EteindreAppareil(idAppareil);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void ParametrerAppareil(string idZone, string idAppareil, string valeur)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).ParametrerAppareil(idAppareil, Convert.ToInt32(valeur));
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal void ParametrerAppareil(string idZone, string idAppareil, int valeur)
        {
            if (GetZone(idZone) != null)
                GetZone(idZone).ParametrerAppareil(idAppareil, valeur);
            else
                throw new C420Exception("La zone n'existe pas");
        }
        internal string GetEtat()
        {        
            return zones.ToString();
        }
        private Zone GetZone(string idZone)
        {
            foreach (Zone z in zones)
            {
                if (idZone == z.Id)
                {
                    return z;
                }
                else
                    throw new C420Exception("La zone n'existe pas");
            }
            return null;
        }
    }
}

