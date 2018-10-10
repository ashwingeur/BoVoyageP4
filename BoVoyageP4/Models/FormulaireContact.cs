using System.ComponentModel.DataAnnotations;

namespace BoVoyageP4.Models
{
    public class FormulaireContact
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
    }
}