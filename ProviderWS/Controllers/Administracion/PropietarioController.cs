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
        public ApplicationResponse<List<PropietarioDTO>> GetPropietarios()
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

        [HttpGet("{id}")]
        public ApplicationResponse<List<PropietarioDTO>> GetPropietarioById([FromRoute]string id)
        {
            var response = new ApplicationResponse<List<PropietarioDTO>>();
            try
            {
                response.Data = _propietarioDao.GetPropietarioByID(id);
            }
            catch (RCVException ex)
            {
                response.Error((ex));
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<PropietarioDTO> PostPropietario([FromBody] PropietarioDTO propietarioDto)
        {
            var response = new ApplicationResponse<PropietarioDTO>()
            {
                Data = propietarioDto
            };

            try
            {
                _propietarioDao.Insert(propietarioDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<PropietarioDTO> PutPropietario([FromBody]PropietarioDTO propietarioDto)
        {
            var response = new ApplicationResponse<PropietarioDTO>()
            {
                Data = propietarioDto
            };

            try
            {
                var list = _propietarioDao.GetPropietarioByID(propietarioDto.CedulaRif);

                if (list.Exists(x => x.CedulaRif.Contains(propietarioDto.CedulaRif)))
                {
                    _propietarioDao.Update(propietarioDto);

                    response.Message = "El Propietario ha sido modificado exitosamente";
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

        [HttpDelete("{id}")]
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
