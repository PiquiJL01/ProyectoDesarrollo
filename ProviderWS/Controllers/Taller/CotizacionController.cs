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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Cotizaciones: "
                    , ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Cotizacion para el: "
                  + id, ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Cotizaciones: "
                    , ex.Message, ex);
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
                throw new RCVException("Ha ocurrido un error al intentar modificar la Cotizacion: "
                  , ex.Message, ex);
            }
        }
    }
}