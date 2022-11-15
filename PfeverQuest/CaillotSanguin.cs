using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfeverQuest
{
    class CaillotSanguin : Ennemi
    {
        /* Rôle de la classe : 
         * Héritant de la classe Ennemi, elle-même classe fille de Personnage
         * Définie un type d'ennemi et tous les attributs et méthodes lui permettant d'interagir avec le donjon 
         * Moins dangereux des ennemis ( vie faible , dégât faible, déplacement linéaire )
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public const string SymboleCaillot = "%";
        public const int DegatCaillot = 3;
        public const int VieCaillot = 3;

        public CaillotSanguin(int X, int Y) : base(X, Y, VieCaillot, DegatCaillot, SymboleCaillot)
        {
        }

        public override void Actions(Donjon donjon)
        //Déplacement en ligne droite
        {
            if (base.XPosition < donjon.LongueurDonjon -1) //tant qu'il peut, l'ennemi se déplace vers la droite
            {
                base.XPosition += 1;
            }
            else // Quand on arrive au bord du donjon, il faut revenir a la ligne
            {   
                if ((base.XPosition) == donjon.LongueurDonjon -1)
                {
                    base.XPosition = 0;
                }
            }
        }
    }
}
