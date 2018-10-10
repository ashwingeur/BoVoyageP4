using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageP4.Models
{
    public class VoyageImage
    {
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