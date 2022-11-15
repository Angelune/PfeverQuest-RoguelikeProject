using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfeverQuest
{
    class EscherichiaColi : Ennemi
    {
        /* Rôle de la classe : 
         * Hérite de Ennemi, elle-même classe fille de Personnage
         * Définie un type d'ennemi et tous les attributs et méthodes lui permettant d'interagir avec le donjon
         * Plus dangereux des ennemis ( vie haute , dégât haut, poursuit le personnage )
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public const string SymboleEsche = "¤";
        public const int DegatEsche = 6;
        public const int VieEsche = 8;
        bool deplacementEnX;

        public EscherichiaColi(int X, int Y) : base(X, Y, VieEsche, DegatEsche, SymboleEsche)
        {
            deplacementEnX = true;
        }

        public override void Actions(Donjon donjon)
        //Déplacement en fonction de la position du joueur, d'abord en x puis en y pour éviter les déplacements en diagonale
        {        
            if (deplacementEnX == true) 
            {
                if (base.XPosition < donjon.Joueur.XPosition)
                    base.XPosition += 1;
                else if (base.XPosition > donjon.Joueur.XPosition)
                    base.XPosition -= 1;
                else
                    deplacementEnX = false;
            }
            
            if (deplacementEnX == false)
            { 
                if ( base.YPosition < donjon.Joueur.YPosition)
                    base.YPosition += 1;
                else if (base.YPosition > donjon.Joueur.YPosition)
                    base.YPosition -= 1;
                else if(base.XPosition < donjon.Joueur.XPosition)
                    base.XPosition += 1;
                else if (base.XPosition > donjon.Joueur.XPosition)
                    base.XPosition -= 1;
            }

            // on change la valeur du booléen pour qu'au prochain tours l'ennemi bouge selon l'autre axe
            if (deplacementEnX)
                deplacementEnX = false;
            else
                deplacementEnX = true;
        }
    }
}
