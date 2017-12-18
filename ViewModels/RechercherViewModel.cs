using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBibliotheque.Models;

namespace EBibliotheque.ViewModels
{
    public class RechercherViewModel
    {
        public List<Livre> Livres { get; set; }
        public List<Auteur> Auteurs { get; set; } 
        public string Rechercher { get; set; }
    }
}