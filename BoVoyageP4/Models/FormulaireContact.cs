using System.ComponentModel.DataAnnotations;

namespace BoVoyageP4.Models
{
    public class FormulaireContact
    {
        public int ID { get; set; }

        [StringLength(150, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    , ErrorMessage = "Le format n'est pas bon.")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le numéro doit contenir entre 1 et 40 caractères")]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
    }
}