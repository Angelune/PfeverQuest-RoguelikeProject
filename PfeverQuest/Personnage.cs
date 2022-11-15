using System;
namespace PfeverQuest
{
    public abstract class Personnage
    {
        /* Rôle de la classe :
         * Permet de définir le cadre de tous les personnages qu'on rencontrera dans le jeu : le joueur ou les ennemis. 
         * 
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public int Vie { get; set; }
        public int Degat { get; set; }
        public string SymbolePerso { get; set; }

        public Personnage (int X, int Y, int vie, int degat, string sym)
        {
            XPosition = X;
            YPosition = Y;
            Vie = vie;
            Degat = degat;
            SymbolePerso = sym;
        }

        public virtual void Actions(Donjon donjon)
        {
        }


    }

}
