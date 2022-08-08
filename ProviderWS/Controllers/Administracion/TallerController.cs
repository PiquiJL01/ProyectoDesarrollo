using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

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
            catch (Exception)
            {
                throw;
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
            catch (RCVException ex)
            {
                throw ex;
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
            catch (RCVException ex)
            {
                throw ex;
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
            catch (RCVException ex)
            {
                throw ex;
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
            catch (RCVException ex)
            {
                throw ex;
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
            catch (RCVException ex)
            {
                throw ex;
            }
        }
    }
}

