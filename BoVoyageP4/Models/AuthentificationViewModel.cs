using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageP4.Models
{
    public class AuthentificationLoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        public string Login { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AuthentificationEmailViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}