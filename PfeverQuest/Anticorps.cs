using System;
namespace PfeverQuest
{
    public class Anticorps : Personnage
    {
        /* Rôle de la classe : 
         * Hérite de la classe Personnage 
         * Représente le joueur
         * Possède les attributs et méthodes nécessaires à l'interaction du joueur avec le monde.
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int NombreDePas { get; set; }
        public const int DegatDeBase = 1; 
        public int VieMaximale { get; set; }

      
        public Anticorps (int vie,string sym,int nbPas) : base(0,0,vie,DegatDeBase,sym)
        {
            NombreDePas = nbPas;
            VieMaximale = 20;
        }


        public override void Actions(Donjon donjon)
        //Déplacements avec les flèches directionnelles et attaque avec la barre d'espace
        {
            ConsoleKeyInfo deplacement = Console.ReadKey();
                      

            if (deplacement.Key is ConsoleKey.LeftArrow) //À gauche
            {
                if(XPosition > 0)
                {
                    XPosition -= 1;
                    NombreDePas -= 1;
                }
            }
            if (deplacement.Key is ConsoleKey.RightArrow) //À droite
            {
                if (XPosition < donjon.LongueurDonjon-1)
                {
                    XPosition += 1;
                    NombreDePas -= 1;
                }
            }
            if (deplacement.Key is ConsoleKey.UpArrow) //En haut
            {
                if (YPosition > 0)
                {
                    YPosition -= 1;
                    NombreDePas -= 1;
                }
            }
            if (deplacement.Key is ConsoleKey.DownArrow) //En bas
            {
                if (YPosition < donjon.LargeurDonjon-1)
                {
                    YPosition += 1;
                    NombreDePas -= 1;
                }
            }
            if (deplacement.Key is ConsoleKey.Spacebar) //Attaque
            {
                donjon.AttaquerEnnemi();
            }
          
        }
    }
}
