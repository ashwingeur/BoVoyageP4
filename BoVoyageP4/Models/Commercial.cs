using BoVoyageP4.Validateurs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class Commercial : Personne
    {
        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [Login]
        public string Login { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        [StringLength(150)]
        public string MotDePasse { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse", ErrorMessage = "La confirmation n'est pas bonne.")]
        [NotMapped]
        public string MotDePasseVerification { get; set; }
    }
}