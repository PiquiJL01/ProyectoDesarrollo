using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using ProviderWS.Exceptions;

namespace RCVUcab.Controllers.Perito
{
    [ApiController]
    [Route("Perito/[controller]")]
    public class PeritoController : Controller
    {
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<UsuarioDTO> GetPeritos()
        {
            try
            {
                var command = GetCommandFactory.CreateGetPeritosCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Peritos: "
                    , ex.Message, ex);
            }
        }


    }
}