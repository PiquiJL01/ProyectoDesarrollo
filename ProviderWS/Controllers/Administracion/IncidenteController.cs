using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Exceptions;

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

