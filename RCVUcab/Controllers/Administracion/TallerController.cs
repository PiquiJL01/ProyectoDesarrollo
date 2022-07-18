﻿using System;
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
    public class TallerController : Controller
    {
        private readonly ITallerDAO _TallerDao;
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger, ITallerDAO TallerDao)
        {
            _TallerDao = TallerDao;
            _logger = logger;
        }

        [HttpGet]
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
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;
        }
    }
}

