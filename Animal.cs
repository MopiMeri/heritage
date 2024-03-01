using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animaux
{
    // Classe Animal
    public class Animal
    {
        // Attributs des animaux
        private string nom;
        private string cri;
        private int age;
        private int age_max;
        private bool est_vivant = true;

        // Constructeur animal
        public Animal(string cri, int age_max)
        {
            this.cri = cri;
            this.age_max = age_max;
            this.age = 0;
            this.nom = nom;
        }

        // Accesseur et Modificateur des attributs
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Cri
        {
            get { return cri; }
            set { cri = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Age_max
        {
            get { return age_max; }
            set { age_max = value; }
        }

        public bool Est_vivant
        {
            get { return est_vivant; }
        }

        // Procédure crier
        public void crier()
        {
            Console.WriteLine("Il crie.........");
            Console.WriteLine(cri);
        }

        // Procédure deplacer
        public virtual void deplacer(int distance)
        {
            Console.WriteLine("L'animal se déplace de " + distance + " mètres.");
        }

        // Procédure vieillir, si age_max est dépassé alors modifier l'attribut est_vivant. sinon afficher son âge
        public void vieillir(int annee = 1)
        {
            age += annee;
            if (age >= age_max)
            {
                Console.WriteLine("L'animal est mort de vieillesse.");
                est_vivant = false;
            }
            else
            {
                Console.WriteLine("L'animal a maintenant " + age + " ans.");
            }
        }

        // Procédure manger
        public virtual void manger()
        {
            Console.WriteLine("L'animal mange.");
        }

        // Procédure afficher, si vivant alors afficher son age etc. sinon afficher qu'il est mort à X ans
        public void afficher()
        {
            if (est_vivant)
            {
                Console.WriteLine("Cet animal a " + age + " ans.");
                Console.WriteLine("Il est vivant.");
            }
            else
            {
                Console.WriteLine("Cet animal est mort. Il avait " + age + " ans.");
            }
        }
    }
}
