using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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
    public class PropietarioController : Controller
    {
        private readonly IPropietarioDAO _propietarioDao;
        private readonly ILogger<PropietarioController> _logger;

        public PropietarioController(ILogger<PropietarioController> logger, IPropietarioDAO propietarioDao)
        {
            _propietarioDao = propietarioDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<PropietarioDTO>> GetAdministradores()
        {
            var response = new ApplicationResponse<List<PropietarioDTO>>();
            try
            {
                response.Data = _propietarioDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("id")]
        public ApplicationResponse<PropietarioDTO> GetPropietarioById([FromRoute]string id)
        {
            var response = new ApplicationResponse<PropietarioDTO>();
            try
            {
                response.Data = _propietarioDao.Select(id);
            }
            catch (Exception ex)
            {
                response.Error((ex));
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<PropietarioDTO> PostAdministrador([FromBody] PropietarioDTO propietarioDto)
        {
            var response = new ApplicationResponse<PropietarioDTO>()
            {
                Data = propietarioDto
            };

            try
            {
                _propietarioDao.Insert(propietarioDto);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<PropietarioDTO> PutAdministrador([FromBody]PropietarioDTO propietarioDto)
        {
            var response = new ApplicationResponse<PropietarioDTO>()
            {
                Data = propietarioDto
            };

            try
            {
                if (_propietarioDao.Select(propietarioDto.CedulaRif) != null)
                {
                    _propietarioDao.Update(propietarioDto);
                }
                else
                {
                    response.Error(new Exception("No existe"));
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpDelete("id")]
        public ApplicationResponse<PropietarioDTO> DeletePropietario([FromRoute] string id)
        {
            var response = new ApplicationResponse<PropietarioDTO>();

            try
            {
                response.Data = _propietarioDao.Select(id);

                _propietarioDao.Delete(response.Data);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}
