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
                //servant a la seconde methode de validation via le javascript
                //Livres = Livres.ListeLivres
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Livre(AjouterViewModel vm)
        {
            if (Livres.LivreExiste(vm.Livre.Titre))
            {
                ModelState.AddModelError("Titre", "Le titre du livre existe déjà");
                vm.Auteurs = new SelectList(Livres.ListeAuteurs, "Id", "Nom");
                return View(vm);
            }

            if (!ModelState.IsValid)
            {
                vm.Auteurs = new SelectList(Livres.ListeAuteurs, "Id", "Nom");
                return View(vm);
            }



            vm.Livre.Auteur = Livres.ListeAuteurs.Find(a => a.Id == Int32.Parse(Request.Form["Livre.Auteur.Nom"]));

            Livres.AjouterLivre(vm.Livre);

            return RedirectToAction("Livre", "Afficher", new { id = vm.Livre.Id});
        }

        public JsonResult VerifTitreLivre(Livre livre)
        {
            bool resultat = !Livres.LivreExiste(livre.Titre);
            return Json(resultat, JsonRequestBehavior.AllowGet);
        }
    }
}