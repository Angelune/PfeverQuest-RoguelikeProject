using System;
namespace PfeverQuest
{
    public class Ennemi : Personnage
    {
       /* Rôle de la classe : 
        * Hérite dans la classe Personnage
        * Elle-même classe abstraite
        * Sera précisée dans différentes sortes d'ennemis par ses classes filles
        *
        * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
        */

        public Ennemi(int X, int Y, int vie, int degat, string sym) : base(X,Y,vie,degat,sym)
        {
        }
    }
}
