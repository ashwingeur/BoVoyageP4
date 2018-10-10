using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class VoyageImage
    {

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Type")]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public int VoyageID { get; set; }

        [ForeignKey("VoyageID")]
        public Voyage Voyage { get; set; }
    }
}