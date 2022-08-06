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
    public class VehiculoController : Controller
    {
        private readonly IVehiculoDAO _VehiculoDao;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(ILogger<VehiculoController> logger, IVehiculoDAO VehiculoDao)
        {
            _VehiculoDao = VehiculoDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<VehiculoDTO>> GetVehiculos()
        {
            var response = new ApplicationResponse<List<VehiculoDTO>>();
            try
            {
                response.Data = _VehiculoDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<VehiculoDTO>> GetVehiculoById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<VehiculoDTO>>();
            try
            {
                response.Data = _VehiculoDao.GetVehiculosByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPost]
        public ApplicationResponse<VehiculoDTO> PostVehiculo([FromBody] VehiculoDTO VehiculoDto)
        {
            var response = new ApplicationResponse<VehiculoDTO>()
            {
                Data = VehiculoDto
            };

            try
            {
                _VehiculoDao.Insert(VehiculoDto);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }


        [HttpPut]
        public ApplicationResponse<VehiculoDTO> PutVehiculo([FromBody] VehiculoDTO VehiculoDto)
        {
            var response = new ApplicationResponse<VehiculoDTO>()
            {
                Data = VehiculoDto
            };

            try
            {
                var list = _VehiculoDao.GetVehiculosByID(VehiculoDto.Placa);

                if (list.Exists(x => x.Placa.Contains(VehiculoDto.Placa)))
                {
                    _VehiculoDao.Update(VehiculoDto);

                    response.Message = "El Vehiculo ha sido modificado exitosamente";
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
        public ApplicationResponse<VehiculoDTO> DeleteVehiculo([FromRoute] string id)
        {
            var response = new ApplicationResponse<VehiculoDTO>();

            try
            {
                response.Data = _VehiculoDao.Select(id);

                _VehiculoDao.Delete(response.Data);

                response.Message = "Vehiculo " + id + " ha sido eliminado exitosamente";
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }
    }
}

