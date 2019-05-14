using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    public class Logiciel
    {
        private Concentrateur concentrateur;
        private int luminosite;
        private int temperature;
        private int nbLumieres;
        private int nbThermosthat;
        private bool lumieresAllumees;
        private const string CUISINE = "cuisine";
        private const string PREF_LUM = "L_";
        private const string PREF_THERM = "T_";
        private const int LUMINOSITE_MIN = 50;
        private const int LUMINOSITE_MAX = 200;
        private const int TEMPERATURE_MIN = 17;
        private const int TEMPERATURE_MAX = 23;
        private const int NB_LUMIERES_MAX = 5;
        private const int NB_THERMOSTHAT_MAX = 2;

        public Logiciel()
        {
            concentrateur = new Concentrateur("");
            concentrateur.CreerZone(CUISINE);
            nbLumieres = 0;
            nbThermosthat = 0;
            luminosite = LUMINOSITE_MIN;
            temperature = TEMPERATURE_MIN;
            lumieresAllumees = true;
        }
        public void AjouterLumiere()
        {
            if (nbLumieres < 5)
            {
                concentrateur.CreerLumiere(CUISINE, PREF_LUM + nbLumieres);
                concentrateur.ParametrerAppareil(CUISINE, PREF_LUM + nbLumieres, luminosite);
                concentrateur.ActiverAppareil(CUISINE, PREF_LUM + nbLumieres);                
            }
            else
            {
                throw new C420Exception("Nombre de lumiere maximum déjà atteint");
            }
        }
        public void SupprimerLumiere()
        {
            if(nbLumieres < 0)
            {
                throw new C420Exception("Nombre minimum de lumieres déjà atteint");
            }
            else
            {
                concentrateur.SupprimerAppareil(CUISINE, PREF_LUM + nbLumieres);
            }
        }
        public void AugmenterLuminosite()
        {
            concentrateur.ParametrerAppareil(CUISINE, PREF_LUM + nbLumieres, luminosite += 25);
        }
        public void DiminuerLuminosite()
        {
            concentrateur.ParametrerAppareil(CUISINE, PREF_LUM + nbLumieres, luminosite -= 25);
        }
        public void AllumerEteindreLumieres()
        {
            if(lumieresAllumees == true)
            {
                for (int i = 0; i < nbLumieres; i++)
                {
                    concentrateur.EteindreAppareil(CUISINE, PREF_LUM + i);
                }
                lumieresAllumees = false;
            }
            else
            {
                for (int i = 0; i < nbLumieres; i++)
                {
                    concentrateur.ActiverAppareil(CUISINE, PREF_LUM + i);
                }
                lumieresAllumees = true;
            }
            
        }
        public void AjouterThermosthat()
        {
            concentrateur.CreerControleur(CUISINE, PREF_THERM + nbThermosthat);
        }
        public void SupprimerThermosthat()
        {
            concentrateur.SupprimerAppareil(CUISINE, PREF_THERM + nbThermosthat);
        }
        public void AugmenterTemperature()
        {
            concentrateur.ParametrerAppareil(CUISINE, PREF_THERM + nbThermosthat, temperature += 1);
        }
        public void DiminuerTemperature()
        {
            concentrateur.ParametrerAppareil(CUISINE, PREF_THERM + nbThermosthat, temperature -= 1);
        }
        public string GetEtat()
        {
            return null;
        }
    }
}
