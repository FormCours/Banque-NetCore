using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        private DateTime? _DernierRetrait;


        public Epargne(string numero, Personne titulaire)
            :base(numero, titulaire)
        {
            this.DernierRetrait = null;
        }

        public Epargne(string numero, Personne titulaire, double solde, DateTime? dernierRetrait)
            :base(numero, titulaire, solde)
        {
            this.DernierRetrait = dernierRetrait;
        }


        public DateTime? DernierRetrait
        {
            get { return _DernierRetrait; }
            set { _DernierRetrait = value; }
        }

        public override double LigneDeCredit
        {
            get { return 0; }
            set { /* On ne fait rien */ }
        }


        public override void Retrait(double Montant)
        {
            double AncienSolde = Solde;
            base.Retrait(Montant);

            if(Solde != AncienSolde)
            {
                DernierRetrait = DateTime.Now;
            }

        }

        // Lesson: Abstract
        protected override double CalculInteret()
        {
            return Solde * .045;
        }
                
    }
}
