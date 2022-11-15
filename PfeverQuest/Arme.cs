using System;
namespace PfeverQuest
{
    public class Arme : Item
    {
        /* Rôle de la classe : 
         * Hérite de Arme
         * Elle-même classe abstraite
         * Sera précisée dans différentes sortes d'armes par ses classes filles
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int GainDegat { get; set; }

        public Arme(int x, int y, int degat) : base(x, y)
        {
            GainDegat = degat;
        }
    }
}
