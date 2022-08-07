/*using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Perito
{
    [ApiController]
    [Route("Perito")]
    public class PeritoController : Controller
    {
        private readonly IUsuarioDAO _PeritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IUsuarioDAO PeritoDAO)
        {
            _PeritoDAO = PeritoDAO;
            _logger = logger;
        }


        [HttpGet("Perito")]
        public ApplicationResponse<List<UsuarioDTO>> GetPeritos()
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _PeritoDAO.GetPeritos();
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
}*/