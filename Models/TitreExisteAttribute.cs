using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
// Classe qui valide les données coté serveur et coté client mais assez lourde
namespace EBibliotheque.Models
{
    
    public class TitreExisteAttribute : ValidationAttribute, IClientValidatable
    {
        public string Titre { get; set; }

        public TitreExisteAttribute() : base ("Le titre existe déjà")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo[] proprietes = validationContext.ObjectType.GetProperties();
            PropertyInfo info = proprietes.FirstOrDefault(p => p.Name == Titre);

            string valeur = info.GetValue(validationContext.ObjectInstance) as string;
            List<Livre> livres = Livres.ListeLivres;

            if (livres.Any(l => l.Titre.ToLowerInvariant().Equals(valeur.ToLowerInvariant())))
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule regle = new ModelClientValidationRule();
            regle.ValidationType = "titreexiste";
            regle.ErrorMessage = ErrorMessage;
            regle.ValidationParameters.Add("titre", Titre);
            return new List<ModelClientValidationRule> { regle };
        }

    }
}