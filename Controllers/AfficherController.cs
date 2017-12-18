using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBibliotheque.Models;

namespace EBibliotheque.Controllers
{
    public class AfficherController : Controller
    {
        // GET: Afficher
        public ActionResult Livre(int? id)
        {
            Livre livre = Livres.ObtenirLivreId(id);
            // Si le livre est null on retourne une Vue Erreur
            if (livre == null)
                return View("Error");
            // Si le livre.Client on instancie un nouveau Client pour évité d'avoir un null
            if (livre.Client == null)
                livre.Client = new Client();

            return View(livre);
        }

        public ActionResult Index()
        {
            List<Livre> livres = Livres.ObtenirListeLivres();
            return View(livres);
        }

        public ActionResult Auteurs()
        {
            List<Auteur> auteurs = Livres.ObtenirListeAuteurs();
            return View(auteurs);
        }

        public ActionResult Auteur(int? id)
        {
            List<Livre> livres = Livres.ObtenirListeLivreParAuteur(id);
            // Si la liste de livres est null ou qu'on cherche un numéro au dela de la longueur de la liste
            // on retourne une Vue Erreur
            if (livres == null || id > livres.Capacity)
                return View("Error");

            return View(livres);
        }
    }
}