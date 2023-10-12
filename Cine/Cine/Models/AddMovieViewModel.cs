using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.Models
{
    public class AddMovieViewModel
    {
     

        [Display(Name = "Titulo")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(400)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Director")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Director { get; set; }

        [Display(Name = "Duracion")]
        [MaxLength(250)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Duration { get; set; }


        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }

        [Display(Name = "Clasificacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ClassificationId { get; set; }
        public IEnumerable<SelectListItem> Classifications { get; set; }
    }
}
