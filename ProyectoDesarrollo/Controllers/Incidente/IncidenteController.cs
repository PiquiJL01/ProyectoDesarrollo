using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Responses;

namespace ProyectoDesarrollo.Controllers.Incidente
{
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _IncidenteDAO;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO IncidenteDAO)
        {
            _IncidenteDAO = IncidenteDAO;
            _logger = logger;
        }


        [HttpGet("Incidentes")]
        public ApplicationResponse<List<AdministradorDTO>> GetIncidentesByAdministrador(string administrador)
        {
            var response = new ApplicationResponse<List<AdministradorDTO>>();
            try
            {
                response.Data = _IncidenteDAO.GetIncidentesByAdministrador(administrador);
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

