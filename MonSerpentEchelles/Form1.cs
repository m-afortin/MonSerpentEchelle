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
            InitialiserCases();
            InitialiserPions();
            InitialiserDe();
            InitialiserFenetre();
        }

        public void InitialiserCases()
        {
            for (int i = 0; i < 16; ++i)
            {
                Case c = new Case(this);
            }

            Case.Renverser();
            Case.Zigzaguer();
        }

        public void InitialiserPions()
        {
            for (int i = 0; i < 4; ++i)
            {
                Pion j = new Pion(this);
            }

            Pion.Pions[0].Activer();
        }

        public void InitialiserDe()
        {
            De d = new De(this);
        }

        public void InitialiserFenetre()
        {
            Width = 240 + 60 * Case.NbColonnes;
            Height = Width - 200;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
