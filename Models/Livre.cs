﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre du livre doit etre saisi")]
        [Display(Name = "Titre du livre")]
        //[TitreExiste(Titre = "Titre", ErrorMessage = "Le titre existe déjà")]
        [Remote("VerifTitreLivre", "Ajouter", ErrorMessage = "Le titre du livre existe déjà")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "La date de parution doit être saisie")]
        [Display(Name = "Date de parution")]
        public DateTime DateParution { get; set; }
        public Auteur Auteur { get; set; }
        public Client Client { get; set; }
        // Une autre façon de valider les données
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<Livre> livres = Livres.ListeLivres;
        //    if (livres.Any(l => l.Titre.ToLowerInvariant().Equals(Titre.ToLowerInvariant())))
        //        yield return new ValidationResult("Le Titre existe déjà", new[] { "Titre" });
        //    // etc.
        //}
    }
}