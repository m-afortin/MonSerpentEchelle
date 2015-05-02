using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class Case : Tableau
    {
        // Nombre de cases instanciées
        public static int NbTotal = 0;

        // Identifiant unique de la case
        public int Id;

        // Bouton représentant la case
        public Button Bouton;

        // Nombre de colonnes du tableau
        public static int NbColonnes = 0;

        // Taille des cases en pixel
        public static readonly int Taille = 60;

        public Case(Form form)
        {
            Initialiser();
            Decorer();
            Montrer(form);
            NbTotal++;
            NbColonnes = (int)Math.Sqrt(NbTotal);
        }

        public void Initialiser()
        {
            Id = NbTotal;
            Bouton = new Button();
        }

        // Configure l'apparence de la case
        public void Decorer()
        {
            Bouton.Enabled = false;
            Bouton.Text = (Id + 1).ToString();
            Bouton.Width = Taille;
            Bouton.Height = Bouton.Width;
        }

        // Affiche la case à l'écran
        public void Montrer(Form form)
        {
            form.Controls.Add(Bouton);
        }

        // Ne fait rien (on positionne plutôt les cases
        // quand elles ont toutes été générées)
        public void Positionner()
        {
        }

        // Rend le bouton de la case cliquable
        public void Activer()
        {
            Bouton.Enabled = true;
            Bouton.Click += new EventHandler(Case_Click);
        }

        // Rend le bouton de la case incliquable
        public void Desactiver()
        {
            Bouton.Enabled = false;
            Bouton.Click -= new EventHandler(Case_Click);
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
