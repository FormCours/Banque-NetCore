using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Exceptions
{
    /// <summary>
    /// Gestion des execptions bancaire
    /// </summary>
    public class SoldeInsuffisantException : Exception
    {
        public double Retrait { get; private set; }
        public double RetraitMax { get; private set; }

        /// <summary>
        /// Permet de générer une execption de solde insufisant
        /// </summary>
        /// <param name="retrait">Tentative de retrait</param>
        /// <param name="soldeDispo">Solde total disponible</param>
        public SoldeInsuffisantException(double retrait, double soldeDispo)
            : this(retrait, soldeDispo, 0)
        { }

        /// <summary>
        /// Permet de générer une execption de solde insufisant
        /// </summary>
        /// <param name="retrait">Tentative de retrait</param>
        /// <param name="solde">Solde du compte</param>
        /// <param name="limite">Limite de solde atteignable</param>
        public SoldeInsuffisantException(double retrait, double solde, double limite)
        {
            this.Retrait = retrait;
            this.RetraitMax = solde - limite;
        }

        public override string Message
        {
            get
            {
                return $"Impossible de retirer {Retrait}. Retrait max {RetraitMax} possible";
            }
        }
    }
}
