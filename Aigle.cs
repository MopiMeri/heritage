using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    // Classe Aigle, enfant de la classe Oiseau
    public class Aigle : Oiseau
    {

        // Constructeur Aigle
        public Aigle(string nom) : base()
        {
            Age_max = 10;
            Cri = "Kree-uh Kree-uh";
            Console.WriteLine(nom + " l'aigle est né !");
            Nom = nom;
        }

        // Procédure manger modifiant celle de la classe mère
        public override void manger()
        {
            Console.WriteLine(Nom+" mange.");
        }

        // Procédure deplacer modifiant celle de la classe mère
        public override void deplacer(int distance)
        {
            Console.WriteLine(Nom+" vole sur " + distance + " mètres.");
        }
    }
}
