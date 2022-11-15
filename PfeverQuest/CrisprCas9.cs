using System;
namespace PfeverQuest
{
    public class CrisprCas9 : Arme
    {
        /* Rôle de la classe : 
         * Hérite de Arme, elle-même classe fille de Item
         * Définie un type d'arme d'efficacité forte
         * Augmente les dégats infligés par le joueur de 5 points une fois récolté
         *Couleur dans le jeu : cyan 
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        
        public const int Degat = 5;

        public CrisprCas9(int x, int y) : base(x, y, Degat)
        {   
        }

        
    }
}
