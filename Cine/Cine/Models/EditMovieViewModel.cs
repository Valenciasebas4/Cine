using Cine.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.Models
{
    public class EditMovieViewModel : Entity
    {
        [Display(Name = "Titulo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Director")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Director { get; set; }

        [Display(Name = "Duración")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Duration { get; set; }
    }
}
