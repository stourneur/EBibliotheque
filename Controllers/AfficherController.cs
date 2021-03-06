﻿using System;
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

            return View(livre);
        }

        public ActionResult Index()
        {
            return View(Livres.ListeLivres);
        }

        public ActionResult Auteurs()
        {
            return View(Livres.ListeAuteurs);
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