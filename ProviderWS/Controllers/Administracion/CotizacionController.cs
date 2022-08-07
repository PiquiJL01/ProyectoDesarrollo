using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Administracion
{

    [ApiController]
    [Route("Administracion/[controller]")]
    public class CotizacionController : Controller
    {
        private readonly ICotizacionDAO _CotizacionDao;
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionDAO CotizacionDao)
        {
            _CotizacionDao = CotizacionDao;
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
        public List<CotizacionDTO> GetCotizacionesById([FromRoute] string id)
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
                throw;
            }
        }
    }
}

