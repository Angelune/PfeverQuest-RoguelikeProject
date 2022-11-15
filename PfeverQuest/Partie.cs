using System;
using System.Collections.Generic;

namespace PfeverQuest
{
    public class Partie
    {
        /* Rôle de la classe : 
         * Gère la création et le déroulement d'une partie. 
         * Articule les différents donjons entre eux pour que le joueur puisse y 
         * accéder d'un donjon à l'autre lorsque tous les fragments ont été récoltés.
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public Anticorps JoueurAnticorps { get; set; } //On déclare notre joueur en début de partie
        public List<Donjon> LesDonjons { get; set; } //Liste des donjons qui composent une partie

        public Partie()
        {
            Console.WriteLine("Choisissez un caractère pour votre personnage");
            string perso = Console.ReadLine();
            //Tant que le caractère choisi n'a pas une longueur de 1, on en redemande un
            while(perso.Length != 1)
            {
                Console.WriteLine("Choisissez un caractère pour votre personnage");
                perso = Console.ReadLine();
            }
            JoueurAnticorps = new Anticorps(20, perso, 30);

            //On crée 5 donjons de difficultés croissantes et un donjon Boss Final
            LesDonjons = new List<Donjon>();
            LesDonjons.Add(new Donjon(1, 3, JoueurAnticorps));
            LesDonjons.Add(new Donjon(1, 5, JoueurAnticorps));
            LesDonjons.Add(new Donjon(2, 5, JoueurAnticorps));
            LesDonjons.Add(new Donjon(3, 3, JoueurAnticorps));
            LesDonjons.Add(new Donjon(4, 0, JoueurAnticorps));
        }

        public void ReglesDuJeu()
        // Règles qu'on affiche en début de jeu
        {
            Console.WriteLine("Bienvenue dans PfeverQuest! " +
                " \n \n Dans ce jeu d’aventure, tu incarnes un anticorps dont l’hôte se voit administrer une dose d’un vaccin contre le virus du covid - 19." +
                "\n \n Ton objectif : récupérer tous les fragments de virus en un nombre limité de déplacement à travers différentes parties du corps de l’hôte," +
                "\n afin de développer son immunité. Mais attention, tu n’es pas tout seul! De nombreux ennemis seront sur ta route. Tu as la possibilité de les éviter" +
                "\n ou de les attaquer lorsque que tu te trouves à côté de l’un d’eux. Ne les laisse pas t’attraper, ou tu perdras de précieux points de vie." +
                "\n \n Pour récupérer une ressource, rends toi simplement sur sa case." +
                "\n Récupérer de la nourriture te fera regagner de la vie." +
                "\n Récupérer les fragments de virus te fera regagner des déplacements." +
                "\n Récupérer une arme augmentera le nombre de dégâts que tu infliges." +
                "\n \n Pour infliger des dégats aux ennemis appuie sur la barre d'espace lorsqu'ils sont sur une case adjacente a toi." +
                "\n\n La partie est perdue si tu n’as plus de vie ou plus de déplacement. " +
                "\n La partie est gagnée si tu as récupéré tous les fragments et que tu passes par la porte qui sera apparue en bas à droite du donjon." +
                "\n Pour lancer une partie, appuies sur la touche « Entrée » \n\n");

        }

        public void AffichageDefinitions()
        //Définitions qu'on affiche actuellement en fin de partie
        //Amélioration possible : chaque définition sera destinée à apparaitre au moment d'une intéraction entre le joueur et l'entité définie
        {
            Console.WriteLine("Un peu de culture G !" +
                " \nEscherichia coli (ou bactérie du caca pour les intimes) est une bactérie normalement présente dans le tube digestif de l’homme et des animaux à sang chaud.\n" +
                "La plupart des souches d’E.coli sont inoffensives et participent physiologiquement à l’équilibre de la flore bactérienne intestinale. Mais, d’autres souches \n" +
                "peuvent être à l’origine d’infections digestives et/ou urinaires" +
                "\n\nUn caillot sanguin est une masse semi - solide et visqueuse composée de cellules sanguines.Sa formation est une réaction normale de l'organisme à la suite \n" +
                "d'une lésion dans un vaisseau sanguin. Ils servent principalement à colmater la fuite et à prévenir l'hémorragie. Cependant, lorsqu'un caillot obstrue une artère\n" +
                "(ou thrombus) et empêche ainsi la circulation du sang et de l'oxygène vers un organe, cela peut créer un danger pour l’organisme." +
                "\n\nCRISPR Cas9 est une protéine d’origine bactérienne au propriétés anti - virales.Sa capacité à couper l’ADN au niveau de séquences spécifiques en fait une arme \n" +
                " redoutable de biologie moléculaire." +
                "\nCRISPR Cas13 est une protéine qui permet de cibler non pas l’ADN comme CRISPR Cas9 mais l’ARN, afin notamment de corriger des mutations sans toucher à l'ADN." +
                "\nLa transfection est un processus de transfert de gènes, c'est-à-dire l'introduction de matériel génétique exogène dans des cellules eucaryotes(avec noyau).Idéal pour déstabiliser l’ennemi!");
        }

        public void JouerPartie()
        //Gestion du déroulement d'une partie complète 
        {
            ReglesDuJeu();
            LesDonjons[0].AffichageLegende();
            Console.ReadLine();

            foreach (Donjon donjonActuel in LesDonjons)
            {
                bool Victoire = donjonActuel.JouerDonjon();
                if (!Victoire)
                {                  
                    break;
                }
                else if (Donjon.NumeroDonjon == 5)
                {
                    Console.WriteLine(" Bravo, l'immunité de ton hôte devrait être au top grâce à toi ! Tu es maintenant prêt à rentrer dans l'armée d'anticorps ! \n\n" +
                        "MAIS ! OMG ! OH NON UN VIRUS UN VRAI VIENT EST EN TRAIN DE NOUS ATTAQUER !!!!! :open_mouth: :open_mouth: :open_mouth: \n \n" +
                        "Bruits de couloirs des vaisseux sanguins  « Je crois que c'est lui, le fameux ... » \n " +
                        "Chuchottement des globules blancs « Il paraît que c'est le fameux Cov...» « CHUT Ne prononce pas son nom !!!» \n\n" +
                        "C'est le moment de prouver tous les efforts que tu as fait pour en arriver là ! Detruit ce virus avant qu'il ne fasse un massacre! Bon courage jeune recru \n" +
                        "Appuie sur «Entrée» quand tu es prêt ");
                    Console.ReadLine();
                }
                else if (Donjon.NumeroDonjon == 6)
                {
                    Console.WriteLine("BRAVO \n Tu as protegé efficacement ton hôte d'une invasion virale \n\n");
                    AffichageDefinitions();
                }
                
            }

            Donjon.NumeroDonjon = 1;
        }
    }   
}
