using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cine.DAL.Entities
{
    public class EntityTwo
    {
      

            [Key]
            public virtual Guid Id { get; set; }

            [Display(Name = "Fecha de creación")]
            public virtual DateTime? CreatedDate { get; set; }

            [Display(Name = "Fecha de modificación")]
            public virtual DateTime? ModifiedDate { get; set; }
        
    }
}
