using VamosEstudar.BLL.Interfaces;
using VamosEstudar.DAO;
using VamosEstudar.DAO.Interfaces;
using VamosEstudar.Models;
using VamosEstudar.Models.DTO;

namespace VamosEstudar.BLL
{
    public class EstudanteManager : IEstudanteManager
    {
        #region Atributos / Propriedades
        private IEstudanteRepository _estudanteRepository;
        #endregion

        #region Construtores
        public EstudanteManager(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        #endregion

        #region Métodos
        public async Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro)
        {
            RespostaApiDTO respostaApi = new();
            try
            {
                // if tenário utilizando a verificação do valor da variável e passado dois possíveis valores, um caso seja nulo e outro caso não seja. O "else".
                filtro = filtro == null ? new FiltroDTO() : filtro;

                // if tenário verificando se a variável "filtro" é nula, caso ela seja, eu passo a instância de um novo filtro.
                filtro ??= new FiltroDTO();

                // resumo dos if's tenários: O primeiro você usa um if else, podendo conferir o valor comparando com qualquer objeto. O segundo é apenas uma verificação de nulo.


                if (string.IsNullOrEmpty(filtro.Matricula)
                    && string.IsNullOrEmpty(filtro.Nome)
                    && string.IsNullOrEmpty(filtro.CPF))
                {
                    respostaApi.Sucesso = false;
                    respostaApi.Mensagem = "Por favor revise os dados da busca. Deve ser preenchido ao menos 1(um) dos filtros.";
                    return respostaApi;
                }
                respostaApi = await _estudanteRepository.BuscarEstudantes(filtro);
                if (respostaApi.ObjetoRetornado != null && !((List<Estudante>)respostaApi.ObjetoRetornado).Any())
                {
                    respostaApi.Sucesso = false;
                    respostaApi.Mensagem = "Não foi encontrado nenhum estudante.";
                    return respostaApi;
                }
                return respostaApi;
            }
            catch (Exception ex)
            {
                respostaApi.Mensagem = $@"Erro na busca de estudantes! Por favor, entre em contato com o setor de desenvolvimento. 
                                                  Descrição do erro: {ex.Message}";
                respostaApi.Sucesso = false;
                return respostaApi;
            }
        }
        #endregion
    }
}
