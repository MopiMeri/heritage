using System;

namespace Animaux
{
    // Classe Chien, enfant de la classe mère Animal
    public class Chien : Animal
    {
        // Constructeur Chien
        public Chien(string nom) : base("Woaf woaf", 15)
        {
            Console.WriteLine(nom + " le chien est né !");
            Nom = nom;
        }

        // Procédure manger modifiant celle de la classe mère
        public override void manger()
        {
            Console.WriteLine(Nom + " mange.");
        }

        // Procédure deplacer modifiant celle de la classe mère
        public override void deplacer(int distance)
        {
            Console.WriteLine(Nom + " marche sur une distance de " + distance + " mètres.");
        }
    }
}
