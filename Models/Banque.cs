using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        #region Champs
        private Dictionary<string, Courant> _Comptes;
        #endregion

        #region Props
        public string Nom { get; set; }
        private Dictionary<string, Courant> Comptes
        {
            get 
            {
                if(_Comptes is null)
                {
                    _Comptes = new Dictionary<string, Courant>();
                }

                return _Comptes;
            }
        }
        #endregion

        #region Indexeur
        public Courant this[string numero]
        {
            get
            {
                Comptes.TryGetValue(numero, out Courant c);
                return c;
            }
        }
        #endregion

        #region Methode
        public void Ajouter(Courant compte)
        {
            if(compte is null || Comptes.ContainsKey(compte.Numero))
            {
                //TODO Envoyé une erreur
                return;
            }

            Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne p)
        {
            double avoir = 0.0;

            foreach(Courant c in _Comptes.Values)
            {
                if(c.Titulaire == p) avoir += c;
            }

            return avoir; 
        }
        #endregion
    }
}
