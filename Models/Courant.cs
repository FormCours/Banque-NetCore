using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant
    {
        #region Champs
        private double _LigneDeCredit;
       // private double _Solde;
        #endregion

        #region Propriété
        public string Numero { get; set; }
        //public double Solde { get { return _Solde; }  } 
        //↑ Prop sans setter mais avec le champs accessible

        public double Solde { get; private set; }

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

        public Personne Titulaire { get; set; }
        #endregion

        #region Methode
        public void Retrait(double montant)
        {
            if(montant <= 0 )
            {
                // TODO Erreur Argument montant negatif
                return;
            }

            if(Solde - montant < -LigneDeCredit)
            {
                // TODO Erreur Ligne de credit!!!
                return;
            }

            Solde = Solde - montant;
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                // TODO Erreur Argument montant negatif
                return;
            }

            Solde = Solde + montant;
        }
        #endregion

    }
}
