using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VishvaShahChair.Models
{
    public class Chair
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Type { get; set; }


        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Material { get; set; }


        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Color { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Ergonomic Design")]
        public string ErgonomicDesign { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Accessories { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Range(1, 5)]
        public int Ratings { get; set; }
    }
}
