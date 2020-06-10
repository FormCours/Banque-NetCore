using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
		#region Surcharge
		public static double operator +(double Solde, Compte c)
		{
			return Solde + ((c.Solde < 0.0) ? 0.0 : c.Solde);
		}
		#endregion

		private string _Numero;

		public string Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		private double _Solde;

		public double Solde
		{
			get { return _Solde; }
			private set { _Solde = value; }
		}

		private Personne _Titulaire;

		public Personne Titulaire
		{
			get { return _Titulaire; }
			set { _Titulaire = value; }
		}

        public int LigneDeCredit { get; set; }

        public void Depot(double Montant)
		{
			if (Montant <= 0)
				return; //TODO Gérer l'exception

			Solde += Montant;
		}

		public virtual void Retrait(double Montant)
		{
			Retrait(Montant, 0.0);
		}

		public void Retrait(double montant, double LigneDeCredit)
		{
			if (montant <= 0)
			{
				// TODO Erreur Argument montant negatif
				return;
			}

			if (Solde - montant < -LigneDeCredit)
			{
				// TODO Erreur Ligne de credit!!!
				return;
			}

			Solde = Solde - montant;
		}

		// Lesson: Abstract
		protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            this._Solde += CalculInteret();
        }
	}
}
