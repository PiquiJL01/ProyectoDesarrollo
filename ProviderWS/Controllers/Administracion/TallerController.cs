using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProviderWS.Exceptions;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTOs.DTOs;

namespace ProviderWS.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class TallerController : Controller
    {
        /*private readonly ITallerDAO _TallerDao;
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger, ITallerDAO TallerDao)
        {
            _TallerDao = TallerDao;
            _logger = logger;
        }*/

        [HttpGet("{taller}")]
        public TallerDTO GetTallerById([Required][FromRoute] string taller)
        {
            try
            {
                GetTallerByIdCommand command =
                  CommandFactory.createGetTallerByIdCommand(taller);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*[HttpGet]
        public ApplicationResponse<List<TallerDTO>> GetTalleres()
        {
            var response = new ApplicationResponse<List<TallerDTO>>();
            try
            {
                response.Data = _TallerDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
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

