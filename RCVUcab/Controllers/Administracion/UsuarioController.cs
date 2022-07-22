using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDAO _UsuarioDao;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioDAO UsuarioDao)
        {
            _UsuarioDao = UsuarioDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<UsuarioDTO>> GetUsuarios()
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _UsuarioDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<UsuarioDTO>> GetUsuarioById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _UsuarioDao.GetUsuariosByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<UsuarioDTO> PostUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            var response = new ApplicationResponse<UsuarioDTO>()
            {
                Data = UsuarioDto
            };

            try
            {
                _UsuarioDao.Insert(UsuarioDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }


        [HttpPut]
        public ApplicationResponse<UsuarioDTO> PutUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            var response = new ApplicationResponse<UsuarioDTO>()
            {
                Data = UsuarioDto
            };

            try
            {
                var list = _UsuarioDao.GetUsuariosByID(UsuarioDto.Id);

                if (list.Exists(x => x.Id.Contains(UsuarioDto.Id)))
                {
                    _UsuarioDao.Update(UsuarioDto);

                    response.Message = "El Usuario ha sido modificado exitosamente";
                }
                else
                {
                    response.Message = "No existe";
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ApplicationResponse<UsuarioDTO> DeleteUsuario([FromRoute] string id)
        {
            var response = new ApplicationResponse<UsuarioDTO>();

            try
            {
                response.Data = _UsuarioDao.Select(id);

                _UsuarioDao.Delete(response.Data);

                response.Message = "Usuario " + id + " ha sido eliminado exitosamente";
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}

