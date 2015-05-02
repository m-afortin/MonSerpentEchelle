using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class Tableau
    {
        // Fenêtre "hôte" du tableau
        private Form Fenetre;

        // Numéro du joueur actif
        public static int Tour = 0;

        // Liste des cases
        public static List<Case> Cases = new List<Case>();

        // Liste des pions
        public static List<Pion> Pions = new List<Pion>();
        
        // Dé
        public static De D;

        // Initialise le tableau
        public void Initialiser(Form form)
        {
            Fenetre = form;
            InitialiserCases();
            InitialiserPions();
            InitialiserDe();
        }

        // Crée une liste de cases
        public void InitialiserCases()
        {
            for (int i = 0; i < 16; ++i)
            {
                Case c = new Case(Fenetre);
                Cases.Add(c);
            }

            Renverser();
            Zigzaguer();
        }

        // Crée une liste de pions
        public void InitialiserPions()
        {
            for (int i = 0; i < 4; ++i)
            {
                Pion p = new Pion(Fenetre);
                Pions.Add(p);
            }

            Pions.First().Activer();
        }

        // Crée un dé
        public void InitialiserDe()
        {
            D = new De(Fenetre);
        }

        // Positionne les cases en forme de zigzag
        // comme dans le jeu de Serpents et Échelles
        public static void Zigzaguer()
        {
            if (Case.NbColonnes > 0)
            {
                foreach (Case c in Cases)
                {
                    int X = c.Id % Case.NbColonnes;
                    int Y = c.Id / Case.NbColonnes;

                    if (c.Id / Case.NbColonnes % 2 == 0)
                    {
                        c.Bouton.Left = Case.Taille * X;
                    }
                    else
                    {
                        c.Bouton.Left = ((Case.NbColonnes - 1) * Case.Taille) - Case.Taille * X;
                    }

                    c.Bouton.Top = Case.Taille * Y;
                }
            }
        }

        // Positionne les cases de bas en haut
        // plutôt que naturellement de haut en bas
        public static void Renverser()
        {
            int i = 0;
            foreach (Case c in Cases.Reverse<Case>())
            {
                c.Id = i;
                ++i;
            }
        }

        // Vérifie si le joueur a gagné ou a dépassé la limite
        public void Evaluer()
        {
            Pion p = Pions[Tour];

            p.NoCase += D.Resultat;

            if (p.EstGagnant())
            {
                Cases[p.NoCase].Bouton.Click += new EventHandler(FeliciterGagnant);
            }
            else if (p.EstTropLoin())
            {
                int Depassement = p.NoCase - (Cases.Count - 1);
                p.NoCase -= Depassement * 2;
            }
        }

        // Indique la case où le joueur doit cliquer
        public void Indiquer()
        {
            Case.Cases[Pions[Tour].NoCase].Activer();
        }

        // Passe au prochain joueur
        public void Permuter()
        {
            Pions[Tour].Desactiver();

            if (Tour < Pions.Count - 1)
            {
                ++Tour;
            }
            else
            {
                Tour = 0;
            }

            Pions[Tour].Activer();
            D.Activer();
        }

        // Affiche un message à l'écran pour féliciter le gagnant
        private void FeliciterGagnant(Object sender, EventArgs e)
        {
            MessageBox.Show("Le joueur " + (Tour + 1) + " a gagné!");
            Application.Exit();
        }
    }
}
