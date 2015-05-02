using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class Pion : Controlable
    {
        private static new int NbTotal = 0;
        private static readonly int Taille = Case.Taille / 2;
        public int NoCase = 0;
        private static readonly Color[] Couleurs = new Color[] {
            Color.Red,
            Color.Blue,
            Color.Yellow,
            Color.Green
        };

        public Pion(Form form)
        {
            Positionner();
            Montrer(form);
            NbTotal++;
        }

        public override void Ajouter()
        {
            Pions.Add(this);
        }

        public override void Initialiser()
        {
            Id = NbTotal;
            Bouton = new Button();
        }

        // Configure l'apparence du pion
        public override void Decorer()
        {
            Bouton.Width = 30;
            Bouton.Height = Bouton.Width;
            Bouton.BackColor = Couleurs[Id];
            Desactiver();
        }

        // Déplace le pion sur la première case
        public override void Positionner()
        {
            Deplacer(Case.Cases.First());
        }

        // Affiche le pion à l'écran
        public override void Montrer(Form form)
        {
            form.Controls.Add(Bouton);
            Bouton.BringToFront();
        }

        // Rend le pion plus évident pour l'oeil pendant son tour
        public override void Activer()
        {
            Bouton.Enabled = true;
        }

        // Dissimule le pion pendant qu'il ne joue pas
        public override void Desactiver()
        {
            Bouton.Enabled = false;
        }

        // Déplace le pion à la position de la case
        // donnée en paramètre
        public void Deplacer(Case c)
        {
            Bouton.Left = c.Bouton.Left + (Id % 2) * (Taille);
            Bouton.Top = c.Bouton.Top + (Id / 2) * (Taille);
        }

        // Indique si le joueur a dépassé la dernière case
        public bool EstTropLoin()
        {
            if (NoCase > Cases.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Indique si le joueur est tombé pile sur la dernière case
        public bool EstGagnant()
        {
            if (NoCase == Cases.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
