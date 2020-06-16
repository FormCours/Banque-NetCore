using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        #region Champs
        private Dictionary<string, Compte> _Comptes;
        #endregion

        #region Props
        public string Nom { get; set; }
        private Dictionary<string, Compte> Comptes
        {
            get 
            {
                if(_Comptes is null)
                {
                    _Comptes = new Dictionary<string, Compte>();
                }

                return _Comptes;
            }
        }
        #endregion

        #region Indexeur
        public Compte this[string numero]
        {
            get
            {
                Comptes.TryGetValue(numero, out Compte c);
                return c;
            }
        }
        #endregion

        #region Methode
        public void Ajouter(Compte compte)
        {
            if(compte is null || Comptes.ContainsKey(compte.Numero))
            {
                //TODO Envoyé une erreur
                return;
            }
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            if (!Comptes.ContainsKey(numero))
                //TODO Envoyé une erreur
                return;
            this[numero].PassageEnNegatifEvent -= PassageEnNegatifAction;
            Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne p)
        {
            double avoir = 0.0;

            foreach(Compte c in _Comptes.Values)
            {
                if(c.Titulaire == p) avoir += c;
            }

            return avoir; 
        }

        private void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif({compte.Solde}).");
        }
        #endregion
    }
}
