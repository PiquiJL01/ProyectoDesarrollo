using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class PolizaController : Controller
    {
        private readonly IPolizaDAO _polizaDao;
        private readonly ILogger<PolizaController> _logger;

        public PolizaController(ILogger<PolizaController> logger, IPolizaDAO polizaDao)
        {
            _polizaDao = polizaDao;
            _logger = logger;
        }

        [HttpGet]
        public List<PolizaDTO> GetPolizas()
        {
            try
            {
                var command = CommandFactory.CreateGetPolizasCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<PolizaDTO> GetPolizaById([FromRoute] string id)
        {
            try
            {
                var command = CommandFactory.CreateGetPolizaByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPost]
        public PolizaDTO PostPoliza([FromBody] PolizaDTO PolizaDto)
        {
            try
            {
                var command = CommandFactory.CreatePostPolizaCommand(PolizaDto);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPut]
        public PolizaDTO PutPoliza([FromBody] PolizaDTO PolizaDto)
        {
            try
            {
                var command = CommandFactory.CreatePutPolizaCommand(PolizaDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public PolizaDTO DeletePoliza([FromRoute] string id)
        {
            try
            {
                var command = CommandFactory.CreateDeletePolizaByIdCommand(id);
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

