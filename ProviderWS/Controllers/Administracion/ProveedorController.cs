using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Proveedores: "
                    , ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Proveedor para el: "
                  + id, ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Proveedores: "
                    , ex.Message, ex);
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
                throw new RCVException("Ha ocurrido un error al intentar modificar el Proveedor: "
                  , ex.Message, ex);
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
                throw new RCVException("Ha ocurrido un error al intentar eliminar el Proveedor para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

