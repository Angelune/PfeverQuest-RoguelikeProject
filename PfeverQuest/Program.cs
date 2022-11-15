using System;

namespace PfeverQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("---------------------------------------");

            ConsoleKeyInfo recommencerPartie;

            do
            {
                Partie partie = new Partie();
                partie.JouerPartie();

                Console.WriteLine("\n\n Voulez-vous recommencer une partie ? Taper sur la barre d'espace");
                recommencerPartie = Console.ReadKey();


            } while (recommencerPartie.Key is ConsoleKey.Spacebar);






        }
    }
}
