using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class Classification : Entity
    {
        [Display(Name = "Clasificación")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ClassificationName { get; set; }

        public List<Movie> Movies { get; set; } //Relacion con Movie (pelicula)
    }
}
