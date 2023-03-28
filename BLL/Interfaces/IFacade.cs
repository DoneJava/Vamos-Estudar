using VamosEstudar.Models.DTO;
using VamosEstudar.Models;

namespace VamosEstudar.BLL.Interfaces
{
    public interface IFacade
    {
        Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro);
    }
}
