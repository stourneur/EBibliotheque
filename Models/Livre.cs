using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre du livre doit etre saisi")]
        [Display(Name = "Titre du livre")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "La date de parution doit être saisie")]
        [Display(Name = "Date de parution")]
        public string DateParution { get; set; }
        public Auteur Auteur { get; set; }
        public Client Client { get; set; }
    }
}