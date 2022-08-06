using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;

namespace RCVUcab.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class ProveedorController : Controller
    {

        private readonly IProveedorDAO _ProveedorDao;
        private readonly ILogger<ProveedorController> _logger;


        public ProveedorController(ILogger<ProveedorController> logger, IProveedorDAO ProveedorDao)
        {
            _ProveedorDao = ProveedorDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<ProveedorDTO>> GetProveedores()
        {
            var response = new ApplicationResponse<List<ProveedorDTO>>();
            try
            {
                response.Data = _ProveedorDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<ProveedorDTO>> GetProveedorById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<ProveedorDTO>>();
            try
            {
                response.Data = _ProveedorDao.GetProveedoresByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<ProveedorDTO> PostProveedor([FromBody] ProveedorDTO ProveedorDto)
        {
            var response = new ApplicationResponse<ProveedorDTO>()
            {
                Data = ProveedorDto
            };

            try
            {
                _ProveedorDao.Insert(ProveedorDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }


        [HttpPut]
        public ApplicationResponse<ProveedorDTO> PutProveedor([FromBody] ProveedorDTO ProveedorDto)
        {
            var response = new ApplicationResponse<ProveedorDTO>()
            {
                Data = ProveedorDto
            };

            try
            {
                var list = _ProveedorDao.GetProveedoresByID(ProveedorDto.Id_Proveedor);

                if (list.Exists(x => x.Id_Proveedor.Contains(ProveedorDto.Id_Proveedor)))
                {
                    _ProveedorDao.Update(ProveedorDto);

                    response.Message = "El Proveedor ha sido modificado exitosamente";
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
        public ApplicationResponse<ProveedorDTO> DeleteProveedor([FromRoute] string id)
        {
            var response = new ApplicationResponse<ProveedorDTO>();

            try
            {
                response.Data = _ProveedorDao.Select(id);

                _ProveedorDao.Delete(response.Data);

                response.Message = "Proveedor " + id + " ha sido eliminado exitosamente";
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}

