using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Zone
    {
        private string id;
        private List<Appareil> appareils;
        public string Id { get { return id; } }

        public Zone(string idZone)
        {
            id = idZone;
            appareils = new List<Appareil>();
        }
        public void Activer()
        {
            foreach (Appareil app in appareils)
            {
                app.Actif = true;
            }
        }
        public void Eteindre()
        {
            foreach (Appareil app in appareils)
            {
                app.Actif = false;
            }
        }
        public void CreerLumiere(string idLumiere)
        {
            if (GetAppareil(idLumiere) == null)
                appareils.Add(new Lumiere(idLumiere));
            else
                throw new C420Exception("Lumière déjà utilisée");           
        }
        public void CreerDetecteur(string idDetecteur)
        {
            if (GetAppareil(idDetecteur) == null)
                appareils.Add(new Detecteur(idDetecteur));
            else
                throw new C420Exception("Détecteur déjà utilisée");            
        }
        public void CreerControleur(string idControleur)
        {
            if (GetAppareil(idControleur) == null)
                appareils.Add(new Controleur(idControleur));
            else                
                throw new C420Exception("Controleur déjà utilisée");   
        }
        public void SupprimerAppareil(string idAppareil)
        {
            if (GetAppareil(idAppareil) != null)
                appareils.Remove(GetAppareil(idAppareil));          
            else
                throw new C420Exception("L'appareil n'existe pas");
        }
        public void ActiverAppareil(string idAppareil)
        {
            if (GetAppareil(idAppareil) != null)
                GetAppareil(idAppareil).Actif = true;
            else
                throw new C420Exception("L'appareil n'existe pas");
        }
        public void EteindreAppareil(string idAppareil)
        {
            if (GetAppareil(idAppareil) != null)
                GetAppareil(idAppareil).Actif = false;
            else
                throw new C420Exception("L'appareil n'existe pas");
        }
        public void ParametrerAppareil(string idAppareil, int valeur)
        {
            if (GetAppareil(idAppareil) != null)
                GetAppareil(idAppareil).Valeur = valeur;
            else
                throw new C420Exception("L'appareil n'existe pas");
        }
        public override string ToString()
        {         
            return base.ToString() + " " + appareils.ToString();
        }
        private Appareil GetAppareil(string idAppareil)
        {
            foreach(Appareil app in appareils)
            {
                if (idAppareil == app.Id)
                {
                    return app;
                }
                else
                    throw new C420Exception("L'appareil n'existe pas");
            }
            return null;
        }
    }
}
