using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class Room : Entity
    {
        [Display(Name = "Numero de Sala")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumberRoom { get; set; }

        [Display(Name = "Capacidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Capacity { get; set; }

        public List<Seat> Seats { get;} //Relación con Seat(asiento)
    }
}
