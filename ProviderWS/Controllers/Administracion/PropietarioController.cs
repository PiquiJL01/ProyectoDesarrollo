using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class PropietarioController : Controller
    {
        private readonly ILogger<PropietarioController> _logger;

        public PropietarioController(ILogger<PropietarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<PropietarioDTO> GetPropietarios()
        {
            try
            {
                var command = GetCommandFactory.CreateGetPropietarosCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Propietarios: "
                    , ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public List<PropietarioDTO> GetPropietariosById([FromRoute]string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetPropietariosByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Propietario para el: "
                  + id, ex.Message, ex);
            }
        }

        [HttpPost]
        public PropietarioDTO PostPropietario([FromBody] PropietarioDTO propietarioDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostPropietarioCommand(propietarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Propietarios: "
                    , ex.Message, ex);
            }
        }

        [HttpPut]
        public PropietarioDTO PutPropietario([FromBody]PropietarioDTO propietarioDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutPropietarioCommand(propietarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar modificar el Propietario: "
                  , ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public PropietarioDTO DeletePropietario([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeletePropietarioByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar el Propietario para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}
