using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Responses;

namespace ProyectoDesarrollo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CotizacionController : Controller
    {
        private readonly ICotizacionDAO _cotizacionDAO;
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionDAO administradorDAO)
        {
            _cotizacionDAO = administradorDAO;
            _logger = logger;
        }


        [HttpGet("cotizaciones/{incidente}")]
        public ApplicationResponse<List<IncidenteDTO>> GetCotizacionesByIncidente([Required][FromRoute] string incidente)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _cotizacionDAO.GetCotizacionesByIncidente(incidente);
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

