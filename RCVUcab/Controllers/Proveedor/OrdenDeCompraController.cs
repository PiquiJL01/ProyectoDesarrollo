using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;


namespace RCVUcab.Controllers.Proveedor
{
    [ApiController]
    [Route("OrdenDeCompra/[controller]")]
    public class OrdenDeCompraController : Controller
    {
        private readonly IOrdenDeCompraDAO _OrdenDeCompraDao;
        private readonly ILogger<OrdenDeCompraController> _logger;

        public OrdenDeCompraController(ILogger<OrdenDeCompraController> logger, IOrdenDeCompraDAO OrdenDeCompraDao)
        {
            _OrdenDeCompraDao = OrdenDeCompraDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<OrdenDeCompraDTO>> GetOrdenesDeCompra()
        {
            var response = new ApplicationResponse<List<OrdenDeCompraDTO>>();
            try
            {
                response.Data = _OrdenDeCompraDao.Select();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpGet("{id}")]
        public ApplicationResponse<List<OrdenDeCompraDTO>> GetOrdenDeCompraById([FromRoute] string id)
        {
            var response = new ApplicationResponse<List<OrdenDeCompraDTO>>();
            try
            {
                response.Data = _OrdenDeCompraDao.GetOrdenesDeCompraByID(id);
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }

            return response;
        }

        [HttpPut]
        public ApplicationResponse<OrdenDeCompraDTO> PutOrdenDeCompra([FromBody] OrdenDeCompraDTO OrdenDeCompraDto)
        {
            var response = new ApplicationResponse<OrdenDeCompraDTO>()
            {
                Data = OrdenDeCompraDto
            };

            try
            {
                var list = _OrdenDeCompraDao.GetOrdenesDeCompraByID(OrdenDeCompraDto.ID);

                if (list.Exists(x => x.ID.Contains(OrdenDeCompraDto.ID)))
                {
                    _OrdenDeCompraDao.Update(OrdenDeCompraDto);

                    response.Message = "El OrdenDeCompra ha sido modificado exitosamente";
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
    }

}