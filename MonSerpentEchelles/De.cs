using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class De : Controlable
    {
        // Taille du bouton en pixels
        private readonly int Taille = 120;

        // Résultat obtenu en lançant le dé
        public int Resultat = 1;

        public De(Form form)
        {
            Positionner();
            Montrer(form);
            NbTotal++;
        }

        public override void Ajouter()
        {
            Des.Add(this);
        }

        public override void Initialiser()
        {
            Id = NbTotal;
            Bouton = new Button();
            Activer();
        }

        // Configure l'apparence du dé
        public override void Decorer()
        {
            Bouton.Text = "Dé";
            Bouton.Width = Taille;
            Bouton.Height = Bouton.Width;
        }

        // Affiche le dé à l'écran
        public override void Montrer(Form form)
        {
            form.Controls.Add(Bouton);
        }

        // Calcule la position du dé
        // selon le nombre de cases
        public override void Positionner()
        {
            Bouton.Left = Taille / 2 + Case.NbColonnes * Case.Taille;
            Bouton.Top = Taille / 2;
            Bouton.BringToFront();
        }

        // Permet de cliquer sur le dé
        public override void Activer()
        {
            Bouton.Enabled = true;
            Bouton.Click += new EventHandler(De_Click);
        }

        // Empêche de cliquer sur le dé
        public override void Desactiver()
        {
            Bouton.Enabled = false;
            Bouton.Click -= new EventHandler(De_Click);
        }

        // Obtient un nombre au hasard entre 1 et 6
        private void Lancer()
        {
            Resultat = new Random().Next(1, 7);
            Bouton.Text = Resultat.ToString();
        }

        // Affiche toutes les faces du dé
        // pendant quelques secondes
        public void Animer()
        {
            for (int i = 0; i < 20; ++i)
            {
                Bouton.Refresh();
                Bouton.Text = (i % 6 + 1).ToString();
                Thread.Sleep(100);
            }
        }

        // Exécute les actions du dé ci-haut
        // et donne le relais à "l'arbitre"
        private void De_Click(Object sender, EventArgs e)
        {
            Desactiver();
            Animer();
            Lancer();
            Evaluer();
            Indiquer();
        }
    }
}
