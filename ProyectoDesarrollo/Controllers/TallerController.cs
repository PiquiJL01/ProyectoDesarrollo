using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Responses;

namespace ProyectoDesarrollo.Controllers
{
    /*[Route("[controller]")]
    [ApiController]
    public class TallerController : Controller
    {
        private readonly ITallerDAO _TallerDAO;
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger, ITallerDAO TallerDAO)
        {
            _TallerDAO = TallerDAO;
            _logger = logger;
        }


        [HttpGet]
        public ApplicationResponse<List<TallerDTO>> GetTalleres()
        {
            var response = new ApplicationResponse<List<TallerDTO>>();
            try
            {
                response.Data = _TallerDAO.Select();
            }
            catch (ProyectoException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }


    }*/
}

