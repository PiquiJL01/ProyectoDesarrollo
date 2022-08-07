using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class ProveedorController : Controller
    {
        private readonly ILogger<ProveedorController> _logger;


        public ProveedorController(ILogger<ProveedorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ProveedorDTO> GetProveedores()
        {
            try
            {
                var command = GetCommandFactory.CreateGetProveedoresCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<ProveedorDTO> GetProveedorById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetProveedoresById(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ProveedorDTO PostProveedor([FromBody] ProveedorDTO ProveedorDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostProveedorCommand(ProveedorDto);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }


        [HttpPut]
        public ProveedorDTO PutProveedor([FromBody] ProveedorDTO ProveedorDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutProveedorCommand(ProveedorDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ProveedorDTO DeleteProveedor([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeleteProveedorByIdCommand(id);
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

