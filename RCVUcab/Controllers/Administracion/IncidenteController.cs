using System;
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
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _IncidenteDao;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO IncidenteDao)
        {
            _IncidenteDao = IncidenteDao;
            _logger = logger;
        }

        [HttpPost]
        public ApplicationResponse<IncidenteDTO> PostIncidente([FromBody] IncidenteDTO IncidenteDto)
        {
            var response = new ApplicationResponse<IncidenteDTO>()
            {
                Data = IncidenteDto
            };

            try
            {
                _IncidenteDao.Insert(IncidenteDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

    }
}

