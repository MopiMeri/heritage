using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    // Classe Chat, enfant de la classe mère Animal
    public class Chat : Animal
    {
        // Constructeur chat
        public Chat(string nom) : base("Miaouu", 16)
        {
            Console.WriteLine(nom + " le chat est né !");
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
