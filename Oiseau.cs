using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    // Classe Oiseau, enfant de la classe mère Animal
    public class Oiseau : Animal
    {
        // Constructeur Oiseau
        public Oiseau() : base("Cui cui", 20)
        {
            Console.WriteLine("Un nouvel oiseau est né !");
        }

        // Procédure deplacer modifiant celle de la classe mère
        public override void deplacer(int distance)
        {
            Console.WriteLine("L'oiseau vole sur une distance de " + distance + " mètres.");
        }
    }
}
