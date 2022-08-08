using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace ProviderWS.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class AdministradorController : Controller
    {
        private readonly ILogger<AdministradorController> _logger;

        public AdministradorController(ILogger<AdministradorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<UsuarioDTO> GetAdministradores()
        {
            try
            {
                var command = GetCommandFactory.CreateGetAdministradoresCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Administradores: "
                    , ex.Message, ex);
            }
        }
    }
}

