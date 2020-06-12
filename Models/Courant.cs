using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant : Compte
    {
        #region Champs
        private double _LigneDeCredit;
        #endregion

        #region Constructeur
        private void InitCtor(double ligneDeCredit)
        {
            this.LigneDeCredit = ligneDeCredit;
        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit)
            :base(numero, titulaire)
        {
            InitCtor(ligneDeCredit);
        }

        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit)
            :base(numero, titulaire, solde)
        {
            InitCtor(ligneDeCredit);
        }
        #endregion

        #region Propriété
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
            if (Solde - montant < -LigneDeCredit)
            {
                // TODO Erreur Ligne de credit!!!
                return;
            }

            base.Retrait(montant);
        }


        // Lesson: Abstract
        protected override double CalculInteret()
        {
            return (Solde < 0) ? Solde * .0975 : Solde * .03;
        }
        #endregion

    }
}
