using Models;
using Models.Exceptions;
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

            Courant c1 = new Courant("BE00001", p1, 100);
            c1.Depot(500);
            c1.LigneDeCredit = 200;
            AfficherCompte(c1);

            c1.Retrait(100);
            AfficherCompte(c1);

            c1.Retrait(300);
            c1.Retrait(300);
            AfficherCompte(c1);

            Epargne e1 = new Epargne("BE00003", p1);
            e1.Depot(200);

            AfficherCompte(e1);

            //--------------------------------------------------
            Banque banque = new Banque();
            banque.Nom = "ConfitBanque";
            banque.Ajouter(c1);
            banque.Ajouter(e1);

            Courant c2 = new Courant("BE00002", p1, 0);
            c2.Depot(50);

            try
            {
                c2.Retrait(1_000_000);
            }
            catch(SoldeInsuffisantException)
            {
                Console.WriteLine("Boulet !");
            }

            banque.Ajouter(c2);

            
            AfficherCompte(e1);

            Console.WriteLine("Avoir des comptes de {0} : {1}", p1.Nom, banque.AvoirDesComptes(p1));

            c2.LigneDeCredit = 500;
            c2.Retrait(100);
        }

        private static void AfficherCompte(Compte c)
        {
            Console.WriteLine($"{c.Numero} {c.Solde} - {c.Titulaire.NomComplet} ");
            Console.WriteLine();
        }
    }
}
