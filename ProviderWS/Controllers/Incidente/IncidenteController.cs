using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar los incidentes para el administrador: "
                  + administrador, ex.Message, ex);
            }
        }


    }
}