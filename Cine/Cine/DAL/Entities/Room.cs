using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class Room : Entity
    {
        [Display(Name = "Numero de Sala")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumberRoom { get; set; }

        [Display(Name = "Capacidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Capacity { get; set; }

        [Display(Name = "Sillas")]
        public ICollection<Seat> Seats { get; set; } // Colección de silla para la sala


       
       
    }
}
