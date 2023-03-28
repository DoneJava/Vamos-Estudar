using VamosEstudar.Models;
using VamosEstudar.Models.DTO;

namespace VamosEstudar.BLL.Interfaces
{
    public interface IEstudanteManager
    {
        Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro);
    }
}
