using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBibliotheque.Models;

namespace EBibliotheque.ViewModels
{
    public class AfficherViewModel
    {
        public Livre Livre { get; set; }
        public List<Livre> Livres { get; set; }
        public List<Auteur> Auteurs { get; set; }
    }
}