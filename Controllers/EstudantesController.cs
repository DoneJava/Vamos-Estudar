using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VamosEstudar.BLL;
using VamosEstudar.BLL.Interfaces;
using VamosEstudar.Data;
using VamosEstudar.Models;
using VamosEstudar.Models.DTO;

namespace VamosEstudar.Controllers
{
    public class EstudantesController : ControllerBase
    {
        #region Atributos / Propriedades
        private IFacade _facade;
        #endregion

        #region Construtores
        public EstudantesController(IFacade facade)
        {
            _facade = facade;
        }
        #endregion

        #region Métodos Get
        [HttpGet("BuscarEstudantes")]
        public async Task<IActionResult> BuscarEstudantes(FiltroDTO filtro)
        {
            try
            {
                RespostaApiDTO respostaApi = new();
                respostaApi = await _facade.BuscarEstudantes(filtro);
                if (respostaApi.ObjetoRetornado == null)
                {
                    return NotFound(respostaApi);
                }
                return Ok(respostaApi);
            }
            catch
            {
                return StatusCode(500, new
                {
                    Mensagem = "Erro de sistema, entre em contato com o setor de desenvolvimento.",
                    Sucesso = false
                });
            }
        }
        #endregion

        #region Métodos Put

        #endregion

        #region Métodos Post

        #endregion

        #region Métodos Delete

        #endregion
    }
}
