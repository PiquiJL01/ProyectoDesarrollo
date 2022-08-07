using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace ProviderWS.Controllers.Taller
{
    [ApiController]
    [Route("Taller/[controller]")]
    public class CotizacionController : Controller
    {
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CotizacionDTO> GetCotizaciones()
        {
            try
            {
                var command = GetCommandFactory.CreateGetCotizacionesCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<CotizacionDTO> GetCotizacionById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetCotizacionesByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPost]
        public CotizacionDTO PostCotizacion([FromBody] CotizacionDTO CotizacionDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostCotizacionCommand(CotizacionDto);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }


        [HttpPut]
        public CotizacionDTO PutCotizacion([FromBody] CotizacionDTO CotizacionDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutCotizacionCommand(CotizacionDto);
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