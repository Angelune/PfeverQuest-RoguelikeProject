using System;

namespace TestAffichageDonjon
{
    class Program
    {
        static void Main(string[] args)
        {
            int longueur = 20;
            int largeur = 10;
            string affichage = "╔";
            for (int k = 0; k < longueur; k++)
            {
                affichage += "═";
            }
            affichage += "╗\n";


            for (int i=0; i< largeur; i++)
            {
                affichage += "║";
                for (int j=0; j< longueur; j++)
                {
                    affichage += ".";
                }
                affichage += "║\n";
            }

            affichage += "╚";
            for (int k = 0; k < longueur; k++)
            {
                affichage += "═";
            }
            affichage += "╝\n";

            Console.WriteLine(affichage);
        }
    }
}
