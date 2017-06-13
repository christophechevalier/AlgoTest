using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest
{
    class Program
    {
        static List<string>[] Barre;
        static string sBarre;
        static int nbDisque;
        static int nbBarre = 3;
        static int x = 0;

        /// <summary>
        /// Méthode d'initialisation
        /// </summary>
        static void InitBarre()
        {
            int i;
            Barre = new List<string>[nbBarre];

            for (i = 0; i < nbBarre; i++) Barre[i] = new List<string>();

            string s = "";

            for (int nbetoile = nbDisque; nbetoile >= 1; nbetoile--)
            {
                s = "|";
                for (i = 0; i < nbetoile; i++) s = "*" + s + "*";
                for (i = nbetoile; i < nbDisque; i++) s = " " + s + " ";
                Barre[0].Add(s);
            }
            sBarre = "|";
            for (i = 0; i < nbDisque; i++) sBarre = " " + sBarre + " ";
        }

        /// <summary>
        /// Méthode qui permet d'aficher les barres
        /// </summary>
        static void AfficherBarre()
        {
            string s;
            for (int x = nbDisque - 1; x >= 0; x--)
            {
                for (int y = 0; y < 3; y++) // boucle pour afficher le nombre de barre
                {
                    if (x < Barre[y].Count) 
                    {
                        s = Barre[y][x];
                    }
                    else
                    {
                        s = sBarre;
                    }
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Méthode qui permet de déplacer les disques en supprimant la position par une nouvelle
        /// </summary>
        /// <param name="deb"></param>
        /// <param name="fin"></param>
        static void DeplacerDisque(int deb, int fin)
        {
            x++;
            string s = Barre[deb][Barre[deb].Count - 1]; // recupere l'element du haut
            Barre[deb].Remove(s); // supprime l'element recuperer precedement
            Barre[fin].Add(s); // l'ajoute à sa nouvelle position
        }

        /// <summary>
        /// Démarrage du jeu
        /// </summary>
        /// <param name="nbDisque"></param>
        /// <param name="deb"></param>
        /// <param name="fin"></param>
        /// <param name="tmp"></param>
        static void Hanoi(int nbDisque, int deb, int fin, int tmp)
        {
            if (nbDisque == 0) return;
            if (nbDisque >= 0)
            {
                Hanoi(nbDisque - 1, deb, tmp, fin); // faire Hanoi de n-1 de deb vers aux

                DeplacerDisque(deb, fin); // deplacer celui qui reste de deb vers fin
                AfficherBarre();

                Hanoi(nbDisque - 1, tmp, fin, deb);
            }
            else
            {
                Console.WriteLine("Vous devez saisir un nombre d'anneaux supérieur à 0 !");
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("BIENVENUE SUR LA TOUR D'HANOI");
            Console.WriteLine(" ");
            Console.Write("Combien voulez-vous de disques ? ");
            nbDisque = int.Parse(Console.ReadLine()); // nombre de disques pour le jeu
            Console.WriteLine(" ");
            sw.Start(); // demarrage temps d'exec
            InitBarre(); // initialisation des parametres des elements du jeu
            AfficherBarre(); // affichage des elements du jeu
            Hanoi(nbDisque, 0, 1, 2); // demarrage du jeu
            sw.Stop(); // fin temps d'exec
            Console.WriteLine("Le temps d'exécution s'est terminé en : " + sw.Elapsed);
            Console.WriteLine("Le jeu s'est terminé en " + x + " tours");
            Console.Read();
        }
    }
}
