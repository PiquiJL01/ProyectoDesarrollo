using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Incidente
{
    [ApiController]
    [Route("Incidente/[controller]")]
    public class IncidenteController : Controller
    {
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<IncidenteDTO> GetIncidentesByAdministrador(string administrador)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetIncidenteByAdministradorCommand(administrador);
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