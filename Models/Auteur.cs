using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBibliotheque.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de l'auteur doit être saisi")]
        [Display(Name = "Nom de l'auteur")]
        public string Nom { get; set; }
    }
}