using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreLibrary.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        public string Author { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RelaseDate { get; set; }

        [DataType(DataType.ImageUrl)]
        public string CoverImage { get; set; }
    }
}
