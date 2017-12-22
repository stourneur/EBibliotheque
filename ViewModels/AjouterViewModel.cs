using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBibliotheque.Models;

namespace EBibliotheque.ViewModels
{
    public class AjouterViewModel
    {
        public SelectList Auteurs { get; set; }
        public Livre Livre { get; set; }
        // Liste d'objet servant a la validation javascript
        //public List<Livre> Livres { get; set; } 
    }
}