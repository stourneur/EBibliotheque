using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBibliotheque.Models;
using EBibliotheque.ViewModels;

namespace EBibliotheque.Controllers
{
    public class AjouterController : Controller
    {
        // GET: Ajouter
        public ActionResult Livre()
        {
            AjouterViewModel vm = new AjouterViewModel();
            vm.Auteurs = Livres.ListeAuteurs;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Livre(Livre livre)
        {
            ViewBag.livre = livre;
            AjouterViewModel vm = new AjouterViewModel();
            vm.Livre = livre;

            if (!ModelState.IsValid)
                return View(vm);

            livre.Auteur = Livres.ListeAuteurs.Find(a => a.Id == Int32.Parse(Request.Form["Auteurs"]));

            Livres.AjouterLivre(livre);

            return RedirectToAction("Livre", "Afficher", new { id = livre.Id});
        }
    }
}