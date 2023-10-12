using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.Helpers
{
    public interface IDropDownListHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLRoomsAsync(); //Lista de salas
        Task<IEnumerable<SelectListItem>> GetDDLSeatsAsync(); //Lista de salas
        Task<IEnumerable<SelectListItem>> GetDDLClassificationsAsync(); //Lista de salas
        Task<IEnumerable<SelectListItem>> GetDDLGendersAsync(); //Lista de salas

    }
}
