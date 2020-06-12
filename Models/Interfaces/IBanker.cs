using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }

        // NB: Exercice 4 du chapitre des interfaces
        //double LigneDeCredit { get; set; }
        
        void AppliquerInteret();
    }
}