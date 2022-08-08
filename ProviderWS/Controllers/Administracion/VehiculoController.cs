using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(ILogger<VehiculoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<VehiculoDTO> GetVehiculos()
        {
            try
            {
                var command = GetCommandFactory.CreateGetVehiculosCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de los Vehiculos: "
                    , ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public List<VehiculoDTO> GetVehiculoById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetVehiculosByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Vehiculo para el: "
                  + id, ex.Message, ex);
            }
        }

        [HttpPost]
        public VehiculoDTO PostVehiculo([FromBody] VehiculoDTO VehiculoDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostVehiculoCommand(VehiculoDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de los Vehiculos: "
                    , ex.Message, ex);
            }
        }


        [HttpPut]
        public VehiculoDTO PutVehiculo([FromBody] VehiculoDTO VehiculoDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutVehiculoCommand(VehiculoDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar modificar el Vehiculo: "
                  , ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public VehiculoDTO DeleteVehiculo([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeleteVehiculoByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar el Vehiculo para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

