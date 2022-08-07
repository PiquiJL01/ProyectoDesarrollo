using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Perito
{
    [ApiController]
    [Route("Perito/[controller]")]
    public class IncidenteController : Controller
    {
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<IncidenteDTO> GetIncidentes()
        {
            try
            {
                var command = GetCommandFactory.CreateGetIncidentesCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<IncidenteDTO> GetIncidenteById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetIncidentesByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }


        [HttpPut]
        public IncidenteDTO PutIncidente([FromBody] IncidenteDTO IncidenteDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutIncidenteCommand(IncidenteDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}