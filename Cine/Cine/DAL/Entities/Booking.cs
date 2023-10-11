using System.ComponentModel.DataAnnotations;

namespace Cine.DAL.Entities
{
    public class Booking : Entity
    {
        public Hour Hour { get; set; }
        public Seat Seat { get; set; }

        [Display(Name = "Estado de Reserva")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string StateBooking { get; set; }
    }
}
