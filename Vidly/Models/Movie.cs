using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field can not be null")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field can not be null")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "This Field can not be null")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "This Field can not be null")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20,ErrorMessage = "This Field must have value bettwen 1 and 20.")]
        public int NumberInStock { get; set; }


        public Genre Genre { get; set; }

        [Required(ErrorMessage = "This Field can not be null")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}