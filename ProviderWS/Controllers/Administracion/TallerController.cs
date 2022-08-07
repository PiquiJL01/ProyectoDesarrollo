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
                var command = CommandFactory.CreateGetTallerByIdCommand(taller);
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
                var command = CommandFactory.CreateGetTalleresCommand();
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
                //response.Data = _TallerDao.GetTalleresByBrand(marca);
                var command = CommandFactory.CreateGetTalleresByBrandCommand(marca);
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
                var command = CommandFactory.CreatePostTallerCommand(TallerDto);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw ex;
            }

        }

        /*[HttpGet("{id}")]
        public ApplicationResponse<List<TallerDTO>> GetTallerById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<TallerDTO>>();
            try
            {
                response.Data = _TallerDao.GetTalleresByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpGet("{marca}/TalleresByBrand")]
        public ApplicationResponse<List<ProveedorMarcaDTO>> GetTallerByBrand([FromRoute] string marca)
        {
            var response = new ApplicationResponse<List<ProveedorMarcaDTO>>();
            try
            {
                response.Data = _TallerDao.GetTalleresByBrand(marca);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<TallerDTO> PostTaller([FromBody] TallerDTO TallerDto)
        {
            var response = new ApplicationResponse<TallerDTO>()
            {
                Data = TallerDto
            };

            try
            {
                _TallerDao.Insert(TallerDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }


        [HttpPut]
        public ApplicationResponse<TallerDTO> PutTaller([FromBody] TallerDTO TallerDto)
        {
            var response = new ApplicationResponse<TallerDTO>()
            {
                Data = TallerDto
            };

            try
            {
                var list = _TallerDao.GetTalleresByID(TallerDto.ID);

                if (list.Exists(x => x.ID.Contains(TallerDto.ID)))
                {
                    _TallerDao.Update(TallerDto);

                    response.Message = "El taller ha sido modificado exitosamente";
                }
                else
                {
                    response.Message = "No existe";
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ApplicationResponse<TallerDTO> DeleteTaller([FromRoute] string id)
        {
            var response = new ApplicationResponse<TallerDTO>();

            try
            {
                response.Data = _TallerDao.Select(id);

                _TallerDao.Delete(response.Data);

                response.Message = "Taller " + id + " ha sido eliminado exitosamente";
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }*/
    }
}

