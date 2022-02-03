using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5Movies.Models
{
    public class MovieEntry
    {
        // Attributes to store about a movie
        [Key]
        [Required]
        public int MovieId { get; set; }

        //Build Foreign Key Relationship
        [Required(ErrorMessage ="Please select a Category")]
        public int CategoryId { get; set; }
        public MovieCategory Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
