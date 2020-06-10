using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant : Compte
    {
       

        #region Champs
        private double _LigneDeCredit;
       // private double _Solde;
        #endregion

        #region Propriété
       
        //public double Solde { get { return _Solde; }  } 
        //↑ Prop sans setter mais avec le champs accessible

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set
            {
                if (value < 0)
                {
                    //TODO Generer une erreur
                    return;
                }

                _LigneDeCredit = value;
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
