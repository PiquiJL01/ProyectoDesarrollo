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
    public class CotizacionController : Controller
    {
        private readonly ICotizacionDAO _CotizacionDao;
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionDAO CotizacionDao)
        {
            _CotizacionDao = CotizacionDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<CotizacionDTO>> GetCotizaciones()
        {
            var response = new ApplicationResponse<List<CotizacionDTO>>();
            try
            {
                response.Data = _CotizacionDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<CotizacionDTO>> GetCotizacionesById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<CotizacionDTO>>();
            try
            {
                response.Data = _CotizacionDao.GetCotizacionesByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<CotizacionDTO> PutCotizacion([FromBody] CotizacionDTO CotizacionDto)
        {
            var response = new ApplicationResponse<CotizacionDTO>()
            {
                Data = CotizacionDto
            };

            try
            {
                var list = _CotizacionDao.GetCotizacionesByID(CotizacionDto.Id);

                if (list.Exists(x => x.Id.Contains(CotizacionDto.Id)))
                {
                    _CotizacionDao.Update(CotizacionDto);

                    response.Message = "El Cotizacion ha sido modificado exitosamente";
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
        public ApplicationResponse<CotizacionDTO> DeleteCotizacion([FromRoute] string id)
        {
            var response = new ApplicationResponse<CotizacionDTO>();

            try
            {
                response.Data = _CotizacionDao.Select(id);

                _CotizacionDao.Delete(response.Data);

                response.Message = "Cotizacion " + id + " ha sido eliminado exitosamente";
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}

