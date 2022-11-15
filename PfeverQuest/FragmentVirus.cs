using System;
namespace PfeverQuest
{
    public class FragmentVirus : Item
    {
        /* Rôle de la classe : 
         * Hérite de Item
         * Redonnent au joueur 15 déplacements une fois récolté
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int GainNombreDePas { get; set; }
        public FragmentVirus(int x, int y) : base(x, y)
        {
            GainNombreDePas = 15;
        }
    }
}
