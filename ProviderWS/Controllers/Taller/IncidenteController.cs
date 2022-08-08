using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Taller
{
    [ApiController]
    [Route("Taller/[controller]")]
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Incidentes: "
                    , ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Incidente para el: "
                  + id, ex.Message, ex);
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
                throw new RCVException("Ha ocurrido un error al intentar modificar el Incidente: "
                  , ex.Message, ex);
            }
        }
    }
}