using System;

namespace Models
{
    public class Personne
    {
        #region Champs
        private string _Nom;
        private string _Prenom;
        private DateTime _DateNaiss;
        #endregion

        #region Prop
        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
            }
        }

        public DateTime DateNaiss
        {
            get
            {
                return _DateNaiss;
            }

            set
            {
                _DateNaiss = value;
            }
        }
        #endregion

    }
}
