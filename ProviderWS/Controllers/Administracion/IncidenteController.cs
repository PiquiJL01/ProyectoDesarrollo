using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

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
            catch (RCVException ex)
            {
                throw;
            }
        }

    }
}

