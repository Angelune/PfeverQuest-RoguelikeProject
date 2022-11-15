using System;
using System.Collections.Generic;
using System.Threading;

namespace PfeverQuest
{
    public class Donjon
    {
        /* Rôle de la classe : 
         * Génére un donjon avec un certain niveau de difficulté
         * Associe un joueur au donjon
         * Intégre les items et les ennemis dans le donjon
         * Gère les intéractions avec l'environnement (récolte d'items et PVE)
         *
         * Copyright 2021, MARQUETON Emma & RONDEAU Angéline
         */

        public int LongueurDonjon { get; set; } // La longueur et la largeur du Donjon ne prennent pas en compte les murs 
        public int LargeurDonjon { get; set; }
        public int NiveauDifficulte { get; set; }
        public int NbFragmentsTotaux { get; set; }
        public int NbFragmentsRecuperer { get; set; }
        
        public static int NumeroDonjon = 1; 

        public List<Item> ListeItems { get; set; }
        public List<Ennemi> ListeEnnemis { get; set; }
        public Anticorps Joueur { get; set; }

        public bool PortailOuvert { get; set; }
        public bool DonjonVictoire { get; set; }


        public Donjon(int niveau, int totFragment, Anticorps joueur)
        {
            
            NiveauDifficulte = niveau;
            GenererDonjon();
            NbFragmentsTotaux = totFragment;
            NbFragmentsRecuperer = 0;

            ListeEnnemis = new List<Ennemi>();
            ListeItems = new List<Item>();
            GenererEnnemi();
            GenererItem();

            Joueur = joueur;
            PortailOuvert = false;
            DonjonVictoire = false;
            
        }

        private void GenererDonjon()
        //Génère aléatoirement la largeur et la longueur d'un donjon en fonction du niveau de difficulté
        {
            if (NiveauDifficulte < 4)
            {
                Random y = new Random();
                LongueurDonjon = y.Next(5 + NiveauDifficulte*5 ,15 + NiveauDifficulte*5 );
                LargeurDonjon = y.Next(5 + NiveauDifficulte * 5, 15 + NiveauDifficulte * 5);
            }
            else
            {
                LongueurDonjon = 5;
                LargeurDonjon = 5;

            }

        }

        private void GenererEnnemi()
        //Génère des ennemis dans le donjon sur des positions aléatoires
        //Plus le niveau de difficulté est grand, plus la probabilité que les ennemis soient des escherichia coli augmente
        {
            if (NiveauDifficulte < 4)
            {
                Random r = new Random();
                int nbEnnemis = 3 * NiveauDifficulte; // On fixe le nombre d'ennemi dans un donjon
                ;
                int nbCaillots = r.Next(0, nbEnnemis - 3 * (NiveauDifficulte - 1)); // On agmente la probabilité d'avoir des ennemis plus fort sur les niveaux plus difficiles

                int nbEsche = nbEnnemis - nbCaillots;


                for (int i = 0; i < nbCaillots; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage
                    } while (VerifEnnemiSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un ennemi sur cette case pour éviter les chevauchements
                    ListeEnnemis.Add(new CaillotSanguin(XPosition, YPosition));
                    

                }

                for (int j = 0; j < nbEsche; j++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon - 1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon -1 ); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage
                    } while (VerifEnnemiSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un ennemi sur cette case pour éviter les chevauchements
                    ListeEnnemis.Add(new EscherichiaColi(XPosition, YPosition));
                }
            }
            else
            {
                Covid19 Boss = new Covid19();
                ListeEnnemis.Add(Boss);
            }

            

        }

        private void GenererItem()
        //Génère des items dans le donjon sur des positions aléatoires
        {
            if (NiveauDifficulte < 4)
            {
                Random r = new Random();
                int nbNourriture = r.Next(2, 6);

                int nbArme = r.Next(1, 3);

                int nbCas9 = r.Next(0, nbArme);

                int nbCas13 = r.Next(0, nbArme - nbCas9);

                int nbTransfection = nbArme - nbCas9 - nbCas13;


                for (int i = 0; i < nbCas9; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage

                    } while (VerifItemSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un item sur cette case pour éviter les chevauchements
                    ListeItems.Add(new CrisprCas9(XPosition, YPosition));
                }

                for (int i = 0; i < nbCas13; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage
                    } while (VerifItemSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un item sur cette case pour éviter les chevauchements
                    ListeItems.Add(new CrisprCas13(XPosition, YPosition));
                }

                for (int i = 0; i < nbTransfection; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (1, 1) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (1, 1) réservée à notre personnage
                    } while (VerifItemSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un item sur cette case pour éviter les chevauchements
                    ListeItems.Add(new Transfection(XPosition, YPosition));
                }


                for (int i = 0; i < nbNourriture; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage
                    } while (VerifItemSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un item sur cette case pour éviter les chevauchements
                    ListeItems.Add(new Nourriture(XPosition, YPosition));
                }

                for (int i = 0; i < NbFragmentsTotaux; i++)
                {
                    int XPosition;
                    int YPosition;
                    do
                    {
                        XPosition = r.Next(1, LongueurDonjon-1); // Génération aléatoire de la position en X, (0, 0) réservée à notre personnage
                        YPosition = r.Next(1, LargeurDonjon-1); // Génération aléatoire de la position en Y, (0, 0) réservée à notre personnage
                    } while (VerifItemSurCase(XPosition, YPosition) != null); // On recommence tant qu'il y a éjà un item sur cette case pour éviter les chevauchements
                    ListeItems.Add(new FragmentVirus(XPosition, YPosition));
                }
            }
        }

        public bool JouerDonjon()
        //Gestion du déroulement d'un donjon, jusqu'à mort du joueur ou récolte de tous les fragments
        {
            AffichageDonjon();
            Timer aTimer = new Timer(TimerCallBack, null, 0, 1500);

            while (Joueur.NombreDePas > 0 && Joueur.Vie > 0 && DonjonVictoire == false)
            {
                Joueur.Actions(this); //nbPasRestant diminue quand le joueur se déplace
                RecupererItem();
                PrendreDegats();

                Console.Clear();
                AffichageDonjon();

              
                if (PortailOuvert && Joueur.XPosition == LongueurDonjon - 1 && Joueur.YPosition == LargeurDonjon - 1)
                {
                    DonjonVictoire = true;
                    NumeroDonjon += 1;
                }

            }
            aTimer.Dispose();

            Console.Clear();
            FinDeDonjon();
            Joueur.XPosition = 0;
            Joueur.YPosition = 0;
            Joueur.NombreDePas += 15*NiveauDifficulte;

            return DonjonVictoire;

        }
                

        private void TimerCallBack(Object source)
        //Timer pour le déplacement des ennemis
        {
            foreach (Ennemi ennemiActuel in ListeEnnemis)
            {
                ennemiActuel.Actions(this);
            }
            PrendreDegats();
            
            Console.Clear();

            if (Joueur.Vie <=0)
                FinDeDonjon();
            else
                AffichageDonjon();           
        }

        public void FinDeDonjon()
        //Mort du joueur si plus de vie ou plus de déplacements disponibles
        {
            int nbPasRestant = Joueur.NombreDePas;

            if (nbPasRestant <= 0)
            {
                Console.WriteLine( "GAME OVER \nTu as utilisé tous vos déplacements.");
            }
            else if (Joueur.Vie <= 0)
            {
                Console.WriteLine( "GAME OVER \n Tu n'as plus de vie.");
            }
        }


        public void PrendreDegats()
        //Perte de points de vie du joueur si un ennemi se trouve sur la même case
        {
            Ennemi ennemiPotentiel = VerifEnnemiSurCase(Joueur.XPosition, Joueur.YPosition);
            if (ennemiPotentiel != null)
            {
                Joueur.Vie -= ennemiPotentiel.Degat;
            }
            
        }

        public void AttaquerEnnemi()
        //Si un ennemi se trouve dans une case à côté du joueur et que ce dernier attaque, l'ennemi prend des dégâts
        {

            List<Ennemi> ListeEnnemisPotentiels = new List<Ennemi>();
            Console.WriteLine(Joueur.XPosition + ":" + Joueur.YPosition);

            Ennemi ennemiPotentielHaut = VerifEnnemiSurCase(Joueur.XPosition, Joueur.YPosition-1);
            Ennemi ennemiPotentielBas = VerifEnnemiSurCase(Joueur.XPosition, Joueur.YPosition+1);
            Ennemi ennemiPotentielGauche = VerifEnnemiSurCase(Joueur.XPosition-1, Joueur.YPosition);
            Ennemi ennemiPotentielDroite = VerifEnnemiSurCase(Joueur.XPosition+1, Joueur.YPosition);

            
            
            ListeEnnemisPotentiels.Add(ennemiPotentielHaut);
            ListeEnnemisPotentiels.Add(ennemiPotentielBas);
            ListeEnnemisPotentiels.Add(ennemiPotentielGauche);
            ListeEnnemisPotentiels.Add(ennemiPotentielDroite);


            foreach (Ennemi ennemiProche in ListeEnnemisPotentiels)
            {
                if (ennemiProche != null)
                {
                    ennemiProche.Vie -= Joueur.Degat;
                    
                    if (ennemiProche.Vie <= 0 && NiveauDifficulte != 4)
                    {
                        ListeEnnemis.Remove(ennemiProche);

                    }
                    
                }        
            }

            if (NiveauDifficulte == 4 && ListeEnnemis.Count == 0) // dans le niveau du boss final il suffit de tuer le boss pour ouvrir le portail
            {
                DonjonVictoire = true;
            }
        }

        public void RecupererItem()
        //Si un item se trouve dans la même case que le joueur, il augmente les statistiques de ce dernier et disparait
        {
            Item item = VerifItemSurCase(Joueur.XPosition, Joueur.YPosition);
            if (item is Nourriture)
            {
                Nourriture nourriture = (Nourriture)item;
                //Si le gain de vie dépasse la vie maximale autorisée on fixe la vie du joueur à VieMaximale
                if (Joueur.Vie + nourriture.GainVie > Joueur.VieMaximale)
                {
                    Joueur.Vie = Joueur.VieMaximale;
                }
                else
                {
                    Joueur.Vie += nourriture.GainVie;
                }
            }
            else if (item is Arme)
            {
                Arme arme = (Arme)item;
                Joueur.Degat += arme.GainDegat;
            }
            else if (item is FragmentVirus)
            {
                FragmentVirus fragment = (FragmentVirus)item;
                Joueur.NombreDePas += fragment.GainNombreDePas;
                NbFragmentsRecuperer += 1;
            }
            ListeItems.Remove(item);

            if(NbFragmentsTotaux-NbFragmentsRecuperer == 0)
            {
                PortailOuvert = true;
            }
        }

        public Item VerifItemSurCase(int x, int y)
        //Vérifie si un item est sur la même case que le joueur
        {
            Item ItemSurCetteCase = null;
            bool trouve = false;
            int i = 0;
            while ((i < ListeItems.Count) && !trouve)
            {
                if (ListeItems[i].XPosition == x && ListeItems[i].YPosition == y)
                {
                    trouve = true;
                    ItemSurCetteCase = ListeItems[i];
                }
                else
                {
                    i++;
                }
            }
            return ItemSurCetteCase;
        }


        public Ennemi VerifEnnemiSurCase(int x, int y)
        //Vérifie si un ennemi est sur la même case que le joueur
        {
            Ennemi EnnemiSurCetteCase = null;
            bool trouve = false;
            int i = 0;
            while ((i < ListeEnnemis.Count) && !trouve)
            {
                if (ListeEnnemis[i].XPosition == x && ListeEnnemis[i].YPosition == y)
                {
                    trouve = true;
                    EnnemiSurCetteCase = ListeEnnemis[i];
                }
                else
                {
                    i++;
                }
            }
            return EnnemiSurCetteCase;
        }

        public void AffichageLegende()
        {
            Console.Write("===================== LEGENDE ======================\n\n");
            Console.WriteLine("LES RESSOURCES");
            Console.Write("Fragments : ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t Nourriture : ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t Arme : ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("1");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("3");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("5\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("LES ENNEMIS");
            Console.WriteLine("Caillots sanguins: %");
            Console.WriteLine("Escherichia Coli: ¤");

        }

        public void AffichageInformations()
        {
            string informations = "";
            string affichageVie = "";
            string affichageFragment = "";


            informations += "=================== INFORMATIONS ====================\n\n";
            for (int i = 0; i < Joueur.Vie; i++)
            {
                affichageVie += "<3";
            }
            for (int j = 0; j < Joueur.VieMaximale - Joueur.Vie; j++)
            {
                affichageVie += "</3";
            }
            for (int k = 0; k < NbFragmentsRecuperer; k++)
            {
                affichageFragment += "\u25A0 ";
            }
            for (int l = 0; l < NbFragmentsTotaux - NbFragmentsRecuperer; l++)
            {
                affichageFragment += "\u25A1 ";
            }

            informations += "DONJON N°" + NumeroDonjon +" \t DONJON DE NIVEAU " + NiveauDifficulte + "\n" + "VIE : " + affichageVie + "\n" + "NOMBRE DE FRAGMENTS : " + affichageFragment + "\n" + "NOMBRE DE DÉPLACEMENTS RESTANTS : " + Joueur.NombreDePas + "\n" + "FORCE D'ATTAQUE : " + Joueur.Degat;
            informations += "\n\n====================================================================== \n \n";

            Console.Write(informations);

            if (NiveauDifficulte == 4)
            {
                Console.Write("Vie du Covid19 : ");
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i = 0; i < ListeEnnemis[0].Vie; i +=5 )
                {
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n");
            }
        }

        
        public void AffichageDonjon()
        {
            AffichageLegende();
            AffichageInformations();

            
            string[,] grille = new string[LongueurDonjon + 2, LargeurDonjon + 2];

            grille[0, 0] = "╔";
            for (int k = 1; k <= LongueurDonjon; k++)
            {
                grille[k, 0] += "═";
            }
            grille[LongueurDonjon + 1, 0] += "╗\t";


            for (int i = 1; i <= LargeurDonjon; i++)
            {
                grille[0, i] += "║";
                for (int j = 1; j <= LongueurDonjon; j++)
                {
                    grille[j, i] += ".";
                }
                grille[LongueurDonjon + 1, i] += "║\t";
            }
            if (PortailOuvert)
            {
                grille[LongueurDonjon, LargeurDonjon] = "O";
            }


            grille[0, LargeurDonjon + 1] += "╚";
            for (int k = 1; k <= LongueurDonjon; k++)
            {
                grille[k, LargeurDonjon + 1] += "═";
            }
            grille[LongueurDonjon + 1, LargeurDonjon + 1] = "╝\n";

            // on positionne les différents personnages 
            

            for (int i = 0; i < ListeEnnemis.Count; i++)
            {
                Ennemi ennemiActuel = ListeEnnemis[i];
                grille[ennemiActuel.XPosition +1, ennemiActuel.YPosition+1] = ennemiActuel.SymbolePerso;     // on choisi de n'afficher qu'un seul des deux ennemis s'il deux se trouvent sur la même case ( ils se sépareront au tours prochain)
            }

            bool attaqueEnnemi = false;

            
            if (grille[Joueur.XPosition+1, Joueur.YPosition+1] != "." && grille[Joueur.XPosition + 1, Joueur.YPosition + 1] != "O")
            { attaqueEnnemi = true; } // on récupère l'information que le joueur est sur la même case qu'un ennemi pour pouvoir afficher la case en rouge.
           
            grille[Joueur.XPosition+1, Joueur.YPosition+1] = Joueur.SymbolePerso;



            // On affiche direct dans la fonction             
            for (int j = 0; j < LargeurDonjon + 2; j++)
            {
                for (int i = 0; i < LongueurDonjon + 2; i++)
                {
                    bool dejaAffiche = false;

                    // on priorise l'information d'être attaqué plutôt que l'item: si on est attaqué sur un case contenant un item la case s'affichera rouge
                    if (i == Joueur.XPosition+1 && j == Joueur.YPosition+1 && attaqueEnnemi == true)
                    {
                        
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(grille[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        dejaAffiche = true;
                    }
                    if (dejaAffiche != true)
                    {
                        for (int compteurItem = 0; compteurItem < ListeItems.Count; compteurItem++)
                        {
                            Item itemActuel = ListeItems[compteurItem];
                            if (itemActuel.XPosition+1 == i && itemActuel.YPosition+1 == j)
                            {
                                // comme le consoleColor accepte seulement le nom des couleurs donc on doit tout tester 
                                if (itemActuel is Nourriture)
                                    Console.BackgroundColor = ConsoleColor.Green;
                                else if (itemActuel is FragmentVirus)
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                else if (itemActuel is Transfection)
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                else if (itemActuel is CrisprCas9)
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                else if (itemActuel is CrisprCas13)
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;

                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(grille[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;

                                dejaAffiche = true;
                            }
                        }
                    }
                    if (dejaAffiche != true)
                    {
                        Console.Write(grille[i, j]);
                    }
                }
                Console.Write('\n');
            }
            
        }
    }
}
