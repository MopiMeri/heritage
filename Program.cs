using Animaux;
using System;
using System.Collections.Generic;
using System.Threading;

internal class Program
{
    // MAIN du programme Animaux
    static void Main(string[] args)
    {
        // Liste animal pour répertiorier les animaux
        List<Animal> animaux = new List<Animal>();

        // Menu pour permettre à l'utilisateur de choisir ce qu'il veut faire
        void displayMenu()
        {
            // Affichage des options pour choisir l'action à faire
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~    Le Zoooooooo    ~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1 - Créer un animal");
            Console.WriteLine("2 - Supprimer un animal");
            Console.WriteLine("3 - Simuler un temps");
            Console.WriteLine("4 - Afficher la liste du Zoo");
            Console.WriteLine("0 - Quitter l'application");
        }

        // Procédure permettant d'ajouter un animal au Zoo
        void add_ani()
        {
            // Affichage des options pour choisir le type d'animal à créer
            Console.WriteLine("Quel animal voulez-vous créer ?");
            Console.WriteLine("1 - Chien");
            Console.WriteLine("2 - Aigle");
            Console.WriteLine("3 - Chat");

            int choix_ani;
            // Boucle pour s'assurer que l'utilisateur entre une option valide (1, 2 ou 3)
            while (!int.TryParse(Console.ReadLine(), out choix_ani) || choix_ani < 1 || choix_ani > 3)
            {
                Console.WriteLine("Veuillez entrer une option valide (1, 2 ou 3).");
            }

            // Fonction locale pour définir l'âge de l'animal en fonction de son type
            int set_age(int type)
            {
                int age;
                int ageMax = 0;
                // Définition de l'âge maximal en fonction du type d'animal
                switch (type)
                {
                    case 1:
                        ageMax = 15;
                        break;
                    case 2:
                        ageMax = 10;
                        break;
                    case 3:
                        ageMax = 16;
                        break;
                }

                // Boucle pour s'assurer que l'utilisateur entre un âge valide (entre 0 et ageMax)
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out age) || age < 0 || age > ageMax)
                    {
                        Console.WriteLine("L'âge ne peut pas dépasser " + ageMax + ".\nVeuillez entrer un âge valide.");
                    }
                    else
                    {
                        return age;
                    }
                }
            }

            Animal nouvelAnimal = null;
            string nomAnimal;

            // Création d'une instance d'animal en fonction du choix de l'utilisateur
            switch (choix_ani)
            {
                case 1:
                    Console.WriteLine("Quel est son petit nom ?");
                    nomAnimal = Console.ReadLine();
                    nouvelAnimal = new Chien(nomAnimal);
                    break;
                case 2:
                    Console.WriteLine("Quel est son petit nom ?");
                    nomAnimal = Console.ReadLine();
                    nouvelAnimal = new Aigle(nomAnimal);
                    break;
                case 3:
                    Console.WriteLine("Quel est son petit nom ?");
                    nomAnimal = Console.ReadLine();
                    nouvelAnimal = new Chat(nomAnimal);
                    break;
            }

            // Si un nouvel animal a été créé
            if (nouvelAnimal != null)
            {
                // Saisie de l'âge en fonction de l'âge maximale de l'animal sélectionné
                Console.WriteLine("Quel âge a-t-il ? <" + ((nouvelAnimal.Age_max)+1) + " puisque les " + nouvelAnimal.GetType().Name + "s ne vivent pas au delà.");
                nouvelAnimal.Age = set_age(choix_ani);

                // Ajout de l'animal à la liste des animaux du zoo
                animaux.Add(nouvelAnimal);
                Console.WriteLine("Animal créé !");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        // Procédure de suppression d'un animal
        void supp_ani()
        {
            // Vérification si des animaux existent avant de procéder à la suppression
            if (animaux.Count == 0)
            {
                Console.WriteLine("Aucun animal dans le Zoo. Veuillez en créer un avant de vouloir en supprimer.");
                Thread.Sleep(2000);
                Console.Clear();
                return; // Sortie de la fonction si aucun animal n'est présent
            }

            // Demande quel animal à supprimer
            Console.WriteLine("Quel animal voulez-vous supprimer ?");
            for (int i = 0; i < animaux.Count; i++)
            {
                Console.WriteLine(i + " - " + animaux[i].Nom);
            }

            int choixS;
            // Boucle pour s'assurer que l'utilisateur entre un nombre valide correspondant à un animal
            while (!int.TryParse(Console.ReadLine(), out choixS) || choixS < 0 || choixS >= animaux.Count)
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
            }

            // Suppression de l'animal sélectionné dans la liste
            animaux.RemoveAt(choixS);
            Console.WriteLine("Animal " + choixS + " supprimé.");
        }

        // Procédure pour simuler le temps dans le Zoo
        void simulation()
        {
            // Vérification si des animaux existent avant de commencer la simulation
            if (animaux.Count == 0)
            {
                Console.WriteLine("Aucun animal dans le Zoo. Veuillez en créer un avant de vouloir simuler le futur du Zoo.");
                Thread.Sleep(2000);
                Console.Clear();
                return; // Sortie de la fonction si aucun animal n'est présent
            }

            // Demande à l'utilisateur de spécifier le nombre d'années à simuler
            int nbr_anim = animaux.Count;
            Console.WriteLine("Combien d'année voulez-vous simuler ?");
            int year = int.Parse(Console.ReadLine());

            // Boucle pour simuler chaque année
            for (int i = 0; i < year; i++)
            {
                Console.WriteLine("An " + (i + 1)); // Affichage de l'année en cours
                bool tous_morts = true; // Variable pour vérifier si tous les animaux sont morts pendant l'année

                // Boucle pour simuler chaque animal
                for (int j = 0; j < nbr_anim; j++)
                {
                    if (animaux[j].Est_vivant) // Vérification si l'animal est vivant
                    {
                        Console.WriteLine("##################################################################");
                        // Simulation des actions de l'animal (déplacer, manger, crier, vieillir)
                        animaux[j].deplacer(50);
                        animaux[j].manger();
                        animaux[j].crier();
                        animaux[j].vieillir();
                        Console.WriteLine("##################################################################");
                        Console.WriteLine("\n");
                        tous_morts = false; // S'il y a au moins un animal vivant, la variable devient false
                    }
                }

                // Si tous les animaux sont morts, arrêter la simulation
                if (tous_morts)
                {
                    Console.WriteLine("Tous les animaux sont morts. Arrêt de la simulation.");
                    break;
                }
            }

            // Vérification finale des animaux morts après la simulation
            verif_mort();
        }

        // Procédure pour afficher le Zoo en entier
        void affich_ani()
        {
            // Vérification si des animaux existent avant d'afficher
            if (animaux.Count == 0)
            {
                Console.WriteLine("Aucun animal dans le Zoo. Veuillez en créer un avant de vouloir afficher quelque chose.");
                Thread.Sleep(2000);
                Console.Clear();
                return; // Sortie de la fonction si aucun animal n'est présent
            }

            // Affichage de tous les animaux du zoo avec leur nom et leur âge
            Console.Clear();
            Console.WriteLine("Voici tous les animaux du Zoo :) \n");
            for (int i = 0; i < animaux.Count; i++)
            {
                Console.WriteLine(i + " - " + animaux[i].Nom + " ; Âge : " + animaux[i].Age);
            }
            Console.WriteLine("\n");
        }

        // Procédure pour vérifier les animaux morts
        void verif_mort()
        {
            // Vérification des animaux morts et suppression de ceux-ci de la liste
            for (int i = animaux.Count - 1; i >= 0; i--)
            {
                if (!animaux[i].Est_vivant)
                {
                    Console.WriteLine(animaux[i].Nom + " est mort. Suppression de l'animal dans le Zoo.");
                    animaux.RemoveAt(i);
                }
            }
        }

        // Boucle principale pour afficher le menu et gérer les options choisies par l'utilisateur
        bool menuOn = true;
        while (menuOn)
        {
            displayMenu(); // Affichage du menu
            int userEntry;
            // Boucle pour s'assurer que l'utilisateur entre une option valide (0 à 4)
            while (!int.TryParse(Console.ReadLine(), out userEntry) || userEntry < 0 || userEntry > 4)
            {
                Console.WriteLine("Veuillez entrer une option valide (0 à 4).");
            }

            // Switch pour gérer les différentes options du menu
            switch (userEntry)
            {
                case 1:
                    add_ani(); // Ajout d'un animal
                    break;
                case 2:
                    supp_ani(); // Suppression d'un animal
                    break;
                case 3:
                    simulation(); // Simulation du temps
                    break;
                case 4:
                    affich_ani(); // Affichage du Zoo
                    break;
                case 0:
                    menuOn = false; // Sortie de la boucle et fin du programme
                    Console.WriteLine("Merci d'avoir utilisé notre application. Au revoir !");
                    break;
            }
        }

    }
}
