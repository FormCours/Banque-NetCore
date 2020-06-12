﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
		private string _Numero;
		private double _Solde;
		private Personne _Titulaire;

		public Compte(string numero, Personne titulaire)
		{
			this.Numero = numero;
			this.Titulaire = titulaire;
			this.Solde = 0;
		}

		public Compte(string numero, Personne titulaire, double solde)
			: this(numero, titulaire)
		{
			this.Solde = 0;
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
			if (Montant <= 0)
				return; //TODO Gérer l'exception

			Solde += Montant;
		}

		public virtual void Retrait(double montant)
		{
			InternalRetrait(montant);
		}

		protected void InternalRetrait(double montant, double limite = 0)
		{
			if (montant <= 0)
			{
				// TODO Erreur Argument montant negatif
				return;
			}

			if(montant - Solde < limite)
			{
				// TODO Erreur
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


		#region Surcharge
		public static double operator +(double Solde, Compte c)
		{
			return Solde + ((c.Solde < 0.0) ? 0.0 : c.Solde);
		}
		#endregion
	}
}
