using VamosEstudar.BLL.Interfaces;
using VamosEstudar.DAO;
using VamosEstudar.Models;
using VamosEstudar.Models.DTO;

namespace VamosEstudar.BLL
{
    public class Facade : IFacade
    {
        #region Atributos / Propriedades
        private IEstudanteManager _estudanteManager;
        #endregion

        #region Construtores
        public Facade(IEstudanteManager estudanteManager)
        {
            _estudanteManager = estudanteManager;
        }
        #endregion

        #region Métodos
        public async Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro)
        {
            return await _estudanteManager.BuscarEstudantes(filtro);
        }
        #endregion
    }
}
