using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Exceptions;

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
            catch (RCVException ex)
            {
                throw;
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
            catch (RCVException ex)
            {
                throw;
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
            catch (RCVException ex)
            {
                throw;
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
                throw;
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
            catch (RCVException ex)
            {
                throw ex;
            }
        }
    }
}
