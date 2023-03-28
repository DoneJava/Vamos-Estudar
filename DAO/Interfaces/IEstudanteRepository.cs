using VamosEstudar.Models.DTO;

namespace VamosEstudar.DAO.Interfaces
{
    public interface IEstudanteRepository
    {
        Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro);
    }
}
