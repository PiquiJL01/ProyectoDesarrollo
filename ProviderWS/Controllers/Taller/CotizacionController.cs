/*using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProviderWS.Exceptions;

namespace ProviderWS.Controllers.Taller
{
    [ApiController]
    [Route("Taller/[controller]")]
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
        public ApplicationResponse<List<CotizacionDTO>> GetCotizacionById([FromRoute] string id)
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

        [HttpPost]
        public ApplicationResponse<CotizacionDTO> PostCotizacion([FromBody] CotizacionDTO CotizacionDto)
        {
            var response = new ApplicationResponse<CotizacionDTO>()
            {
                Data = CotizacionDto
            };

            try
            {
                _CotizacionDao.Insert(CotizacionDto);
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
    }
}*/