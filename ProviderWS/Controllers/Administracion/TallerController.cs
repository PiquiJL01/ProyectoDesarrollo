using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace ProviderWS.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class TallerController : Controller
    {
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{taller}")]
        public TallerDTO GetTallerById([Required][FromRoute] string taller)
        {
            try
            {
                var command = GetCommandFactory.CreateGetTallerByIdCommand(taller);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + taller, ex.Message, ex);
            }
        }

        [HttpGet]
        public List<TallerDTO> GetTalleres()
        {
            try
            {
                var command = GetCommandFactory.CreateGetTalleresCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        [HttpGet("TalleresByBrand/{marca}")]
        public List<ProveedorMarcaDTO> GetTallerByBrand([FromRoute] string marca)
        {
            try
            {
                var command = GetCommandFactory.CreateGetTalleresByBrandCommand(marca);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para la: "
                  + marca, ex.Message, ex);
            }
        }

        [HttpPost]
        public TallerDTO PostTaller([FromBody] TallerDTO TallerDto)
        {
            try
            {
                var command = PostCommandFactory.CreatePostTallerCommand(TallerDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar agregar a la lista de Talleres: "
                    , ex.Message, ex);
            }

        }

        [HttpPut]
        public TallerDTO PutTaller([FromBody] TallerDTO tallerDto)
        {

            try
            {
                var command = PutCommandFactory.CreatePutTallerCommand(tallerDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar modificar el Taller: "
                  , ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public TallerDTO DeleteTaller([FromRoute] string id)
        {
            try
            {
                var command = DeleteByCommandFactory.CreateDeleteTallerByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar eliminar el Taller para el: "
                  + id, ex.Message, ex);
            }
        }
    }
}

