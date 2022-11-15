using System;
namespace PfeverQuest
{
    public class Item
    {
        /* Rôle de la classe : 
         * Permet de définir la position et la couleur de tous les items qu'on rencontrera dans le jeu : la nourriture, les armes et les fragments de virus. 
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int XPosition { get; set; }
        public int YPosition { get; set; }
        
        public Item(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }
    }
}
