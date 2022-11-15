using System;
namespace PfeverQuest
{
    public class CrisprCas13 : Arme
    {
        /* Rôle de la classe : 
         * Hérite de Arme, elle-même classe fille de Item
         * Définie un type d'arme d'efficacité moyenne
         * Augmente les dégats infligés par le joueur de 3 points une fois récolté
         * Couleur dans le jeu : Dark Cyan
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        
        public const int Degat = 3;

        public CrisprCas13(int x, int y) : base(x, y, Degat)
        {
        }

    }
}
