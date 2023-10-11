using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class Gender : Entity
    {
        [Display(Name = "Genero")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string GenderName { get; set; }

        public List<Movie> Movies { get; set; } //Relacion con Movie (pelicula)
    }
}
