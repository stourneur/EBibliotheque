using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBibliotheque.Models
{
    public class Client
    {
        public string Nom { get; set; }
        public string Email { get; set; }
        public List<Livre> Livres { get; set; } 
    }
}