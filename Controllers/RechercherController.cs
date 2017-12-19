using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EBibliotheque.Models;
using EBibliotheque.ViewModels;

namespace EBibliotheque.Controllers
{
    public class RechercherController : Controller
    {
        // GET: Rechercher
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            var vm = new RechercherViewModel();
            var id = Request.Form["Rechercher"];

            if (id != null)
            {
                vm.Livres =
                    Livres.ListeLivres.FindAll(l => l.Titre.ToLowerInvariant().Contains(id.ToLowerInvariant()));
                vm.Auteurs =
                    Livres.ListeAuteurs.FindAll(a => a.Nom.ToLowerInvariant().Contains(id.ToLowerInvariant()));
            }

            return View(vm);
        }
    }
}