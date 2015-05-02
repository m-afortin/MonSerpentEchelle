using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonSerpentEchelles
{
    public abstract class Controlable : Arbitre
    {
        public static int NbTotal = 0;
        public Button Bouton;
        public int Id;

        public abstract void Ajouter();
        public abstract void Initialiser();
        public abstract void Decorer();
        public abstract void Montrer(Form form);
        public abstract void Positionner();
        public abstract void Activer();
        public abstract void Desactiver();

        public Controlable()
        {
            Ajouter();
            Initialiser();
            Decorer();
        }
    }
}
