using System;
namespace PfeverQuest
{
    public class Nourriture : Item
    {
        /* Rôle de la classe : 
         * Hérite de Item
         * Redonnent au joueur 3 points de vie une fois récolté
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int GainVie { get; set; }
        
        public Nourriture(int x, int y) : base(x, y)
        {
            GainVie = 3;
        }
    }
}
