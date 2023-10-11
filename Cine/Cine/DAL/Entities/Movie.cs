using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class Movie : Entity
    {

        [Display(Name = "Titulo")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Director")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Director { get; set; }

        [Display(Name = "Duracion")]
        [MaxLength(250)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Duration { get; set; }

        public Gender Gender { get; set; }
        public Classification Classification { get; set; }

        public List<Hour> Hours { get; set; } // Relacion con Horario
    }
}
