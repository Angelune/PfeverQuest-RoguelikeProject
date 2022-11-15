using System;
namespace PfeverQuest
{
    public class Transfection : Arme
    {
        /* Rôle de la classe : 
         * Hérite de Arme, elle-même classe fille de Item
         * Définie un type d'arme d'efficacité faible 
         * Augmente les dégats infligés par le joueur de 1 points une fois récolté
         * Couleur dans le Jeu : bleu
         * 
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public const int Degat = 1 ;
        

        public Transfection(int x, int y) : base(x, y, Degat )
        {
        }

       
    }
}
