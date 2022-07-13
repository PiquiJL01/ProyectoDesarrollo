using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class AdministradorController : Controller
    {
        private readonly IAdministradorDAO _administradorDAO;
        private readonly ILogger<AdministradorController> _logger;

        public AdministradorController(ILogger<AdministradorController> logger, IAdministradorDAO administradorDao)
        {
            _administradorDAO = administradorDao;
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
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }


        /*[HttpGet]
        public List<UsuarioDTO> GetAdministradores()
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
            return response.Data;
        }*/

        /*[HttpGet]
        public string GetAdministradoresDtos()
        {
            return "prueba";
        }*/
    }
}

