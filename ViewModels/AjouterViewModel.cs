using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBibliotheque.Models;

namespace EBibliotheque.ViewModels
{
    public class AjouterViewModel
    {
        public List<Auteur> Auteurs { get; set; }
        public Livre Livre { get; set; }
    }
}