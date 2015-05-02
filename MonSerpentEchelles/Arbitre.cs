using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public class Arbitre
    {
        public static List<Case> Cases = new List<Case>();
        public static List<Pion> Pions = new List<Pion>();
        public static List<De> Des = new List<De>();
        public static int Tour = 0;

        public void Evaluer()
        {
            Pion p = Pions[Tour];
            De d = Des[0];

            p.NoCase += d.Resultat;

            if (p.EstGagnant())
            {
                Cases[p.NoCase].Bouton.Click += new EventHandler(FeliciterGagnant);
            }
            else if (p.EstTropLoin())
            {
                int Depassement = p.NoCase - (Cases.Count - 1);
                p.NoCase -= Depassement * 2;
            }
            else
            {

            }
        }

        public void Indiquer()
        {
            Case.Cases[Pions[Tour].NoCase].Activer();
        }

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
            Des[0].Activer();
        }

        private void FeliciterGagnant(Object sender, EventArgs e)
        {
            MessageBox.Show("Le joueur " + (Tour + 1) + " a gagné!");
            Application.Exit();
        }
    }
}
