using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cine.DAL.Entities
{
    public class Seat : Entity
    {
        [Display(Name = "Número de Asiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumberSeat { get; set; }

        public bool Busy { get; set; }

        [Display(Name = "Sala.")]
        [JsonIgnore]
        public virtual Room Room { get; set; } //Relacion con Room(sala)
    }
}
