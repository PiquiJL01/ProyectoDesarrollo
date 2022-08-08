using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class IncidenteController : Controller
    {
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IncidenteDTO PostIncidente([FromBody] IncidenteDTO IncidenteDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostIncidenteCommand(IncidenteDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Incidentes: "
                    , ex.Message, ex);
            }
        }

    }
}

