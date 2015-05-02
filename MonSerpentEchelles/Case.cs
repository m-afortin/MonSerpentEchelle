using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class Case : Controlable
    {
        // Nombre de cases instanciées
        private static new int NbTotal = 0;

        // Nombre de colonnes du tableau
        public static int NbColonnes = 0;

        // Taille des cases en pixel
        public static readonly int Taille = 60;

        public Case(Form form)
        {
            Montrer(form);
            NbTotal++;
            NbColonnes = (int)Math.Sqrt(NbTotal);
        }

        public override void Ajouter()
        {
            Cases.Add(this);
        }

        public override void Initialiser()
        {
            Id = NbTotal;
            Bouton = new Button();
        }

        // Configure l'apparence de la case
        public override void Decorer()
        {
            Bouton.Enabled = false;
            Bouton.Text = (Id + 1).ToString();
            Bouton.Width = Taille;
            Bouton.Height = Bouton.Width;
        }

        // Affiche la case à l'écran
        public override void Montrer(Form form)
        {
            form.Controls.Add(Bouton);
        }

        // Ne fait rien (on positionne plutôt les cases
        // quand elles ont toutes été générées)
        public override void Positionner()
        {
        }

        // Rend le bouton de la case cliquable
        public override void Activer()
        {
            Bouton.Enabled = true;
            Bouton.Click += new EventHandler(Case_Click);
        }

        // Rend le bouton de la case incliquable
        public override void Desactiver()
        {
            Bouton.Enabled = false;
            Bouton.Click -= new EventHandler(Case_Click);
        }

        // Positionne les cases en forme de zigzag
        // comme dans le jeu de Serpents et Échelles
        public static void Zigzaguer()
        {
            if (NbColonnes > 0)
            {
                foreach (Case c in Cases)
                {
                    int X = c.Id % NbColonnes;
                    int Y = c.Id / NbColonnes;

                    if (c.Id / NbColonnes % 2 == 0)
                    {
                        c.Bouton.Left = Taille * X;
                    }
                    else
                    {
                        c.Bouton.Left = ((NbColonnes - 1) * Taille) - Taille * X;
                    }

                    c.Bouton.Top = Taille * Y;
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

        // Laisse le pion se déplacer sur cette case
        private void Case_Click(Object sender, EventArgs e)
        {
            Pions[Tour].Deplacer(this);
            Desactiver();
            Permuter();
        }
    }
}
