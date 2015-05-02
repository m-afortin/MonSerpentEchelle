using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialiserTableau();
            InitialiserFenetre();
        }

        // Crée un tableau de jeu et l'affiche à l'écran
        public void InitialiserTableau()
        {
            Tableau t = new Tableau();
            t.Initialiser(this);
        }

        // Configure la fenêtre selon la taille du tableau
        public void InitialiserFenetre()
        {
            Width = 240 + 60 * Case.NbColonnes;
            Height = Width - 200;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
