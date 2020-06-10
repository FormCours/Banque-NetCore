using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ICustomer
    {
        double Solde { get; }
        void Retrait(double Montant);
        void Depot(double Montant);        
    }
}