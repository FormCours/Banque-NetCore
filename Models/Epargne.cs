using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        
        private DateTime _DernierRetrait;

        public DateTime DernierRetrait
        {
            get { return _DernierRetrait; }
            set { _DernierRetrait = value; }
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
