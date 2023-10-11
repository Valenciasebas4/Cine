using System.ComponentModel.DataAnnotations;

namespace Cine.DAL.Entities
{
    public class Hour : Entity
    {
        [Display (Name = "Hora de inicio")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime StarTime { get; set; }

        [Display(Name = "Hora de Finalización")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime EndignTime { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Movie Movie { get; set; } // Relacion con Movie (pelicula)

    }
}
