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
    public class PolizaController : Controller
    {
        private readonly IPolizaDAO _polizaDao;
        private readonly ILogger<PolizaController> _logger;

        public PolizaController(ILogger<PolizaController> logger, IPolizaDAO polizaDao)
        {
            _polizaDao = polizaDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<PolizaDTO>> GetPolizas()
        {
            var response = new ApplicationResponse<List<PolizaDTO>>();
            try
            {
                response.Data = _polizaDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<PolizaDTO>> GetPolizaById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<PolizaDTO>>();
            try
            {
                response.Data = _polizaDao.GetPolizasByID(id);
            }
            catch (RCVException ex)
            {
                response.Error((ex));
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<PolizaDTO> PostPoliza([FromBody] PolizaDTO PolizaDto)
        {
            var response = new ApplicationResponse<PolizaDTO>()
            {
                Data = PolizaDto
            };

            try
            {
                _polizaDao.Insert(PolizaDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<PolizaDTO> PutPoliza([FromBody] PolizaDTO PolizaDto)
        {
            var response = new ApplicationResponse<PolizaDTO>()
            {
                Data = PolizaDto
            };

            try
            {
                var list = _polizaDao.GetPolizasByID(PolizaDto.ID);

                if (list.Exists(x => x.ID.Contains(PolizaDto.ID)))
                {
                    _polizaDao.Update(PolizaDto);

                    response.Message = "El Poliza ha sido modificado exitosamente";
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
        public ApplicationResponse<PolizaDTO> DeletePoliza([FromRoute] string id)
        {
            var response = new ApplicationResponse<PolizaDTO>();

            try
            {
                response.Data = _polizaDao.Select(id);

                _polizaDao.Delete(response.Data);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}

