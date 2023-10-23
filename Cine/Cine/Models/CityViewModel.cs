
using Cine.DAL.Entities;

namespace Cine.Models
{
    public class CityViewModel : City
    {
        public Guid StateId { get; set; }
    }
}
