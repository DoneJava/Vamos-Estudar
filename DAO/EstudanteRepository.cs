using Microsoft.EntityFrameworkCore;
using VamosEstudar.DAO.Interfaces;
using VamosEstudar.Data;
using VamosEstudar.Models;
using VamosEstudar.Models.DTO;

namespace VamosEstudar.DAO
{
    public class EstudanteRepository : IEstudanteRepository
    {
        #region Atributos / Propriedades
        private VamosEstudarContext _contexto;
        #endregion

        #region Construtor
        public EstudanteRepository(VamosEstudarContext contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region Métodos
        public async Task<RespostaApiDTO> BuscarEstudantes(FiltroDTO filtro)
        {
            RespostaApiDTO respostaApi = new();
            try
            {
                List<Estudante> estudantes = new();
                Estudante? estudante = new(); // O símbolo de interrogação logo após a classe "Estudante" significa que essa varíável aceita valor null


                /* Utilizando o método "Where" para realizar filtros simultaneos, por cpf, nome e matrícula! 
                 * OBS: o método ToListAsync no final faz com que o retorno da query seja uma lista, é um cast, já que a variável que está recebendo
                 * o valor da query é uma lista de estudantes! */
                estudantes = await _contexto.Estudante
                    .Where(x => x.Cpf == filtro.CPF
                    || x.Nome == filtro.Nome
                    || x.Matricula == filtro.Matricula).ToListAsync();


                /* O método "FirstOrDefault" é bem intuitivo pelo nome, mas ele busca o primeiro objeto que atenda ao filtro
                 que impomos dentro dele utilizando lambda, da mesma forma que fizemos com o "Where". Caso ele não 
                encontre nenhum valor, ele trará o valor default - nulo */
                estudante = await _contexto.Estudante.FirstOrDefaultAsync(x => x.Cpf == filtro.CPF
                    || x.Nome == filtro.Nome
                    || x.Matricula == filtro.Matricula);


                /* Nesse caso, usamos apenas o "Single". qual a diferença para o "FirstOrDefault"? 
                 É bem simples! Caso ele busque um objeto e encontro mais de um, ele irá gerar uma exceção!
                Então sempre use esse método, quando nas suas regras de negócio, após aplicar os filtros necessários,
                o resultado obrigatoriamente tenha que ser 1(um) objeto! Ele também irá geraer uma exceção
                caso não encontre nenhum objeto que atenda os filtros! */
                estudante = await _contexto.Estudante.SingleAsync(x => x.Cpf == filtro.CPF
                    || x.Nome == filtro.Nome
                    || x.Matricula == filtro.Matricula);


                /* Temos também o muito conhecido pra quem usa SQL, "Count", nada mais é um método que retorna a quantidade total
                 de objetos que existem no banco que passam pelo filtro que você impor. Podendo também não por filtro algum! */
                int totalCandidatos = await _contexto.Estudante.CountAsync(x => x.Cpf == filtro.CPF
                    || x.Nome == filtro.Nome
                    || x.Matricula == filtro.Matricula);



                /*Aqui nós utilizamos um recurso do Entity FrameWork que nos permite reproduzir querys com strings
                 e ele irá executar exatamente como ocorre no banco de dados!
                É necessário sempre passar no "diamante" o tipo de retorno da sua query! */               
                estudantes = await _contexto.Database.SqlQuery<Estudante>($@"   SELECT * 
                                                                                FROM Estudante 
                                                                                Where Cpf = {filtro.CPF}
                                                                                    AND Nome = {filtro.Nome}
                                                                                    AND Matricula = {filtro.Matricula}").ToListAsync();
                                 


                /* Galera, o Linq disponibiliza muitos métodos extremamente úteis! Esses foram só alguns deles, 
                 * mas tem muitos métodos úteis! Dêem uma olhada com calma.
                 Então dêem uma olhada com calma, tenho certeza que vai ser muito bom! */


                // Este abaixo é o if tenário verificando se a variável "estudante é null, e caso for, passo como valor para ela
                // uma nova instância de estudante!
                estudantes ??= new List<Estudante>();

                respostaApi.Sucesso = true;
                respostaApi.Mensagem = "Busca feita com sucesso";
                respostaApi.ObjetoRetornado = estudantes;
                return respostaApi;
            }
            catch (Exception ex)
            {
                respostaApi.Sucesso = false;
                respostaApi.Mensagem = $@"Erro ao efetuar busca, por favor entre em contato
                                          com o setor de desenvolvimento. {ex.Message}";
                respostaApi.ObjetoRetornado = new List<Estudante>();
                return respostaApi;
            }
        }
        #endregion
    }
}
