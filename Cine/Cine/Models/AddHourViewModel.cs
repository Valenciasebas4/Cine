using Cine.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.Models
{
    public class AddHourViewModel
    {

        [Display(Name = "Hora de inicio")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime StarTime { get; set; }

        /*
        [Display(Name = "Hora de Finalización")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime EndignTime { get; set; }
        */
        [Display(Name = "Fecha")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Pelicula")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MovieId { get; set; }
        public IEnumerable<SelectListItem> Movies { get; set; }

       
    }
}
