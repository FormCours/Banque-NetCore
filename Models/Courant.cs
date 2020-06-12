using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant : Compte
    {
        #region Propriété
        public override double LigneDeCredit
        {
            get { return base.LigneDeCredit; }
            set
            {
                if (value < 0)
                {
                    //TODO Generer une erreur
                    return;
                }

                base.LigneDeCredit = value;
            }
        }

       
        #endregion

        #region Methode
        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }
        #endregion

        // Lesson: Abstract
        protected override double CalculInteret()
        {
            return (Solde < 0) ? Solde * .0975 : Solde * .03;
        }

    }
}
