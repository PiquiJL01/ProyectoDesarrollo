using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Responses;

namespace ProyectoDesarrollo.Controllers.Perito
{
    public class PeritoController : Controller
    {
        private readonly IPeritoDAO _PeritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IPeritoDAO PeritoDAO)
        {
            _PeritoDAO = PeritoDAO;
            _logger = logger;
        }


        [HttpGet("Perito")]
        public ApplicationResponse<List<UsuarioDTO>> GetPeritos()
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _PeritoDAO.GetPeritos();
            }
            catch (ProyectoException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }


    }
}

