using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string DateParution { get; set; }
        public Auteur Auteur { get; set; }
        public Client Client { get; set; }
    }
}