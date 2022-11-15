using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfeverQuest
{
    class Covid19 : Ennemi
    {
        /* Rôle de la classe : 
         * Hérite de Ennemi, elle-même classe fille de Personnage
         * Définie un type d'ennemi et tous les attributs et méthodes lui permettant d'interagir avec le donjon
         * Boss Final ( vie très haute , dégât haut, poursuit le personnage même en diagonale )
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public const string SymboleCovid = "*";
        public const int DegatCovid = 6;
        public const int VieCovid = 250;
       

        public Covid19() : base(3, 3, VieCovid, DegatCovid, SymboleCovid)
        {
            
        }

        public override void Actions(Donjon donjon)
        //Déplacement en fonction de la position du joueur, diagonales autorisées
        {
            
            if (base.XPosition < donjon.Joueur.XPosition)
                base.XPosition += 1;
            else if (base.XPosition > donjon.Joueur.XPosition)
                base.XPosition -= 1;
            
            if (base.YPosition < donjon.Joueur.YPosition)
                base.YPosition += 1;
            else if (base.YPosition > donjon.Joueur.YPosition)
                base.YPosition -= 1;
             
        }
    }
}
