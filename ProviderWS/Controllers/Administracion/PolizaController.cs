using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class PolizaController : Controller
    {
        private readonly ILogger<PolizaController> _logger;

        public PolizaController(ILogger<PolizaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<PolizaDTO> GetPolizas()
        {
            try
            {
                var command = GetCommandFactory.CreateGetPolizasCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Polizas: "
                    , ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public List<PolizaDTO> GetPolizaById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetPolizaByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la Poliza para el: "
                  + id, ex.Message, ex);
            }
        }

        [HttpPost]
        public PolizaDTO PostPoliza([FromBody] PolizaDTO PolizaDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostPolizaCommand(PolizaDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Polizas: "
                    , ex.Message, ex);
            }
        }

        [HttpPut]
        public PolizaDTO PutPoliza([FromBody] PolizaDTO PolizaDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutPolizaCommand(PolizaDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar modificar la Poliza: "
                  , ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public PolizaDTO DeletePoliza([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeletePolizaByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar la Poliza para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

