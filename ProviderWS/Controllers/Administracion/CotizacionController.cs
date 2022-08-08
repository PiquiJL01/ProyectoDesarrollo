using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{

    [ApiController]
    [Route("Administracion/[controller]")]
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
        public List<CotizacionDTO> GetCotizacionesById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetCotizacionesByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la Cotizacion para el: "
                  + id, ex.Message, ex);
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

        [HttpDelete("{id}")]
        public CotizacionDTO DeleteCotizacion([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeleteCotizacionByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar la Cotizacion para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

