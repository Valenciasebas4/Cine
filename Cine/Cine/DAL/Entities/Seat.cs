using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.DAL.Entities
{
    public class Seat : Entity
    {
        [Display(Name = "Número de Asiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumberSeat { get; set; }

        [ForeignKey("Sala")]
        public int SalaID { get; set; }

        [Display(Name = "Servicio.")]
        public virtual Room Room { get; set; } //Relacion con Room(sala)
    }
}
