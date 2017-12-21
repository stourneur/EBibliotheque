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
            AjouterViewModel vm = new AjouterViewModel
            {
                Auteurs = new SelectList(Livres.ListeAuteurs, "Id", "Nom"),
                Livres = Livres.ListeLivres
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Livre(AjouterViewModel vm)
        {
            ViewBag.test = vm.Livre.Titre;
            if (!ModelState.IsValid)
            {
                vm.Auteurs = new SelectList(Livres.ListeAuteurs, "Id", "Nom");
                return View(vm);
            }
            foreach (var listeLivre in Livres.ListeLivres)
            {
                if (vm.Livre.Titre.ToLowerInvariant().Equals(listeLivre.Titre.ToLowerInvariant()))
                {
                    return View(vm);
                }
            }

            vm.Livre.Auteur = Livres.ListeAuteurs.Find(a => a.Id == Int32.Parse(Request.Form["Livre.Auteur.Nom"]));

            Livres.AjouterLivre(vm.Livre);

            return RedirectToAction("Livre", "Afficher", new { id = vm.Livre.Id});
        }
    }
}