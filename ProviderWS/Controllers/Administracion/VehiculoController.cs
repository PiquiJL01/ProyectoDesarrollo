using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

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
            catch (RCVException ex)
            {
                throw;
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
            catch (RCVException ex)
            {
                throw;
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
            catch (RCVException ex)
            {
                throw;
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
                throw;
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
                throw;
            }
        }
    }
}

