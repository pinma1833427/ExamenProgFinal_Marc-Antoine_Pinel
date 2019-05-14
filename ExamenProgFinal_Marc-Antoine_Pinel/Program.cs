using System;
using System.IO;
using Concentrateur420;

namespace examen
{
    class Program
    {
        private static void CommunicationLogiciel()
        {
            Logiciel logiciel = new Logiciel();

            int choix = -1;
            do
            {
                Console.WriteLine(logiciel.GetEtat());
                choix = GetChoixMenuLogiciel();
                switch (choix)
                {
                    case 1:
                        logiciel.AllumerEteindreLumieres();
                        break;
                    case 2:
                        logiciel.AjouterLumiere();
                        break;
                    case 3:
                        logiciel.SupprimerLumiere();
                        break;
                    case 4:
                        logiciel.AugmenterLuminosite();
                        break;
                    case 5:
                        logiciel.DiminuerLuminosite();
                        break;
                    case 6:
                        logiciel.AjouterThermosthat();
                        break;
                    case 7:
                        logiciel.SupprimerThermosthat();
                        break;
                    case 8:
                        logiciel.AugmenterTemperature();
                        break;
                    case 9:
                        logiciel.DiminuerTemperature();
                        break;
                }
            }
            while (choix != 0);
        }

        private static void CommunicationConsole()
        {

            Concentrateur concentrateur = new Concentrateur("DEPARTEMENT 420");

            string commande = "";
            do
            {
                commande = GetCommande();
                Console.WriteLine(concentrateur.ExecuterCommande(commande));
            }
            while (commande != "Q");
        }

        #region NE PAS MODIFIER CETTE SECTION        
        static void Main(string[] args)
        {
            // Redirection de la sortie d'erreur
            FileInfo exceptionsFile = new FileInfo(@"errors.txt");
            TextWriter exceptionWriter = new StreamWriter(exceptionsFile.FullName, true);   // true : pour ne pas effacer le fichier
            Console.SetError(exceptionWriter);

            // Choix du mode
            switch (GetMode())
            {
                case "C":
                    CommunicationConsole();
                    break;
                case "L":
                    CommunicationLogiciel();
                    break;
                case "1":
                    VerificationsConsole();     // POUR LA CORRECTION ET VOS TESTS
                    break;
                case "2":
                    VerificationsLogiciel();     // POUR LA CORRECTION ET VOS TESTS
                    break;
            }

            // Pour fermer le fichier
            using (TextWriter errorWriter = Console.Error)
            {
                errorWriter.Close();
                Console.SetError(new StreamWriter(Console.OpenStandardError()));
            }
        }

        private static string GetCommande()
        {
            string commande = "";

            Console.WriteLine("Entrer une commande, (h) pour de l'aide");

            do
            {
                Console.Write(" > ");
                commande = Console.ReadLine().Trim().ToUpper();
            }
            while (commande.Length == 0);
            Console.WriteLine();

            return commande;
        }
        private static int GetChoixMenuLogiciel()
        {
            int choix = -1;

            Console.WriteLine("MENU principal");
            Console.WriteLine("(1) Allumer/Eteindre les lumieres");
            Console.WriteLine("(2) Ajouter une lumiere");
            Console.WriteLine("(3) Supprimer une lumiere");
            Console.WriteLine("(4) Augmenter la luminosite");
            Console.WriteLine("(5) Diminuer la luminosite");
            Console.WriteLine("(6) Ajouter un thermosthat");
            Console.WriteLine("(7) Supprimer un thermosthat");
            Console.WriteLine("(8) Augmenter la temperature");
            Console.WriteLine("(9) Diminuer la temperature");
            Console.WriteLine("(0) Quitter");

            do
            {
                try
                {
                    Console.Write(" > ");
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Entree incorrecte!");
                }
            }
            while (choix == -1);
            Console.WriteLine();
            return choix;
        }
        private static string GetMode()
        {
            string mode = "";

            Console.WriteLine("Choix du mode de communication");
            Console.WriteLine("(C) Console");
            Console.WriteLine("(L) Logiciel");
            Console.WriteLine("(1) Verifications Console");
            Console.WriteLine("(2) Verifications Logiciel");

            do
            {
                Console.Write(" > ");
                mode = Console.ReadLine().Trim().ToUpper();
            }
            while (mode != "C" && mode != "L" && mode != "1" && mode != "2");

            Console.WriteLine();

            return mode;
        }

        private static void VerificationsLogiciel()
        {
            
                Console.WriteLine("\nVERIFICATIONS DU LOGICIEL");
                Console.WriteLine("-------------------------");

                Console.WriteLine("A - Creation LOGICIEL");
                Logiciel logiciel = new Logiciel();
                Console.WriteLine(logiciel.GetEtat());
                Console.ReadKey();

                Console.WriteLine("B - Interrupteurs");
                Console.WriteLine("B.1 - Eteindre lumieres");
                logiciel.AllumerEteindreLumieres();
                Console.WriteLine(logiciel.GetEtat());
                Console.WriteLine("B.1 - Allumer lumieres");
                logiciel.AllumerEteindreLumieres();
                Console.WriteLine(logiciel.GetEtat());
                Console.ReadKey();

                Console.WriteLine("C - Lumieres");

                Console.WriteLine("C.1 - Ajouter trop de lumieres");
                try
                {
                    for (int x = 0; x < 10; x++)
                        logiciel.AjouterLumiere();
                }
                catch (C420Exception c420e)
                {
                    Console.WriteLine(c420e.Message);
                }
                Console.WriteLine(logiciel.GetEtat());

                Console.WriteLine("C.2 - Supprimer trop de lumieres");
                try
                {
                    for (int x = 0; x < 10; x++)
                        logiciel.SupprimerLumiere();
                }
                catch (C420Exception c420e)
                {
                    Console.WriteLine(c420e.Message);
                }
                Console.WriteLine(logiciel.GetEtat());

                logiciel.AjouterLumiere();
                logiciel.AjouterLumiere();

                Console.ReadKey();

                Console.WriteLine("D - Thermosthats");

                Console.WriteLine("D.1 - Ajouter trop de thermosthats");
                try
                {
                    for (int x = 0; x < 4; x++)
                        logiciel.AjouterThermosthat();
                }
                catch (C420Exception c420e)
                {
                    Console.WriteLine(c420e.Message);
                }
                Console.WriteLine(logiciel.GetEtat());

                Console.WriteLine("D.2 - Supprimer trop de thermosthats");
                try
                {
                    for (int x = 0; x < 4; x++)
                        logiciel.SupprimerThermosthat();
                }
                catch (C420Exception c420e)
                {
                    Console.WriteLine(c420e.Message);
                }
                Console.WriteLine(logiciel.GetEtat());

                logiciel.AjouterThermosthat();
                logiciel.AjouterThermosthat();

                Console.ReadKey();


                Console.WriteLine("E - Parametres");

                Console.WriteLine("E.1 - Augmenter la luminosite 100X");
                for (int x = 0; x < 100; x++)
                    logiciel.AugmenterLuminosite();
                Console.WriteLine(logiciel.GetEtat());

                Console.WriteLine("E.2 - Diminuer la luminosite 100X");
                for (int x = 0; x < 100; x++)
                    logiciel.DiminuerLuminosite();
                Console.WriteLine(logiciel.GetEtat());

                Console.ReadKey();

                Console.WriteLine("E.3 - Augmenter la temperature 100X");
                for (int x = 0; x < 100; x++)
                    logiciel.AugmenterTemperature();
                Console.WriteLine(logiciel.GetEtat());

                Console.WriteLine("E.4 - Diminuer la temperature 100X");
                for (int x = 0; x < 100; x++)
                    logiciel.DiminuerTemperature();
                Console.WriteLine(logiciel.GetEtat());


                Console.WriteLine("-------------------------");
                Console.WriteLine("FIN DE LA VERIFICATION");
                Console.ReadKey();           
        }

        private static void VerificationsConsole()
        {
            /*
                string[] commandes = {
                    "C",                    // Commande invalide (Exception)
                    "",                     // Commande invalide (Exception)
                    "CZ",                   // Parametre manquant (Exception)
                    "CL Z1",                // Parametre manquant (Exception)
                    "CL Z1 L1",             // Zone inexistante (Exception)
                    "CZ Z1",                // Creation d'une zone Z1
                    "CL Z1",                // Parametre manquant (Exception)
                    "CZ Z1",                // Creation d'une zone Z1 (Exception)
                    "CZ Z2",                // Creation d'une zone Z2
                    "SZ Z2",                // Suppression d'une zone Z2
                    "SZ Z2",                // Suppression d'une zone Z2 (Exception)
                    "AZ Z2",                // Operation sur une zone supprimee Z2 (Exception)
                    "AZ Z1",                // Activer une zone sans appareil
                };


                int nb = 1;

                Console.WriteLine("\nVERIFICATIONS DE LA CONSOLE");
                Console.WriteLine("---------------------------");

                Console.WriteLine("A - Creation CONSOLE");
                Concentrateur concentrateur = new Concentrateur("DEPARTEMENT 420");

                foreach (string commande in commandes)
                {
                    try
                    {
                        Console.WriteLine("A." + nb++ + " >>>  " + commande);
                        Console.WriteLine(concentrateur.ExecuterCommande(commande));
                    }
                    catch (C420Exception c420e)
                    {
                        Console.WriteLine(c420e.Message);
                    }
                    Console.ReadKey();
                }

                Console.WriteLine("-------------------------");
                Console.WriteLine("FIN DE LA VERIFICATION");
        */
        }
        #endregion
    }
}
