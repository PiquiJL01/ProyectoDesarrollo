using System;
using System.Collections.Generic;
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
    public class AdministradorController : Controller
    {
        private readonly IAdministradorDAO _administradorDAO;
        private readonly ILogger<AdministradorController> _logger;

        public AdministradorController(ILogger<AdministradorController> logger, IAdministradorDAO administradorDAO)
        {
            _administradorDAO = administradorDAO;
            _logger = logger;
        }


        [HttpGet]
        public ApplicationResponse<List<UsuarioDTO>> GetAdministradores()
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _administradorDAO.GetAdministradores();
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

