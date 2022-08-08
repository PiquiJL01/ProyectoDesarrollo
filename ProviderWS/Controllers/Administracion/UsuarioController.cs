using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{

    [ApiController]
    [Route("Administracion/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<UsuarioDTO> GetUsuarios()
        {
            try
            {
                var command = GetCommandFactory.CreateGetUsuariosCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Usuarios: "
                    , ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public List<UsuarioDTO> GetUsuarioById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetUsuariosByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Usuario para el: "
                  + id, ex.Message, ex);
            }
        }

        [HttpPost]
        public UsuarioDTO PostUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            try
            {
                var command = PostCommandFactory.CretaePostUsuarioCommand(UsuarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Usuarios: "
                    , ex.Message, ex);
            }
        }


        [HttpPut]
        public UsuarioDTO PutUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutUsuarioCommand(UsuarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar modificar el Usuario: "
                  , ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public UsuarioDTO DeleteUsuario([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeleteUsuarioByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar el Usuario para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

