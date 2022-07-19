using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;

namespace RCVUcab.Controllers.Taller
{
    [ApiController]
    [Route("Taller/[controller]")]
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _IncidenteDao;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO IncidenteDao)
        {
            _IncidenteDao = IncidenteDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<IncidenteDTO>> GetIncidentes()
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _IncidenteDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<IncidenteDTO>> GetIncidenteById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _IncidenteDao.GetIncidenteByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<IncidenteDTO> PutIncidente([FromBody] IncidenteDTO IncidenteDto)
        {
            var response = new ApplicationResponse<IncidenteDTO>()
            {
                Data = IncidenteDto
            };

            try
            {
                var list = _IncidenteDao.GetIncidenteByID(IncidenteDto.ID);

                if (list.Exists(x => x.ID.Contains(IncidenteDto.ID)))
                {
                    _IncidenteDao.Update(IncidenteDto);

                    response.Message = "El Incidente ha sido modificado exitosamente";
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
}

