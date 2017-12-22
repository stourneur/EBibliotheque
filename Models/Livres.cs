using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBibliotheque.Models
{
    public static class Livres
    {

        public static List<Livre> ListeLivres = ObtenirListeLivres();
        public static List<Auteur> ListeAuteurs = ObtenirListeAuteurs(); 

        // Retourne une list d'auteurs
        public static List<Auteur> ObtenirListeAuteurs()
        {
            return new List<Auteur>
            {
                new Auteur {Id = 1, Nom = "Brice-Arnaud Guerin"},
                new Auteur {Id = 2, Nom = "Sebastien Putier"},
                new Auteur {Id = 3, Nom = "Sébastien OLLIVIER"}
            };
        } 

        // Retourne une liste de de livres
        public static List<Livre> ObtenirListeLivres()
        {
            // Création des auteurs
            Auteur auteur1 = ObtenirListeAuteurs().Find(a => a.Id == 1);
            Auteur auteur2 = ObtenirListeAuteurs().Find(a => a.Id == 2);
            Auteur auteur3 = ObtenirListeAuteurs().Find(a => a.Id == 3);

            // Création des clients
            Client client1 = ObtenirListeClients().Find(c => c.Email == "client1@ocr.fr");
            Client client2 = ObtenirListeClients().Find(c => c.Email == "client2@ocr.fr");

            return new List<Livre>
            {
                // Création des livres
                new Livre { Id = 1, Titre = "ASP.NET avec C# sous Visual Studio 2017", Auteur = auteur1, DateParution = new DateTime(2017, 9,1), Client = client1},
                new Livre { Id = 2, Titre = "ASP.NET avec C# sous Visual Studio 2015", Auteur = auteur1, DateParution = new DateTime(2016, 2, 1), Client = client1},
                new Livre { Id = 3, Titre = "C# 7 et Visual Sudio 2017", Auteur = auteur2, DateParution = new DateTime(2017, 9, 1)},
                new Livre { Id = 4, Titre = "Entity Framework Core", Auteur = auteur2, DateParution = new DateTime(2017, 2, 1), Client = client2},
                new Livre { Id = 5, Titre = "Angular", Auteur = auteur3, DateParution = new DateTime(2017, 7 ,1)}
            };
        }

        // Retourne une liste de clients
        public static List<Client> ObtenirListeClients()
        {
            return new List<Client>
            {
                new Client { Email = "client1@ocr.fr", Nom = "Client1"},
                new Client { Email = "client2@ocr.fr", Nom = "Client2"}
            };
        }
        // Retourne une Liste de livre par auteur
        public static List<Livre> ObtenirListeLivreParAuteur(int? id)
        {
            // Si id est null ou 0 on renvoi une valeur null
            if (id == null || id == 0)
                return null;

            List<Livre> livres = ListeLivres.FindAll(l => l.Auteur.Id == id);
            return livres;
        }
        // Retourne une liste de livre par id
        public static Livre ObtenirLivreId(int? id)
        {
            // Si l'id est null on renvoi une valeur null
            if (id == null)
                return null;

            Livre livre = ListeLivres.Find(l => l.Id == id);
            return livre;
        }

        public static int? AjouterLivre(Livre livre)
        {
            if (livre == null)
                return null;

            List<Livre> livres = ListeLivres;
            livre.Id = livres.Last().Id + 1;
            livres.Add(livre);
            return livre.Id;
        }

        public static bool LivreExiste(string titre)
        {
            return ListeLivres.Any(livre => string.Compare(livre.Titre, titre, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}