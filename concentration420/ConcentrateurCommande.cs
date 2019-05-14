using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    sealed public partial class Concentrateur
    {
        public string ExecuterCommande(string ligneCommande)
        {
            string[] parametres = ligneCommande.Split(' ');
            switch (parametres[0])
            {
                case "CZ":
                    if (parametres.Length == 2)                    
                        CreerZone(parametres[1]);                    
                    break;
                case "SZ":
                    if (parametres.Length == 2)
                        SupprimerZone(parametres[1]);                    
                    break;
                case "AZ":
                    if (parametres.Length == 2)
                        ActiverZone(parametres[1]);                   
                    break;
                case "EZ":
                    if (parametres.Length == 2)
                        EteindreZone(parametres[1]);                   
                    break;
                case "CL":
                    if (parametres.Length == 3)
                        CreerLumiere(parametres[1], parametres[2]);
                    break;
                case "CD":
                    if (parametres.Length == 3)
                        CreerDetecteur(parametres[1], parametres[2]);                   
                    break;
                case "CC":
                    if (parametres.Length == 3)
                        CreerControleur(parametres[1], parametres[2]);                  
                    break;
                case "SA":
                    if (parametres.Length == 3)
                        SupprimerAppareil(parametres[1], parametres[2]);
                    break;
                case "AA":
                    if (parametres.Length == 3)
                        ActiverAppareil(parametres[1], parametres[2]);                    
                    break;
                case "PA":
                    if (parametres.Length == 3)
                        ParametrerAppareil(parametres[1], parametres[2], parametres[3]);
                    break;
                case "E":
                    if (parametres.Length == 3)
                        ParametrerAppareil(parametres[1], parametres[2], parametres[3]);
                    break;
                case "H":
                    if (parametres.Length == 1)
                        return GetAide();
                    break;
                case "Q":
                    if (parametres.Length == 1)
                    {
                    }                        
                    break;
                default:
                    throw new C420Exception("mauvause commande");                    
            }
            return GetEtat();
        }
        private void ValiderParametres(string[] parametres, int nbParametres)
        {
            if (parametres.Length != nbParametres)
            {
                throw new C420Exception("Le tableau n'a pas le même nombre de paramètres");
            }
        }
        private string GetAide()
        {
            return GetAideGeneral() + GetAideZone() + GetAideAppareil();
        }
        private string GetAideGeneral()
        {
            return "COMMANDES GENERALES\n"
                + " E Consulter l'etat du concentrateur\n"
                + " H Recevoir de l'aide sur les commandes\n"
                + " Q Quitter\n";
        }
        private string GetAideZone()
        {
            return "COMMANDES DE ZONES\n"
                + " CZ {ID_ZONE} Creer une ZONE\n"
                + " > CZ MA_ZONE Creer la zone MA_ZONE\n"
                + " SZ {ID_ZONE} Supprimer une zone\n"
                + " > SZ MA_ZONE Supprimer la zone MA_ZONE\n"
                + " AZ {ID_ZONE} Activer tous les appareils d'une ZONE\n"
                + " > AZ MA_ZONE Activer tous les appareils de la zone MA_ZONE\n"
                + " EZ {ID_ZONE} Eteindre tous les appareils d'une ZONE \n"
                + " > AZ MA_ZONE Eteindre tous les appareils de la zone MA_ZONE\n";
        }
        private string GetAideAppareil()
        {
            return "COMMANDES D'APPAREIL\n"
                + " C{L|D|C} {ID_ZONE} {ID_APPAREIL}) Creer un appareil dans une zone\n"
                + " > CL MA_ZONE L1 creer une LUMIERE avec l'identifiant L1 dans MA_ZONE\n"
                + " > CD MA_ZONE D1 creer un DETECTEUR avec l'identifiant D1 dans MA_ZONE\n"
                + " > CC MA_ZONE C1 creer un CONTROLEUR avec l'identifiant C1 dans MA_ZONE\n"
                + " SA {ID_ZONE} {ID_APPAREIL} Supprimer un appareil dans une zone\n"
                + " > SL MA_ZONE L1 Supprimer l'appareil L1 dans MA_ZONE\n"
                + " AA {ID_ZONE} {ID_APPAREIL} Activer un appareil d'une ZONE \n"
                + " > AA MA_ZONE L1 Activer l'appareil L1 de la zone MA_ZONE\n"
                + " EA {ID_ZONE} {ID_APPAREIL} Eteindre un appareil d'une ZONE\n"
                + " > EA MA_ZONE L1 Eteindre l'appareil L1 de la zone MA_ZONE\n"
                + " PA {ID_ZONE} {ID_APPAREIL} {MIN-MAX} Parametrer un appareil d'une ZONE avec une valeur entre MIN-MAX (inclusivement)\n"
                + " > PA MA_ZONE L1 40 Parametrer l'appareil L1 de la zone MA_ZONE avec une valeur de 40\n";
        }
    }
}
