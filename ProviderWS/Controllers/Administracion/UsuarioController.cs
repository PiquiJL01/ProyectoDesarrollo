using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

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
                var command = CommandFactory.CreateGetUsuariosCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<UsuarioDTO> GetUsuarioById([FromRoute] string id)
        {
            try
            {
                var command = CommandFactory.CreateGetUsuariosByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPost]
        public UsuarioDTO PostUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            try
            {
                var command = CommandFactory.CretaePostUsuarioCommand(UsuarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }


        [HttpPut]
        public UsuarioDTO PutUsuario([FromBody] UsuarioDTO UsuarioDto)
        {
            try
            {
                var command = CommandFactory.CreatePutUsuarioCommand(UsuarioDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public UsuarioDTO DeleteUsuario([FromRoute] string id)
        {
            try
            {
                var command = CommandFactory.CreateDeleteUsuarioByIdCommand(id);
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

