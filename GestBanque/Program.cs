using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Exo!");

            Personne p1 = new Personne();
            p1.Prenom = "Zaza";
            p1.Nom = "Vanderquack";
            p1.DateNaiss = new DateTime(2010, 01, 06);

            Courant c1 = new Courant();
            c1.Numero = "BE00001";
            c1.Titulaire = p1;
            c1.LigneDeCredit = 100;
            c1.Depot(500);
            AfficherCompte(c1);

            c1.Retrait(250);
            AfficherCompte(c1);

            c1.Retrait(300);
            c1.Retrait(300);
            AfficherCompte(c1);

        }

        private static void AfficherCompte(Courant c)
        {
            Console.WriteLine($"{c.Numero} {c.Solde} - {c.Titulaire.NomComplet} ");
            Console.WriteLine();
        }
    }
}
