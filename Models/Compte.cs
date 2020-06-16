using System;
using System.Collections.Generic;
using System.Text;
using Models.Delegates;
using Models.Exceptions;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
		private string _Numero;
		private double _Solde;
		private Personne _Titulaire;

		public event PassageEnNegatifDelegate PassageEnNegatifEvent = null;

		public Compte(string numero, Personne titulaire)
			: this(numero, titulaire,0)
		{

		}

		public Compte(string numero, Personne titulaire, double solde)
		{
			this.Numero = numero;
			this.Titulaire = titulaire;
			this.Solde = solde;
			//PassageEnNegatifEvent += Banque.PassageEnNegatifAction; //Ok, seulement si la méthode est public et static!
		}

		public string Numero
		{
			get { return _Numero; }
			private set { _Numero = value; }
		}

		public double Solde
		{
			get { return _Solde; }
			private set { _Solde = value; }
		}

		public Personne Titulaire
		{
			get { return _Titulaire; }
			private set { _Titulaire = value; }
		}

        public void Depot(double Montant)
		{
			if (!(Montant > 0))
				throw new ArgumentOutOfRangeException();

			Solde += Montant;
		}

		public virtual void Retrait(double montant)
		{
			InternalRetrait(montant);
		}

		protected void InternalRetrait(double montant, double limite = 0)
		{
			if (montant <= 0)
				throw new ArgumentOutOfRangeException();

			if (Solde - montant < limite)
				throw new SoldeInsuffisantException(montant, Solde, limite);

			Solde = Solde - montant;
		}

		// Lesson: Abstract
		protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            this._Solde += CalculInteret();
        }

		protected void RaisePassageEnNegatifEvent(Compte compte)
		{
			PassageEnNegatifEvent?.Invoke(compte);
		}

		#region Surcharge
		public static double operator +(double Solde, Compte c)
		{
			return Solde + ((c.Solde < 0.0) ? 0.0 : c.Solde);
		}
		#endregion
	}
}
